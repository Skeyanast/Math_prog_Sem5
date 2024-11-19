using WinFormsApp1.Presentation.Common;
using WinFormsApp1.Presentation.Views;

namespace WinFormsApp1.Presentation.Presenters;

public class ChangeUsernamePresenter : BasePresenter<IChangeUsernameView, ChangeUsernamePresenterRunArgs>
{
    private Action<string> _changeUsernameCallback;

    public ChangeUsernamePresenter(IChangeUsernameView view, IApplicationController controller)
        : base(view, controller)
    {
        View.SaveClicked += () => ChangeUsername(View.Username);
    }

    private void ChangeUsername(string username)
    {
        ArgumentNullException.ThrowIfNull(username);

        if (username != string.Empty)
        {
            _changeUsernameCallback?.Invoke(username);
            View.Close();
        }
    }

    public override void Run(ChangeUsernamePresenterRunArgs args)
    {
        _changeUsernameCallback = args.ChangeUsernameCallback;
        View.Show();
    }
}