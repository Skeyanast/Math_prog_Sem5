
namespace WinFormsApp1;

public partial class Form1 : Form
{
    private VigenereCipherViewModel _viewModel;

    public Form1()
    {
        InitializeComponent();

        _viewModel = new VigenereCipherViewModel();

        BindControls();
    }

    private void BindControls()
    {
        _inputTextBox.DataBindings.Add(nameof(_inputTextBox.Text), _viewModel, nameof(_viewModel.Input), true, DataSourceUpdateMode.OnPropertyChanged);
        
        _keyTextBox.DataBindings.Add(nameof(_keyTextBox.Text), _viewModel, nameof(_viewModel.Key), true, DataSourceUpdateMode.OnPropertyChanged);

        _resultTextBox.DataBindings.Add(nameof(_resultTextBox.Text), _viewModel, nameof(_viewModel.Result), true, DataSourceUpdateMode.OnPropertyChanged);

        _processButton.DataBindings.Add(nameof(_processButton.Command), _viewModel, nameof(_viewModel.ProcessButtonCommand), true);

        _encodeRadioButton.DataBindings.Add(nameof(_encodeRadioButton.Command), _viewModel, nameof(_viewModel.EnterEncodeModeCommand), true);
        
        _decodeRadioButton.DataBindings.Add(nameof(_decodeRadioButton.Command), _viewModel, nameof(_viewModel.EnterDecodeModeCommand), true);
    }
}