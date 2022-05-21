using Serwis_UsprawniającyModelProdukcyjny.Models;
using Serwis_UsprawniającyModelProdukcyjny.ModelsDTO;
using Serwis_UsprawniającyModelProdukcyjny.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Serwis_UsprawniającyModelProdukcyjny.Services.Implementations
{
    public class SearchHistoryService : ISearchHistoryService
    {
        private readonly CalculatorContext context;
        private readonly IModuleService moduleService;
        private readonly ICityService cityService;
        public SearchHistoryService(CalculatorContext context,IModuleService moduleService, ICityService cityService  )
        {
            this.context = context;
            this.moduleService = moduleService;
            this.cityService = cityService;
        }


        public OperationResultDTO AddSearchHistory(SearchHistory searchHistory)
        {
            context.SearchHistory.Add(searchHistory);
            context.SaveChanges();
            return new OperationSuccessDTO<SearchHistory> { Message = "Success" };
        }
        public ResultCostDTO getSearchHistory(string cityName, ModuleListDTO moduleListDTO)
        {


            var city = cityService.GetCityByName(cityName);

            if (city == null)
            {

                return new ResultCostDTO { InSearchHistory = false };
            }

           var searchHistoryList = context.SearchHistory.Where(x => x.CityId == city.id);

            if (searchHistoryList == null)
            {

                return new ResultCostDTO { InSearchHistory = false };
            }
            int counterModule = 0;
            foreach(SearchHistory searchHistrory in searchHistoryList)
            {

                counterModule = 0;
                foreach (string searchHistoryPar in moduleListDTO.ModuleList)
                {

                    if (searchHistrory.ModuleName1 == searchHistoryPar ||
                        searchHistrory.ModuleName2 == searchHistoryPar ||
                        searchHistrory.ModuleName3 == searchHistoryPar ||
                        searchHistrory.ModuleName4 == searchHistoryPar)
                    {
                        counterModule++;
                    }
                    else
                    {
                        break;
                    }
                }
                if(moduleListDTO.ModuleList.Count() == ModuleHasValue(searchHistrory) &&
                    moduleListDTO.ModuleList.Count() == counterModule)
                {
                    return new ResultCostDTO { InSearchHistory = true, Cost = searchHistrory.PrductionCost };        
                }
            }

            return new ResultCostDTO { InSearchHistory = false };
        }

        OperationSuccessDTO<IList<SearchHistory>> ISearchHistoryService.GetSearchHiestories()
        {

            List<SearchHistory> searchHistories = context.SearchHistory.ToList();
            return new OperationSuccessDTO<IList<SearchHistory>> { Message = "SUCCESS", Result = searchHistories };
        }


        private int ModuleHasValue(SearchHistory searchHistory) {
            int counter = 0;

            if(!(searchHistory.ModuleName1 == string.Empty))
            {
                counter++;
            }
            if (!(searchHistory.ModuleName2 == string.Empty))
            {
                counter++;
            }
            if (!(searchHistory.ModuleName3 == string.Empty))
            {
                counter++;
            }
            if (!(searchHistory.ModuleName4 == string.Empty))
            {
                counter++;
            }
           return counter;
        }
    }
}