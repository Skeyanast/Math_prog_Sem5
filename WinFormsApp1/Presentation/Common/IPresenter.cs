namespace WinFormsApp1.Presentation.Common;

/// <summary>
/// Represents common functionality for presenters.
/// </summary>
public interface IPresenter
{
    void Run();
}

/// <summary>
/// Represents common functionality for presenters with a launch arguments.
/// </summary>
/// <typeparam name="TArgs"></typeparam>
public interface IPresenter<in TArgs>
{
    void Run(TArgs args);
}