using Serwis_UsprawniającyModelProdukcyjny.Models;
using Serwis_UsprawniającyModelProdukcyjny.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Serwis_UsprawniającyModelProdukcyjny.Services.Interfaces
{
    public interface IModuleService
    {
        Module GetModuleByName(string moduleName);
        OperationSuccessDTO<List<Module>> getModules();
        OperationSuccessDTO<Module> addModule(Module module);
        OperationSuccessDTO<Module> UpdateModule (Module module);
        OperationSuccessDTO<Module> DeleteModule(string nameModule);

    }
}