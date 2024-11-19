namespace WinFormsApp1.Presentation.Common;

/// <summary>
/// Serves as an central hub for managing dependencies
/// and initialization of user interface components.
/// </summary>
public interface IApplicationController
{
    IApplicationController RegisterView<TView, TImplementation>()
        where TView : IView
        where TImplementation : class, TView;

    IApplicationController RegisterService<TService, TImplementation>()
        where TImplementation : class, TService;

    IApplicationController RegisterInstance<TParameter>(TParameter instance);

    void Run<TPresenter>()
        where TPresenter : class, IPresenter;

    void Run<TPresenter, TArgs>(TArgs args)
        where TPresenter : class, IPresenter<TArgs>
        where TArgs : class, IRunPresenterArgs;
}
