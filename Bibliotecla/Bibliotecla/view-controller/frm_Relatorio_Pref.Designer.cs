namespace Bibliotecla
{
    partial class frm_Relatorio_Pref
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
            this.gunaLabel2 = new Guna.UI.WinForms.GunaLabel();
            this.cmb_Filtro = new Guna.UI.WinForms.GunaComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Gerar_Relatorio = new Guna.UI.WinForms.GunaButton();
            this.btn_Voltar = new Guna.UI.WinForms.GunaButton();
            this.SuspendLayout();
            // 
            // gunaLabel2
            // 
            this.gunaLabel2.AutoSize = true;
            this.gunaLabel2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaLabel2.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.gunaLabel2.Location = new System.Drawing.Point(372, 157);
            this.gunaLabel2.Name = "gunaLabel2";
            this.gunaLabel2.Size = new System.Drawing.Size(57, 21);
            this.gunaLabel2.TabIndex = 79;
            this.gunaLabel2.Text = "Filtros";
            this.gunaLabel2.Click += new System.EventHandler(this.gunaLabel2_Click);
            // 
            // cmb_Filtro
            // 
            this.cmb_Filtro.BackColor = System.Drawing.Color.Transparent;
            this.cmb_Filtro.BaseColor = System.Drawing.Color.White;
            this.cmb_Filtro.BorderColor = System.Drawing.Color.Silver;
            this.cmb_Filtro.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmb_Filtro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Filtro.FocusedColor = System.Drawing.Color.Empty;
            this.cmb_Filtro.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmb_Filtro.ForeColor = System.Drawing.Color.Black;
            this.cmb_Filtro.FormattingEnabled = true;
            this.cmb_Filtro.Items.AddRange(new object[] {
            "Geral",
            "Mais Escolhido",
            "Mais Esperado"});
            this.cmb_Filtro.Location = new System.Drawing.Point(163, 181);
            this.cmb_Filtro.Name = "cmb_Filtro";
            this.cmb_Filtro.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.cmb_Filtro.OnHoverItemForeColor = System.Drawing.Color.White;
            this.cmb_Filtro.Size = new System.Drawing.Size(497, 26);
            this.cmb_Filtro.TabIndex = 78;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria Math", 35.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.label1.Location = new System.Drawing.Point(233, -84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(370, 262);
            this.label1.TabIndex = 80;
            this.label1.Text = "Preferências";
            // 
            // btn_Gerar_Relatorio
            // 
            this.btn_Gerar_Relatorio.AnimationHoverSpeed = 0.07F;
            this.btn_Gerar_Relatorio.AnimationSpeed = 0.03F;
            this.btn_Gerar_Relatorio.BaseColor = System.Drawing.Color.SaddleBrown;
            this.btn_Gerar_Relatorio.BorderColor = System.Drawing.Color.Black;
            this.btn_Gerar_Relatorio.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btn_Gerar_Relatorio.FocusedColor = System.Drawing.Color.Empty;
            this.btn_Gerar_Relatorio.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Gerar_Relatorio.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.btn_Gerar_Relatorio.Image = null;
            this.btn_Gerar_Relatorio.ImageSize = new System.Drawing.Size(20, 20);
            this.btn_Gerar_Relatorio.Location = new System.Drawing.Point(510, 352);
            this.btn_Gerar_Relatorio.Name = "btn_Gerar_Relatorio";
            this.btn_Gerar_Relatorio.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.btn_Gerar_Relatorio.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btn_Gerar_Relatorio.OnHoverForeColor = System.Drawing.Color.White;
            this.btn_Gerar_Relatorio.OnHoverImage = null;
            this.btn_Gerar_Relatorio.OnPressedColor = System.Drawing.Color.Black;
            this.btn_Gerar_Relatorio.Size = new System.Drawing.Size(184, 42);
            this.btn_Gerar_Relatorio.TabIndex = 82;
            this.btn_Gerar_Relatorio.Text = "Gerar";
            this.btn_Gerar_Relatorio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btn_Gerar_Relatorio.Click += new System.EventHandler(this.btn_Gerar_Relatorio_Click_1);
            // 
            // btn_Voltar
            // 
            this.btn_Voltar.AnimationHoverSpeed = 0.07F;
            this.btn_Voltar.AnimationSpeed = 0.03F;
            this.btn_Voltar.BaseColor = System.Drawing.Color.SaddleBrown;
            this.btn_Voltar.BorderColor = System.Drawing.Color.Black;
            this.btn_Voltar.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btn_Voltar.FocusedColor = System.Drawing.Color.Empty;
            this.btn_Voltar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Voltar.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.btn_Voltar.Image = null;
            this.btn_Voltar.ImageSize = new System.Drawing.Size(20, 20);
            this.btn_Voltar.Location = new System.Drawing.Point(131, 352);
            this.btn_Voltar.Name = "btn_Voltar";
            this.btn_Voltar.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.btn_Voltar.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btn_Voltar.OnHoverForeColor = System.Drawing.Color.White;
            this.btn_Voltar.OnHoverImage = null;
            this.btn_Voltar.OnPressedColor = System.Drawing.Color.Black;
            this.btn_Voltar.Size = new System.Drawing.Size(184, 42);
            this.btn_Voltar.TabIndex = 81;
            this.btn_Voltar.Text = "Voltar";
            this.btn_Voltar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btn_Voltar.Click += new System.EventHandler(this.btn_Voltar_Click);
            // 
            // frm_Relatorio_Pref
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGreen;
            this.ClientSize = new System.Drawing.Size(830, 457);
            this.Controls.Add(this.btn_Gerar_Relatorio);
            this.Controls.Add(this.btn_Voltar);
            this.Controls.Add(this.gunaLabel2);
            this.Controls.Add(this.cmb_Filtro);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "frm_Relatorio_Pref";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Relatorio_Pref";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI.WinForms.GunaLabel gunaLabel2;
        private Guna.UI.WinForms.GunaComboBox cmb_Filtro;
        private System.Windows.Forms.Label label1;
        private Guna.UI.WinForms.GunaButton btn_Gerar_Relatorio;
        private Guna.UI.WinForms.GunaButton btn_Voltar;
    }
}