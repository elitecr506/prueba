using AutoMapper;
using Ecommerce.SOS.Datasources.MongoDB.Entities.Collections;
using Ecommerce.SOS.Datasources.MongoDB.Entities.Gallery;
using Ecommerce.SOS.Domain.Models.Collections;
using Ecommerce.SOS.Domain.Models.Gallery;

namespace Ecommerce.SOS.Datasources.MongoDB.Mappers
{
    public class MapperDS : Profile
    {

        public MapperDS()
        {
            CreateMap<GalleryEntity, GalleryItem>();
            CreateMap<CollectionEntity, Collection>();
        }
    }
}

