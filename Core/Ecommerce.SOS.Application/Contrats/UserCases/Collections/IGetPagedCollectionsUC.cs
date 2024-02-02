using Ecommerce.SOS.Domain.DTOs;
using Ecommerce.SOS.Domain.Enums;
using Ecommerce.SOS.Domain.Models.Collections;

namespace Ecommerce.SOS.Application.Contrats.UserCases.Collections
{
	public interface IGetPagedCollectionsUC
	{
		Task<(StatusCode, IEnumerable<Collection>?)> GetPagedCollections(PagedCollectionsRequest request);
	}
}
