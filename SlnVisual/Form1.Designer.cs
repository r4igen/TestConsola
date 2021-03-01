
namespace SlnVisual
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pbImagen = new System.Windows.Forms.PictureBox();
            this.txtRuc = new System.Windows.Forms.TextBox();
            this.btnConsultaRuc = new System.Windows.Forms.Button();
            this.txtCaptcha = new System.Windows.Forms.TextBox();
            this.txtRpta = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagen)).BeginInit();
            this.SuspendLayout();
            // 
            // pbImagen
            // 
            this.pbImagen.Location = new System.Drawing.Point(507, 11);
            this.pbImagen.Name = "pbImagen";
            this.pbImagen.Size = new System.Drawing.Size(181, 81);
            this.pbImagen.TabIndex = 0;
            this.pbImagen.TabStop = false;
            // 
            // txtRuc
            // 
            this.txtRuc.Location = new System.Drawing.Point(376, 11);
            this.txtRuc.Name = "txtRuc";
            this.txtRuc.Size = new System.Drawing.Size(102, 23);
            this.txtRuc.TabIndex = 1;
            this.txtRuc.Text = "10709854092";
            // 
            // btnConsultaRuc
            // 
            this.btnConsultaRuc.Location = new System.Drawing.Point(376, 69);
            this.btnConsultaRuc.Name = "btnConsultaRuc";
            this.btnConsultaRuc.Size = new System.Drawing.Size(102, 23);
            this.btnConsultaRuc.TabIndex = 2;
            this.btnConsultaRuc.Text = "&ConsultaRuc";
            this.btnConsultaRuc.UseVisualStyleBackColor = true;
            this.btnConsultaRuc.Click += new System.EventHandler(this.btnConsultaRuc_Click);
            // 
            // txtCaptcha
            // 
            this.txtCaptcha.Location = new System.Drawing.Point(376, 40);
            this.txtCaptcha.Name = "txtCaptcha";
            this.txtCaptcha.Size = new System.Drawing.Size(102, 23);
            this.txtCaptcha.TabIndex = 3;
            // 
            // txtRpta
            // 
            this.txtRpta.Location = new System.Drawing.Point(12, 98);
            this.txtRpta.Multiline = true;
            this.txtRpta.Name = "txtRpta";
            this.txtRpta.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtRpta.Size = new System.Drawing.Size(1039, 340);
            this.txtRpta.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 450);
            this.Controls.Add(this.txtRpta);
            this.Controls.Add(this.txtCaptcha);
            this.Controls.Add(this.btnConsultaRuc);
            this.Controls.Add(this.txtRuc);
            this.Controls.Add(this.pbImagen);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbImagen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbImagen;
        private System.Windows.Forms.TextBox txtRuc;
        private System.Windows.Forms.Button btnConsultaRuc;
        private System.Windows.Forms.TextBox txtCaptcha;
        private System.Windows.Forms.TextBox txtRpta;
    }
}

