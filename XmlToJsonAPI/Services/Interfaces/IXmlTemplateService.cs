using System.Xml;

namespace XmlToJsonAPI.Services.Interfaces
{
    public interface IXmlTemplateService
    {
        public Task GetXmlDocumentAsync(String code);
    }
}
