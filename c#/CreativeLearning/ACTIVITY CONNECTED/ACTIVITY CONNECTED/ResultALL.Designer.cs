namespace ACTIVITY_CONNECTED
{
    partial class ResultALL
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResultALL));
            this.label1 = new System.Windows.Forms.Label();
            this.GoBack = new System.Windows.Forms.PictureBox();
            this.SaveExcel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.GoBack)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 136);
            this.label1.TabIndex = 0;
            this.label1.Text = "랭킹";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.TextChanged += new System.EventHandler(this.label1_TextChanged);
            // 
            // GoBack
            // 
            this.GoBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.GoBack.Image = ((System.Drawing.Image)(resources.GetObject("GoBack.Image")));
            this.GoBack.Location = new System.Drawing.Point(407, 3);
            this.GoBack.Name = "GoBack";
            this.GoBack.Size = new System.Drawing.Size(125, 63);
            this.GoBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.GoBack.TabIndex = 2;
            this.GoBack.TabStop = false;
            this.GoBack.Click += new System.EventHandler(this.GoBack_Click);
            // 
            // SaveExcel
            // 
            this.SaveExcel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveExcel.Location = new System.Drawing.Point(407, 72);
            this.SaveExcel.MaximumSize = new System.Drawing.Size(300, 150);
            this.SaveExcel.Name = "SaveExcel";
            this.SaveExcel.Size = new System.Drawing.Size(125, 60);
            this.SaveExcel.TabIndex = 12;
            this.SaveExcel.Text = "결과엑셀저장";
            this.SaveExcel.UseVisualStyleBackColor = true;
            this.SaveExcel.Click += new System.EventHandler(this.SaveExcel_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.GoBack);
            this.panel1.Controls.Add(this.SaveExcel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(535, 136);
            this.panel1.TabIndex = 13;
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 136);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(535, 176);
            this.panel2.TabIndex = 14;
            this.panel2.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.panel2_ControlAdded);
            // 
            // ResultALL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ResultALL";
            this.Size = new System.Drawing.Size(535, 312);
            this.Load += new System.EventHandler(this.ResultALL_Load);
            this.Resize += new System.EventHandler(this.ResultALL_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.GoBack)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox GoBack;
        private System.Windows.Forms.Button SaveExcel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}
