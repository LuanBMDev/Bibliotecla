namespace Bibliotecla
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Login = new Guna.UI.WinForms.GunaButton();
            this.gunaLabel2 = new Guna.UI.WinForms.GunaLabel();
            this.gunaLabel1 = new Guna.UI.WinForms.GunaLabel();
            this.txt_senha = new Guna.UI.WinForms.GunaTextBox();
            this.txt_cadastro = new Guna.UI.WinForms.GunaTextBox();
            this.chk_MostrarSenha = new Guna.UI.WinForms.GunaCheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria Math", 35.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.label1.Location = new System.Drawing.Point(260, -70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(336, 262);
            this.label1.TabIndex = 1;
            this.label1.Text = "Bibliotecla";
            // 
            // btn_Login
            // 
            this.btn_Login.AnimationHoverSpeed = 0.07F;
            this.btn_Login.AnimationSpeed = 0.03F;
            this.btn_Login.BaseColor = System.Drawing.Color.SaddleBrown;
            this.btn_Login.BorderColor = System.Drawing.Color.Black;
            this.btn_Login.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btn_Login.FocusedColor = System.Drawing.Color.Empty;
            this.btn_Login.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Login.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.btn_Login.Image = null;
            this.btn_Login.ImageSize = new System.Drawing.Size(20, 20);
            this.btn_Login.Location = new System.Drawing.Point(339, 312);
            this.btn_Login.Name = "btn_Login";
            this.btn_Login.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.btn_Login.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btn_Login.OnHoverForeColor = System.Drawing.Color.White;
            this.btn_Login.OnHoverImage = null;
            this.btn_Login.OnPressedColor = System.Drawing.Color.Black;
            this.btn_Login.Size = new System.Drawing.Size(160, 42);
            this.btn_Login.TabIndex = 10;
            this.btn_Login.Text = "Entrar";
            this.btn_Login.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btn_Login.Click += new System.EventHandler(this.btn_Login_Click);
            // 
            // gunaLabel2
            // 
            this.gunaLabel2.AutoSize = true;
            this.gunaLabel2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaLabel2.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.gunaLabel2.Location = new System.Drawing.Point(389, 197);
            this.gunaLabel2.Name = "gunaLabel2";
            this.gunaLabel2.Size = new System.Drawing.Size(57, 21);
            this.gunaLabel2.TabIndex = 9;
            this.gunaLabel2.Text = "Senha";
            // 
            // gunaLabel1
            // 
            this.gunaLabel1.AutoSize = true;
            this.gunaLabel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaLabel1.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.gunaLabel1.Location = new System.Drawing.Point(379, 107);
            this.gunaLabel1.Name = "gunaLabel1";
            this.gunaLabel1.Size = new System.Drawing.Size(77, 21);
            this.gunaLabel1.TabIndex = 8;
            this.gunaLabel1.Text = "Cadastro";
            // 
            // txt_senha
            // 
            this.txt_senha.BaseColor = System.Drawing.Color.White;
            this.txt_senha.BorderColor = System.Drawing.Color.Silver;
            this.txt_senha.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_senha.FocusedBaseColor = System.Drawing.Color.White;
            this.txt_senha.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txt_senha.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txt_senha.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_senha.Location = new System.Drawing.Point(335, 221);
            this.txt_senha.Name = "txt_senha";
            this.txt_senha.PasswordChar = '●';
            this.txt_senha.SelectedText = "";
            this.txt_senha.Size = new System.Drawing.Size(164, 30);
            this.txt_senha.TabIndex = 7;
            // 
            // txt_cadastro
            // 
            this.txt_cadastro.BaseColor = System.Drawing.Color.White;
            this.txt_cadastro.BorderColor = System.Drawing.Color.Silver;
            this.txt_cadastro.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_cadastro.FocusedBaseColor = System.Drawing.Color.White;
            this.txt_cadastro.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txt_cadastro.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txt_cadastro.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_cadastro.Location = new System.Drawing.Point(335, 131);
            this.txt_cadastro.Name = "txt_cadastro";
            this.txt_cadastro.PasswordChar = '\0';
            this.txt_cadastro.SelectedText = "";
            this.txt_cadastro.Size = new System.Drawing.Size(164, 30);
            this.txt_cadastro.TabIndex = 6;
            // 
            // chk_MostrarSenha
            // 
            this.chk_MostrarSenha.BaseColor = System.Drawing.Color.White;
            this.chk_MostrarSenha.CheckedOffColor = System.Drawing.Color.Gray;
            this.chk_MostrarSenha.CheckedOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.chk_MostrarSenha.FillColor = System.Drawing.Color.White;
            this.chk_MostrarSenha.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.chk_MostrarSenha.Location = new System.Drawing.Point(335, 257);
            this.chk_MostrarSenha.Name = "chk_MostrarSenha";
            this.chk_MostrarSenha.Size = new System.Drawing.Size(104, 20);
            this.chk_MostrarSenha.TabIndex = 79;
            this.chk_MostrarSenha.Text = "Mostrar Senha";
            this.chk_MostrarSenha.CheckedChanged += new System.EventHandler(this.chk_MostrarSenha_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGreen;
            this.ClientSize = new System.Drawing.Size(834, 461);
            this.Controls.Add(this.chk_MostrarSenha);
            this.Controls.Add(this.btn_Login);
            this.Controls.Add(this.gunaLabel2);
            this.Controls.Add(this.gunaLabel1);
            this.Controls.Add(this.txt_senha);
            this.Controls.Add(this.txt_cadastro);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Guna.UI.WinForms.GunaButton btn_Login;
        private Guna.UI.WinForms.GunaLabel gunaLabel2;
        private Guna.UI.WinForms.GunaLabel gunaLabel1;
        private Guna.UI.WinForms.GunaTextBox txt_senha;
        private Guna.UI.WinForms.GunaTextBox txt_cadastro;
        private Guna.UI.WinForms.GunaCheckBox chk_MostrarSenha;
    }
}

