using System.ComponentModel;
using System.Data;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace WinFormsApp1;

internal class CalculatorViewModel : INotifyPropertyChanged
{
    private static int _id = 0;
    private double _memory = 0;
    private string _expression = "0";

    private delegate double SpecialOperation(double value);
    private delegate void FunctionalOperation();
    
    public event PropertyChangedEventHandler? PropertyChanged;

    public BindingList<InputButton> InputButtons { get; }
    public double Memory
    {
        get => _memory;
        set
        {
            if (_memory != value)
            {
                _memory = value;
                OnPropertyChanged();
            }
        }
    }
    public string Expression
    {
        get => _expression;
        set
        {
            if (_expression != value)
            {
                if (!IsValidExpression(value))
                {
                    value = "0";
                }
                _expression = value;
                OnPropertyChanged();
            }
        }
    }


    public ICommand NumberButtonCommand { get; set; }
    public ICommand BaseOperationButtonCommand { get; set; }
    public ICommand SpecialOperationButtonCommand { get; set; }
    public ICommand FunctionalButtonCommand { get; set; }

    public CalculatorViewModel()
    {
        InputButtons = new BindingList<InputButton>
        {
            new InputButton(_id++, "sin", ButtonType.SpecialOperation),
            new InputButton(_id++, "exp", ButtonType.SpecialOperation),
            new InputButton(_id++, "x\u00B2", ButtonType.SpecialOperation),//x²
            new InputButton(_id++, "CE", ButtonType.Functional),
            new InputButton(_id++, "<<", ButtonType.Functional),
            new InputButton(_id++, "cos", ButtonType.SpecialOperation),
            new InputButton(_id++, "7", ButtonType.Number),
            new InputButton(_id++, "8", ButtonType.Number),
            new InputButton(_id++, "9", ButtonType.Number),
            new InputButton(_id++, "/", ButtonType.BaseOperation),
            new InputButton(_id++, "tan", ButtonType.SpecialOperation),
            new InputButton(_id++, "4", ButtonType.Number),
            new InputButton(_id++, "5", ButtonType.Number),
            new InputButton(_id++, "6", ButtonType.Number),
            new InputButton(_id++, "*", ButtonType.BaseOperation),
            new InputButton(_id++, "tanh", ButtonType.SpecialOperation),
            new InputButton(_id++, "1", ButtonType.Number),
            new InputButton(_id++, "2", ButtonType.Number),
            new InputButton(_id++, "3", ButtonType.Number),
            new InputButton(_id++, "-", ButtonType.BaseOperation),
            new InputButton(_id++, "log10", ButtonType.SpecialOperation),
            new InputButton(_id++, "0", ButtonType.Number),
            new InputButton(_id++, "+", ButtonType.BaseOperation),
            new InputButton(_id++, "ln", ButtonType.SpecialOperation),
            new InputButton(_id++, "MRC", ButtonType.Functional),
            new InputButton(_id++, "M+", ButtonType.Functional),
            new InputButton(_id++, "M-", ButtonType.Functional),
            new InputButton(_id++, "=", ButtonType.Functional),
        };

        NumberButtonCommand = new CalculatorCommand(obj =>
        {
            if (obj is string number)
            {
                if (double.TryParse(number, out _))
                {
                    if (Expression == "0")
                    {
                        Expression = number;
                    }
                    else
                    {
                        Expression += number;
                    }
                }
                else
                {
                    throw new FormatException($"Ошибка в тексте кнопки цифры {number}");
                }
            }
            else
            {
                throw new Exception("Неверный тип привязки параметра команды");
            }
        });

        FunctionalButtonCommand = new CalculatorCommand(obj =>
        {
            if (obj is string functionName)
            {
                FunctionalOperation doFunction;
                switch (functionName)
                {
                    case "CE":
                        doFunction = () =>
                        {
                            Expression = "0";
                        };
                        doFunction?.Invoke();
                        break;
                    case "<<":
                        doFunction = () =>
                        {
                            if (Expression.Length > 1)
                            {
                                Expression = Expression.Remove(Expression.Length - 1);
                            }
                            else if (Expression.Length == 1)
                            {
                                if (Expression != "0")
                                {
                                    Expression = "0";
                                }
                            }
                        };
                        doFunction?.Invoke();
                        break;
                    case "MRC":
                        doFunction = () =>
                        {
                            Expression = Memory.ToString();
                        };
                        doFunction?.Invoke();
                        break;
                    case "M+":
                        doFunction = () =>
                        {
                            Memory += ProcessExpression();
                        };
                        doFunction?.Invoke();
                        break;
                    case "M-":
                        doFunction = () =>
                        {
                            Memory -= ProcessExpression();
                        };
                        doFunction?.Invoke();
                        break;
                    case "=":
                        doFunction = () =>
                        {
                            ProcessExpression();
                        };
                        doFunction?.Invoke();
                        break;
                    default:
                        throw new FormatException($"Ошибка в тексте кнопки функции {functionName}");
                }
            }
            else
            {
                throw new Exception("Неверный тип привязки параметра команды");
            }
        });
        
        BaseOperationButtonCommand = new CalculatorCommand(obj =>
        {
            if (obj is string operationChar)
            {
                Expression += operationChar switch
                {
                    "+" or "-" or "*" or "/" => operationChar,
                    _ => throw new FormatException($"Ошибка в тексте кнопки базовой операции: {operationChar}"),
                };
            }
            else
            {
                throw new Exception("Неверный тип привязки параметра команды");
            }
        });

        SpecialOperationButtonCommand = new CalculatorCommand(obj =>
        {
            if (obj is string operationName)
            {
                SpecialOperation doOperation;
                switch (operationName)
                {
                    case "sin":
                        doOperation = (double number) => Math.Sin(number);
                        try
                        {
                            ProcessSpecialOperation(doOperation);
                        }
                        catch
                        {
                            Expression = "0";
                            MessageBox.Show("Ошибка");
                        }
                        break;
                    case "cos":
                        doOperation = (double number) => Math.Cos(number);
                        try
                        {
                            ProcessSpecialOperation(doOperation);
                        }
                        catch
                        {
                            Expression = "0";
                            MessageBox.Show("Ошибка");
                        }
                        break;
                    case "tan":
                        doOperation = (double number) => Math.Tan(number);
                        try
                        {
                            ProcessSpecialOperation(doOperation);
                        }
                        catch
                        {
                            Expression = "0";
                            MessageBox.Show("Ошибка");
                        }
                        break;
                    case "tanh":
                        doOperation = (double number) => Math.Tanh(number);
                        try
                        {
                            ProcessSpecialOperation(doOperation);
                        }
                        catch
                        {
                            Expression = "0";
                            MessageBox.Show("Ошибка");
                        }
                        break;
                    case "log10":
                        doOperation = (double number) => Math.Log10(number);
                        try
                        {
                            ProcessSpecialOperation(doOperation);
                        }
                        catch
                        {
                            Expression = "0";
                            MessageBox.Show("Ошибка");
                        }
                        break;
                    case "ln":
                        doOperation = (double number) => Math.Log(number);
                        try
                        {
                            ProcessSpecialOperation(doOperation);
                        }
                        catch
                        {
                            Expression = "0";
                            MessageBox.Show("Ошибка");
                        }
                        break;
                    case "exp":
                        doOperation = (double number) => Math.Exp(number);
                        try
                        {
                            ProcessSpecialOperation(doOperation);
                        }
                        catch
                        {
                            Expression = "0";
                            MessageBox.Show("Ошибка");
                        }
                        break;
                    case "x\u00B2":
                        doOperation = (double number) => Math.Pow(number, 2);
                        try
                        {
                            ProcessSpecialOperation(doOperation);
                        }
                        catch
                        {
                            Expression = "0";
                            MessageBox.Show("Ошибка");
                        }
                        break;
                    default:
                        throw new Exception($"Ошибка в тексте кнопки специальной операции {operationName}");
                }
            }
            else
            {
                throw new Exception("Неверный тип привязки параметра команды");
            }
        });
    }

    private bool IsValidExpression(string expression)
    {
        return !string.IsNullOrEmpty(expression);
    }

    private void ProcessSpecialOperation(SpecialOperation doOperation)
    {
        if (double.TryParse(Expression, out double number))
        {
            Expression = doOperation?.Invoke(number).ToString()!;
        }
        else
        {
            Expression = "0";
            MessageBox.Show("Ошибка в выражении");
        }
    }

    private double ProcessExpression()
    {
        try
        {
            object? result = new DataTable().Compute(Expression, null);
            Expression = result.ToString()!;
            try
            {
                return Convert.ToDouble(result);
            }
            catch
            {
                throw new Exception("Ошибка при расчете выражения");
            }
        }
        catch
        {
            MessageBox.Show("Ошибка в выражении");
            return 0;
        }
    }

    private void OnPropertyChanged([CallerMemberName] string prop = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}