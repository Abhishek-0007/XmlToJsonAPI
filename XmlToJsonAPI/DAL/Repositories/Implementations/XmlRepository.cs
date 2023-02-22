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
           var list = await _context.XmlTemplates.ToListAsync();
            return list;
        }

        public async Task<XmlTemplate> GetXmlTemplateByCodeAsync(string code)
        {
            var item = await _context.XmlTemplates.Where(t => t.Code.Equals(code)).FirstOrDefaultAsync();
            return item;
        }
    }
}
