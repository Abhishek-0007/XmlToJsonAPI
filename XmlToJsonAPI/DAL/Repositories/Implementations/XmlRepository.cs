using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.EntityFrameworkCore;
using XmlToJsonAPI.DAL.DbContexts;
using XmlToJsonAPI.DAL.Entity;
using IXmlRepository = XmlToJsonAPI.DAL.Repositories.Interfaces.IXmlRepository;

namespace XmlToJsonAPI.DAL.Repositories.Implementations
{
    public class XmlRepository : IXmlRepository
    {
        private readonly ApplicationDbContext _context;
        public XmlRepository(IServiceProvider serviceProvider) 
        {
            _context = serviceProvider.GetRequiredService<ApplicationDbContext>();
        }

        public async Task<IEnumerable<XmlTemplate>> GetAllXmlTemplateAsync()
        {
            List<XmlTemplate> list;

            try
            {
              list =  await _context.XmlTemplates.ToListAsync();
            }
            catch (Exception ex)
            {
                list = null;
            }

            return list;
        }

        public async Task<XmlTemplate> GetXmlTemplateByCodeAsync(string code)
        {
            XmlTemplate item;
            try
            {
                item = await _context.XmlTemplates.Where(t => t.Code.Equals(code)).FirstOrDefaultAsync();
            }
            catch(Exception ex)
            {
                item = null;
            }

            return item;
        }
    }
}
