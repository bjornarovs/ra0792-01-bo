using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Altinn.App.Models;
using Altinn.App.Core.Interface;
using Altinn.App.Core.Models;

namespace Altinn.App.Core.Features.PageOrder
{
    public class PageOrder  : IPageOrder
    {
        private readonly IAppResources _appResourcesService;

        public PageOrder (IAppResources appResourcesService)
        {
            _appResourcesService = appResourcesService;
        }
        /// <inheritdoc />
        public async Task<List<string>> GetPageOrder(AppIdentifier appIdentifier, InstanceIdentifier instanceIdentifier, string layoutSetId, string currentPage, string dataTypeId, object formData)
        {
            List<string> pageOrder = new List<string>();
            //henter ut default pageorder
            if (string.IsNullOrEmpty(layoutSetId))
            {
                pageOrder = _appResourcesService.GetLayoutSettings().Pages.Order;
            }
            else
            {
                pageOrder = _appResourcesService.GetLayoutSettingsForSet(layoutSetId).Pages.Order;
            }
            if (currentPage.ToUpper()=="S1FORSIDE")
            {
                //Sjekker om vi ikke skal vise oppgavebyrde.
                if (formData.GetType()==typeof(A3_RA0792_M))
                {   
                    A3_RA0792_M datamodel=(A3_RA0792_M) formData; 
                    if (datamodel.InternInfo.visBrukeropplevelse !="1" || String.IsNullOrEmpty(datamodel.InternInfo.visBrukeropplevelse.ToString()))
                    {
                        if (pageOrder.IndexOf("Brukeropplevelse")!=-1) pageOrder.Remove("Brukeropplevelse");
                    }
                    if (datamodel.InternInfo.visOppgaveByrde !="1" || String.IsNullOrEmpty(datamodel.InternInfo.visOppgaveByrde.ToString()))
                    {
                        if (pageOrder.IndexOf("Tidsbruk")!=-1) pageOrder.Remove("Tidsbruk");
                    }
                }
            }

            return await Task.FromResult(pageOrder);
        }

    }

}