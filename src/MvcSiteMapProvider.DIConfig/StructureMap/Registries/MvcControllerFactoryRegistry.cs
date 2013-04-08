﻿using System;
using System.Web.Mvc;
using StructureMap.Configuration.DSL;
using MvcSiteMapProvider.Web.Mvc;
using DI.StructureMap.Conventions;

namespace DI.StructureMap.Registries
{
    internal class MvcControllerFactoryRegistry
        : Registry
    {
        public MvcControllerFactoryRegistry()
        {
            this.For<IControllerFactory>()
                .Singleton()
                .Use<InjectableControllerFactory>();
        }
    }
}