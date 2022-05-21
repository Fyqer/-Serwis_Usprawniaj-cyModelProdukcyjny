using Serwis_UsprawniającyModelProdukcyjny.Models;
using Serwis_UsprawniającyModelProdukcyjny.ModelsDTO;
using Serwis_UsprawniającyModelProdukcyjny.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Serwis_UsprawniającyModelProdukcyjny.Services.Implementations
{
    public class CityService: ICityService
    {
        private readonly CalculatorContext context;
        public CityService(CalculatorContext context)
        {
            this.context = context;
        }

        public City GetCityByName(string cityName)
        {
           return context.City.Where(x => x.Name == cityName).FirstOrDefault();
        }


        public OperationResultDTO UpdateTransportCost(string cityName, double transprotCost)
        {
            var updateCity = context.City.Where(x => x.Name == cityName).FirstOrDefault();

            if(updateCity == null)
            {

                return new OperationErrorDTO { Code = 404, Message = $"City with name {cityName} does not exist" };
            }
            updateCity.TransportCost = transprotCost;
            context.SaveChanges();
            return new OperationSuccessDTO<City> { Message = "Success" };
        }

        public OperationResultDTO UpdateCostOfWorkingHour( string cityName, double workingHourcost)
        {
            var updateCity = context.City.Where(x => x.Name == cityName).FirstOrDefault();

            if (updateCity == null)
            {

                return new OperationErrorDTO { Code = 404, Message = $"City with name {cityName} does not exist" };
            }
            updateCity.CostOfWorkingPerHour = workingHourcost;
            context.SaveChanges();
            return new OperationSuccessDTO<City> { Message = "Success" };
        }


        public OperationSuccessDTO<IList<City>> GetCities()
        {
            List<City> cities = context.City.ToList();

            return new OperationSuccessDTO<IList<City>>{ Message = "Success", Result = cities};
        }

        public OperationResultDTO AddCity(City city)
        {
            context.City.Add(city);
            context.SaveChanges();
            return new OperationSuccessDTO<City> { Message = "Success" };
        }
        public OperationResultDTO DeleteCity(string cityName)
        {
            var city = context.City.Where(x => x.Name == cityName).FirstOrDefault();

            context.City.Remove(city);
            context.SaveChanges();
            return new OperationSuccessDTO<City> { Message = "Success" };
        }


    }
}