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
        components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
        _ballPicture1 = new PictureBox();
        _playButton = new Button();
        _timer1 = new System.Windows.Forms.Timer(components);
        _speedUpButton = new Button();
        _speedDownButton = new Button();
        _ballPicture2 = new PictureBox();
        _timer2 = new System.Windows.Forms.Timer(components);
        ((System.ComponentModel.ISupportInitialize)_ballPicture1).BeginInit();
        ((System.ComponentModel.ISupportInitialize)_ballPicture2).BeginInit();
        SuspendLayout();
        // 
        // _ballPicture1
        // 
        _ballPicture1.Image = (Image)resources.GetObject("_ballPicture1.Image");
        _ballPicture1.Location = new Point(58, 300);
        _ballPicture1.Name = "_ballPicture1";
        _ballPicture1.Size = new Size(100, 100);
        _ballPicture1.TabIndex = 0;
        _ballPicture1.TabStop = false;
        _ballPicture1.LocationChanged += BallPicture1_LocationChanged;
        // 
        // _playButton
        // 
        _playButton.Cursor = Cursors.Hand;
        _playButton.Location = new Point(305, 345);
        _playButton.Name = "_playButton";
        _playButton.Size = new Size(100, 40);
        _playButton.TabIndex = 1;
        _playButton.Text = "Пуск";
        _playButton.UseVisualStyleBackColor = true;
        _playButton.Click += PlayButton_Click;
        // 
        // _timer1
        // 
        _timer1.Interval = 50;
        _timer1.Tick += Timer1_Tick;
        // 
        // _speedUpButton
        // 
        _speedUpButton.Location = new Point(438, 345);
        _speedUpButton.Name = "_speedUpButton";
        _speedUpButton.Size = new Size(75, 23);
        _speedUpButton.TabIndex = 2;
        _speedUpButton.Text = "Быстрее";
        _speedUpButton.UseVisualStyleBackColor = true;
        _speedUpButton.Click += SpeedUpButton_Click;
        // 
        // _speedDownButton
        // 
        _speedDownButton.Location = new Point(438, 376);
        _speedDownButton.Name = "_speedDownButton";
        _speedDownButton.Size = new Size(75, 23);
        _speedDownButton.TabIndex = 3;
        _speedDownButton.Text = "Медленнее";
        _speedDownButton.UseVisualStyleBackColor = true;
        _speedDownButton.Click += SpeedDownButton_Click;
        // 
        // _ballPicture2
        // 
        _ballPicture2.Image = (Image)resources.GetObject("_ballPicture2.Image");
        _ballPicture2.Location = new Point(653, 300);
        _ballPicture2.Name = "_ballPicture2";
        _ballPicture2.Size = new Size(100, 100);
        _ballPicture2.TabIndex = 4;
        _ballPicture2.TabStop = false;
        _ballPicture2.LocationChanged += BallPicture2_LocationChanged;
        // 
        // _timer2
        // 
        _timer2.Interval = 50;
        _timer2.Tick += Timer2_Tick;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(784, 441);
        Controls.Add(_ballPicture2);
        Controls.Add(_speedDownButton);
        Controls.Add(_speedUpButton);
        Controls.Add(_playButton);
        Controls.Add(_ballPicture1);
        MinimumSize = new Size(100, 100);
        Name = "Form1";
        Text = "Арканоид";
        ((System.ComponentModel.ISupportInitialize)_ballPicture1).EndInit();
        ((System.ComponentModel.ISupportInitialize)_ballPicture2).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private PictureBox _ballPicture1;
    private PictureBox _ballPicture2;
    private Button _playButton;
    private Button _speedUpButton;
    private Button _speedDownButton;
    private System.Windows.Forms.Timer _timer1;
    private System.Windows.Forms.Timer _timer2;
}
