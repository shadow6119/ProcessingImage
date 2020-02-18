namespace ProcessingImage
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.SelectImageButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.GrayScale = new System.Windows.Forms.ToolStripMenuItem();
            this.二値化ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.モザイクToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.エッジ抽出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.回転ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.明るさ調整ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.コントラストToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveImage = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox.Location = new System.Drawing.Point(0, 29);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(960, 540);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 2;
            this.pictureBox.TabStop = false;
            // 
            // SelectImageButton
            // 
            this.SelectImageButton.Location = new System.Drawing.Point(5, 1);
            this.SelectImageButton.Name = "SelectImageButton";
            this.SelectImageButton.Size = new System.Drawing.Size(75, 23);
            this.SelectImageButton.TabIndex = 4;
            this.SelectImageButton.Text = "画像選択";
            this.SelectImageButton.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(80, 8, 0, 2);
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GrayScale,
            this.二値化ToolStripMenuItem,
            this.モザイクToolStripMenuItem,
            this.エッジ抽出ToolStripMenuItem,
            this.回転ToolStripMenuItem,
            this.明るさ調整ToolStripMenuItem,
            this.コントラストToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Margin = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(964, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // GrayScale
            // 
            this.GrayScale.Name = "GrayScale";
            this.GrayScale.Size = new System.Drawing.Size(93, 20);
            this.GrayScale.Text = "グレースケール化";
            // 
            // 二値化ToolStripMenuItem
            // 
            this.二値化ToolStripMenuItem.Name = "二値化ToolStripMenuItem";
            this.二値化ToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.二値化ToolStripMenuItem.Text = "二値化";
            // 
            // モザイクToolStripMenuItem
            // 
            this.モザイクToolStripMenuItem.Name = "モザイクToolStripMenuItem";
            this.モザイクToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.モザイクToolStripMenuItem.Text = "モザイク";
            // 
            // エッジ抽出ToolStripMenuItem
            // 
            this.エッジ抽出ToolStripMenuItem.Name = "エッジ抽出ToolStripMenuItem";
            this.エッジ抽出ToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.エッジ抽出ToolStripMenuItem.Text = "エッジ抽出";
            // 
            // 回転ToolStripMenuItem
            // 
            this.回転ToolStripMenuItem.Name = "回転ToolStripMenuItem";
            this.回転ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.回転ToolStripMenuItem.Text = "回転";
            // 
            // 明るさ調整ToolStripMenuItem
            // 
            this.明るさ調整ToolStripMenuItem.Name = "明るさ調整ToolStripMenuItem";
            this.明るさ調整ToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.明るさ調整ToolStripMenuItem.Text = "明るさ調整";
            // 
            // コントラストToolStripMenuItem
            // 
            this.コントラストToolStripMenuItem.Name = "コントラストToolStripMenuItem";
            this.コントラストToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.コントラストToolStripMenuItem.Text = "コントラスト";
            // 
            // SaveImage
            // 
            this.SaveImage.Location = new System.Drawing.Point(885, 1);
            this.SaveImage.Name = "SaveImage";
            this.SaveImage.Size = new System.Drawing.Size(75, 23);
            this.SaveImage.TabIndex = 6;
            this.SaveImage.Text = "画像保存";
            this.SaveImage.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 571);
            this.Controls.Add(this.SaveImage);
            this.Controls.Add(this.SelectImageButton);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "画像処理";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button SelectImageButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem GrayScale;
        private System.Windows.Forms.ToolStripMenuItem 二値化ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem モザイクToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem エッジ抽出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 回転ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 明るさ調整ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem コントラストToolStripMenuItem;
        private System.Windows.Forms.Button SaveImage;
    }
}

