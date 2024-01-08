namespace OCR_on_screenshot
{
    partial class FormEkranYakala
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
            this.pbEkranGoruntusu = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbEkranGoruntusu)).BeginInit();
            this.SuspendLayout();
            // 
            // pbEkranGoruntusu
            // 
            this.pbEkranGoruntusu.Location = new System.Drawing.Point(0, 0);
            this.pbEkranGoruntusu.Name = "pbEkranGoruntusu";
            this.pbEkranGoruntusu.Size = new System.Drawing.Size(100, 100);
            this.pbEkranGoruntusu.TabIndex = 0;
            this.pbEkranGoruntusu.TabStop = false;
            this.pbEkranGoruntusu.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbEkranGoruntusu_MouseDown);
            this.pbEkranGoruntusu.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbEkranGoruntusu_MouseMove);
            this.pbEkranGoruntusu.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbEkranGoruntusu_MouseUp);
            // 
            // FormEkranYakala
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pbEkranGoruntusu);
            this.Name = "FormEkranYakala";
            this.Text = "FormEkranYakala";
            this.Load += new System.EventHandler(this.FormEkranYakala_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbEkranGoruntusu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbEkranGoruntusu;
    }
}