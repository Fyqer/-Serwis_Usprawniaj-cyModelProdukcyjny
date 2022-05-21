using Serwis_UsprawniającyModelProdukcyjny.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Serwis_UsprawniającyModelProdukcyjny.Services.Interfaces
{
    public interface ICalculatorCostService
    {
        OperationResultDTO CalculateCost(string cityName, ModuleListDTO moduleListDTO);
    }
}