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
        _dijkstraButton = new Button();
        _aAsteriskButton = new Button();
        _waveAlgorithmButton = new Button();
        SuspendLayout();
        // 
        // _dijkstraButton
        // 
        _dijkstraButton.Location = new Point(12, 415);
        _dijkstraButton.Name = "_dijkstraButton";
        _dijkstraButton.Size = new Size(150, 23);
        _dijkstraButton.TabIndex = 0;
        _dijkstraButton.Text = "Dijkstra";
        _dijkstraButton.UseVisualStyleBackColor = true;
        _dijkstraButton.Click += DijkstraButton_Click;
        // 
        // _aAsteriskButton
        // 
        _aAsteriskButton.Location = new Point(206, 415);
        _aAsteriskButton.Name = "_aAsteriskButton";
        _aAsteriskButton.Size = new Size(150, 23);
        _aAsteriskButton.TabIndex = 1;
        _aAsteriskButton.Text = "A*";
        _aAsteriskButton.UseVisualStyleBackColor = true;
        _aAsteriskButton.Click += AAsteriskButton_Click;
        // 
        // _waveAlgorithmButton
        // 
        _waveAlgorithmButton.Location = new Point(407, 415);
        _waveAlgorithmButton.Name = "_waveAlgorithmButton";
        _waveAlgorithmButton.Size = new Size(150, 23);
        _waveAlgorithmButton.TabIndex = 2;
        _waveAlgorithmButton.Text = "WaveAlgorithm";
        _waveAlgorithmButton.UseVisualStyleBackColor = true;
        _waveAlgorithmButton.Click += WaveAlgorithmButton_Click;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(8F, 17F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(_waveAlgorithmButton);
        Controls.Add(_aAsteriskButton);
        Controls.Add(_dijkstraButton);
        Name = "MainForm";
        Text = "MainForm";
        ResumeLayout(false);
    }

    #endregion

    private Button _dijkstraButton;
    private Button _aAsteriskButton;
    private Button _waveAlgorithmButton;
}