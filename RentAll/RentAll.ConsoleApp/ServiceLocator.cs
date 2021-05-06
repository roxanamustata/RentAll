using RentAll.Domain.Interfaces;
using RentAll.Domain.Models;
using RentAll.Infrastructure.Repositories;
using RentAll.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Unity;
using Unity.Injection;

namespace RentAll.ConsoleApp
{
   public static class ServiceLocator
    {
        private static readonly IUnityContainer Container=new UnityContainer();


        public static void RegisterAll()
        {
            Container.RegisterType<ICenterRepository, CenterRepository>();
            Container.RegisterType<ICompanyRepository, CompanyRepository>();
            Container.RegisterType<IUserRepository, UserRepository>();

            Container.RegisterType<ICenterService, CenterService>();

            Container.RegisterType<IUnit, StorageUnit>(new InjectionConstructor("Storage"));
            Container.RegisterType<IUnit, RetailUnit>(new InjectionConstructor("Retail"));
            Container.RegisterType<IUnit, OfficeUnit>(new InjectionConstructor("Office"));

        }

        public static T Resolve<T>()
        {
            return Container.Resolve<T>();
        }

        public static T Resolve<T>(string type)
        {
            return Container.Resolve<T>(type);
        }
    }
}
