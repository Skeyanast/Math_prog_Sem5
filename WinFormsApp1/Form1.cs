using System.ComponentModel;

namespace WinFormsApp1;

public partial class Form1 : Form
{
    private CalculatorViewModel _viewModel;
    private TextBox _expressionTextBox;
    private TableLayoutPanel _inputTableLayoutPanel;
    private BindingList<InputButton> _inputButtons;

    public Form1()
    {
        InitializeComponent();

        _viewModel = new CalculatorViewModel();
        _inputButtons = _viewModel.InputButtons;

        InitializeExpressionTextBox(out _expressionTextBox);
        InitializeInputTableLayoutPanel(6, 5, out _inputTableLayoutPanel);
    }

    private void InitializeExpressionTextBox(out TextBox expressionTextBox)
    {
        expressionTextBox = new TextBox();
        expressionTextBox.Dock = DockStyle.Top;
        expressionTextBox.TabIndex = 0;
        expressionTextBox.TextAlign = HorizontalAlignment.Right;

        Controls.Add(expressionTextBox);

        expressionTextBox.DataBindings.Add(new Binding(nameof(expressionTextBox.Text), _viewModel, nameof(_viewModel.Expression), true, DataSourceUpdateMode.OnPropertyChanged));
    }

    private void InitializeInputTableLayoutPanel(in int rowCount, in int columnCount, out TableLayoutPanel inputTableLayoutPanel)
    {
        inputTableLayoutPanel = new TableLayoutPanel();
        inputTableLayoutPanel.Dock = DockStyle.Bottom;
        inputTableLayoutPanel.RowCount = rowCount;
        inputTableLayoutPanel.ColumnCount = columnCount;
        for (int i = 0; i < inputTableLayoutPanel.ColumnCount; i++)
        {
            inputTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, inputTableLayoutPanel.Width / inputTableLayoutPanel.ColumnCount));
        }
        for (int i = 0; i < inputTableLayoutPanel.RowCount; i++)
        {
            inputTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, inputTableLayoutPanel.Height / inputTableLayoutPanel.RowCount));
        }
        inputTableLayoutPanel.Height = (int)Math.Round(Height * 0.8);
        inputTableLayoutPanel.TabIndex = 1;

        int buttonNumber = 0;
        for (int i = 0; i < inputTableLayoutPanel.RowCount; i++)
        {
            for (int j = 0; j < inputTableLayoutPanel.ColumnCount; j++)
            {
                if ((i == 4) && (j == 1))
                {
                    continue;
                }
                else if ((i == 4) && (j == 3))
                {
                    continue;
                }
                InitializeInputButton(buttonNumber, j, i);
                buttonNumber++;
            }
        }

        Controls.Add(inputTableLayoutPanel);
    }

    private void InitializeInputButton(in int buttonNumber, in int column, in int row)
    {
        InputButton inputButton = _inputButtons[buttonNumber];
        Button button = inputButton.Button;
        try
        {
            switch (inputButton.Type)
            {
                case ButtonType.Number:
                    button.DataBindings.Add(new Binding(nameof(button.Command), _viewModel, nameof(_viewModel.NumberButtonCommand), true));
                    button.DataBindings.Add(new Binding(nameof(button.CommandParameter), button, nameof(button.Text)));
                    break;
                case ButtonType.BaseOperation:
                    button.DataBindings.Add(new Binding(nameof(button.Command), _viewModel, nameof(_viewModel.BaseOperationButtonCommand), true));
                    button.DataBindings.Add(new Binding(nameof(button.CommandParameter), button, nameof(button.Text)));
                    break;
                case ButtonType.SpecialOperation:
                    button.DataBindings.Add(new Binding(nameof(button.Command), _viewModel, nameof(_viewModel.SpecialOperationButtonCommand), true));
                    button.DataBindings.Add(new Binding(nameof(button.CommandParameter), button, nameof(button.Text)));
                    break;
                case ButtonType.Functional:
                    button.DataBindings.Add(new Binding(nameof(button.Command), _viewModel, nameof(_viewModel.FunctionalButtonCommand), true));
                    button.DataBindings.Add(new Binding(nameof(button.CommandParameter), button, nameof(button.Text)));
                    break;
                default:
                    throw new Exception("Ошибка в типе кнопки");
            }
            _inputTableLayoutPanel.Controls.Add(button, column, row);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ошибка при инициализации кнопки: {ex.Message}");
        }
    }
}