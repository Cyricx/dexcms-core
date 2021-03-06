﻿using DexCMS.Core.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DexCMS.Core.Initializers.Helpers
{
    public class SettingGroupsReference
    {
        public int Main { get; set; }
        public int Images { get; set; }
        public int Social { get; set; }

        public SettingGroupsReference(IDexCMSCoreContext Context)
        {
            Main = Context.SettingGroups.Where(x => x.SettingGroupName == "Main").Select(x => x.SettingGroupID).SingleOrDefault();
            Images = Context.SettingGroups.Where(x => x.SettingGroupName == "Images").Select(x => x.SettingGroupID).SingleOrDefault();
            Social = Context.SettingGroups.Where(x => x.SettingGroupName == "Social").Select(x => x.SettingGroupID).SingleOrDefault();
        }
    }
}
