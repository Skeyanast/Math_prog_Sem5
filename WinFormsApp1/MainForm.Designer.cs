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
        _aStarButton = new Button();
        _waveAlgorithmButton = new Button();
        _clearPathButton = new Button();
        _executionTimeLabel = new Label();
        _algorithmNameLabel = new Label();
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
        // 
        // _aStarButton
        // 
        _aStarButton.Location = new Point(206, 415);
        _aStarButton.Name = "_aStarButton";
        _aStarButton.Size = new Size(150, 23);
        _aStarButton.TabIndex = 1;
        _aStarButton.Text = "A*";
        _aStarButton.UseVisualStyleBackColor = true;
        // 
        // _waveAlgorithmButton
        // 
        _waveAlgorithmButton.Location = new Point(407, 415);
        _waveAlgorithmButton.Name = "_waveAlgorithmButton";
        _waveAlgorithmButton.Size = new Size(150, 23);
        _waveAlgorithmButton.TabIndex = 2;
        _waveAlgorithmButton.Text = "WaveAlgorithm";
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
        // _executionTimeLabel
        // 
        _executionTimeLabel.AutoSize = true;
        _executionTimeLabel.Location = new Point(524, 164);
        _executionTimeLabel.Name = "_executionTimeLabel";
        _executionTimeLabel.Size = new Size(128, 17);
        _executionTimeLabel.TabIndex = 4;
        _executionTimeLabel.Text = "Execution time:";
        // 
        // _algorithmNameLabel
        // 
        _algorithmNameLabel.AutoSize = true;
        _algorithmNameLabel.Location = new Point(524, 110);
        _algorithmNameLabel.Name = "_algorithmNameLabel";
        _algorithmNameLabel.Size = new Size(128, 17);
        _algorithmNameLabel.TabIndex = 5;
        _algorithmNameLabel.Text = "Algorithm Name:";
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(8F, 17F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(_algorithmNameLabel);
        Controls.Add(_executionTimeLabel);
        Controls.Add(_clearPathButton);
        Controls.Add(_waveAlgorithmButton);
        Controls.Add(_aStarButton);
        Controls.Add(_dijkstraButton);
        Name = "MainForm";
        Text = "MainForm";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Button _dijkstraButton;
    private Button _aStarButton;
    private Button _waveAlgorithmButton;
    private Button _clearPathButton;
    private Label _executionTimeLabel;
    private Label _algorithmNameLabel;
}