namespace WinFormsApp1.Presentation.Common;

public class ApplicationController : IApplicationController
{
    private readonly IContainer _container;

    public ApplicationController(IContainer container)
    {
        _container = container;
        _container.RegisterInstance<IApplicationController>(this);
    }

    public IApplicationController RegisterView<TView, TImplementation>()
        where TView : IView
        where TImplementation : class, TView
    {
        _container.Register<TView, TImplementation>();
        return this;
    }

    public IApplicationController RegisterService<TModel, TImplementation>()
        where TImplementation : class, TModel
    {
        _container.Register<TModel, TImplementation>();
        return this;
    }

    public IApplicationController RegisterInstance<TInstance>(TInstance instance)
    {
        _container.RegisterInstance(instance);
        return this;
    }

    public void Run<TPresenter>()
        where TPresenter : class, IPresenter
    {
        if (!_container.IsRegistered<TPresenter>())
        {
            _container.Register<TPresenter>();
        }

        TPresenter presenter = _container.Resolve<TPresenter>();
        presenter.Run();
    }

    public void Run<TPresenter, TArgs>(TArgs args)
        where TPresenter : class, IPresenter<TArgs>
        where TArgs : class, IRunPresenterArgs
    {
        if (!_container.IsRegistered<TPresenter>())
        {
            _container.Register<TPresenter>();
        }

        TPresenter presenter = _container.Resolve<TPresenter>();
        presenter.Run(args);
    }
}
