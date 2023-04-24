using System.Collections.Generic;
using System.Threading.Tasks;
using Altinn.App.AppLogic.CustomCode;
using Altinn.App.Core.Features;
using Altinn.App.Core.Interface;
using Altinn.App.Models;
using Altinn.Platform.Storage.Interface.Models;
using Microsoft.AspNetCore.Http;

namespace Altinn.App.AppLogic.DataProcessing;

public class InstantiationProcessor : IInstantiationProcessor
{
    private IProfile _profileService;
    private IRegister _registerService;
    private AppUtils _appUtils;
    private AppInfo _appInfo;

    public InstantiationProcessor(AppInfo appInfo, AppUtils appUtils, IProfile profileService, IRegister registerService,IHttpContextAccessor httpContextAccessor,IInstance instanceService, IAppResources appResourcesService)
    {
        _profileService = profileService;
        _registerService = registerService;
        _appUtils = appUtils;
        _appInfo = appInfo; 
    }
    
    
    public async Task DataCreation(Instance instance, object data, Dictionary<string, string> prefill)
    {
        if (data.GetType()==typeof(A3_RA0792_M))
            {
                _appUtils.datamodel=(A3_RA0792_M) data; //Setter Datamodell
                await _appUtils.CreateObject(); //Opprettet objekter i datamodellen som skal prefilles
                //_appUtils.SettTestPrefill(true); //booolske verdier, vis Virksomhetsinfo, vis Tidsbruk, vis Brukeropplevelse
            }
            await _appInfo.AddSkjemaInfo(data,instance,"1.0","RA-0792");//Setter datafields, presentation samt skjema versjon og RA nummer
        
        await Task.CompletedTask;     
    }
}