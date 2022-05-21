using Serwis_UsprawniającyModelProdukcyjny.Models;
using Serwis_UsprawniającyModelProdukcyjny.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Mvc;
using HttpDeleteAttribute = System.Web.Http.HttpDeleteAttribute;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using HttpPutAttribute = System.Web.Http.HttpPutAttribute;
using RouteAttribute = System.Web.Http.RouteAttribute;

namespace Serwis_UsprawniającyModelProdukcyjny.Controllers
{
    public class ModulesController : ApiController
    {
        private readonly IModuleService moduleService;
        public ModulesController(IModuleService moduleService)
        {
            this.moduleService = moduleService;
        }

        [HttpGet]
        [Route("Module/GetModules")]
        public IHttpActionResult GetModules()
        {
            return Content(System.Net.HttpStatusCode.OK, moduleService.getModules().Result);
        }


        [HttpGet]
        [Route("Module/GetModule/{name}")]
        public IHttpActionResult GetModuleByName(string name)
        {
            Module module = moduleService.GetModuleByName(name);
            if(module == null)
            {
                return NotFound();
            }
            return Content(System.Net.HttpStatusCode.OK, module);
        }

        [HttpPut]
        [Route("Cities/UpdateModule")]
        public IHttpActionResult UpdateModule(Module module )
        {
           return Content<string>(System.Net.HttpStatusCode.OK, moduleService.UpdateModule(module).Message);
        }


        [HttpPost]
        [ResponseType(typeof(void))]
        [Route("Cities/AddModule")]
        public IHttpActionResult AddModule(Module module)
        {
            if (module == null)
            {
                return Content(System.Net.HttpStatusCode.BadRequest, "Object module is null");
            }
            var response = moduleService.addModule(module);
            if (response.Message.Equals("Success"))
            {
                return Content(System.Net.HttpStatusCode.OK, response.Message);
            }
            return Content(System.Net.HttpStatusCode.BadRequest, "Error");
        }



        [HttpDelete]
        [Route("Cities/DeleteModule/{name}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult DeleteModule(string name)
        {
            if (name == null)
            {
                return Content(System.Net.HttpStatusCode.BadRequest, "Object name is null");
            }

            var response = moduleService.DeleteModule(name);
            if (response.Message.Equals("Success"))
            {
                return Content(System.Net.HttpStatusCode.OK, response.Message);
            }
            return Content(System.Net.HttpStatusCode.BadRequest, "Error");
        }

    }
}