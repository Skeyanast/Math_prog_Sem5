using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace WinFormsApp1;

internal class VigenereCipherViewModel : INotifyPropertyChanged
{
    private string _input = "";
    private string _key = "";
    private string _result = "";

    public event PropertyChangedEventHandler? PropertyChanged;

    public string Input
    {
        get => _input;
        set
        {
            if (_input != value)
            {
                _input = value;
                OnPropertyChanged();
            }
        }
    }

    public string Key
    {
        get => _key;
        set
        {
            if (_key != value)
            {
                _key = value;
                OnPropertyChanged();
            }
        }
    }

    public string Result
    {
        get => _result;
        private set
        {
            if (_result != value)
            {
                _result = value;
                OnPropertyChanged();
            }
        }
    }

    public ICommand ProcessButtonCommand { get; private set; }

    public ICommand EnterEncodeModeCommand { get; private set; }

    public ICommand EnterDecodeModeCommand { get; private set; }

    public VigenereCipherViewModel()
    {
        ProcessButtonCommand = new MainCommand(_ =>
        {
            Encrypt();
        });

        EnterEncodeModeCommand = new MainCommand(_ =>
        {
            ProcessButtonCommand = new MainCommand(_ =>
            {
                Encrypt();
            });
            ProcessButtonCommand.Execute(null);
        });

        EnterDecodeModeCommand = new MainCommand(_ =>
        {
            ProcessButtonCommand = new MainCommand(_ =>
            {
                Decrypt();
            });
            ProcessButtonCommand.Execute(null);
        });
    }

    private void Encrypt()
    {
        if (IsValidInput(Input) && IsValidInput(Key))
        {
            Result = VigenereCipherModel.Encrypt(Input, Key);
        }
        else
        {
            Result = "Fields must be filled";
        }
    }

    private void Decrypt()
    {
        if (IsValidInput(Input) && IsValidInput(Key))
        {
            Result = VigenereCipherModel.Decrypt(Input, Key);
        }
        else
        {
            Result = "Fields must be filled";
        }
    }

    private static bool IsValidInput(in string input)
    {
        return !string.IsNullOrEmpty(input);
    }

    private void OnPropertyChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}