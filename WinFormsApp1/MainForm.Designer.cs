namespace WinFormsApp1;

partial class MainForm
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
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
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        _waveAlgorithmButton = new Button();
        _clearPathButton = new Button();
        _movementTimer = new System.Windows.Forms.Timer(components);
        SuspendLayout();
        // 
        // _waveAlgorithmButton
        // 
        _waveAlgorithmButton.Location = new Point(407, 415);
        _waveAlgorithmButton.Name = "_waveAlgorithmButton";
        _waveAlgorithmButton.Size = new Size(150, 23);
        _waveAlgorithmButton.TabIndex = 2;
        _waveAlgorithmButton.Text = "Run";
        _waveAlgorithmButton.UseVisualStyleBackColor = true;
        // 
        // _clearPathButton
        // 
        _clearPathButton.Location = new Point(570, 37);
        _clearPathButton.Name = "_clearPathButton";
        _clearPathButton.Size = new Size(150, 23);
        _clearPathButton.TabIndex = 3;
        _clearPathButton.Text = "Clear path";
        _clearPathButton.UseVisualStyleBackColor = true;
        // 
        // _movementTimer
        // 
        _movementTimer.Interval = 500;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(8F, 17F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(_clearPathButton);
        Controls.Add(_waveAlgorithmButton);
        Name = "MainForm";
        Text = "MainForm";
        ResumeLayout(false);
    }

    #endregion
    private Button _waveAlgorithmButton;
    private Button _clearPathButton;
    private System.Windows.Forms.Timer _movementTimer;
}