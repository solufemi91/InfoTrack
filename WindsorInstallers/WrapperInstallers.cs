using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using InfoTrack.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InfoTrack.WindsorInstallers
{
    public class WrapperInstallers : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IScrappingWrapper>().ImplementedBy<ScrappingWrapper>());
        }
    }
}