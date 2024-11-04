namespace WinFormsApp1;

internal class InputButton
{
    private readonly int _id;
    private readonly ButtonType _type;
    private Button _button;
    private bool _canPressed = true;

    public Button Button
    {
        get => _button;
        private set => _button = value;
    }

    public bool CanPressed
    {
        get => _canPressed;
        set => _canPressed = value;
    }

    public ButtonType Type
    {
        get => _type;
    }

    public InputButton(int id, string text, ButtonType type)
    {
        _id = id;
        _type = type;
        InitializeButton(text, out _button);
    }

    private void InitializeButton(in string text, out Button button)
    {
        button = new Button();
        button.Name = $"inputButton{_id}";
        button.Text = text;
        button.Dock = DockStyle.Fill;
        button.TextAlign = ContentAlignment.MiddleCenter;
        button.TabIndex = _id;
    }
}
