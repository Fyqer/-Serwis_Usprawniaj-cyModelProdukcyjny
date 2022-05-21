using Serwis_UsprawniającyModelProdukcyjny.Models;
using Serwis_UsprawniającyModelProdukcyjny.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Serwis_UsprawniającyModelProdukcyjny.Services.Interfaces
{
    public interface ISearchHistoryService
    {
        ResultCostDTO getSearchHistory(string cityName, ModuleListDTO moduleListDTO);
        OperationSuccessDTO<IList<SearchHistory>> GetSearchHiestories();
        OperationResultDTO AddSearchHistory(SearchHistory searchHistory);
    }
}