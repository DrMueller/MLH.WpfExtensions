using System;
using System.Reflection;
using System.Threading.Tasks;
using Mmu.Mlh.LanguageExtensions.Areas.Maybes;

namespace Mmu.Mlh.WpfExtensions.Areas.Initialization.AppStart
{
    internal interface IAppStartService
    {
        Task StartUpAsync(Assembly rootAssembly, ApplicationConfiguration appConfig, Maybe<Action> appInitializedCallbackMaybe);
    }
}