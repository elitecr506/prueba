using Ecommerce.SOS.Domain.Models.Collections;

namespace Ecommerce.SOS.Application.Contrats.Datasources
{
	public interface ICollectionsDS
	{
		Task<IEnumerable<Collection>>
			GetPagedCollections(string clientDataBase, int pageNumber, int pageSize);
	}
}

