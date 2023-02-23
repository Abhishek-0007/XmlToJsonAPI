using System.Xml;
using XmlToJsonAPI.Models.RequestViewModel;
using XmlToJsonAPI.Models.ResponseViewModel;

namespace XmlToJsonAPI.Services.Interfaces
{
    public interface IXmlTemplateService
    {
        public Task<Object> GetXmlDocumentAsync(String code);
    }
}
