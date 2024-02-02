namespace Ecommerce.SOS.Domain.DTOs
{
	public class PagedCollectionsRequest
	{
		public required string ClientId { get; set; }
		public required int PageSize { get; set; }
		public required int PageNumber { get; set; }
	}
}

