using Microsoft.AspNetCore.Mvc;
using XmlToJsonAPI.DAL.Entity;
using XmlToJsonAPI.Services.Interfaces;

namespace XmlToJsonAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class XmlTemplateController : ControllerBase
    {
        private readonly IXmlTemplateService _service;
        public XmlTemplateController(IServiceProvider serviceProvider)
        {
            _service = serviceProvider.GetRequiredService<IXmlTemplateService>();
        }

        [HttpGet]
        public async Task<IActionResult> GetXmlTemplate()
        {
            var code = "template-1";
            await _service.GetXmlDocumentAsync(code);

            return NoContent();
        }
    }
}
