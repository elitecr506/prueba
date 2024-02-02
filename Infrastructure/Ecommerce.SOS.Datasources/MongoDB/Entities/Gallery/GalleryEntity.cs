using Ecommerce.SOS.Datasources.MongoDB.Entities.Bases;
using Ecommerce.SOS.Domain.Enums.Gallery;

namespace Ecommerce.SOS.Datasources.MongoDB.Entities.Gallery
{
    public class GalleryEntity
    {
        public required string Path { get; set; }
        public required GalleryType Type { get; set; }
    }
}
