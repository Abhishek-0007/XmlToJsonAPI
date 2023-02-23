using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using XmlToJsonAPI.DAL.Repositories.Interfaces;
using XmlToJsonAPI.Models.RequestViewModel;
using XmlToJsonAPI.Models.ResponseViewModel;
using XmlToJsonAPI.Services.Interfaces;

namespace XmlToJsonAPI.Services.Implementations
{
    public class XmlTemplateService : IXmlTemplateService
    {
        private readonly IXmlRepository _repository;
        public XmlTemplateService(IServiceProvider serviceProvider) 
        { 
            _repository = serviceProvider.GetRequiredService<IXmlRepository>();
        }
        public async Task<Object> GetXmlDocumentAsync(String code)
        {
            Object response = new Object();
            try
            {
                var xmlTemplate = await _repository.GetXmlTemplateByCodeAsync(code);
                var xmlString = xmlTemplate.Xml;
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(xmlString);
                response = ConvertToJson(xmlDocument);
            }
            catch (Exception ex)
            {
                response = null;
            }
            
            return response;
        }

        private Object ConvertToJson(XmlDocument xml)
        {
            var fromXml = JsonConvert.SerializeXmlNode(xml);

            JObject jObject = JObject.Parse(fromXml);

            return JsonConvert.DeserializeObject<Information>(fromXml);  
        }
    }
}
