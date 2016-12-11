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

        public override void Run()
        {
            Context.Images.AddIfNotExists(x => x.Alt,
                new Image { Alt = "Gaea Retreat", Caption = "Gaea Retreat Center", Credit = "Chris Byram", Original = "GaeaRetreat_original.png", Gallery = "GaeaRetreat_gallery.jpg", Slider = "GaeaRetreat_slider.jpg", Thumbnail = "GaeaRetreat_thumbnail.jpg" },
                new Image { Alt = "Lawrence Busker", Caption = "Lawrence Busker Festival", Credit = "Chris Byram", Original = "LawrenceBusker_original.png", Gallery = "LawrenceBusker_gallery.jpg", Slider = "LawrenceBusker_slider.jpg", Thumbnail = "LawrenceBusker_thumbnail.jpg" }
            );
            Context.SaveChanges();
        }
    }
}
