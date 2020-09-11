namespace ACTIVITY_CONNECTED
{
    partial class DBsetting
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
            this.DBALL = new System.Windows.Forms.Button();
            this.manage = new System.Windows.Forms.Button();
            this.addpanel = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button7 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.findpanel = new System.Windows.Forms.Panel();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.editpanel = new System.Windows.Forms.Panel();
            this.infoinput1 = new ACTIVITY_CONNECTED.Infoinput();
            this.button10 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.menupanel = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.addpanel.SuspendLayout();
            this.findpanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.editpanel.SuspendLayout();
            this.menupanel.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // DBALL
            // 
            this.DBALL.Location = new System.Drawing.Point(3, 3);
            this.DBALL.Name = "DBALL";
            this.DBALL.Size = new System.Drawing.Size(126, 47);
            this.DBALL.TabIndex = 3;
            this.DBALL.Text = "DB 전체 출력";
            this.DBALL.UseVisualStyleBackColor = true;
            this.DBALL.Click += new System.EventHandler(this.DBALL_Click);
            // 
            // manage
            // 
            this.manage.Location = new System.Drawing.Point(135, 3);
            this.manage.Name = "manage";
            this.manage.Size = new System.Drawing.Size(126, 47);
            this.manage.TabIndex = 3;
            this.manage.Text = "학생 정보 관리";
            this.manage.UseVisualStyleBackColor = true;
            this.manage.Click += new System.EventHandler(this.manage_Click);
            // 
            // addpanel
            // 
            this.addpanel.BackColor = System.Drawing.SystemColors.Info;
            this.addpanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.addpanel.Controls.Add(this.textBox1);
            this.addpanel.Controls.Add(this.button7);
            this.addpanel.Location = new System.Drawing.Point(181, 56);
            this.addpanel.Name = "addpanel";
            this.addpanel.Size = new System.Drawing.Size(349, 339);
            this.addpanel.TabIndex = 4;
            this.addpanel.Visible = false;
            this.addpanel.VisibleChanged += new System.EventHandler(this.addpanel_VisibleChanged);
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.textBox1.Location = new System.Drawing.Point(0, 13);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(350, 27);
            this.textBox1.TabIndex = 8;
            this.textBox1.Text = "학생 추가";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(266, 300);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(78, 34);
            this.button7.TabIndex = 1;
            this.button7.Text = "추가하기";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.add_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(3, 2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(55, 43);
            this.button5.TabIndex = 0;
            this.button5.Text = "추가";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.openadd_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(64, 2);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(55, 43);
            this.button6.TabIndex = 0;
            this.button6.Text = "찾기";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.openfind_Click);
            // 
            // findpanel
            // 
            this.findpanel.BackColor = System.Drawing.SystemColors.Info;
            this.findpanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.findpanel.Controls.Add(this.textBox2);
            this.findpanel.Controls.Add(this.dataGridView1);
            this.findpanel.Controls.Add(this.editpanel);
            this.findpanel.Controls.Add(this.button8);
            this.findpanel.Location = new System.Drawing.Point(3, 56);
            this.findpanel.Name = "findpanel";
            this.findpanel.Size = new System.Drawing.Size(701, 475);
            this.findpanel.TabIndex = 5;
            this.findpanel.Visible = false;
            this.findpanel.VisibleChanged += new System.EventHandler(this.findpanel_VisibleChanged);
            // 
            // textBox2
            // 
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.textBox2.Location = new System.Drawing.Point(0, 13);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(698, 27);
            this.textBox2.TabIndex = 10;
            this.textBox2.Text = "학생 수정 및 삭제";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Info;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(294, 50);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(402, 420);
            this.dataGridView1.TabIndex = 9;
            this.dataGridView1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseUp);
            // 
            // editpanel
            // 
            this.editpanel.Controls.Add(this.infoinput1);
            this.editpanel.Controls.Add(this.button10);
            this.editpanel.Controls.Add(this.button9);
            this.editpanel.Location = new System.Drawing.Point(0, 224);
            this.editpanel.Name = "editpanel";
            this.editpanel.Size = new System.Drawing.Size(242, 246);
            this.editpanel.TabIndex = 6;
            this.editpanel.Visible = false;
            this.editpanel.VisibleChanged += new System.EventHandler(this.editpanel_VisibleChanged);
            // 
            // infoinput1
            // 
            this.infoinput1.Location = new System.Drawing.Point(-1, 3);
            this.infoinput1.Name = "infoinput1";
            this.infoinput1.Size = new System.Drawing.Size(237, 190);
            this.infoinput1.TabIndex = 1;
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(135, 199);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(82, 38);
            this.button10.TabIndex = 0;
            this.button10.Text = "삭제";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.delete_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(37, 199);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(82, 38);
            this.button9.TabIndex = 0;
            this.button9.Text = "수정";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.revise_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(236, 50);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(53, 34);
            this.button8.TabIndex = 0;
            this.button8.Text = "찾기";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.find_Click);
            // 
            // menupanel
            // 
            this.menupanel.Controls.Add(this.button6);
            this.menupanel.Controls.Add(this.button5);
            this.menupanel.Location = new System.Drawing.Point(583, 8);
            this.menupanel.Name = "menupanel";
            this.menupanel.Size = new System.Drawing.Size(121, 47);
            this.menupanel.TabIndex = 0;
            this.menupanel.Visible = false;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.button1);
            this.panel5.Controls.Add(this.addpanel);
            this.panel5.Controls.Add(this.menupanel);
            this.panel5.Controls.Add(this.manage);
            this.panel5.Controls.Add(this.DBALL);
            this.panel5.Controls.Add(this.findpanel);
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(709, 533);
            this.panel5.TabIndex = 6;
            this.panel5.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DBsetting_MouseClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(267, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(131, 47);
            this.button1.TabIndex = 6;
            this.button1.Text = "엑셀로 추가하기";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.ExceltoDB_Click);
            // 
            // DBsetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel5);
            this.Name = "DBsetting";
            this.Size = new System.Drawing.Size(714, 535);
            this.Load += new System.EventHandler(this.DBsetting_Load);
            this.SizeChanged += new System.EventHandler(this.DBsetting_SizeChanged);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DBsetting_MouseClick);
            this.addpanel.ResumeLayout(false);
            this.addpanel.PerformLayout();
            this.findpanel.ResumeLayout(false);
            this.findpanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.editpanel.ResumeLayout(false);
            this.menupanel.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button DBALL;
        private System.Windows.Forms.Button manage;
        private System.Windows.Forms.Panel addpanel;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Panel findpanel;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Panel menupanel;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Panel editpanel;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button9;
        private Infoinput infoinput1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button1;
    }
}
