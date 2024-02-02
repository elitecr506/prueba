using Ecommerce.SOS.Domain.Models.Gallery;

namespace Ecommerce.SOS.Domain.Models.Collections
{
	public class Collection
	{
        public required string Id { get; set; }
        public required string Description { get; set; }
        public required GalleryItem MainImage { get; set; }
    }
}

