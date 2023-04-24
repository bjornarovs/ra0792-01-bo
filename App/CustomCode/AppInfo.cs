using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Altinn.App.Models;
using Microsoft.AspNetCore.Http;
using Altinn.Platform.Storage.Interface.Models;
using System.Linq;
using Altinn.App.Core.Interface;

namespace Altinn.App.AppLogic.CustomCode 
{
  public class AppInfo
  {
        private A3_RA0792_M _model {get; set;} //Sett riktig datamodell her. ERSTATT A3_RA0792_M
        private readonly IInstance _instanceService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        
        
        public AppInfo(IInstance instanceService , IHttpContextAccessor httpContextAccessor,IAppResources appResources)
        {
          _instanceService = instanceService;
          _httpContextAccessor=httpContextAccessor;
        }

        private int GetPartyIdFromInstance(Instance instance)
        {
          return int.Parse(instance.InstanceOwner.PartyId);
        }

        private Guid GetInstanceGUIDFromInstance(Instance instance)
        {
          return Guid.Parse(instance.Id.Split("/")[1]);
        }

        private async Task AddPresentationTexts(object data,Instance instance)
        {
          //legger til presentationfelter i metadata på skjema.
          var customDataValues = new PresentationTexts(){ Texts =new Dictionary<string, string>() { { "periodeFritekst", _model.InternInfo.periodeFritekst }}};            
          await _instanceService.UpdatePresentationTexts(GetPartyIdFromInstance(instance),GetInstanceGUIDFromInstance(instance), customDataValues);
        }

        private async Task AddDataFields(object data,Instance instance)
        {
          //legger til custom datafields i metadata på instansen.
          var customDataValues = new DataValues() { Values = new Dictionary<string, string>() {{"raNummer", _model.InternInfo.raNummer}
          ,{"skjemaVersjon", _model.InternInfo.skjemaVersjon}
          ,{"undersoekelsesNr", _model.InternInfo.undersoekelsesNr}
          ,{"periodeType", _model.InternInfo.periodeType}
          ,{"periodeNummer", _model.InternInfo.periodeNummer}
          ,{"periodeAAr", _model.InternInfo.periodeAAr}
          ,{"enhetsOrgNr", _model.InternInfo.enhetsOrgNr} }};
          await _instanceService.UpdateDataValues( GetPartyIdFromInstance(instance),GetInstanceGUIDFromInstance(instance), customDataValues);
        }

        public async Task AddSkjemaInfo(object data,Instance instance, string version, string raNumber)
        {
          _model=(A3_RA0792_M)data;  //Sett riktig datamodell her. ERSTATT A3_RA0792_M
          _model.InternInfo.skjemaVersjon=version;
          _model.InternInfo.raNummer=raNumber;
          await AddPresentationTexts(data,instance);
          await AddDataFields(data,instance);


        }
  }
}