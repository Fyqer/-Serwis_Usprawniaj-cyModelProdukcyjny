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
    public class CitiesController : ApiController
    {
        private readonly ICityService cityService;
        public CitiesController(ICityService cityService)
        {
            this.cityService = cityService;
        }

        [HttpGet]
        [Route("Cities/GetCities")]
        public IHttpActionResult GetCities()
        {
            return Content(System.Net.HttpStatusCode.OK, cityService.GetCities().Result);
        }


        [HttpGet]
        [Route("Cities/GetCityByName/{name}")]
        [ResponseType(typeof(City))]
        public IHttpActionResult GetCityByName(string name)
        {
            City city = cityService.GetCityByName(name);
            if(city == null)
            {
                return NotFound();
            }
            return Content(System.Net.HttpStatusCode.OK, city);
        }

        [HttpPut]
        [Route("Cities/UpdateCostOfWork")]
        public IHttpActionResult UpdateCostOfWork(City city)
        {
            var response = cityService.UpdateCostOfWorkingHour(city.Name, city.CostOfWorkingPerHour);
            if (response.Message.Equals("Success"))
            {
                return Content(System.Net.HttpStatusCode.OK, response.Message);
            }
            return Content(System.Net.HttpStatusCode.BadRequest, response.Message);
        }


        [HttpPost]
        [ResponseType(typeof(void))]
        [Route("Cities/AddCity")]
        public IHttpActionResult AddCity(City city)
        {
            if (city == null)
            {
                return Content(System.Net.HttpStatusCode.BadRequest, "Object city is null");
            }
            var response = cityService.AddCity(city);
            if (response.Message.Equals("Success"))
            {
                return Content(System.Net.HttpStatusCode.OK, response.Message);
            }
            return Content(System.Net.HttpStatusCode.BadRequest, "Error");
        }



        [HttpDelete]
        [Route("Cities/DeleteCity/{name}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult DeleteCity(string name)
        {
            if (name == null)
            {
                return Content(System.Net.HttpStatusCode.BadRequest, "Object name is null");
            }

            var response = cityService.DeleteCity(name);
            if (response.Message.Equals("Success"))
            {
                return Content(System.Net.HttpStatusCode.OK, response.Message);
            }
            return Content(System.Net.HttpStatusCode.BadRequest, "Error");
        }

    }
}