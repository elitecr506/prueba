using Ecommerce.SOS.Datasources.MongoDB.Entities.Bases;
using Ecommerce.SOS.Datasources.MongoDB.Entities.Gallery;

namespace Ecommerce.SOS.Datasources.MongoDB.Entities.Collections
{
    public class CollectionEntity : AuditableEntity
    {
        public required string Description { get; set; }
        public GalleryEntity? MainImage { get; set; }
    }
}
