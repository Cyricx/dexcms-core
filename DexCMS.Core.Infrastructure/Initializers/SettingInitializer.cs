using DexCMS.Core.Infrastructure.Contexts;
using DexCMS.Core.Infrastructure.Models;
using System.Linq;
using DexCMS.Core.Infrastructure.Extensions;
using DexCMS.Core.Infrastructure.Globals;

namespace DexCMS.Core.Infrastructure.Initializers
{
    class SettingInitializer : DexCMSInitializer<IDexCMSCoreContext>
    {
        public SettingInitializer(IDexCMSCoreContext context) : base(context)
        {
        }

        public override void Run()
        {
            int Text = Context.SettingDataTypes.Where(x => x.Name == "Text").Select(x => x.SettingDataTypeID).Single();
            int Date = Context.SettingDataTypes.Where(x => x.Name == "Date").Select(x => x.SettingDataTypeID).Single();
            int Bool = Context.SettingDataTypes.Where(x => x.Name == "Bool").Select(x => x.SettingDataTypeID).Single();
            int Html = Context.SettingDataTypes.Where(x => x.Name == "Html").Select(x => x.SettingDataTypeID).Single();
            int Int = Context.SettingDataTypes.Where(x => x.Name == "Int").Select(x => x.SettingDataTypeID).Single();
            int Multiline = Context.SettingDataTypes.Where(x => x.Name == "Multiline").Select(x => x.SettingDataTypeID).Single();
            int FourDigitWhole = Context.SettingDataTypes.Where(x => x.Name == "FourDigitWhole").Select(x => x.SettingDataTypeID).Single();
            int Email = Context.SettingDataTypes.Where(x => x.Name == "Email").Select(x => x.SettingDataTypeID).Single();
            int Password = Context.SettingDataTypes.Where(x => x.Name == "Password").Select(x => x.SettingDataTypeID).Single();

            int Main = Context.SettingGroups.Where(x => x.SettingGroupName == "Main").Select(x => x.SettingGroupID).Single();
            int Images = Context.SettingGroups.Where(x => x.SettingGroupName == "Images").Select(x => x.SettingGroupID).Single();
            int Url = Context.SettingGroups.Where(x => x.SettingGroupName == "Url").Select(x => x.SettingGroupID).Single();

            Context.Settings.AddIfNotExists(x => x.Name,
                new Setting { Name = "SiteTitle", Value = "Your Website", SettingDataTypeID = Text, SettingGroupID = Main },
                new Setting { Name = "TagLine", Value = "tag", SettingDataTypeID = Multiline, SettingGroupID = Main },
                new Setting { Name = "SmtpServer", Value = "yoursite.com", SettingDataTypeID = Text, SettingGroupID = Main },
                new Setting { Name = "ContactFromEmail", Value = "no-reply@yoursite.cmo", SettingDataTypeID = Email, SettingGroupID = Main },
                new Setting { Name = "ContactFromPassword", Value = "abc123", SettingDataTypeID = Password, SettingGroupID = Main },
                new Setting { Name = "ContactTo", Value = "contact@chrisbyram.com,you@yoursite.com", SettingDataTypeID = Multiline, SettingGroupID = Main },
                new Setting { Name = "MetaKeywords", Value = "DexCMS, Transcending Tech, Content Management System", SettingDataTypeID = Text, SettingGroupID = Main },
                new Setting { Name = "ThumbHeight", Value = "100", SettingDataTypeID = Text, SettingGroupID = Images },
                new Setting { Name = "ThumbWidth", Value = "100", SettingDataTypeID = Text, SettingGroupID = Images },
                new Setting { Name = "GalleryHeight", Value = "500", SettingDataTypeID = Text, SettingGroupID = Images },
                new Setting { Name = "GalleryWidth", Value = "850", SettingDataTypeID = Text, SettingGroupID = Images },
                new Setting { Name = "SliderHeight", Value = "1200", SettingDataTypeID = Text, SettingGroupID = Images },
                new Setting { Name = "SliderWidth", Value = "1600", SettingDataTypeID = Text, SettingGroupID = Images },
                new Setting { Name = "OriginalHeight", Value = "1300", SettingDataTypeID = Text, SettingGroupID = Images },
                new Setting { Name = "OriginalWidth", Value = "1600", SettingDataTypeID = Text, SettingGroupID = Images },
                new Setting { Name = "ContactFromUseCredentials", Value = "False", SettingDataTypeID = Bool, SettingGroupID = Main },
                new Setting { Name = "FacebookUrl", Value = "#", SettingDataTypeID = Url, SettingGroupID = Main },
                new Setting { Name = "TwitterUrl", Value = "#", SettingDataTypeID = Url, SettingGroupID = Main }
            );
            Context.SaveChanges();
        }
    }
}
