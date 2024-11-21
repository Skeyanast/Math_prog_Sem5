using System.Linq.Expressions;

namespace WinFormsApp1.Presentation.Common;

/// <summary>
/// Represents common functionality for any IoC container implementation.
/// </summary>
public interface IContainer
{
    void Register<TService, TImplementation>()
        where TImplementation : TService;

    void Register<TService>();

    void RegisterInstance<T>(T instance);

    TService Resolve<TService>();

    bool IsRegistered<TService>();

    void Register<TService, TArgs>(Expression<Func<TArgs, TService>> factory);
}
