using System;
using System.Threading.Tasks;
using Altinn.App.AppLogic.CustomCode;
using Altinn.App.Core.Features;
using Altinn.App.Core.Interface;
using Altinn.App.Models;
using Altinn.Platform.Storage.Interface.Models;
using Microsoft.AspNetCore.Http;

namespace Altinn.App.AppLogic.DataProcessing;

public class DataProcessor : IDataProcessor
 {
        private AppUtils _aputils;
        private IHttpContextAccessor _httpContextAccessor;

        public DataProcessor(AppUtils apputils, IProfile profileService, IRegister registerService,IHttpContextAccessor httpContextAccessor)
        {
            _aputils = apputils;
            _httpContextAccessor = httpContextAccessor;
        }
        

     public async Task<bool> ProcessDataRead(Instance instance, Guid? dataId, object data)
     {
        if (data.GetType()==typeof(A3_RA0792_M))
            {
                _aputils.datamodel=(A3_RA0792_M) data; //Setter Datamodell
                await _aputils.CreateObject(); //Opprettet objekter i datamodellen som skal prefilles
                await _aputils.SettKontaktInfoPrefill(); //Setter prefill fra profil objekte til kontakt opplysinger
                //_aputils.AddKlassInfo("/api/klass/v1/classifications/623/codesAt.json?date=2023-03-15&language=nb&selectLevel=2","hovedsammenslutning",true);
                //_aputils.AddKlassInfo("/api/klass/v1/classifications/642/codesAt.json?date=2023-03-15&language=nb","konfliktNaeringsType",false);
                _aputils.datamodel.Hjelpefelter.hjelpefelt1= _aputils.GetKvartal(Int32.Parse(_aputils.datamodel.InternInfo.periodeNummer),Int32.Parse(_aputils.datamodel.InternInfo.periodeAAr),AppUtils.KvartalsTyper.Neste);
                //_aputils.datamodel.Hjelpefelter.hjelpefelt2= _aputils.GetKvartal(Int32.Parse(_aputils.datamodel.InternInfo.periodeNummer),Int32.Parse(_aputils.datamodel.InternInfo.periodeAAr),AppUtils.KvartalsTyper.UtAaret);
            
                
            }
            return await Task.FromResult(false);
     }

     public async Task<bool> ProcessDataWrite(Instance instance, Guid? dataId, object data)
     {
        return await Task.FromResult(false);
     }
 }