namespace WinFormsApp1;

partial class Form1
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
        _inputTextBox = new TextBox();
        _keyTextBox = new TextBox();
        _processButton = new Button();
        _encodeRadioButton = new RadioButton();
        _decodeRadioButton = new RadioButton();
        _methodsGroupBox = new GroupBox();
        _resultTextBox = new TextBox();
        _inputLabel = new Label();
        _keyLabel = new Label();
        _resultLabel = new Label();
        _methodsGroupBox.SuspendLayout();
        SuspendLayout();
        // 
        // _inputTextBox
        // 
        _inputTextBox.Location = new Point(40, 200);
        _inputTextBox.Name = "_inputTextBox";
        _inputTextBox.Size = new Size(400, 35);
        _inputTextBox.TabIndex = 0;
        // 
        // _keyTextBox
        // 
        _keyTextBox.Location = new Point(40, 300);
        _keyTextBox.Name = "_keyTextBox";
        _keyTextBox.Size = new Size(400, 35);
        _keyTextBox.TabIndex = 1;
        // 
        // _processButton
        // 
        _processButton.Location = new Point(40, 480);
        _processButton.Name = "_processButton";
        _processButton.Size = new Size(142, 40);
        _processButton.TabIndex = 2;
        _processButton.Text = "Process";
        _processButton.UseVisualStyleBackColor = true;
        // 
        // _encodeRadioButton
        // 
        _encodeRadioButton.AutoSize = true;
        _encodeRadioButton.Location = new Point(6, 34);
        _encodeRadioButton.Name = "_encodeRadioButton";
        _encodeRadioButton.Size = new Size(116, 36);
        _encodeRadioButton.TabIndex = 3;
        _encodeRadioButton.TabStop = true;
        _encodeRadioButton.Text = "Encode";
        _encodeRadioButton.UseVisualStyleBackColor = true;
        // 
        // _decodeRadioButton
        // 
        _decodeRadioButton.AutoSize = true;
        _decodeRadioButton.Location = new Point(6, 76);
        _decodeRadioButton.Name = "_decodeRadioButton";
        _decodeRadioButton.Size = new Size(116, 36);
        _decodeRadioButton.TabIndex = 4;
        _decodeRadioButton.TabStop = true;
        _decodeRadioButton.Text = "Decode";
        _decodeRadioButton.UseVisualStyleBackColor = true;
        // 
        // _methodsGroupBox
        // 
        _methodsGroupBox.CausesValidation = false;
        _methodsGroupBox.Controls.Add(_encodeRadioButton);
        _methodsGroupBox.Controls.Add(_decodeRadioButton);
        _methodsGroupBox.Location = new Point(40, 20);
        _methodsGroupBox.Name = "_methodsGroupBox";
        _methodsGroupBox.Size = new Size(200, 122);
        _methodsGroupBox.TabIndex = 5;
        _methodsGroupBox.TabStop = false;
        _methodsGroupBox.Text = "Method";
        // 
        // _resultTextBox
        // 
        _resultTextBox.Location = new Point(40, 400);
        _resultTextBox.Name = "_resultTextBox";
        _resultTextBox.ReadOnly = true;
        _resultTextBox.Size = new Size(400, 35);
        _resultTextBox.TabIndex = 6;
        // 
        // label1
        // 
        _inputLabel.AutoSize = true;
        _inputLabel.Location = new Point(40, 160);
        _inputLabel.Name = "label1";
        _inputLabel.Size = new Size(84, 32);
        _inputLabel.TabIndex = 7;
        _inputLabel.Text = "Input";
        // 
        // label2
        // 
        _keyLabel.AutoSize = true;
        _keyLabel.Location = new Point(40, 260);
        _keyLabel.Name = "label2";
        _keyLabel.Size = new Size(56, 32);
        _keyLabel.TabIndex = 8;
        _keyLabel.Text = "Key";
        // 
        // label3
        // 
        _resultLabel.AutoSize = true;
        _resultLabel.Location = new Point(40, 360);
        _resultLabel.Name = "label3";
        _resultLabel.Size = new Size(98, 32);
        _resultLabel.TabIndex = 9;
        _resultLabel.Text = "Result";
        // 
        // Form1
        // 
        ClientSize = new Size(784, 561);
        Controls.Add(_resultLabel);
        Controls.Add(_keyLabel);
        Controls.Add(_inputLabel);
        Controls.Add(_resultTextBox);
        Controls.Add(_methodsGroupBox);
        Controls.Add(_processButton);
        Controls.Add(_keyTextBox);
        Controls.Add(_inputTextBox);
        Font = new Font("Cascadia Code", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        Name = "Form1";
        Padding = new Padding(10);
        Text = "Vigenere Cipher Calculator";
        _methodsGroupBox.ResumeLayout(false);
        _methodsGroupBox.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private TextBox _inputTextBox;
    private TextBox _keyTextBox;
    private Button _processButton;
    private RadioButton _encodeRadioButton;
    private RadioButton _decodeRadioButton;
    private GroupBox _methodsGroupBox;
    private TextBox _resultTextBox;
    private Label _inputLabel;
    private Label _keyLabel;
    private Label _resultLabel;
}
