using Serwis_UsprawniającyModelProdukcyjny.Models;
using Serwis_UsprawniającyModelProdukcyjny.ModelsDTO;
using Serwis_UsprawniającyModelProdukcyjny.Services.Implementations;
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
    public class ShowResultController : ApiController
    {
        private readonly IShowResultService showResultService;
        public ShowResultController(IShowResultService showResultService)
        {
           this.showResultService =  showResultService;
        }

        [HttpGet]
        [Route("ShowResults/Get")]
        public IHttpActionResult Get(ShowResultDTO showResultDTO)
        {
            var result = this.showResultService.PresentResult(showResultDTO.CityName, showResultDTO.ModuleListDTO);
            if (result.Cost == -1)
            {
                return Content(System.Net.HttpStatusCode.ExpectationFailed, "Error");


            }

            return Content<ResultCostDTO>(System.Net.HttpStatusCode.OK, 
                showResultService.PresentResult(showResultDTO.CityName,showResultDTO.ModuleListDTO));
        }


  

    }
}