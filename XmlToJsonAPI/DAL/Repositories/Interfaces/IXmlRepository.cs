using XmlToJsonAPI.DAL.Entity;

namespace XmlToJsonAPI.DAL.Repositories.Interfaces
{
    public interface IXmlRepository
    {
        public Task<IEnumerable<XmlTemplate>> GetAllXmlTemplateAsync();

        public Task<XmlTemplate> GetXmlTemplateByCodeAsync(string code);
    }
}
