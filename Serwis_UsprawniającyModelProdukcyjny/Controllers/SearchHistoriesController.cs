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
    public class SearchHistoriesController : ApiController
    {
        private readonly ISearchHistoryService searchHistoryService;
        public SearchHistoriesController(ISearchHistoryService searchHistoryService)
        {
            this.searchHistoryService = searchHistoryService;
        }

        [HttpGet]
        [Route("SearchHistories/GetSearchHistory")]
        public IHttpActionResult GetSearchHistory()
        {
            return Content(System.Net.HttpStatusCode.OK,
                searchHistoryService.GetSearchHiestories().Result);
        }



        [HttpPost]
        [ResponseType(typeof(void))]
        [Route("SearchHistories/AddSearchHistories")]
        public IHttpActionResult AddSearchHistory(SearchHistory searchHistory)
        {
            if (searchHistory== null)
            {
                return Content(System.Net.HttpStatusCode.BadRequest, "Object searchhistory is null");
            }
            var response = searchHistoryService.AddSearchHistory(searchHistory);
            if (response.Message.Equals("Success"))
            {
                return Content(System.Net.HttpStatusCode.OK, response.Message);
            }
            return Content(System.Net.HttpStatusCode.BadRequest, "Error");
        }

    }
}