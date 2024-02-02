using System;
using Ecommerce.SOS.Domain.Enums.Gallery;

namespace Ecommerce.SOS.Domain.Models.Gallery
{
	public class GalleryItem
	{
        public required string Path { get; set; }
        public required GalleryType Type { get; set; }
    }
}

