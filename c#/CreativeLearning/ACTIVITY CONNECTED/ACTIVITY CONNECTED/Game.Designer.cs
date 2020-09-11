namespace ACTIVITY_CONNECTED
{
    partial class Game
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.gamepanel = new System.Windows.Forms.Panel();
            this.gamesetpanel = new System.Windows.Forms.Panel();
            this.participatepanel = new System.Windows.Forms.Panel();
            this.showinfocomboBox = new System.Windows.Forms.ComboBox();
            this.register = new System.Windows.Forms.Button();
            this.find = new System.Windows.Forms.Button();
            this.infoinput1 = new ACTIVITY_CONNECTED.Infoinput();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.maxparticipatescomboBox = new System.Windows.Forms.ComboBox();
            this.gamepanel.SuspendLayout();
            this.gamesetpanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // gamepanel
            // 
            this.gamepanel.Controls.Add(this.gamesetpanel);
            this.gamepanel.Location = new System.Drawing.Point(4, 5);
            this.gamepanel.Name = "gamepanel";
            this.gamepanel.Size = new System.Drawing.Size(884, 482);
            this.gamepanel.TabIndex = 0;
            // 
            // gamesetpanel
            // 
            this.gamesetpanel.Controls.Add(this.participatepanel);
            this.gamesetpanel.Controls.Add(this.showinfocomboBox);
            this.gamesetpanel.Controls.Add(this.register);
            this.gamesetpanel.Controls.Add(this.find);
            this.gamesetpanel.Controls.Add(this.infoinput1);
            this.gamesetpanel.Controls.Add(this.button3);
            this.gamesetpanel.Controls.Add(this.label1);
            this.gamesetpanel.Controls.Add(this.button2);
            this.gamesetpanel.Controls.Add(this.maxparticipatescomboBox);
            this.gamesetpanel.Location = new System.Drawing.Point(3, 3);
            this.gamesetpanel.Name = "gamesetpanel";
            this.gamesetpanel.Size = new System.Drawing.Size(873, 476);
            this.gamesetpanel.TabIndex = 7;
            // 
            // participatepanel
            // 
            this.participatepanel.AutoScroll = true;
            this.participatepanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.participatepanel.Location = new System.Drawing.Point(316, 3);
            this.participatepanel.Name = "participatepanel";
            this.participatepanel.Size = new System.Drawing.Size(538, 376);
            this.participatepanel.TabIndex = 10;
            // 
            // showinfocomboBox
            // 
            this.showinfocomboBox.Enabled = false;
            this.showinfocomboBox.FormattingEnabled = true;
            this.showinfocomboBox.Location = new System.Drawing.Point(3, 250);
            this.showinfocomboBox.Name = "showinfocomboBox";
            this.showinfocomboBox.Size = new System.Drawing.Size(224, 23);
            this.showinfocomboBox.TabIndex = 9;
            // 
            // register
            // 
            this.register.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.register.Enabled = false;
            this.register.Location = new System.Drawing.Point(233, 250);
            this.register.Name = "register";
            this.register.Size = new System.Drawing.Size(68, 39);
            this.register.TabIndex = 8;
            this.register.Text = "등록";
            this.register.UseVisualStyleBackColor = false;
            this.register.Click += new System.EventHandler(this.register_Click);
            // 
            // find
            // 
            this.find.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.find.Enabled = false;
            this.find.Location = new System.Drawing.Point(233, 194);
            this.find.Name = "find";
            this.find.Size = new System.Drawing.Size(68, 39);
            this.find.TabIndex = 8;
            this.find.Text = "찾기";
            this.find.UseVisualStyleBackColor = false;
            this.find.Click += new System.EventHandler(this.find_Click);
            // 
            // infoinput1
            // 
            this.infoinput1.Enabled = false;
            this.infoinput1.Location = new System.Drawing.Point(3, 54);
            this.infoinput1.Name = "infoinput1";
            this.infoinput1.Size = new System.Drawing.Size(241, 190);
            this.infoinput1.TabIndex = 7;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point(3, 381);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(152, 92);
            this.button3.TabIndex = 4;
            this.button3.Text = "movechallenge";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.gamestart_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "참가인원";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(161, 381);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(152, 92);
            this.button2.TabIndex = 3;
            this.button2.Text = "pacer";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.gamestart_Click);
            // 
            // maxparticipatescomboBox
            // 
            this.maxparticipatescomboBox.FormattingEnabled = true;
            this.maxparticipatescomboBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30"});
            this.maxparticipatescomboBox.Location = new System.Drawing.Point(79, 25);
            this.maxparticipatescomboBox.Name = "maxparticipatescomboBox";
            this.maxparticipatescomboBox.Size = new System.Drawing.Size(42, 23);
            this.maxparticipatescomboBox.TabIndex = 5;
            this.maxparticipatescomboBox.Text = "0";
            this.maxparticipatescomboBox.SelectedIndexChanged += new System.EventHandler(this.maxparticipatecomboBox_SelectedIndexChanged);
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.gamepanel);
            this.Name = "Game";
            this.Size = new System.Drawing.Size(891, 490);
            this.Load += new System.EventHandler(this.Game_Load);
            this.Resize += new System.EventHandler(this.Game_Resize);
            this.gamepanel.ResumeLayout(false);
            this.gamesetpanel.ResumeLayout(false);
            this.gamesetpanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel gamepanel;
        private System.Windows.Forms.Panel gamesetpanel;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox maxparticipatescomboBox;
        private Infoinput infoinput1;
        private System.Windows.Forms.Button find;
        private System.Windows.Forms.ComboBox showinfocomboBox;
        private System.Windows.Forms.Button register;
        private System.Windows.Forms.Panel participatepanel;
    }
}
