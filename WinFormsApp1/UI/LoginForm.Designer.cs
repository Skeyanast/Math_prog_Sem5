namespace WinFormsApp1;

partial class LoginForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        _usernameTextBox = new TextBox();
        _passwordTextBox = new TextBox();
        _loginButton = new Button();
        SuspendLayout();
        // 
        // _usernameTextBox
        // 
        _usernameTextBox.Location = new Point(115, 110);
        _usernameTextBox.Name = "_usernameTextBox";
        _usernameTextBox.Size = new Size(557, 23);
        _usernameTextBox.TabIndex = 0;
        // 
        // _passwordTextBox
        // 
        _passwordTextBox.Location = new Point(115, 183);
        _passwordTextBox.Name = "_passwordTextBox";
        _passwordTextBox.Size = new Size(557, 23);
        _passwordTextBox.TabIndex = 1;
        _passwordTextBox.UseSystemPasswordChar = true;
        // 
        // _loginButton
        // 
        _loginButton.Location = new Point(115, 261);
        _loginButton.Name = "_loginButton";
        _loginButton.Size = new Size(557, 53);
        _loginButton.TabIndex = 2;
        _loginButton.Text = "Войти";
        _loginButton.UseVisualStyleBackColor = true;
        // 
        // LoginForm
        // 
        ClientSize = new Size(784, 561);
        Controls.Add(_loginButton);
        Controls.Add(_passwordTextBox);
        Controls.Add(_usernameTextBox);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        Name = "LoginForm";
        Padding = new Padding(10);
        Text = "Test form";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private TextBox _usernameTextBox;
    private TextBox _passwordTextBox;
    private Button _loginButton;
}
