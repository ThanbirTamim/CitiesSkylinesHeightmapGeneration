
namespace MapBoxHeightPngDownload
{
    partial class HeightMapPngDownload
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
            this.txtMinLong = new System.Windows.Forms.TextBox();
            this.txtMinLat = new System.Windows.Forms.TextBox();
            this.txtMaxLong = new System.Windows.Forms.TextBox();
            this.txtMaxLat = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.radioOnline = new System.Windows.Forms.RadioButton();
            this.radioLocal = new System.Windows.Forms.RadioButton();
            this.btnGenerateHeightPng = new System.Windows.Forms.Button();
            this.txtImageWidth = new System.Windows.Forms.TextBox();
            this.txtImageHeight = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtMinLong
            // 
            this.txtMinLong.Location = new System.Drawing.Point(191, 122);
            this.txtMinLong.Name = "txtMinLong";
            this.txtMinLong.Size = new System.Drawing.Size(141, 20);
            this.txtMinLong.TabIndex = 0;
            this.txtMinLong.Text = "91.63331";
            // 
            // txtMinLat
            // 
            this.txtMinLat.Location = new System.Drawing.Point(191, 164);
            this.txtMinLat.Name = "txtMinLat";
            this.txtMinLat.Size = new System.Drawing.Size(141, 20);
            this.txtMinLat.TabIndex = 1;
            this.txtMinLat.Text = "25.20607";
            // 
            // txtMaxLong
            // 
            this.txtMaxLong.Location = new System.Drawing.Point(461, 122);
            this.txtMaxLong.Name = "txtMaxLong";
            this.txtMaxLong.Size = new System.Drawing.Size(141, 20);
            this.txtMaxLong.TabIndex = 2;
            this.txtMaxLong.Text = "91.80512";
            // 
            // txtMaxLat
            // 
            this.txtMaxLat.Location = new System.Drawing.Point(461, 164);
            this.txtMaxLat.Name = "txtMaxLat";
            this.txtMaxLat.Size = new System.Drawing.Size(141, 20);
            this.txtMaxLat.TabIndex = 3;
            this.txtMaxLat.Text = "25.36141";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(347, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "Extent";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(134, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Min Long";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(143, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Min Lat";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(401, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Max Long";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(410, 167);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Max Lat";
            // 
            // radioOnline
            // 
            this.radioOnline.AutoSize = true;
            this.radioOnline.Checked = true;
            this.radioOnline.Location = new System.Drawing.Point(293, 273);
            this.radioOnline.Name = "radioOnline";
            this.radioOnline.Size = new System.Drawing.Size(162, 17);
            this.radioOnline.TabIndex = 9;
            this.radioOnline.TabStop = true;
            this.radioOnline.Text = "Height Data (Mapbox Online)";
            this.radioOnline.UseVisualStyleBackColor = true;
            // 
            // radioLocal
            // 
            this.radioLocal.AutoSize = true;
            this.radioLocal.Location = new System.Drawing.Point(315, 296);
            this.radioLocal.Name = "radioLocal";
            this.radioLocal.Size = new System.Drawing.Size(117, 17);
            this.radioLocal.TabIndex = 10;
            this.radioLocal.Text = "Height Data (Local)";
            this.radioLocal.UseVisualStyleBackColor = true;
            this.radioLocal.Visible = false;
            // 
            // btnGenerateHeightPng
            // 
            this.btnGenerateHeightPng.Location = new System.Drawing.Point(335, 343);
            this.btnGenerateHeightPng.Name = "btnGenerateHeightPng";
            this.btnGenerateHeightPng.Size = new System.Drawing.Size(97, 32);
            this.btnGenerateHeightPng.TabIndex = 11;
            this.btnGenerateHeightPng.Text = "Generate Png";
            this.btnGenerateHeightPng.UseVisualStyleBackColor = true;
            this.btnGenerateHeightPng.Click += new System.EventHandler(this.btnGenerateHeightPng_Click);
            // 
            // txtImageWidth
            // 
            this.txtImageWidth.Location = new System.Drawing.Point(191, 223);
            this.txtImageWidth.Name = "txtImageWidth";
            this.txtImageWidth.Size = new System.Drawing.Size(141, 20);
            this.txtImageWidth.TabIndex = 12;
            this.txtImageWidth.Text = "1081";
            // 
            // txtImageHeight
            // 
            this.txtImageHeight.Location = new System.Drawing.Point(461, 223);
            this.txtImageHeight.Name = "txtImageHeight";
            this.txtImageHeight.Size = new System.Drawing.Size(141, 20);
            this.txtImageHeight.TabIndex = 13;
            this.txtImageHeight.Text = "1081";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(198, 207);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(119, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Image Dimension Width";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(469, 207);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(122, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Image Dimension Height";
            // 
            // HeightMapPngDownload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 490);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtImageHeight);
            this.Controls.Add(this.txtImageWidth);
            this.Controls.Add(this.btnGenerateHeightPng);
            this.Controls.Add(this.radioLocal);
            this.Controls.Add(this.radioOnline);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMaxLat);
            this.Controls.Add(this.txtMaxLong);
            this.Controls.Add(this.txtMinLat);
            this.Controls.Add(this.txtMinLong);
            this.Name = "HeightMapPngDownload";
            this.Text = "HeightMapPngDownload";
            this.Load += new System.EventHandler(this.HeightMapPngDownload_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMinLong;
        private System.Windows.Forms.TextBox txtMinLat;
        private System.Windows.Forms.TextBox txtMaxLong;
        private System.Windows.Forms.TextBox txtMaxLat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton radioOnline;
        private System.Windows.Forms.RadioButton radioLocal;
        private System.Windows.Forms.Button btnGenerateHeightPng;
        private System.Windows.Forms.TextBox txtImageWidth;
        private System.Windows.Forms.TextBox txtImageHeight;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}