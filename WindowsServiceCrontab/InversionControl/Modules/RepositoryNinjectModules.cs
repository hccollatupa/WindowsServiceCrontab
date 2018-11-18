using Ninject.Modules;
using Repositories.Contracts;
using Repositories.Implementatios;

namespace InversionControl.Modules
{
    public class RepositoryNinjectModules : NinjectModule
    {
        public override void Load()
        {
            Bind<IClientRepository>().To<ClientRepository>();
        }
    }
}