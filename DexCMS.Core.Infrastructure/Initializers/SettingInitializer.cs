using DexCMS.Core.Infrastructure.Contexts;
using DexCMS.Core.Infrastructure.Models;
using System.Linq;
using DexCMS.Core.Infrastructure.Extensions;
using DexCMS.Core.Infrastructure.Globals;

namespace DexCMS.Core.Infrastructure.Initializers
{
    class SettingInitializer : DexCMSInitializer<IDexCMSCoreContext>
    {
        private DataTypes DataTypes;
        private Groups Groups;

        public SettingInitializer(IDexCMSCoreContext context) : base(context)
        {
            DataTypes = new DataTypes(Context);
            Groups = new Groups(Context);
        }

        public override void Run()
        {

            Context.Settings.AddIfNotExists(x => x.Name,
                new Setting { Name = "SiteTitle", Value = "Your Website", SettingDataTypeID = DataTypes.Text, SettingGroupID = Groups.Main },
                new Setting { Name = "TagLine", Value = "tag", SettingDataTypeID = DataTypes.Multiline, SettingGroupID = Groups.Main },
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
                new Setting { Name = "ContactFromUseCredentials", Value = "False", SettingDataTypeID = DataTypes.Bool, SettingGroupID = Groups.Main },
                new Setting { Name = "CodepenUrl", Value = "", SettingDataTypeID = DataTypes.Url, SettingGroupID = Groups.Social },
                new Setting { Name = "EtsyUrl", Value = "", SettingDataTypeID = DataTypes.Url, SettingGroupID = Groups.Social },
                new Setting { Name = "FacebookUrl", Value = "#", SettingDataTypeID = DataTypes.Url, SettingGroupID = Groups.Social },
                new Setting { Name = "GithubUrl", Value = "", SettingDataTypeID = DataTypes.Url, SettingGroupID = Groups.Social },
                new Setting { Name = "GooglePlusUrl", Value = "", SettingDataTypeID = DataTypes.Url, SettingGroupID = Groups.Social },
                new Setting { Name = "InstagramUrl", Value = "#", SettingDataTypeID = DataTypes.Url, SettingGroupID = Groups.Social },
                new Setting { Name = "LinkedInUrl", Value = "#", SettingDataTypeID = DataTypes.Url, SettingGroupID = Groups.Social },
                new Setting { Name = "PinterestUrl", Value = "", SettingDataTypeID = DataTypes.Url, SettingGroupID = Groups.Social },
                new Setting { Name = "StackOverflowUrl", Value = "", SettingDataTypeID = DataTypes.Url, SettingGroupID = Groups.Social },
                new Setting { Name = "TwitterUrl", Value = "#", SettingDataTypeID = DataTypes.Url, SettingGroupID = Groups.Social },
                new Setting { Name = "YouTubeUrl", Value = "#", SettingDataTypeID = DataTypes.Url, SettingGroupID = Groups.Social }
            );
            Context.SaveChanges();
        }
    }

    class DataTypes
    {
        public int Text { get; set; }
        public int Date { get; set; }
        public int Bool { get; set; }
        public int Html { get; set; }
        public int Int { get; set; }
        public int Multiline { get; set; }
        public int FourDigitWhole { get; set; }
        public int Email { get; set; }
        public int Password { get; set; }
        public int Url { get; set; }

        public DataTypes(IDexCMSCoreContext Context)
        {
            Text = Context.SettingDataTypes.Where(x => x.Name == "Text").Select(x => x.SettingDataTypeID).Single();
            Date = Context.SettingDataTypes.Where(x => x.Name == "Date").Select(x => x.SettingDataTypeID).Single();
            Bool = Context.SettingDataTypes.Where(x => x.Name == "Bool").Select(x => x.SettingDataTypeID).Single();
            Html = Context.SettingDataTypes.Where(x => x.Name == "Html").Select(x => x.SettingDataTypeID).Single();
            Int = Context.SettingDataTypes.Where(x => x.Name == "Int").Select(x => x.SettingDataTypeID).Single();
            Multiline = Context.SettingDataTypes.Where(x => x.Name == "Multiline").Select(x => x.SettingDataTypeID).Single();
            FourDigitWhole = Context.SettingDataTypes.Where(x => x.Name == "FourDigitWhole").Select(x => x.SettingDataTypeID).Single();
            Email = Context.SettingDataTypes.Where(x => x.Name == "Email").Select(x => x.SettingDataTypeID).Single();
            Password = Context.SettingDataTypes.Where(x => x.Name == "Password").Select(x => x.SettingDataTypeID).Single();
            Url = Context.SettingDataTypes.Where(x => x.Name == "Url").Select(x => x.SettingDataTypeID).Single();
        }
    }
    class Groups
    {
        public int Main { get; set; }
        public int Images { get; set; }
        public int Social { get; set; }

        public Groups(IDexCMSCoreContext Context)
        {
            Main = Context.SettingGroups.Where(x => x.SettingGroupName == "Main").Select(x => x.SettingGroupID).Single();
            Images = Context.SettingGroups.Where(x => x.SettingGroupName == "Images").Select(x => x.SettingGroupID).Single();
            Social = Context.SettingGroups.Where(x => x.SettingGroupName == "Social").Select(x => x.SettingGroupID).Single();
        }
    }

}
