using AutoMapper;
using Ecommerce.SOS.Application.Contrats.Datasources;
using Ecommerce.SOS.Datasources.MongoDB.Constants;
using Ecommerce.SOS.Datasources.MongoDB.ContextFactory;
using Ecommerce.SOS.Datasources.MongoDB.Entities.Collections;
using Ecommerce.SOS.Domain.Models.Collections;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Ecommerce.SOS.Datasources.MongoDB.Implementations
{
	public class CollectionsDS : ICollectionsDS
    {
        private readonly IMapper _mapper;
        private readonly MongoFactory _mongoFactory;

        public CollectionsDS(IMapper mapper, MongoFactory mongoFactory)
		{
            _mapper = mapper;
            _mongoFactory = mongoFactory;
		}

        public async Task<IEnumerable<Collection>>
            GetPagedCollections(string clientDataBase, int pageNumber, int pageSize)
        {
            IMongoCollection<CollectionEntity> collection = _mongoFactory
                .GetCollection<CollectionEntity>(clientDataBase, CollectionNames.SOSCOLLECTIONS,
                _mongoFactory.CreateMongoClientFromConnectionString());

            //collection.InsertOne(CreateOne());

            int skip = (pageNumber - 1) * pageSize;
            var sort = Builders<CollectionEntity>.Sort.Descending(c => c.CreatedAt);

            IEnumerable<CollectionEntity> result = collection
                .Aggregate()
                .Sort(sort)
                .Skip(skip)
                .Limit(pageSize)
                .ToEnumerable();

            IEnumerable<Collection> result1 = _mapper.Map<IEnumerable<Collection>>(result);

            return await Task.FromResult(result1);
        }

        private CollectionEntity CreateOne()
        {
            CollectionEntity collectionEntity =
                new CollectionEntity() {
                    Id = ObjectId.GenerateNewId(),
                    CreatedAt = new DateTime(),
                    UpdatedAt = new DateTime(),
                    Description = "des",
                    MainImage = new Entities.Gallery.GalleryEntity()
                    {
                        Path = "path",
                        Type = Domain.Enums.Gallery.GalleryType.Picture
                    }
                };

            return collectionEntity;
        }
    }
}

