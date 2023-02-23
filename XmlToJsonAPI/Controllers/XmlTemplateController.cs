using Microsoft.AspNetCore.Mvc;
using XmlToJsonAPI.DAL.Entity;
using XmlToJsonAPI.Models.RequestViewModel;
using XmlToJsonAPI.Models.ResponseViewModel;
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
        public async Task<Object> GetXmlTemplateAsync()
        {
            var response = await _service.GetXmlDocumentAsync("template-1");
            INFORMATION info = new INFORMATION();
            info.Timestamp = DateTime.Now;

            if(response != null)
            {
                info.Body = response;
                info.Code = "200";
                info.Message = "Success";
            }
            else
            {
                info.Body = null;
                info.Code = "404";
                info.Message = "Failed";
            }

            return info;
        }
    }
}
