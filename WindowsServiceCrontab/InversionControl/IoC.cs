using InversionControl.Modules;
using Ninject;

namespace InversionControl
{
    public class IoC
    {
        public IKernel Kernel { get; private set; }

        public IoC()
        {
            Kernel = GetNinjectModules();
        }

        private IKernel GetNinjectModules()
        {
            return new StandardKernel(
                new RepositoryNinjectModules()
                );
        }
    }
}
