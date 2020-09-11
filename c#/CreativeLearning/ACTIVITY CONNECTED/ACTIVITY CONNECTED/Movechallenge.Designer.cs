namespace ACTIVITY_CONNECTED
{
    partial class Movechallenge
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Movechallenge));
            this.rank1label = new System.Windows.Forms.Label();
            this.rank2label = new System.Windows.Forms.Label();
            this.rank3label = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.GameEnd = new System.Windows.Forms.Button();
            this.GetResult = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // rank1label
            // 
            this.rank1label.BackColor = System.Drawing.Color.Black;
            this.rank1label.ForeColor = System.Drawing.Color.White;
            this.rank1label.Location = new System.Drawing.Point(127, 230);
            this.rank1label.Name = "rank1label";
            this.rank1label.Size = new System.Drawing.Size(15, 15);
            this.rank1label.TabIndex = 9;
            this.rank1label.Text = "-";
            this.rank1label.TextChanged += new System.EventHandler(this.RankingLabel_TextChanged);
            // 
            // rank2label
            // 
            this.rank2label.BackColor = System.Drawing.Color.Black;
            this.rank2label.ForeColor = System.Drawing.Color.White;
            this.rank2label.Location = new System.Drawing.Point(127, 335);
            this.rank2label.Name = "rank2label";
            this.rank2label.Size = new System.Drawing.Size(15, 15);
            this.rank2label.TabIndex = 9;
            this.rank2label.Text = "-";
            this.rank2label.TextChanged += new System.EventHandler(this.RankingLabel_TextChanged);
            // 
            // rank3label
            // 
            this.rank3label.BackColor = System.Drawing.Color.Black;
            this.rank3label.ForeColor = System.Drawing.Color.White;
            this.rank3label.Location = new System.Drawing.Point(127, 435);
            this.rank3label.Name = "rank3label";
            this.rank3label.Size = new System.Drawing.Size(15, 15);
            this.rank3label.TabIndex = 9;
            this.rank3label.Text = "-";
            this.rank3label.TextChanged += new System.EventHandler(this.RankingLabel_TextChanged);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 52);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(238, 485);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(244, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(600, 477);
            this.panel1.TabIndex = 10;
            this.panel1.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Blue;
            this.label1.Font = new System.Drawing.Font("굴림", 30F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(238, 50);
            this.label1.TabIndex = 13;
            this.label1.Text = "00:00.00";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(31, 200);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(80, 80);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 14;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(31, 300);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(80, 80);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 14;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(31, 400);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(80, 80);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 14;
            this.pictureBox4.TabStop = false;
            // 
            // GameEnd
            // 
            this.GameEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.GameEnd.Location = new System.Drawing.Point(743, 486);
            this.GameEnd.Name = "GameEnd";
            this.GameEnd.Size = new System.Drawing.Size(101, 48);
            this.GameEnd.TabIndex = 15;
            this.GameEnd.Text = "게임 종료";
            this.GameEnd.UseVisualStyleBackColor = true;
            this.GameEnd.Click += new System.EventHandler(this.GameEnd_Click);
            // 
            // GetResult
            // 
            this.GetResult.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.GetResult.Enabled = false;
            this.GetResult.Location = new System.Drawing.Point(662, 486);
            this.GetResult.Name = "GetResult";
            this.GetResult.Size = new System.Drawing.Size(75, 48);
            this.GetResult.TabIndex = 16;
            this.GetResult.Text = "결과";
            this.GetResult.UseVisualStyleBackColor = true;
            this.GetResult.Click += new System.EventHandler(this.GetResult_Click);
            // 
            // Movechallenge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.GetResult);
            this.Controls.Add(this.GameEnd);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rank3label);
            this.Controls.Add(this.rank2label);
            this.Controls.Add(this.rank1label);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Name = "Movechallenge";
            this.Size = new System.Drawing.Size(847, 537);
            this.Load += new System.EventHandler(this.Movechallenge_Load);
            this.Resize += new System.EventHandler(this.Movechallenge_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label rank1label;
        private System.Windows.Forms.Label rank2label;
        private System.Windows.Forms.Label rank3label;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Button GameEnd;
        private System.Windows.Forms.Button GetResult;
    }
}
