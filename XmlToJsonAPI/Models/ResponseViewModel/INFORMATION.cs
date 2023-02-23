using Newtonsoft.Json;
using System.Xml.Serialization;

namespace XmlToJsonAPI.Models.ResponseViewModel
{
    public class INFORMATION
    {
        [JsonIgnore]
        public DateTime? Timestamp { get; set; }

        [JsonIgnore]
        public string? Message { get; set; }

        [JsonIgnore]
        public string? Code { get; set; }

        public object Body { get; set; }
    }

    public class Information
    {
        [XmlElement("INFORMATION")]
        [JsonProperty("INFORMATION")]
        public Info Inform { get; set; }
    }
    public class Info
    {
        [XmlElement("ADDITIONAL_FIELDS")]
        [JsonProperty("ADDITIONAL_FIELDS")]
        public List<ADDITIONAL_FIELDS> ADDITIONAL_FIELDS { get; set; }
    }
    public class ADDITIONAL_FIELDS
    {
        [XmlElement("RSTERM")]
        [JsonProperty("RSTERM")]
        public string ProductType { get; set; }

        [XmlElement("ZPRDTYP")]
        [JsonProperty("ZPRDTYP")]
        public string RiskTerm { get; set; }

        [XmlElement("PMTERM")]
        [JsonProperty("PMTERM")]
        public string PremiumTerm { get; set; }

        [XmlElement("PAYMMETH")]
        [JsonProperty("PAYMMETH")]
        public string PaymentMethod { get; set; }

        [XmlElement("PAYFREQ")]
        [JsonProperty("PAYFREQ")]
        public string PaymentFrequency { get; set; }

        [XmlElement("RCDDATE")]
        [JsonProperty("RCDDATE")]
        public string RiskCommencementDate { get; set; }

        [XmlElement("LASEX")]
        [JsonProperty("LASEX")]
        public string LifeAssuredGender { get; set; }

        [XmlElement("LADOB")]
        [JsonProperty("LADOB")]
        public string LifeAssuredDateOfBirth { get; set; }

        [XmlElement("LACRTBL")]
        [JsonProperty("LACRTBL")]
        public string LifeAssuredComponentCode { get; set; }

        [XmlElement("LAINSPR")]
        [JsonProperty("LAINSPR")]
        public string LifeAssuredInstallmentPremium { get; set; }
    }

}
