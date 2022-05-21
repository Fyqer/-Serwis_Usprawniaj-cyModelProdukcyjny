using Serwis_UsprawniającyModelProdukcyjny.Models;
using Serwis_UsprawniającyModelProdukcyjny.ModelsDTO;
using Serwis_UsprawniającyModelProdukcyjny.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Serwis_UsprawniającyModelProdukcyjny.Services.Implementations
{
    public class ShowResultService : IShowResultService
    {
        private readonly ICityService cityService;
        private readonly ICalculatorCostService calculatorService;
        private readonly ISearchHistoryService searchHistoryService;

        public ShowResultService(ICityService cityService, ICalculatorCostService calculatorService, ISearchHistoryService searchHistoryService)
        {
            this.cityService = cityService;
            this.calculatorService = calculatorService;
            this.searchHistoryService = searchHistoryService;
        }

        public ResultCostDTO PresentResult(string cityName, ModuleListDTO moduleListDTO)
        {
            var checkInHistory = searchHistoryService.getSearchHistory(cityName, moduleListDTO);

            OperationSuccessDTO<ResultCostDTO> calculateCost = null;

            if (checkInHistory.InSearchHistory == true)
            {
                return new ResultCostDTO { Cost = checkInHistory.Cost, InSearchHistory = checkInHistory.InSearchHistory };
            }
            try
            {
                calculateCost = (OperationSuccessDTO<ResultCostDTO>)calculatorService.CalculateCost(cityName, moduleListDTO);
            }
            catch
            {
                return new ResultCostDTO { Cost = 1, InSearchHistory = false };
            }
            var city = cityService.GetCityByName(cityName);
            SearchHistory searchHistory = new SearchHistory
            {
                CityId = city.id,
                PrductionCost = calculateCost.Result.Cost,
                ModuleName1 = moduleListDTO.ModuleList.Count > 0 ?
                moduleListDTO.ModuleList[0] : string.Empty,
                ModuleName2 = moduleListDTO.ModuleList.Count > 1 ?
                moduleListDTO.ModuleList[1] : string.Empty,
                ModuleName3 = moduleListDTO.ModuleList.Count > 2 ?
                moduleListDTO.ModuleList[2] : string.Empty,
                ModuleName4 = moduleListDTO.ModuleList.Count > 2 ?
                moduleListDTO.ModuleList[3] : string.Empty,
            };
            searchHistoryService.AddSearchHistory(searchHistory);
            return new ResultCostDTO { Cost = calculateCost.Result.Cost, InSearchHistory = false };
        }
    }
}