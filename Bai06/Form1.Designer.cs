namespace Bai06
{
    partial class Form1
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSaoChep = new System.Windows.Forms.Button();
            this.btnChonDich = new System.Windows.Forms.Button();
            this.btnChonNguon = new System.Windows.Forms.Button();
            this.txtDich = new System.Windows.Forms.TextBox();
            this.txtNguon = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pbTienDo = new System.Windows.Forms.ProgressBar();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.bgWorker = new System.ComponentModel.BackgroundWorker();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSaoChep);
            this.groupBox1.Controls.Add(this.btnChonDich);
            this.groupBox1.Controls.Add(this.btnChonNguon);
            this.groupBox1.Controls.Add(this.txtDich);
            this.groupBox1.Controls.Add(this.txtNguon);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Blue;
            this.groupBox1.Location = new System.Drawing.Point(12, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(776, 258);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sao chép tập tin";
            // 
            // btnSaoChep
            // 
            this.btnSaoChep.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSaoChep.Location = new System.Drawing.Point(319, 209);
            this.btnSaoChep.Name = "btnSaoChep";
            this.btnSaoChep.Size = new System.Drawing.Size(210, 33);
            this.btnSaoChep.TabIndex = 5;
            this.btnSaoChep.Text = "Sao Chép";
            this.btnSaoChep.UseVisualStyleBackColor = true;
            this.btnSaoChep.Click += new System.EventHandler(this.btnSaoChep_Click);
            // 
            // btnChonDich
            // 
            this.btnChonDich.Location = new System.Drawing.Point(695, 157);
            this.btnChonDich.Name = "btnChonDich";
            this.btnChonDich.Size = new System.Drawing.Size(75, 29);
            this.btnChonDich.TabIndex = 4;
            this.btnChonDich.Text = "...";
            this.btnChonDich.UseVisualStyleBackColor = true;
            this.btnChonDich.Click += new System.EventHandler(this.btnChonDich_Click);
            // 
            // btnChonNguon
            // 
            this.btnChonNguon.Location = new System.Drawing.Point(695, 52);
            this.btnChonNguon.Name = "btnChonNguon";
            this.btnChonNguon.Size = new System.Drawing.Size(75, 26);
            this.btnChonNguon.TabIndex = 3;
            this.btnChonNguon.Text = "...";
            this.btnChonNguon.UseVisualStyleBackColor = true;
            this.btnChonNguon.Click += new System.EventHandler(this.btnChonNguon_Click);
            // 
            // txtDich
            // 
            this.txtDich.Location = new System.Drawing.Point(319, 157);
            this.txtDich.Name = "txtDich";
            this.txtDich.Size = new System.Drawing.Size(352, 26);
            this.txtDich.TabIndex = 2;
            // 
            // txtNguon
            // 
            this.txtNguon.Location = new System.Drawing.Point(319, 52);
            this.txtNguon.Name = "txtNguon";
            this.txtNguon.Size = new System.Drawing.Size(352, 26);
            this.txtNguon.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(82, 163);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(192, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Đường Dẫn Thư Mục Đích";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(82, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(207, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Đường Dẫn Thư Mục Nguồn";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pbTienDo);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Blue;
            this.groupBox2.Location = new System.Drawing.Point(12, 318);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(776, 100);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tiến trình sao chép";
            // 
            // pbTienDo
            // 
            this.pbTienDo.Location = new System.Drawing.Point(86, 55);
            this.pbTienDo.Name = "pbTienDo";
            this.pbTienDo.Size = new System.Drawing.Size(606, 23);
            this.pbTienDo.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(91, 17);
            this.lblStatus.Text = "Đang sao chép: ";
            // 
            // bgWorker
            // 
            this.bgWorker.WorkerReportsProgress = true;
            this.bgWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorker_DoWork);
            this.bgWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgWorker_ProgressChanged);
            this.bgWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorker_RunWorkerCompleted);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtNguon;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnChonNguon;
        private System.Windows.Forms.TextBox txtDich;
        private System.Windows.Forms.Button btnChonDich;
        private System.Windows.Forms.Button btnSaoChep;
        private System.Windows.Forms.ProgressBar pbTienDo;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.ComponentModel.BackgroundWorker bgWorker;
    }
}

