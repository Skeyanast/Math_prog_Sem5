namespace WinFormsApp1.Presentation.Common;

/// <summary>
/// Represents an abstract base class for all presenters that work with a view.
/// </summary>
/// <typeparam name="TView"></typeparam>
public abstract class BasePresenter<TView> : IPresenter
    where TView : IView
{
    protected TView View { get; private set; }
    protected IApplicationController Controller { get; private set; }

    protected BasePresenter(TView view, IApplicationController controller)
    {
        View = view;
        Controller = controller;
    }

    public void Run()
    {
        View.Show();
    }
}

/// <summary>
/// Represents an abstract base class for all presenters that work with a view.
/// Allows you to pass arguments to the presenter when it is launched.
/// </summary>
/// <typeparam name="TView"></typeparam>
/// <typeparam name="TArgs"></typeparam>
public abstract class BasePresenter<TView, TArgs> : IPresenter<TArgs>
    where TView : IView
    where TArgs : class, IRunPresenterArgs
{
    protected TView View { get; private set; }
    protected IApplicationController Controller { get; private set; }

    protected BasePresenter(TView view, IApplicationController controller)
    {
        View = view;
        Controller = controller;
    }

    public abstract void Run(TArgs args);
}