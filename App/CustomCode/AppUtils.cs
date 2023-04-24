using System;
using System.Collections.Generic;
using System.Reflection;
using Altinn.App.Models;
using Microsoft.AspNetCore.Http;
using Altinn.App.Core.Interface;
using Altinn.App.Core.Helpers;
using Altinn.Platform.Profile.Models;
using System.Threading.Tasks;
using Altinn.Platform.Storage.Interface.Models;
using System.Linq;


namespace Altinn.App.AppLogic.CustomCode {
  public class AppUtils
  {
    private IProfile _profileService;
    private IHttpContextAccessor _httpContextAccessor;
    private IAppResources _appResources;
    private A3_RA0792_M _datamodel  {get; set;} //Sett riktig datamodell her. ERSTATT A3_RA0792_M

    /// <summary>
    /// Datamodel må settes før en kan manipulere data 
    /// </summary>
    /// <example>
    /// Viser hvordan vi kaller denne og setter datamodellen 
    /// <code>
    /// _aputils.datamodel=(Vedlegg_M) data;
    /// </code>
    /// </example>
    /// <returns>Returnere ikke data</returns>

    public A3_RA0792_M datamodel  //Sett riktig datamodell her. ERSTATT A3_RA0792_M
    {
        get
        {
            return _datamodel;
        }
        set
        {
           _datamodel = value;
        }
    }
    
    public AppUtils(IProfile profileService , IHttpContextAccessor httpContextAccessor,IAppResources appResources)
    {
        _profileService = profileService;
        _httpContextAccessor=httpContextAccessor;
        _appResources=appResources;
    }
   

    /// <summary>
    /// Funksjon for å sjekke datamodel objekter og  oppretter de hvis de ikke finnes fra før  <see cref="CreateObject"/> 
    /// </summary>
    /// <example>
    /// <code>
    /// _aputils.datamodel=(Vedlegg_M) data;
    /// _aputils.CreateObject();
    /// _aputils.SettTestPrefill(true);
    /// </code>
    /// </example>
    /// <returns>Returnere ikke data</returns>

    public async Task CreateObject()
    {

        if (_datamodel.InternInfo== null) _datamodel.InternInfo=new InternInfo();
        if (_datamodel.Kontakt== null) _datamodel.Kontakt=new Kontakt();
        if (_datamodel.Hjelpefelter== null) _datamodel.Hjelpefelter=new Hjelpefelter();
        if (_datamodel.SkjemaData == null) _datamodel.SkjemaData=new SkjemaData();
        if (_datamodel.KlassInfo== null) _datamodel.KlassInfo=new List<KlassInfo>();

        await Task.CompletedTask;
    }

    /// <summary>
    /// Funksjon for å sette inn testprefill i Interninfo, både for foretak og virksomhet <see cref="SettTestPrefill"/> 
    /// </summary>
    /// <remarks>
    /// datamodell må settes før denne kan kalles
    /// </remarks>
    /// <example>
    /// Eksempel på kall: 
    /// <code>
    /// _aputils.datamodel=(Vedlegg_M) data;
    /// _aputils.SettTestPrefill(true);
    /// </code>
    /// </example>
    /// <returns>Ikke noe</returns>
    public void SettTestPrefill(bool testVirksomhet)
    {
        _datamodel.InternInfo.undersoekelsesInfoUrl="https://www.ssb.no/innrapportering/";
        _datamodel.InternInfo.periodeFritekst="2. kvartal 2022";
        _datamodel.InternInfo.periodeType="KVRT";
        _datamodel.InternInfo.periodeNummer="2";
        _datamodel.InternInfo.periodeAAr="2022";
        _datamodel.InternInfo.delregNr="1234";
        _datamodel.InternInfo.raNummer="RA-0815";
        _datamodel.InternInfo.undersoekelsesNr="1234";
        _datamodel.InternInfo.enhetsIdent="666";
         _datamodel.InternInfo.visBrukeropplevelse="1";
        _datamodel.InternInfo.visOppgaveByrde="1";
        if(testVirksomhet)
        {
            _datamodel.InternInfo.enhetsNavn="STATISTISK SENTRALBYRÅ";
            _datamodel.InternInfo.enhetsAvdeling="STATISTISK SENTRALBYRÅ AVD KONGSVINGER";
            _datamodel.InternInfo.enhetsOrgNr="974716887";
            _datamodel.InternInfo.enhetsGateadresse="Otervegen 26";
            _datamodel.InternInfo.enhetsPostnr="2211";
            _datamodel.InternInfo.enhetsPoststed="KONGSVINGER";
        }else
        {
            _datamodel.InternInfo.enhetsNavn="NORD-ODAL JAKT- OG FISKEFORENING";
            _datamodel.InternInfo.enhetsAvdeling="";
            _datamodel.InternInfo.enhetsOrgNr="984045689";
            _datamodel.InternInfo.enhetsGateadresse="Gamle Vallsetvegen 47";
            _datamodel.InternInfo.enhetsPostnr="2120";
            _datamodel.InternInfo.enhetsPoststed="Sagstua";    
        }                    
    }

    
    /// <summary>
    /// Funksjon for å hente ut userprofil for pålogget bruker i altinn
    /// </summary>
    /// <remarks>
    /// Legg til using Altinn.Platform.Profile.Models; i filen du skal kalle funksjonen 
    /// </remarks>
    /// <example>
    /// Eksempel på kall: 
    /// <code>
    /// var userinfo=await _aputils.GetUserInfo();
    /// </code>
    /// </example>
    /// <returns>UserProfile</returns>
    public async Task<UserProfile> GetUserInfo()
    {
        int userId=GetUserId(_httpContextAccessor.HttpContext);
        
        UserProfile profile=await _profileService.GetUserProfile(userId);
        
        return profile;
    }
    
    private  int GetUserId(HttpContext context)
    {
        int userId=AuthenticationHelper.GetUserId(context);
        return userId;
    }
     /// <summary>
    /// Funksjon for å hente ut UserId for pålogget bruker i altinn
    /// </summary>
    /// <remarks>
    /// Legg til using Altinn.Platform.Profile.Models; i filen du skal kalle funksjonen 
    /// </remarks>
    /// <example>
    /// Eksempel på kall: 
    /// <code>
    /// int userid=await _aputils.GetUserId();
    /// </code>
    /// </example>
    /// <returns>Userid</returns>
    public  int GetUserId()
    {
        int userId=AuthenticationHelper.GetUserId(_httpContextAccessor.HttpContext);
        return userId;
    }
    public async Task<string> GetUserLanguage()
    {
        UserProfile user=await GetUserInfo();
        return user.ProfileSettingPreference.Language;
    }
    public  DateTime GetLastBusinessDayOfCurrentMonth(DateTime dato)
    {
      //finner siste arbeidsdag
        DateTime lastDayOfCurrentMonth = new DateTime(dato.Year, dato.Month,  DateTime.DaysInMonth(dato.Year, dato.Month));

        if(lastDayOfCurrentMonth.DayOfWeek == DayOfWeek.Sunday)
            lastDayOfCurrentMonth = lastDayOfCurrentMonth.AddDays(-2);
        else if(lastDayOfCurrentMonth.DayOfWeek == DayOfWeek.Saturday)
            lastDayOfCurrentMonth = lastDayOfCurrentMonth.AddDays(-1);

        return lastDayOfCurrentMonth;
    }

    public  DateTime GetFirstBusinessDayOfCurrentMonth(DateTime dato)
    {
      //Finner første arbeidsdag
        DateTime firstDayOfCurrentMonth = new DateTime(dato.Year, dato.Month,  1);

        if(firstDayOfCurrentMonth.DayOfWeek == DayOfWeek.Sunday)
            firstDayOfCurrentMonth = firstDayOfCurrentMonth.AddDays(+1);
        else if(firstDayOfCurrentMonth.DayOfWeek == DayOfWeek.Saturday)
            firstDayOfCurrentMonth = firstDayOfCurrentMonth.AddDays(+2);

        return firstDayOfCurrentMonth;
    }

    /// <summary>
    /// Funksjon tar imot dato og returnere dato på format dd.MM.YYYY der mnd er på norsk
    /// </summary>
    /// <example>
    /// GetDateFormatString(DateTime date)
    /// <code>
    /// </code>
    /// </example>
    /// <param name="date">Dato som skal konverteres</param>
    /// <returns>Formatert dato</returns>

    public string GetDateFormatString(DateTime date)
    {
        Dictionary<int, string> norMonths = new Dictionary<int, string>()
        {
            {1, "Januar"},
            {2, "Februar"},
            {3, "Mars"},
            {4, "April"},
            {5, "Mai"},
            {6, "Juni"},
            {7, "Juli"},
            {8, "August"},
            {9, "September"},
            {10, "Oktober"},
            {11, "November"},
            {12, "Desember"}
        };
        
        return $"{date.Day}. {norMonths[date.Month]} {date.Year}";
    }

    
     /// <summary>
    /// Funksjon for å sette inn enkelt prefill via enkel instansiering<see cref="SettPrefill"/> 
    /// </summary>
    /// <remarks>
    /// datamodell må settes før denne kan kalles, det er bare "Telefonnummer" i kontaktsiden som settes enn så lenge
    /// </remarks>
    /// <example>
    /// Eksempel på kall i DataCreation: 
    /// <code>
    /// if (prefill!=null)
    ///     _aputils.SettPrefill(prefill);
    /// </code>
    /// </example>
    /// <param name="prefill">Dictionary med prefill data</param>
    /// <returns>Ikke noe</returns>
    public void SettPrefill(Dictionary<string,string> prefill)
    {
         if (prefill.Count>0)
         {
            foreach (string a in prefill.Keys)
            {
                if (a=="Telefonnummer")
                {
                    _datamodel.Kontakt.kontaktPersonTelefon=prefill[a];
                }
            }
         }
    }

    /// <summary>
    /// Funksjon for å sette inn prefill i kontaktinfo, bare navn enn så lenge <see cref="SettKontaktInfoPrefill"/> 
    /// </summary>
    /// <remarks>
    /// datamodell må settes før denne kan kalles
    /// </remarks>
    /// <example>
    /// Eksempel på kall: 
    /// <code>
    /// _aputils.datamodel=(Vedlegg_M) data;
    /// _aputils.SettKontaktInfoPrefill();
    /// </code>
    /// </example>
    /// <returns>Ikke noe</returns>
    public async Task SettKontaktInfoPrefill()
    {
        var userinfo=await GetUserInfo();
        if (userinfo.Party.Person.Name!=null)
        {
            if (String.IsNullOrEmpty(_datamodel.Kontakt.kontaktPersonNavn))
                _datamodel.Kontakt.kontaktPersonNavn=userinfo.Party.Person.Name;
        }

        await Task.CompletedTask;
    }


    // public async void SettSkjemaTitelPrefill()
    // {
    //     //NB er fallback språk hvis man ber om noe som ikke ligger der.
    //     string userLanguage= await GetUserLanguage();
        
    //     //nynorsk
    //     if (userLanguage.ToUpper()=="NN")
    //     {
    //         if (String.IsNullOrEmpty(_datamodel.SkjemaTekster.skjemaNavnNN))
    //         {       
    //             _datamodel.Hjelpefelter.skjemaNavn=_datamodel.SkjemaTekster.skjemaNavnNB;
    //         }else
    //         {
    //             _datamodel.Hjelpefelter.skjemaNavn=_datamodel.SkjemaTekster.skjemaNavnNN;
    //         }    
    //     }
    //     //Engelsk tittel
    //     if (userLanguage.ToUpper()=="EN")
    //     {
    //         if (String.IsNullOrEmpty(_datamodel.SkjemaTekster.skjemaNavnEN))
    //         {       
    //             _datamodel.Hjelpefelter.skjemaNavn=_datamodel.SkjemaTekster.skjemaNavnNB;
    //         }else
    //         {
    //             _datamodel.Hjelpefelter.skjemaNavn=_datamodel.SkjemaTekster.skjemaNavnEN;
    //         }    
    //     }
    //     //norsk bokmål er fellback
    //     if (userLanguage.ToUpper()=="NB")
    //     {
    //         _datamodel.Hjelpefelter.skjemaNavn=_datamodel.SkjemaTekster.skjemaNavnNB;
    //     }

         
    //     await Task.CompletedTask;
    // }


    public enum KvartalsTyper
    {   
        Forrige = 0,
        Neste = 1, 
        UtAaret = 2,
        NesteAar = 3
    }
 

    /// <summary>
    /// Funksjon for å finne andre kvartaler <see cref="GetKvartal"/> 
    /// </summary>
    /// <remarks>
    /// Man sender inn rapporterings kvartalet og ber om en type
    /// retur av kvartal på formatet "2. kvartal 2022"
    /// </remarks>
    /// <example>
    /// Eksempel på kall: 
    /// <code>
    /// string result =GetKvartal(1,2022,PeriodeTyper.Neste);
    /// </code>
    /// </example>
    /// <returns>Kvartalsinfo som en string</returns>
    public string GetKvartal(int periodeNummer, int periodeAAr,KvartalsTyper periodeType)
    {
        
        string result="";
        switch (periodeType)
        {
            case KvartalsTyper.Forrige:
                if ((periodeNummer-1)==0) 
                    result=String.Concat("4. kvartal ",(periodeAAr-1).ToString());
                else 
                    result=String.Concat((periodeNummer-1).ToString(), ". kvartal ",(periodeAAr).ToString());
                break;
            case KvartalsTyper.Neste:
                if ((periodeNummer+1)==5) 
                    result=String.Concat("1. kvartal ",(periodeAAr+1).ToString());
                else 
                    result=String.Concat((periodeNummer+1).ToString(), ". kvartal ",(periodeAAr).ToString());
                break;
            case KvartalsTyper.UtAaret:
                if ((periodeNummer)==1) 
                    result=String.Concat("2-4. kvartal ",(periodeAAr).ToString());
                else if((periodeNummer)==2)
                    result=String.Concat("3-4. kvartal ",(periodeAAr).ToString());
                else if((periodeNummer)==3)
                    result=String.Concat("4. kvartal ",(periodeAAr).ToString());
                else
                    result="";
                break;
            case KvartalsTyper.NesteAar:
                result=(periodeAAr+1).ToString();
                break;
            default:
                break;
        }

        return result;
    }

    public async Task<TextResource> HentTekster(string spraak,Instance instance)
    {
        return await _appResources.GetTexts(instance.Org,instance.AppId.Split("/")[1],spraak);
    }

    public async Task<Dictionary<string,string>> HentOptionList(string listNavn,string spraak,Instance instance)
    {
        TextResource skjemaTekster=await HentTekster(spraak,instance);
        List<TextResourceElement> optList= skjemaTekster.Resources.FindAll(a => a.Id.StartsWith(listNavn));
        Dictionary<string,string> optionList= optList.ToDictionary(x => x.Id.Split(".")[1], x => x.Value);

        return optionList;

    }


    //Brukes for å sette Klass dokumentasjon
    //Man sette KlassID i form av api kallet feks: "/api/klass/v1/classifications/623/codesAt.json?date=2023-03-15&language=nb&selectLevel=2"
    // nodenavn er løvnodenavnet som får data fra klass lista
    //slettliste sletter lista hvis satt til true før den legger inn noe.
    public void AddKlassInfo(string klassID,string nodeNavn,bool slettListe = false)
    {
        if (slettListe==true) _datamodel.KlassInfo.Clear();
        //Legger til Klassinfo i KlassInfo listen
        KlassInfo klassInfo= new KlassInfo();
        klassInfo.KlassID=klassID;
        klassInfo.KlassDatamodellNode=nodeNavn;
        _datamodel.KlassInfo.Add(klassInfo);
    }

  }
}