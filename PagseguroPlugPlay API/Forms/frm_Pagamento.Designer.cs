
namespace PagseguroPlugPlay_API.Forms
{
    partial class frm_Pagamento
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
            this.lblStatusMaquininha = new System.Windows.Forms.Label();
            this.btnVerComprovante = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblTitle2 = new System.Windows.Forms.Label();
            this.lblCodigoResposta = new System.Windows.Forms.Label();
            this.btnFechar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblStatusMaquininha
            // 
            this.lblStatusMaquininha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatusMaquininha.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatusMaquininha.Location = new System.Drawing.Point(69, 41);
            this.lblStatusMaquininha.Name = "lblStatusMaquininha";
            this.lblStatusMaquininha.Size = new System.Drawing.Size(462, 30);
            this.lblStatusMaquininha.TabIndex = 0;
            this.lblStatusMaquininha.Text = "Moderninha PRO - Processando o pagamento";
            this.lblStatusMaquininha.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnVerComprovante
            // 
            this.btnVerComprovante.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVerComprovante.Location = new System.Drawing.Point(165, 168);
            this.btnVerComprovante.Name = "btnVerComprovante";
            this.btnVerComprovante.Size = new System.Drawing.Size(123, 52);
            this.btnVerComprovante.TabIndex = 1;
            this.btnVerComprovante.Text = "Verificar comprovante";
            this.btnVerComprovante.UseVisualStyleBackColor = true;
            this.btnVerComprovante.Click += new System.EventHandler(this.btnVerComprovante_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(204, 14);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(192, 25);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Codigo da transação:";
            // 
            // lblTitle2
            // 
            this.lblTitle2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle2.Location = new System.Drawing.Point(214, 95);
            this.lblTitle2.Name = "lblTitle2";
            this.lblTitle2.Size = new System.Drawing.Size(172, 25);
            this.lblTitle2.TabIndex = 4;
            this.lblTitle2.Text = "Codigo de resposta:";
            // 
            // lblCodigoResposta
            // 
            this.lblCodigoResposta.AutoSize = true;
            this.lblCodigoResposta.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodigoResposta.Location = new System.Drawing.Point(230, 122);
            this.lblCodigoResposta.Name = "lblCodigoResposta";
            this.lblCodigoResposta.Size = new System.Drawing.Size(141, 30);
            this.lblCodigoResposta.TabIndex = 3;
            this.lblCodigoResposta.Text = "Andamento...";
            this.lblCodigoResposta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnFechar
            // 
            this.btnFechar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFechar.Location = new System.Drawing.Point(294, 168);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(123, 52);
            this.btnFechar.TabIndex = 5;
            this.btnFechar.Text = "Sair";
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // frm_Pagamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 232);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.lblTitle2);
            this.Controls.Add(this.lblCodigoResposta);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnVerComprovante);
            this.Controls.Add(this.lblStatusMaquininha);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_Pagamento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_Pagamento";
            this.Load += new System.EventHandler(this.frm_Pagamento_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblStatusMaquininha;
        private System.Windows.Forms.Button btnVerComprovante;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblTitle2;
        private System.Windows.Forms.Label lblCodigoResposta;
        private System.Windows.Forms.Button btnFechar;
    }
}