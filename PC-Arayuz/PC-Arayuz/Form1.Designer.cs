namespace PC_Arayuz
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>/ Clean up any resources being used.
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
            this.components = new System.ComponentModel.Container();
            this.APP_EXIT = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.disconnectBtn = new System.Windows.Forms.Button();
            this.connectBox = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.baudrateComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.portComboBox = new System.Windows.Forms.ComboBox();
            this.TITLE = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.checkBtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.saveBtn = new System.Windows.Forms.Button();
            this.endPosTxt = new System.Windows.Forms.TextBox();
            this.startPosTxt = new System.Windows.Forms.TextBox();
            this.end = new System.Windows.Forms.RadioButton();
            this.start = new System.Windows.Forms.RadioButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.robot_arm_show_screen1 = new PC_Arayuz.robot_arm_show_screen();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // APP_EXIT
            // 
            this.APP_EXIT.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.APP_EXIT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.APP_EXIT.Dock = System.Windows.Forms.DockStyle.Right;
            this.APP_EXIT.FlatAppearance.BorderSize = 0;
            this.APP_EXIT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.APP_EXIT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.APP_EXIT.Location = new System.Drawing.Point(1250, 0);
            this.APP_EXIT.Name = "APP_EXIT";
            this.APP_EXIT.Size = new System.Drawing.Size(30, 720);
            this.APP_EXIT.TabIndex = 0;
            this.APP_EXIT.Text = "X";
            this.APP_EXIT.UseVisualStyleBackColor = false;
            this.APP_EXIT.Click += new System.EventHandler(this.APP_EXIT_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.disconnectBtn);
            this.panel1.Controls.Add(this.connectBox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.baudrateComboBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.portComboBox);
            this.panel1.Controls.Add(this.TITLE);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1250, 30);
            this.panel1.TabIndex = 1;
            // 
            // disconnectBtn
            // 
            this.disconnectBtn.Location = new System.Drawing.Point(1034, 4);
            this.disconnectBtn.Name = "disconnectBtn";
            this.disconnectBtn.Size = new System.Drawing.Size(143, 23);
            this.disconnectBtn.TabIndex = 7;
            this.disconnectBtn.Text = "Baglantiyi Kes";
            this.disconnectBtn.UseVisualStyleBackColor = true;
            this.disconnectBtn.Click += new System.EventHandler(this.disconnectBtn_Click);
            // 
            // connectBox
            // 
            this.connectBox.Location = new System.Drawing.Point(885, 4);
            this.connectBox.Name = "connectBox";
            this.connectBox.Size = new System.Drawing.Size(143, 23);
            this.connectBox.TabIndex = 1;
            this.connectBox.Text = "Baglan";
            this.connectBox.UseVisualStyleBackColor = true;
            this.connectBox.Click += new System.EventHandler(this.connectBox_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(686, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "BAUDRATE";
            // 
            // baudrateComboBox
            // 
            this.baudrateComboBox.FormattingEnabled = true;
            this.baudrateComboBox.Items.AddRange(new object[] {
            "9600",
            "14400",
            "19200",
            "28800",
            "115200",
            "230400"});
            this.baudrateComboBox.Location = new System.Drawing.Point(758, 6);
            this.baudrateComboBox.Name = "baudrateComboBox";
            this.baudrateComboBox.Size = new System.Drawing.Size(121, 21);
            this.baudrateComboBox.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(511, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "PORT";
            // 
            // portComboBox
            // 
            this.portComboBox.FormattingEnabled = true;
            this.portComboBox.Location = new System.Drawing.Point(554, 6);
            this.portComboBox.Name = "portComboBox";
            this.portComboBox.Size = new System.Drawing.Size(121, 21);
            this.portComboBox.TabIndex = 3;
            // 
            // TITLE
            // 
            this.TITLE.AutoSize = true;
            this.TITLE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TITLE.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.TITLE.Location = new System.Drawing.Point(13, 7);
            this.TITLE.Name = "TITLE";
            this.TITLE.Size = new System.Drawing.Size(470, 15);
            this.TITLE.TabIndex = 2;
            this.TITLE.Text = "ROBOT KOL KONTROL PANEL VER 0.0 / BAHTIYAR BAYIR - 2015705027";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkGray;
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.comboBox1);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.listBox2);
            this.panel2.Controls.Add(this.checkBtn);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.deleteBtn);
            this.panel2.Controls.Add(this.listBox1);
            this.panel2.Controls.Add(this.saveBtn);
            this.panel2.Controls.Add(this.endPosTxt);
            this.panel2.Controls.Add(this.startPosTxt);
            this.panel2.Controls.Add(this.end);
            this.panel2.Controls.Add(this.start);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(880, 30);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(370, 690);
            this.panel2.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(278, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Silinecek gorev";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "9600",
            "14400",
            "19200",
            "28800",
            "115200",
            "230400"});
            this.comboBox1.Location = new System.Drawing.Point(278, 124);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(86, 21);
            this.comboBox1.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 668);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "label4";
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(20, 289);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(344, 368);
            this.listBox2.TabIndex = 12;
            // 
            // checkBtn
            // 
            this.checkBtn.Location = new System.Drawing.Point(278, 180);
            this.checkBtn.Name = "checkBtn";
            this.checkBtn.Size = new System.Drawing.Size(86, 23);
            this.checkBtn.TabIndex = 11;
            this.checkBtn.Text = "Listele";
            this.checkBtn.UseVisualStyleBackColor = true;
            this.checkBtn.Click += new System.EventHandler(this.checkBtn_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(306, 663);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(58, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // deleteBtn
            // 
            this.deleteBtn.Location = new System.Drawing.Point(278, 151);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(86, 23);
            this.deleteBtn.TabIndex = 6;
            this.deleteBtn.Text = "Sil";
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(20, 97);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(252, 173);
            this.listBox1.TabIndex = 5;
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(20, 68);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(344, 23);
            this.saveBtn.TabIndex = 4;
            this.saveBtn.Text = "Kaydet";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // endPosTxt
            // 
            this.endPosTxt.Location = new System.Drawing.Point(214, 42);
            this.endPosTxt.Name = "endPosTxt";
            this.endPosTxt.Size = new System.Drawing.Size(150, 20);
            this.endPosTxt.TabIndex = 3;
            // 
            // startPosTxt
            // 
            this.startPosTxt.Location = new System.Drawing.Point(20, 42);
            this.startPosTxt.Name = "startPosTxt";
            this.startPosTxt.Size = new System.Drawing.Size(150, 20);
            this.startPosTxt.TabIndex = 2;
            // 
            // end
            // 
            this.end.AutoSize = true;
            this.end.Location = new System.Drawing.Point(214, 19);
            this.end.Name = "end";
            this.end.Size = new System.Drawing.Size(71, 17);
            this.end.TabIndex = 1;
            this.end.TabStop = true;
            this.end.Text = "End Pos>";
            this.end.UseVisualStyleBackColor = true;
            // 
            // start
            // 
            this.start.AutoSize = true;
            this.start.Location = new System.Drawing.Point(20, 19);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(74, 17);
            this.start.TabIndex = 0;
            this.start.TabStop = true;
            this.start.Text = "Start Pos>";
            this.start.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Gray;
            this.panel3.Controls.Add(this.robot_arm_show_screen1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 30);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(880, 690);
            this.panel3.TabIndex = 3;
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // robot_arm_show_screen1
            // 
            this.robot_arm_show_screen1.ArmPositionX = 999;
            this.robot_arm_show_screen1.ArmPositionY = 999;
            this.robot_arm_show_screen1.ArmPositionZ = 999;
            this.robot_arm_show_screen1.ArmRotateDegree = 0F;
            this.robot_arm_show_screen1.BackColor = System.Drawing.Color.Transparent;
            this.robot_arm_show_screen1.CorssSize = 10;
            this.robot_arm_show_screen1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.robot_arm_show_screen1.EndPoint = new System.Drawing.Point(0, 0);
            this.robot_arm_show_screen1.FirstArmDegree = 60F;
            this.robot_arm_show_screen1.InsideCircle = 180F;
            this.robot_arm_show_screen1.Location = new System.Drawing.Point(0, 0);
            this.robot_arm_show_screen1.Name = "robot_arm_show_screen1";
            this.robot_arm_show_screen1.OutsideCircle = 180F;
            this.robot_arm_show_screen1.RobotArmState = PC_Arayuz.robot_arm_show_screen.robotArmState.AVAILABLE;
            this.robot_arm_show_screen1.SecondArmDegree = 60F;
            this.robot_arm_show_screen1.Size = new System.Drawing.Size(880, 690);
            this.robot_arm_show_screen1.StartPoint = new System.Drawing.Point(0, 0);
            this.robot_arm_show_screen1.TabIndex = 0;
            this.robot_arm_show_screen1.TakeorDrop = PC_Arayuz.robot_arm_show_screen.takeDropState.DROP;
            this.robot_arm_show_screen1.Text = "robot_arm_show_screen1";
            this.robot_arm_show_screen1.Click += new System.EventHandler(this.robot_arm_show_screen1_Click);
            this.robot_arm_show_screen1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.robot_arm_show_screen1_MouseClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.APP_EXIT);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button APP_EXIT;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label TITLE;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox endPosTxt;
        private System.Windows.Forms.TextBox startPosTxt;
        private System.Windows.Forms.RadioButton end;
        private System.Windows.Forms.RadioButton start;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button saveBtn;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button disconnectBtn;
        private System.Windows.Forms.Button connectBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox baudrateComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox portComboBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button checkBtn;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Timer timer1;
        private robot_arm_show_screen robot_arm_show_screen1;
    }
}

