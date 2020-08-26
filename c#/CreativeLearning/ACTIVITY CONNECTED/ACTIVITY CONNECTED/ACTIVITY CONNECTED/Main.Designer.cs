namespace ACTIVITY_CONNECTED
{
    partial class Main
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

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.openbuzzerset = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.opendbset = new System.Windows.Forms.Button();
            this.opengame = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // openbuzzerset
            // 
            this.openbuzzerset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.openbuzzerset.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.openbuzzerset.Location = new System.Drawing.Point(921, 569);
            this.openbuzzerset.Name = "openbuzzerset";
            this.openbuzzerset.Size = new System.Drawing.Size(150, 61);
            this.openbuzzerset.TabIndex = 0;
            this.openbuzzerset.Text = "버저설정";
            this.openbuzzerset.UseVisualStyleBackColor = false;
            this.openbuzzerset.Click += new System.EventHandler(this.openbuzzerset_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(903, 618);
            this.panel1.TabIndex = 1;
            // 
            // opendbset
            // 
            this.opendbset.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.opendbset.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.opendbset.Location = new System.Drawing.Point(921, 265);
            this.opendbset.Name = "opendbset";
            this.opendbset.Size = new System.Drawing.Size(150, 61);
            this.opendbset.TabIndex = 2;
            this.opendbset.Text = "학생설정";
            this.opendbset.UseVisualStyleBackColor = false;
            this.opendbset.Click += new System.EventHandler(this.opendbset_Click);
            // 
            // opengame
            // 
            this.opengame.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.opengame.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.opengame.Location = new System.Drawing.Point(921, 12);
            this.opengame.Name = "opengame";
            this.opengame.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.opengame.Size = new System.Drawing.Size(150, 61);
            this.opengame.TabIndex = 3;
            this.opengame.Text = "게임";
            this.opengame.UseVisualStyleBackColor = false;
            this.opengame.Click += new System.EventHandler(this.opengame_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1080, 635);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.opengame);
            this.Controls.Add(this.opendbset);
            this.Controls.Add(this.openbuzzerset);
            this.Name = "Main";
            this.Text = "ACTIVITY CONNECTED";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
            this.ResizeEnd += new System.EventHandler(this.Main_ResizeEnd);
            this.SizeChanged += new System.EventHandler(this.Main_SizeChanged);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button openbuzzerset;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button opendbset;
        private System.Windows.Forms.Button opengame;
    }
}

