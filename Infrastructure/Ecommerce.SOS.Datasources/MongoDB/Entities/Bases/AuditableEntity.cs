using MongoDB.Bson;
namespace Ecommerce.SOS.Datasources.MongoDB.Entities.Bases
{
    public abstract class AuditableEntity
    {
        public ObjectId Id { get; set; }
        public required DateTime CreatedAt { get; set; }
        public required DateTime UpdatedAt { get; set; }
    }
}

