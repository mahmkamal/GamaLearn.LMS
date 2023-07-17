using GamaLearn.LMS.Services.Validators;
using GamaLearn.LMS.Services.Interfaces;
using Ninject.Modules;
namespace GamaLearn.LMS.Services
{
    internal class Module : NinjectModule
    {
        public override void Load()
        {
            Bind<IBookService>().To<BookValidator>();
        }
    }
}
