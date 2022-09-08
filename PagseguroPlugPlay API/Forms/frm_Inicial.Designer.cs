
namespace PagseguroPlugPlay_API.Forms
{
    partial class frm_Inicial
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
            this.txtValorCompra = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnEstornarCompra = new System.Windows.Forms.Button();
            this.btnEfetuarCompra = new System.Windows.Forms.Button();
            this.chkCredito = new System.Windows.Forms.CheckBox();
            this.chkDebito = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // txtValorCompra
            // 
            this.txtValorCompra.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValorCompra.Location = new System.Drawing.Point(88, 35);
            this.txtValorCompra.Name = "txtValorCompra";
            this.txtValorCompra.Size = new System.Drawing.Size(49, 33);
            this.txtValorCompra.TabIndex = 0;
            this.txtValorCompra.Text = "1";
            this.txtValorCompra.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(49)))), ((int)(((byte)(116)))));
            this.label1.Location = new System.Drawing.Point(47, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "R$";
            // 
            // btnEstornarCompra
            // 
            this.btnEstornarCompra.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnEstornarCompra.Location = new System.Drawing.Point(24, 178);
            this.btnEstornarCompra.Name = "btnEstornarCompra";
            this.btnEstornarCompra.Size = new System.Drawing.Size(176, 34);
            this.btnEstornarCompra.TabIndex = 2;
            this.btnEstornarCompra.Text = "Estornar Compra";
            this.btnEstornarCompra.UseVisualStyleBackColor = true;
            this.btnEstornarCompra.Click += new System.EventHandler(this.btnEstornarCompra_Click);
            // 
            // btnEfetuarCompra
            // 
            this.btnEfetuarCompra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(50)))), ((int)(((byte)(180)))));
            this.btnEfetuarCompra.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEfetuarCompra.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnEfetuarCompra.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnEfetuarCompra.Location = new System.Drawing.Point(24, 217);
            this.btnEfetuarCompra.Name = "btnEfetuarCompra";
            this.btnEfetuarCompra.Size = new System.Drawing.Size(176, 34);
            this.btnEfetuarCompra.TabIndex = 3;
            this.btnEfetuarCompra.Text = "Efetuar Compra";
            this.btnEfetuarCompra.UseVisualStyleBackColor = false;
            this.btnEfetuarCompra.Click += new System.EventHandler(this.btnEfetuarCompra_Click);
            // 
            // chkCredito
            // 
            this.chkCredito.AutoSize = true;
            this.chkCredito.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.chkCredito.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.chkCredito.Location = new System.Drawing.Point(75, 102);
            this.chkCredito.Name = "chkCredito";
            this.chkCredito.Size = new System.Drawing.Size(74, 23);
            this.chkCredito.TabIndex = 4;
            this.chkCredito.Text = "Credito";
            this.chkCredito.UseVisualStyleBackColor = true;
            this.chkCredito.CheckedChanged += new System.EventHandler(this.chkCredito_CheckedChanged);
            // 
            // chkDebito
            // 
            this.chkDebito.AutoSize = true;
            this.chkDebito.Checked = true;
            this.chkDebito.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDebito.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.chkDebito.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.chkDebito.Location = new System.Drawing.Point(75, 124);
            this.chkDebito.Name = "chkDebito";
            this.chkDebito.Size = new System.Drawing.Size(70, 23);
            this.chkDebito.TabIndex = 5;
            this.chkDebito.Text = "Debito";
            this.chkDebito.UseVisualStyleBackColor = true;
            this.chkDebito.CheckedChanged += new System.EventHandler(this.chkDebito_CheckedChanged);
            // 
            // frm_Inicial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(36)))), ((int)(((byte)(42)))));
            this.ClientSize = new System.Drawing.Size(224, 286);
            this.Controls.Add(this.chkDebito);
            this.Controls.Add(this.chkCredito);
            this.Controls.Add(this.btnEfetuarCompra);
            this.Controls.Add(this.btnEstornarCompra);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtValorCompra);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_Inicial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_Inicial";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtValorCompra;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnEstornarCompra;
        private System.Windows.Forms.Button btnEfetuarCompra;
        private System.Windows.Forms.CheckBox chkCredito;
        private System.Windows.Forms.CheckBox chkDebito;
    }
}