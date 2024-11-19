namespace WinFormsApp1.Presentation.Common;

/// <summary>
/// Common functionality for presenters
/// </summary>
public interface IPresenter
{
    void Run();
}

/// <summary>
/// Common functionality for presenters with a launch parameter
/// </summary>
/// <typeparam name="TArgs"></typeparam>
public interface IPresenter<in TArgs>
{
    void Run(TArgs args);
}