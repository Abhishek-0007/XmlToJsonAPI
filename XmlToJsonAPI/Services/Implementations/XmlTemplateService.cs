using Microsoft.Extensions.Primitives;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using XmlToJsonAPI.DAL.Repositories.Interfaces;
using XmlToJsonAPI.Models;
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
        public async Task GetXmlDocumentAsync(string code)
        {
            var xmlTemplate = await _repository.GetXmlTemplateByCodeAsync(code);
            var xmlString = xmlTemplate.Xml;

            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(xmlString);
            Console.WriteLine(xmlString);
            ConvertToJson(xmlDocument);
        }

        private void ConvertToJson(XmlDocument xml)
        {
            string rootElement = xml.DocumentElement.Name;
            XmlNodeList root = xml.SelectNodes($"//{rootElement}");
            string result = "";

            INFORMATION inf = new INFORMATION()
            {
                AdditionalFields = new List<ADDITIONAL_FIELDS>()
            };

            InfoModel infoModel = new InfoModel()
            {
                Body = new Body()
                {
                   INFORMATIONS = new List<INFORMATION> {}
                }
            };



            try
            {
                foreach (XmlNode child in root.Item(0).ChildNodes)
                {
                    ADDITIONAL_FIELDS customClass = new ADDITIONAL_FIELDS();
                    foreach (XmlNode childNode in child.ChildNodes)
                    {
                        PropertyInfo pr = customClass.GetType().GetProperty(childNode.Name);

                        if (pr.Name.Equals(childNode.Name))
                        {
                            string value = childNode.InnerText;
                            pr.SetValue(customClass, value);
                        }
                    }
                    if (customClass != null)
                    {
                        inf.AdditionalFields.Add(customClass);
                    }
                }
                infoModel.Body.INFORMATIONS.Add(inf);
                infoModel.Message = "Success";
                infoModel.Code = "200";
                infoModel.Timestamp = DateTime.Now;
            }
            catch(Exception ex)
            {
                infoModel.Message = ex.Message;
                infoModel.Body = null;
                infoModel.Code = "404";
                infoModel.Timestamp = DateTime.Now;
            }

            result = JsonConvert.SerializeObject(infoModel);

            Console.WriteLine(result);


        }
    }
}
