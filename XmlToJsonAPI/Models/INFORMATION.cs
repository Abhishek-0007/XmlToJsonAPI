using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Xml.Serialization;
using System.Xml;

namespace XmlToJsonAPI.Models
{
    public class INFORMATION
    {
        [XmlElement("ADDITIONAL_FIELDS")]
        [JsonProperty("ADDITIONAL_FIELDS")]
        public List<ADDITIONAL_FIELDS> AdditionalFields { get; set; }
    }
    public class InfoModel
    {
        public DateTime? Timestamp { get; set; }
        public string Message { get; set; }
        public string Code { get; set; }
        public Body? Body { get; set; }
    }

    public class Body
    {
        public List<INFORMATION> INFORMATIONS { get; set; }
    }
    public class ADDITIONAL_FIELDS
    {
        [XmlElement("RSTERM")]
        [JsonProperty("ProductType")]
        public string ZPRDTYP { get; set; }

        [XmlElement("ZPRDTYP")]
        [JsonProperty("RiskTerm")]
        public string RSTERM { get; set; }

        [XmlElement("PMTERM")]
        [JsonProperty("PremiumTerm")]
        public string PMTERM { get; set; }

        [XmlElement("PAYMMETH")]
        [JsonProperty("PaymentMethod")]
        public string PAYMMETH { get; set; }

        [XmlElement("PAYFREQ")]
        [JsonProperty("PaymentFrequency")]
        public string PAYFREQ { get; set; }

        [XmlElement("RCDDATE")]
        [JsonProperty("RiskCommencementDate")]
        public string RCDDATE { get; set; }

        [XmlElement("LASEX")]
        [JsonProperty("LifeAssuredGender")]
        public string LASEX { get; set; }

        [XmlElement("LADOB")]
        [JsonProperty("LifeAssuredDateOfBirth")]
        public string LADOB { get; set; }

        [XmlElement("LACRTBL")]
        [JsonProperty("LifeAssuredComponentCode")]
        public string LACRTBL { get; set; }

        [XmlElement("LAINSPR")]
        [JsonProperty("LifeAssuredInstallmentPremium")]
        public string LAINSPR { get; set; }
    }

    public class MyXmlData
    {
        [XmlElement("ZPRDTYP")]
        public string ProductType { get; set; }

        [XmlElement("RSTERM")]
        public int RiskTerm { get; set; }

        [XmlElement("PMTERM")]
        public int PremiumTerm { get; set; }

        [XmlElement("PAYMMETH")]
        public string PaymentMethod { get; set; }

        [XmlElement("PAYFREQ")]
        public string PaymentFrequency { get; set; }

        [XmlElement("RCDDATE")]
        public string RiskCommencementDate { get; set; }

        [XmlElement("LASEX")]
        public string LifeAssuredGender { get; set; }

        [XmlElement("LADOB")]
        public string LifeAssuredDateOfBirth { get; set; }

        [XmlElement("LACRTBL")]
        public string LifeAssuredComponentCode { get; set; }

        [XmlElement("LAINSPR")]
        public int LifeAssuredInstallmentPremium { get; set; }
    }
    public class JsonObjectNames
    {
        public string ProductType { get; set; }
        public string RiskTerm { get; set; }
        public string PremiumTerm { get; set; }
        public string PaymentMethod { get; set; }
        public string PaymentFrequency { get; set; }
        public string RiskCommencementDate { get; set; }
        public string LifeAssuredGender { get; set; }
        public string LifeAssuredDateOfBirth { get; set; }
        public string LifeAssuredComponentCode { get; set; }
        public string LifeAssuredInstallmentPremium { get; set; }
    }
}

