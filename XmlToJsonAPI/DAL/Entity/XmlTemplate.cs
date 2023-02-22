using System.ComponentModel.DataAnnotations.Schema;

namespace XmlToJsonAPI.DAL.Entity
{
    [Table("xmlTbl")]
    public class XmlTemplate
    {
        public int? Id { get; set; }
        public string? Code { get; set; }
        public string? Xml { get; set; }
        public bool isDeleted { get; set; }

    }
}
