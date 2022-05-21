using Serwis_UsprawniającyModelProdukcyjny.Models;
using Serwis_UsprawniającyModelProdukcyjny.ModelsDTO;
using Serwis_UsprawniającyModelProdukcyjny.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Serwis_UsprawniającyModelProdukcyjny.Services.Implementations
{
    public class ModuleService: IModuleService
    {
        private readonly CalculatorContext context;
        public ModuleService(CalculatorContext context)
        {
            this.context = context;
        }

        public OperationSuccessDTO<Module> addModule(Module module)
        {
            context.Module.Add(module);
            context.SaveChanges();
            return new OperationSuccessDTO<Module> { Message = "Success" };
        }


        public Module GetModuleByName(string moduleName)
        {
            return context.Module.Where(module => module.Name == moduleName).SingleOrDefault();
        }

        public OperationSuccessDTO<List<Module>> getModules()
        {
            List<Module> modules = context.Module.ToList();
            return new OperationSuccessDTO<List<Module>> { Message = "Success", Result = modules };
        }


        public OperationSuccessDTO<Module>  DeleteModule(string name)
        {
            var module = context.Module.Where(x => x.Name == name).FirstOrDefault();

            context.Module.Remove(module);
            context.SaveChanges();
            return new OperationSuccessDTO<Module> { Message = "Success"};
        }

        public OperationSuccessDTO<Module> UpdateModule(Module module)
        {
            var mod = context.Module.Where(x => x.Name == module.Name).FirstOrDefault();
            mod.Name = module.Name;
            mod.Price = module.Price;
            mod.Weight = module.Weight;
            mod.AssemblyTime = module.AssemblyTime;
            mod.Code = module.Code;
            mod.Description = module.Description;
            context.SaveChanges();
            return new OperationSuccessDTO<Module> { Message = "Success" };
        }
    }
}