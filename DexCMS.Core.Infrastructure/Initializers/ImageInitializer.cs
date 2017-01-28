using DexCMS.Core.Infrastructure.Contexts;
using DexCMS.Core.Infrastructure.Extensions;
using DexCMS.Core.Infrastructure.Globals;
using DexCMS.Core.Infrastructure.Models;
using System.Data.Entity.Migrations;

namespace DexCMS.Core.Infrastructure.Initializers
{
    class ImageInitializer : DexCMSInitializer<IDexCMSCoreContext>
    {
        public ImageInitializer(IDexCMSCoreContext context) : base(context)
        {
        }

        public override void Run(bool addDemoContent = true)
        {
            if (addDemoContent)
            {
                string baseOne = "content/images/cdn/1/";
                string baseTwo = "content/images/cdn/2/";

                Context.Images.AddIfNotExists(x => x.Alt,
                    new Image
                    {
                        Alt = "Gaea Retreat",
                        Caption = "Gaea Retreat Center",
                        Credit = "Chris Byram",
                        Original = baseOne + "GaeaRetreat_original.png",
                        Gallery = baseOne + "GaeaRetreat_gallery.jpg",
                        Slider = baseOne + "GaeaRetreat_slider.jpg",
                        Thumbnail = baseOne + "GaeaRetreat_thumbnail.jpg"
                    },
                    new Image
                    {
                        Alt = "Lawrence Busker",
                        Caption = "Lawrence Busker Festival",
                        Credit = "Chris Byram",
                        Original = baseTwo + "LawrenceBusker_original.png",
                        Gallery = baseTwo + "LawrenceBusker_gallery.jpg",
                        Slider = baseTwo + "LawrenceBusker_slider.jpg",
                        Thumbnail = baseTwo + "LawrenceBusker_thumbnail.jpg"
                    }
                );
                Context.SaveChanges();
            }
        }
    }
}
