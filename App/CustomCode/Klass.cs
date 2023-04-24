using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Altinn.App.Models;
using Microsoft.AspNetCore.Http;
using Altinn.Platform.Storage.Interface.Models;
using System.Linq;
using Altinn.App.Core.Interface;
using System.Net.Http;
using Newtonsoft.Json;

namespace Altinn.App.AppLogic.CustomCode 
{
  public class Klass
  {
        public string apiRequestUrl { get; set;} 
        public class Code
        {
            public string code { get; set; }
            public object parentCode { get; set; }
            public string level { get; set; }
            public string name { get; set; }
            public string shortName { get; set; }
            public string presentationName { get; set; }
            public string validFrom {get; set;}
            public string validTo {get; set;}
            public string notes {get; set;}

        }
        
        private class Root
        {
            public List<Code> codes { get; set; }
        }
        
        public Klass()
        {

        }

        public async Task<Dictionary<string,Code>> getCodelist(string language,int listID) 
        {
            return await getCodelist(language,listID,DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd")));
        }
       

        public async Task<Dictionary<string,Code>> getCodelist(string language,int listID,DateTime fraDato,string codeRange="", string selectLevel="") 
        {
            string requestURL="";
            //datoformat 2021-01-01
            Dictionary<string,Code> optionList= new Dictionary<string,Code>();
           
            using var client = new HttpClient
            {
                BaseAddress = new Uri(string.Format("https://data.ssb.no/api/klass/v1/classifications/{0}/",listID.ToString()))
            };

            HttpResponseMessage response=new HttpResponseMessage();

            requestURL=string.Format("codesAt.json?date={0}&language={1}",fraDato.ToString("yyyy-MM-dd"),language);

            if (codeRange!="")
            {
                requestURL=requestURL + string.Format("&selectCodes={0}",codeRange);     
            }

            if (selectLevel!="")
            {
                requestURL=requestURL + string.Format("&selectLevel={0}",selectLevel); 
                //response = await client.GetAsync(string.Format("codesAt.json?date={1}&language={0}&selectCodes={2}",language,fraDato.ToString("yyyy-MM-dd"),codeRange));   
            }

            response = await client.GetAsync(requestURL);   

            apiRequestUrl=client.BaseAddress.LocalPath.ToString() + requestURL;
            
        
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var result=await response.Content.ReadAsStringAsync();
                Root datalist = JsonConvert.DeserializeObject<Root>(result);
                optionList=datalist.codes.ToDictionary(x => x.code);
                return optionList;
            }

            return null;
        }       

  }
}