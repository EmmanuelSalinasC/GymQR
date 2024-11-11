namespace GymPrueba1
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
            this.labelidCliente = new System.Windows.Forms.Label();
            this.buttonGenerarQR = new System.Windows.Forms.Button();
            this.pictureBoxQR = new System.Windows.Forms.PictureBox();
            this.textBoxCliente = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxQR)).BeginInit();
            this.SuspendLayout();
            // 
            // labelidCliente
            // 
            this.labelidCliente.AutoSize = true;
            this.labelidCliente.Location = new System.Drawing.Point(82, 216);
            this.labelidCliente.Name = "labelidCliente";
            this.labelidCliente.Size = new System.Drawing.Size(64, 16);
            this.labelidCliente.TabIndex = 0;
            this.labelidCliente.Text = "ID Cliente";
            // 
            // buttonGenerarQR
            // 
            this.buttonGenerarQR.Location = new System.Drawing.Point(67, 169);
            this.buttonGenerarQR.Name = "buttonGenerarQR";
            this.buttonGenerarQR.Size = new System.Drawing.Size(99, 26);
            this.buttonGenerarQR.TabIndex = 2;
            this.buttonGenerarQR.Text = "Generar QR";
            this.buttonGenerarQR.UseVisualStyleBackColor = true;
            this.buttonGenerarQR.Click += new System.EventHandler(this.buttonGenerarQR_Click);
            // 
            // pictureBoxQR
            // 
            this.pictureBoxQR.Location = new System.Drawing.Point(226, 111);
            this.pictureBoxQR.Name = "pictureBoxQR";
            this.pictureBoxQR.Size = new System.Drawing.Size(212, 195);
            this.pictureBoxQR.TabIndex = 3;
            this.pictureBoxQR.TabStop = false;
            this.pictureBoxQR.Click += new System.EventHandler(this.pictureBoxQR_Click);
            // 
            // textBoxCliente
            // 
            this.textBoxCliente.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.textBoxCliente.Location = new System.Drawing.Point(67, 256);
            this.textBoxCliente.Name = "textBoxCliente";
            this.textBoxCliente.Size = new System.Drawing.Size(100, 22);
            this.textBoxCliente.TabIndex = 4;
            this.textBoxCliente.TextChanged += new System.EventHandler(this.textBoxCliente_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBoxCliente);
            this.Controls.Add(this.pictureBoxQR);
            this.Controls.Add(this.buttonGenerarQR);
            this.Controls.Add(this.labelidCliente);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxQR)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelidCliente;
        private System.Windows.Forms.Button buttonGenerarQR;
        private System.Windows.Forms.PictureBox pictureBoxQR;
        private System.Windows.Forms.TextBox textBoxCliente;
    }
}

