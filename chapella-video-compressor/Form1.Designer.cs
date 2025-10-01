namespace chapella_video_compressor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.videoToCompressTxt = new System.Windows.Forms.TextBox();
            this.videoCompressDestinationFolderTxt = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.destinationFolderBtn = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.videoToCompressDirBtn = new System.Windows.Forms.Button();
            this.compressVideoBtn = new System.Windows.Forms.Button();
            this.videoCompressionProgressTxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // videoToCompressTxt
            // 
            this.videoToCompressTxt.AllowDrop = true;
            this.videoToCompressTxt.Font = new System.Drawing.Font("Arial Narrow", 10F);
            this.videoToCompressTxt.Location = new System.Drawing.Point(6, 34);
            this.videoToCompressTxt.Name = "videoToCompressTxt";
            this.videoToCompressTxt.Size = new System.Drawing.Size(402, 23);
            this.videoToCompressTxt.TabIndex = 0;
            this.videoToCompressTxt.Text = "drag and drop your video file here...";
            this.videoToCompressTxt.DragDrop += new System.Windows.Forms.DragEventHandler(this.videoToCompressTxt_DragDrop);
            this.videoToCompressTxt.DragEnter += new System.Windows.Forms.DragEventHandler(this.videoToCompressTxt_DragEnter);
            this.videoToCompressTxt.Enter += new System.EventHandler(this.videoToCompressTxt_Enter);
            this.videoToCompressTxt.Leave += new System.EventHandler(this.videoToCompressTxt_Leave);
            // 
            // videoCompressDestinationFolderTxt
            // 
            this.videoCompressDestinationFolderTxt.AllowDrop = true;
            this.videoCompressDestinationFolderTxt.Font = new System.Drawing.Font("Arial Narrow", 10F);
            this.videoCompressDestinationFolderTxt.Location = new System.Drawing.Point(6, 34);
            this.videoCompressDestinationFolderTxt.Name = "videoCompressDestinationFolderTxt";
            this.videoCompressDestinationFolderTxt.Size = new System.Drawing.Size(402, 23);
            this.videoCompressDestinationFolderTxt.TabIndex = 1;
            this.videoCompressDestinationFolderTxt.Text = "drag and drop your video file here...";
            this.videoCompressDestinationFolderTxt.DragDrop += new System.Windows.Forms.DragEventHandler(this.videoCompressDestinationFolderTxt_DragDrop);
            this.videoCompressDestinationFolderTxt.DragEnter += new System.Windows.Forms.DragEventHandler(this.videoCompressDestinationFolderTxt_DragEnter);
            this.videoCompressDestinationFolderTxt.Enter += new System.EventHandler(this.videoCompressDestinationFolderTxt_Enter);
            this.videoCompressDestinationFolderTxt.Leave += new System.EventHandler(this.videoCompressDestinationFolderTxt_Leave);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.destinationFolderBtn);
            this.groupBox1.Controls.Add(this.videoCompressDestinationFolderTxt);
            this.groupBox1.Font = new System.Drawing.Font("Arial Narrow", 10F);
            this.groupBox1.Location = new System.Drawing.Point(20, 152);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(434, 114);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "destination folder";
            // 
            // destinationFolderBtn
            // 
            this.destinationFolderBtn.BackColor = System.Drawing.Color.Black;
            this.destinationFolderBtn.FlatAppearance.BorderColor = System.Drawing.Color.Firebrick;
            this.destinationFolderBtn.FlatAppearance.BorderSize = 2;
            this.destinationFolderBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.destinationFolderBtn.Image = global::chapella_video_compressor.Properties.Resources.open_folder;
            this.destinationFolderBtn.Location = new System.Drawing.Point(350, 63);
            this.destinationFolderBtn.Name = "destinationFolderBtn";
            this.destinationFolderBtn.Size = new System.Drawing.Size(58, 29);
            this.destinationFolderBtn.TabIndex = 2;
            this.destinationFolderBtn.UseVisualStyleBackColor = false;
            this.destinationFolderBtn.Click += new System.EventHandler(this.destinationFolderBtn_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.videoToCompressDirBtn);
            this.groupBox2.Controls.Add(this.videoToCompressTxt);
            this.groupBox2.Font = new System.Drawing.Font("Arial Narrow", 10F);
            this.groupBox2.Location = new System.Drawing.Point(20, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(434, 114);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "video to compress";
            // 
            // videoToCompressDirBtn
            // 
            this.videoToCompressDirBtn.BackColor = System.Drawing.Color.Black;
            this.videoToCompressDirBtn.FlatAppearance.BorderColor = System.Drawing.Color.Firebrick;
            this.videoToCompressDirBtn.FlatAppearance.BorderSize = 2;
            this.videoToCompressDirBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.videoToCompressDirBtn.Image = global::chapella_video_compressor.Properties.Resources.open_folder;
            this.videoToCompressDirBtn.Location = new System.Drawing.Point(350, 63);
            this.videoToCompressDirBtn.Name = "videoToCompressDirBtn";
            this.videoToCompressDirBtn.Size = new System.Drawing.Size(58, 29);
            this.videoToCompressDirBtn.TabIndex = 1;
            this.videoToCompressDirBtn.UseVisualStyleBackColor = false;
            this.videoToCompressDirBtn.Click += new System.EventHandler(this.videoToCompressDirBtn_Click);
            // 
            // compressVideoBtn
            // 
            this.compressVideoBtn.Font = new System.Drawing.Font("Arial Narrow", 15F);
            this.compressVideoBtn.Location = new System.Drawing.Point(127, 278);
            this.compressVideoBtn.Name = "compressVideoBtn";
            this.compressVideoBtn.Size = new System.Drawing.Size(221, 43);
            this.compressVideoBtn.TabIndex = 4;
            this.compressVideoBtn.Text = "COMPRES VIDEO";
            this.compressVideoBtn.UseVisualStyleBackColor = true;
            this.compressVideoBtn.Click += new System.EventHandler(this.compressVideoBtn_Click);
            // 
            // videoCompressionProgressTxt
            // 
            this.videoCompressionProgressTxt.Font = new System.Drawing.Font("Arial Narrow", 15F);
            this.videoCompressionProgressTxt.Location = new System.Drawing.Point(26, 358);
            this.videoCompressionProgressTxt.Multiline = true;
            this.videoCompressionProgressTxt.Name = "videoCompressionProgressTxt";
            this.videoCompressionProgressTxt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.videoCompressionProgressTxt.Size = new System.Drawing.Size(402, 79);
            this.videoCompressionProgressTxt.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 10F);
            this.label1.Location = new System.Drawing.Point(23, 338);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "video compression progress";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 449);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.videoCompressionProgressTxt);
            this.Controls.Add(this.compressVideoBtn);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "chapella video compressor";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox videoToCompressTxt;
        private System.Windows.Forms.TextBox videoCompressDestinationFolderTxt;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button destinationFolderBtn;
        private System.Windows.Forms.Button videoToCompressDirBtn;
        private System.Windows.Forms.Button compressVideoBtn;
        private System.Windows.Forms.TextBox videoCompressionProgressTxt;
        private System.Windows.Forms.Label label1;
    }
}

