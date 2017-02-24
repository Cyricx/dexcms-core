using DexCMS.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DexCMS.Core.Globals
{
    public class DexCMSModelMapper<M>
    {
        public static M MapForServer(object viewModel, M model)
        {
            Type modelType = model.GetType();

            PropertyInfo[] viewProperties = (viewModel.GetType()).GetProperties();
            PropertyInfo[] modelProperties = modelType.GetProperties(BindingFlags.Public);

            foreach (PropertyInfo prop in viewProperties)
            {
                OverrideMappingTypeAttribute attr = (OverrideMappingTypeAttribute)prop.GetCustomAttribute(typeof(OverrideMappingTypeAttribute));

                if (attr == null || attr.MappingType == MappingType.ServerAndClient)
                {
                    PropertyInfo modelProp = modelType.GetProperty(prop.Name);
                    modelProp.SetValue(model, prop.GetValue(viewModel));
                }

            }

            return model;
        }

        public static List<T> MapForClient<T>(IEnumerable<M> models)
        {
            var items = new List<T>();
            foreach (var model in models)
            {
                items.Add(MapForClient<T>(model));
            }
            return items;
        }

        public static T MapForClient<T>(object model)
        {
            var viewModel = (T)Activator.CreateInstance(typeof(T));

            Type modelType = model.GetType();
            Type viewModelType = viewModel.GetType();
            PropertyInfo[] modelProperties = modelType.GetProperties();
            string[] viewProperties = viewModelType.GetProperties().Select(x => x.Name).ToArray();

            foreach (string propName in viewProperties)
            {
                PropertyInfo propertyInfo = viewModel.GetType().GetProperty(propName);

                OverrideMappingTypeAttribute overrideAttr = (OverrideMappingTypeAttribute)propertyInfo.GetCustomAttribute(typeof(OverrideMappingTypeAttribute));

                if (overrideAttr == null || overrideAttr.MappingType != MappingType.NoMappings)
                {
                    //check if a nested map clas
                    NestedClassMappingAttribute classAttr = (NestedClassMappingAttribute)propertyInfo.GetCustomAttribute(typeof(NestedClassMappingAttribute));

                    if (classAttr != null)
                    {
                        if (classAttr.IsList)
                        {
                            var listType = typeof(List<>);
                            MethodInfo addMethod = listType.GetMethod("Add");
                            var listValues = Activator.CreateInstance(listType.MakeGenericType(classAttr.MapType));
                            PropertyInfo modelProp = modelProperties.Where(x => x.Name == propName).FirstOrDefault();
                            var modelValue = (IEnumerable<object>)modelProp.GetValue(model);

                            foreach (var item in modelValue)
                            {
                                addMethod.Invoke(listValues, new object[] {
                                    CallMapForClient(model, modelProperties, propName, classAttr.MapType)
                                });
                            }
                            propertyInfo.SetValue(viewModel, listValues, null);
                        }
                        else
                        {
                            object modelValue = CallMapForClient(model, modelProperties, propName, classAttr.MapType);
                            propertyInfo.SetValue(viewModel, modelValue, null);
                        }
                    }
                    else
                    {
                        //else do this stuff
                        NestedPropertyMappingAttribute attr = (NestedPropertyMappingAttribute)propertyInfo.GetCustomAttribute(typeof(NestedPropertyMappingAttribute));

                        if (attr == null)
                        {
                            PropertyInfo modelProp = modelProperties.Where(x => x.Name == propName).FirstOrDefault();
                            propertyInfo.SetValue(viewModel, modelProp.GetValue(model), null);
                        }
                        else
                        {
                            PropertyInfo baseProp = modelProperties.Where(x => x.Name == attr.BaseProperty).FirstOrDefault();
                            object baseValue = baseProp.GetValue(model);
                            object childValue = baseValue.GetType().GetProperty(attr.ChildProperty).GetValue(baseValue);
                            propertyInfo.SetValue(viewModel, childValue, null);
                        }
                    }
                }
            }
            return viewModel;
        }

        private static object CallMapForClient(object model, PropertyInfo[] modelProperties, string propName, Type mapType)
        {
            MethodInfo mapMethod = mapType.GetMethod("MapForClient", BindingFlags.Public | BindingFlags.Static);
            PropertyInfo modelProp = modelProperties.Where(x => x.Name == propName).FirstOrDefault();
            object modelValue = mapMethod.Invoke(null, new object[] { modelProp.GetValue(model) });
            return modelValue;
        }
    }
}
