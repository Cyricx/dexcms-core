using DexCMS.Core.Infrastructure.Contexts;
using DexCMS.Core.Infrastructure.Models;
using System.Linq;
using DexCMS.Core.Infrastructure.Extensions;
using DexCMS.Core.Infrastructure.Globals;
using System;
using DexCMS.Core.Infrastructure.Initializers.Helpers;

namespace DexCMS.Core.Infrastructure.Initializers
{
    class SettingInitializer : DexCMSInitializer<IDexCMSCoreContext>
    {
        private SettingDataTypesReference DataTypes;
        private SettingGroupsReference Groups;

        public SettingInitializer(IDexCMSCoreContext context) : base(context)
        {
            DataTypes = new SettingDataTypesReference(Context);
            Groups = new SettingGroupsReference(Context);
        }

        public override void Run()
        {

            Context.Settings.AddIfNotExists(x => x.Name,
                new Setting { Name = "SiteTitle", Value = "Awesome Site", SettingDataTypeID = DataTypes.Text, SettingGroupID = Groups.Main },
                new Setting { Name = "TagLine", Value = "The absolute bestest ever!", SettingDataTypeID = DataTypes.Multiline, SettingGroupID = Groups.Main },
                new Setting { Name = "SmtpServer", Value = "yoursite.com", SettingDataTypeID = DataTypes.Text, SettingGroupID = Groups.Main },
                new Setting { Name = "ContactFromEmail", Value = "no-reply@yoursite.cmo", SettingDataTypeID = DataTypes.Email, SettingGroupID = Groups.Main },
                new Setting { Name = "ContactFromPassword", Value = "abc123", SettingDataTypeID = DataTypes.Password, SettingGroupID = Groups.Main },
                new Setting { Name = "ContactTo", Value = "contact@chrisbyram.com,you@yoursite.com", SettingDataTypeID = DataTypes.Multiline, SettingGroupID = Groups.Main },
                new Setting { Name = "MetaKeywords", Value = "DexCMS, Transcending Tech, Content Management System", SettingDataTypeID = DataTypes.Text, SettingGroupID = Groups.Main },
                new Setting { Name = "ThumbHeight", Value = "100", SettingDataTypeID = DataTypes.Text, SettingGroupID = Groups.Images },
                new Setting { Name = "ThumbWidth", Value = "100", SettingDataTypeID = DataTypes.Text, SettingGroupID = Groups.Images },
                new Setting { Name = "GalleryHeight", Value = "500", SettingDataTypeID = DataTypes.Text, SettingGroupID = Groups.Images },
                new Setting { Name = "GalleryWidth", Value = "850", SettingDataTypeID = DataTypes.Text, SettingGroupID = Groups.Images },
                new Setting { Name = "SliderHeight", Value = "1200", SettingDataTypeID = DataTypes.Text, SettingGroupID = Groups.Images },
                new Setting { Name = "SliderWidth", Value = "1600", SettingDataTypeID = DataTypes.Text, SettingGroupID = Groups.Images },
                new Setting { Name = "OriginalHeight", Value = "1300", SettingDataTypeID = DataTypes.Text, SettingGroupID = Groups.Images },
                new Setting { Name = "OriginalWidth", Value = "1600", SettingDataTypeID = DataTypes.Text, SettingGroupID = Groups.Images },
                new Setting { Name = "ContactFromUseCredentials", Value = "false", SettingDataTypeID = DataTypes.Bool, SettingGroupID = Groups.Main },
                new Setting { Name = "CodepenEnabled", Value = "false", SettingDataTypeID = DataTypes.Bool, SettingGroupID = Groups.Social },
                new Setting { Name = "CodepenUrl", Value = "#", SettingDataTypeID = DataTypes.Url, SettingGroupID = Groups.Social },
                new Setting { Name = "EtsyEnabled", Value = "false", SettingDataTypeID = DataTypes.Bool, SettingGroupID = Groups.Social },
                new Setting { Name = "EtsyUrl", Value = "#", SettingDataTypeID = DataTypes.Url, SettingGroupID = Groups.Social },
                new Setting { Name = "FacebookEnabled", Value = "true", SettingDataTypeID = DataTypes.Bool, SettingGroupID = Groups.Social },
                new Setting { Name = "FacebookUrl", Value = "#", SettingDataTypeID = DataTypes.Url, SettingGroupID = Groups.Social },
                new Setting { Name = "GithubEnabled", Value = "false", SettingDataTypeID = DataTypes.Bool, SettingGroupID = Groups.Social },
                new Setting { Name = "GithubUrl", Value = "#", SettingDataTypeID = DataTypes.Url, SettingGroupID = Groups.Social },
                new Setting { Name = "GooglePlusEnabled", Value = "false", SettingDataTypeID = DataTypes.Bool, SettingGroupID = Groups.Social },
                new Setting { Name = "GooglePlusUrl", Value = "#", SettingDataTypeID = DataTypes.Url, SettingGroupID = Groups.Social },
                new Setting { Name = "InstagramEnabled", Value = "false", SettingDataTypeID = DataTypes.Bool, SettingGroupID = Groups.Social },
                new Setting { Name = "InstagramUrl", Value = "#", SettingDataTypeID = DataTypes.Url, SettingGroupID = Groups.Social },
                new Setting { Name = "LinkedInEnabled", Value = "true", SettingDataTypeID = DataTypes.Bool, SettingGroupID = Groups.Social },
                new Setting { Name = "LinkedInUrl", Value = "#", SettingDataTypeID = DataTypes.Url, SettingGroupID = Groups.Social },
                new Setting { Name = "PinterestEnabled", Value = "false", SettingDataTypeID = DataTypes.Bool, SettingGroupID = Groups.Social },
                new Setting { Name = "PinterestUrl", Value = "#", SettingDataTypeID = DataTypes.Url, SettingGroupID = Groups.Social },
                new Setting { Name = "StackOverflowEnabled", Value = "false", SettingDataTypeID = DataTypes.Bool, SettingGroupID = Groups.Social },
                new Setting { Name = "StackOverflowUrl", Value = "#", SettingDataTypeID = DataTypes.Url, SettingGroupID = Groups.Social },
                new Setting { Name = "TwitterEnabled", Value = "true", SettingDataTypeID = DataTypes.Bool, SettingGroupID = Groups.Social },
                new Setting { Name = "TwitterUrl", Value = "#", SettingDataTypeID = DataTypes.Url, SettingGroupID = Groups.Social },
                new Setting { Name = "YouTubeEnabled", Value = "false", SettingDataTypeID = DataTypes.Bool, SettingGroupID = Groups.Social },
                new Setting { Name = "YouTubeUrl", Value = "#", SettingDataTypeID = DataTypes.Url, SettingGroupID = Groups.Social }
            );
            Context.SaveChanges();
        }
    }
}
