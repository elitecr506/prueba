using Ecommerce.SOS.Application.Contrats.Datasources;
using Ecommerce.SOS.Application.Contrats.UserCases.Collections;
using Ecommerce.SOS.Domain.DTOs;
using Ecommerce.SOS.Domain.Enums;
using Ecommerce.SOS.Domain.Models.Collections;
using Microsoft.Extensions.Logging;

namespace Ecommerce.SOS.Application.UserCases.Collections
{
	public class GetPagedCollectionsUC : IGetPagedCollectionsUC
    {
        private readonly ICollectionsDS _collectionsDS;
        private readonly ILogger<IGetPagedCollectionsUC> _logger;

        public GetPagedCollectionsUC(
            ICollectionsDS collectionsDS,
            ILogger<IGetPagedCollectionsUC> logger)
		{
            _collectionsDS = collectionsDS;
            _logger = logger;
		}

        public async Task<(StatusCode, IEnumerable<Collection>?)>
            GetPagedCollections(PagedCollectionsRequest request)
        {
            if (false) //TODO: Llamar validaciones
            {
                //TODO: Registrar log del error
                return (StatusCode.ServerError, null);
            }

            try
            {
                IEnumerable<Collection> pagedCollections = await _collectionsDS.GetPagedCollections(
                    request.ClientId, request.PageNumber, request.PageSize);

                return (pagedCollections.Count() > 0 ? StatusCode.Ok : StatusCode.NoContent,
                    pagedCollections);
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message);
                return (StatusCode.ServerError, null);
            }
        }
    }
}

