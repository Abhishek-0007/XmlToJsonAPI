using XmlToJsonAPI.DAL.Entity;
using XmlToJsonAPI.Models.RequestViewModel;

namespace XmlToJsonAPI.DAL.Repositories.Interfaces
{
    public interface IXmlRepository
    {
        public Task<IEnumerable<XmlTemplate>> GetAllXmlTemplateAsync();

        public Task<XmlTemplate> GetXmlTemplateByCodeAsync(String code);
    }
}
