using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
namespace Altinn.App.Models
{
  [XmlRoot(ElementName="A3_RA0792_M")]
  public class A3_RA0792_M
  {
    [XmlAttribute("dataFormatProvider")]
    [BindNever]
    public string dataFormatProvider {get; set; } = "ALTINNSTUDIO";

    [XmlAttribute("dataFormatId")]
    [BindNever]
    public string dataFormatId {get; set; } = "A30792";

    [XmlAttribute("dataFormatVersion")]
    [BindNever]
    public string dataFormatVersion {get; set; } = "1";

    [XmlElement("InternInfo", Order = 1)]
    [JsonProperty("InternInfo")]
    [JsonPropertyName("InternInfo")]
    public InternInfo InternInfo { get; set; }

    [XmlElement("Tidsbruk", Order = 2)]
    [JsonProperty("Tidsbruk")]
    [JsonPropertyName("Tidsbruk")]
    public Tidsbruk Tidsbruk { get; set; }

    [XmlElement("Brukeropplevelse", Order = 3)]
    [JsonProperty("Brukeropplevelse")]
    [JsonPropertyName("Brukeropplevelse")]
    public Brukeropplevelse Brukeropplevelse { get; set; }

    [XmlElement("Kontakt", Order = 4)]
    [JsonProperty("Kontakt")]
    [JsonPropertyName("Kontakt")]
    public Kontakt Kontakt { get; set; }

    [XmlElement("Hjelpefelter", Order = 5)]
    [JsonProperty("Hjelpefelter")]
    [JsonPropertyName("Hjelpefelter")]
    public Hjelpefelter Hjelpefelter { get; set; }

    [XmlElement("KlassInfo", Order = 6)]
    [JsonProperty("KlassInfo")]
    [JsonPropertyName("KlassInfo")]
    public List<KlassInfo> KlassInfo { get; set; }

    [XmlElement("SkjemaData", Order = 7)]
    [JsonProperty("SkjemaData")]
    [JsonPropertyName("SkjemaData")]
    public SkjemaData SkjemaData { get; set; }

  }

  public class InternInfo
  {
    [MaxLength(1000)]
    [XmlElement("raNummer", Order = 1)]
    [JsonProperty("raNummer")]
    [JsonPropertyName("raNummer")]
    public string raNummer { get; set; }

    [MaxLength(1000)]
    [XmlElement("skjemaVersjon", Order = 2)]
    [JsonProperty("skjemaVersjon")]
    [JsonPropertyName("skjemaVersjon")]
    public string skjemaVersjon { get; set; }

    [MaxLength(1000)]
    [XmlElement("endepunktUrl", Order = 3)]
    [JsonProperty("endepunktUrl")]
    [JsonPropertyName("endepunktUrl")]
    public string endepunktUrl { get; set; }

    [MaxLength(1000)]
    [XmlElement("undersoekelsesNr", Order = 4)]
    [JsonProperty("undersoekelsesNr")]
    [JsonPropertyName("undersoekelsesNr")]
    public string undersoekelsesNr { get; set; }

    [MaxLength(1000)]
    [XmlElement("undersoekelsesInfoUrl", Order = 5)]
    [JsonProperty("undersoekelsesInfoUrl")]
    [JsonPropertyName("undersoekelsesInfoUrl")]
    public string undersoekelsesInfoUrl { get; set; }

    [MaxLength(1000)]
    [XmlElement("visOppgaveByrde", Order = 6)]
    [JsonProperty("visOppgaveByrde")]
    [JsonPropertyName("visOppgaveByrde")]
    public string visOppgaveByrde { get; set; }

    [MaxLength(1000)]
    [XmlElement("visBrukeropplevelse", Order = 7)]
    [JsonProperty("visBrukeropplevelse")]
    [JsonPropertyName("visBrukeropplevelse")]
    public string visBrukeropplevelse { get; set; }

    [MaxLength(1000)]
    [XmlElement("delregNr", Order = 8)]
    [JsonProperty("delregNr")]
    [JsonPropertyName("delregNr")]
    public string delregNr { get; set; }

    [MaxLength(1000)]
    [XmlElement("periodeFritekst", Order = 9)]
    [JsonProperty("periodeFritekst")]
    [JsonPropertyName("periodeFritekst")]
    public string periodeFritekst { get; set; }

    [MaxLength(1000)]
    [XmlElement("periodeFomDato", Order = 10)]
    [JsonProperty("periodeFomDato")]
    [JsonPropertyName("periodeFomDato")]
    public string periodeFomDato { get; set; }

    [MaxLength(1000)]
    [XmlElement("periodeTomDato", Order = 11)]
    [JsonProperty("periodeTomDato")]
    [JsonPropertyName("periodeTomDato")]
    public string periodeTomDato { get; set; }

    [MaxLength(1000)]
    [XmlElement("periodeType", Order = 12)]
    [JsonProperty("periodeType")]
    [JsonPropertyName("periodeType")]
    public string periodeType { get; set; }

    [MaxLength(1000)]
    [XmlElement("periodeNummer", Order = 13)]
    [JsonProperty("periodeNummer")]
    [JsonPropertyName("periodeNummer")]
    public string periodeNummer { get; set; }

    [MaxLength(1000)]
    [XmlElement("periodeAAr", Order = 14)]
    [JsonProperty("periodeAAr")]
    [JsonPropertyName("periodeAAr")]
    public string periodeAAr { get; set; }

    [XmlElement("periodeDato", Order = 15)]
    [JsonProperty("periodeDato")]
    [JsonPropertyName("periodeDato")]
    public string periodeDato { get; set; }

    [MaxLength(1000)]
    [XmlElement("enhetsIdent", Order = 16)]
    [JsonProperty("enhetsIdent")]
    [JsonPropertyName("enhetsIdent")]
    public string enhetsIdent { get; set; }

    [MaxLength(1000)]
    [XmlElement("enhetsType", Order = 17)]
    [JsonProperty("enhetsType")]
    [JsonPropertyName("enhetsType")]
    public string enhetsType { get; set; }

    [MaxLength(1000)]
    [XmlElement("enhetsOrgNr", Order = 18)]
    [JsonProperty("enhetsOrgNr")]
    [JsonPropertyName("enhetsOrgNr")]
    public string enhetsOrgNr { get; set; }

    [MaxLength(1000)]
    [XmlElement("enhetsNavn", Order = 19)]
    [JsonProperty("enhetsNavn")]
    [JsonPropertyName("enhetsNavn")]
    public string enhetsNavn { get; set; }

    [MaxLength(1000)]
    [XmlElement("enhetsGateadresse", Order = 20)]
    [JsonProperty("enhetsGateadresse")]
    [JsonPropertyName("enhetsGateadresse")]
    public string enhetsGateadresse { get; set; }

    [MaxLength(1000)]
    [XmlElement("enhetsPostnr", Order = 21)]
    [JsonProperty("enhetsPostnr")]
    [JsonPropertyName("enhetsPostnr")]
    public string enhetsPostnr { get; set; }

    [MaxLength(1000)]
    [XmlElement("enhetsPoststed", Order = 22)]
    [JsonProperty("enhetsPoststed")]
    [JsonPropertyName("enhetsPoststed")]
    public string enhetsPoststed { get; set; }

    [MaxLength(1000)]
    [XmlElement("enhetsAvdeling", Order = 23)]
    [JsonProperty("enhetsAvdeling")]
    [JsonPropertyName("enhetsAvdeling")]
    public string enhetsAvdeling { get; set; }

    [MaxLength(1000)]
    [XmlElement("reporteeOrgNr", Order = 24)]
    [JsonProperty("reporteeOrgNr")]
    [JsonPropertyName("reporteeOrgNr")]
    public string reporteeOrgNr { get; set; }

    [MaxLength(1000)]
    [XmlElement("parentId", Order = 25)]
    [JsonProperty("parentId")]
    [JsonPropertyName("parentId")]
    public string parentId { get; set; }

    [MaxLength(1000)]
    [XmlElement("childId", Order = 26)]
    [JsonProperty("childId")]
    [JsonPropertyName("childId")]
    public string childId { get; set; }

  }

  public class Tidsbruk
  {
    [XmlElement("hjelpAvAndre", Order = 1)]
    [JsonProperty("hjelpAvAndre")]
    [JsonPropertyName("hjelpAvAndre")]
    public string hjelpAvAndre { get; set; }

    [XmlElement("samletInfo", Order = 2)]
    [JsonProperty("samletInfo")]
    [JsonPropertyName("samletInfo")]
    public string samletInfo { get; set; }

    [Range(0, 9999)]
    [XmlElement("hjelpAvAndreMin", Order = 3)]
    [JsonProperty("hjelpAvAndreMin")]
    [JsonPropertyName("hjelpAvAndreMin")]
    public decimal? hjelpAvAndreMin { get; set; }

    [Range(0, 9999)]
    [XmlElement("samletInfoMin", Order = 4)]
    [JsonProperty("samletInfoMin")]
    [JsonPropertyName("samletInfoMin")]
    public decimal? samletInfoMin { get; set; }

    [Range(0, 9999)]
    [XmlElement("utfyllingMin", Order = 5)]
    [JsonProperty("utfyllingMin")]
    [JsonPropertyName("utfyllingMin")]
    public decimal? utfyllingMin { get; set; }

  }

  public class Brukeropplevelse
  {
    [XmlElement("enkeltKrevende", Order = 1)]
    [JsonProperty("enkeltKrevende")]
    [JsonPropertyName("enkeltKrevende")]
    public string enkeltKrevende { get; set; }

    [MaxLength(1000)]
    [XmlElement("krevendeForh", Order = 2)]
    [JsonProperty("krevendeForh")]
    [JsonPropertyName("krevendeForh")]
    public string krevendeForh { get; set; }

    [MaxLength(1000)]
    [XmlElement("forklarKrevendeForh", Order = 3)]
    [JsonProperty("forklarKrevendeForh")]
    [JsonPropertyName("forklarKrevendeForh")]
    public string forklarKrevendeForh { get; set; }

    [MaxLength(1000)]
    [XmlElement("krevendeForhDLId", Order = 4)]
    [JsonProperty("krevendeForhDLId")]
    [JsonPropertyName("krevendeForhDLId")]
    public string krevendeForhDLId { get; set; }

  }

  public class Kontakt
  {
    [MaxLength(200)]
    [XmlElement("kontaktPersonNavn", Order = 1)]
    [JsonProperty("kontaktPersonNavn")]
    [JsonPropertyName("kontaktPersonNavn")]
    public string kontaktPersonNavn { get; set; }

    [MaxLength(200)]
    [XmlElement("kontaktPersonEpost", Order = 2)]
    [JsonProperty("kontaktPersonEpost")]
    [JsonPropertyName("kontaktPersonEpost")]
    public string kontaktPersonEpost { get; set; }

    [MaxLength(25)]
    [RegularExpression(@"^((00)?|(\+)?|()?)\d{8,}$")]
    [XmlElement("kontaktPersonTelefon", Order = 3)]
    [JsonProperty("kontaktPersonTelefon")]
    [JsonPropertyName("kontaktPersonTelefon")]
    public string kontaktPersonTelefon { get; set; }

    [XmlElement("kontaktInfoBekreftet", Order = 4)]
    [JsonProperty("kontaktInfoBekreftet")]
    [JsonPropertyName("kontaktInfoBekreftet")]
    public string kontaktInfoBekreftet { get; set; }

    [MaxLength(2000)]
    [XmlElement("kontaktInfoKommentar", Order = 5)]
    [JsonProperty("kontaktInfoKommentar")]
    [JsonPropertyName("kontaktInfoKommentar")]
    public string kontaktInfoKommentar { get; set; }

  }

  public class Hjelpefelter
  {
    [MaxLength(100)]
    [XmlElement("hjelpefelt1", Order = 1)]
    [JsonProperty("hjelpefelt1")]
    [JsonPropertyName("hjelpefelt1")]
    public string hjelpefelt1 { get; set; }

    [MaxLength(100)]
    [XmlElement("hjelpefelt2", Order = 2)]
    [JsonProperty("hjelpefelt2")]
    [JsonPropertyName("hjelpefelt2")]
    public string hjelpefelt2 { get; set; }

    [MaxLength(100)]
    [XmlElement("hjelpefelt3", Order = 3)]
    [JsonProperty("hjelpefelt3")]
    [JsonPropertyName("hjelpefelt3")]
    public string hjelpefelt3 { get; set; }

    [MaxLength(100)]
    [XmlElement("hjelpefelt4", Order = 4)]
    [JsonProperty("hjelpefelt4")]
    [JsonPropertyName("hjelpefelt4")]
    public string hjelpefelt4 { get; set; }

    [MaxLength(100)]
    [XmlElement("hjelpefelt5", Order = 5)]
    [JsonProperty("hjelpefelt5")]
    [JsonPropertyName("hjelpefelt5")]
    public string hjelpefelt5 { get; set; }

    [MaxLength(100)]
    [XmlElement("hjelpefelt6", Order = 6)]
    [JsonProperty("hjelpefelt6")]
    [JsonPropertyName("hjelpefelt6")]
    public string hjelpefelt6 { get; set; }

    [MaxLength(100)]
    [XmlElement("hjelpefelt7", Order = 7)]
    [JsonProperty("hjelpefelt7")]
    [JsonPropertyName("hjelpefelt7")]
    public string hjelpefelt7 { get; set; }

    [MaxLength(100)]
    [XmlElement("hjelpefelt8", Order = 8)]
    [JsonProperty("hjelpefelt8")]
    [JsonPropertyName("hjelpefelt8")]
    public string hjelpefelt8 { get; set; }

    [MaxLength(100)]
    [XmlElement("hjelpefelt9", Order = 9)]
    [JsonProperty("hjelpefelt9")]
    [JsonPropertyName("hjelpefelt9")]
    public string hjelpefelt9 { get; set; }

    [MaxLength(100)]
    [XmlElement("hjelpefelt10", Order = 10)]
    [JsonProperty("hjelpefelt10")]
    [JsonPropertyName("hjelpefelt10")]
    public string hjelpefelt10 { get; set; }

  }

  public class KlassInfo
  {
    [MaxLength(1000)]
    [XmlElement("KlassID", Order = 1)]
    [JsonProperty("KlassID")]
    [JsonPropertyName("KlassID")]
    public string KlassID { get; set; }

    [MaxLength(1000)]
    [XmlElement("KlassDatamodellNode", Order = 2)]
    [JsonProperty("KlassDatamodellNode")]
    [JsonPropertyName("KlassDatamodellNode")]
    public string KlassDatamodellNode { get; set; }

  }

  public class SkjemaData
  {
    [XmlElement("investMaskinerJaNei", Order = 1)]
    [JsonProperty("investMaskinerJaNei")]
    [JsonPropertyName("investMaskinerJaNei")]
    public string investMaskinerJaNei { get; set; }

    [Range(0, 99999999999)]
    [XmlElement("investMaskinerSum", Order = 2)]
    [JsonProperty("investMaskinerSum")]
    [JsonPropertyName("investMaskinerSum")]
    public decimal? investMaskinerSum { get; set; }

    [XmlElement("merverdiMaskinerRefJaNei", Order = 3)]
    [JsonProperty("merverdiMaskinerRefJaNei")]
    [JsonPropertyName("merverdiMaskinerRefJaNei")]
    public string merverdiMaskinerRefJaNei { get; set; }

    [Range(0, 99999999999)]
    [XmlElement("merverdiMaskinerRefSum", Order = 4)]
    [JsonProperty("merverdiMaskinerRefSum")]
    [JsonPropertyName("merverdiMaskinerRefSum")]
    public decimal? merverdiMaskinerRefSum { get; set; }

    [XmlElement("planInvestMaskinerJaNei", Order = 5)]
    [JsonProperty("planInvestMaskinerJaNei")]
    [JsonPropertyName("planInvestMaskinerJaNei")]
    public string planInvestMaskinerJaNei { get; set; }

    [Range(0, 99999999999)]
    [XmlElement("planInvestMaskinerSum", Order = 6)]
    [JsonProperty("planInvestMaskinerSum")]
    [JsonPropertyName("planInvestMaskinerSum")]
    public decimal? planInvestMaskinerSum { get; set; }

    [XmlElement("investBilerJaNei", Order = 7)]
    [JsonProperty("investBilerJaNei")]
    [JsonPropertyName("investBilerJaNei")]
    public string investBilerJaNei { get; set; }

    [Range(0, 99999999999)]
    [XmlElement("investBilerSum", Order = 8)]
    [JsonProperty("investBilerSum")]
    [JsonPropertyName("investBilerSum")]
    public decimal? investBilerSum { get; set; }

    [XmlElement("merverdiBilerRefJaNei", Order = 9)]
    [JsonProperty("merverdiBilerRefJaNei")]
    [JsonPropertyName("merverdiBilerRefJaNei")]
    public string merverdiBilerRefJaNei { get; set; }

    [Range(0, 99999999999)]
    [XmlElement("merverdibilerRefSum", Order = 10)]
    [JsonProperty("merverdibilerRefSum")]
    [JsonPropertyName("merverdibilerRefSum")]
    public decimal? merverdibilerRefSum { get; set; }

    [XmlElement("planInvestBilerJaNei", Order = 11)]
    [JsonProperty("planInvestBilerJaNei")]
    [JsonPropertyName("planInvestBilerJaNei")]
    public string planInvestBilerJaNei { get; set; }

    [Range(0, 99999999999)]
    [XmlElement("planInvestBilerSum", Order = 12)]
    [JsonProperty("planInvestBilerSum")]
    [JsonPropertyName("planInvestBilerSum")]
    public decimal? planInvestBilerSum { get; set; }

    [XmlElement("investByggJaNei", Order = 13)]
    [JsonProperty("investByggJaNei")]
    [JsonPropertyName("investByggJaNei")]
    public string investByggJaNei { get; set; }

    [Range(0, 99999999999)]
    [XmlElement("investByggSum", Order = 14)]
    [JsonProperty("investByggSum")]
    [JsonPropertyName("investByggSum")]
    public decimal? investByggSum { get; set; }

    [XmlElement("merverdiByggRefJaNei", Order = 15)]
    [JsonProperty("merverdiByggRefJaNei")]
    [JsonPropertyName("merverdiByggRefJaNei")]
    public string merverdiByggRefJaNei { get; set; }

    [Range(0, 99999999999)]
    [XmlElement("merverdiByggRefSum", Order = 16)]
    [JsonProperty("merverdiByggRefSum")]
    [JsonPropertyName("merverdiByggRefSum")]
    public decimal? merverdiByggRefSum { get; set; }

    [XmlElement("planInvestByggJaNei", Order = 17)]
    [JsonProperty("planInvestByggJaNei")]
    [JsonPropertyName("planInvestByggJaNei")]
    public string planInvestByggJaNei { get; set; }

    [Range(0, 99999999999)]
    [XmlElement("planInvestByggSum", Order = 18)]
    [JsonProperty("planInvestByggSum")]
    [JsonPropertyName("planInvestByggSum")]
    public decimal? planInvestByggSum { get; set; }

  }
}
