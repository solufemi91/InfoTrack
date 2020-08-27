﻿using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using InfoTrack.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InfoTrack.WindsorInstallers
{
    public class RepositoryInstallers : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IGoogleSearchResultsRepository>().ImplementedBy<GoogleSearchResultsRepository>());
        }
    }
}