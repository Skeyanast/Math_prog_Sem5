using LightInject;
using System.Linq.Expressions;
using WinFormsApp1.Presentation.Common;

namespace WinFormsApp1.UI;

/// <summary>
/// Implementation of IoC container using a LightInject package.
/// </summary>
public class LightInjectAdapter : IContainer
{
    private readonly ServiceContainer _container = new ServiceContainer();

    public void Register<TService, TImplementation>()
        where TImplementation : TService
    {
        _container.Register<TService, TImplementation>();
    }

    public void Register<TService>()
    {
        _container.Register<TService>();
    }

    public void RegisterInstance<T>(T instance)
    {
        _container.RegisterInstance(instance);
    }

    public TService Resolve<TService>()
    {
        return _container.GetInstance<TService>();
    }

    public bool IsRegistered<TService>()
    {
        return _container.CanGetInstance(typeof(TService), string.Empty);
    }

    public void Register<TService, TParameter>(Expression<Func<TParameter, TService>> factory)
    {
        _container.Register(serviceFactory => factory);
    }
}
