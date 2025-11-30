namespace Bibliotecla
{
    partial class frm_Consul_Funcionario
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.gunaLabel2 = new Guna.UI.WinForms.GunaLabel();
            this.cmb_Filtro = new Guna.UI.WinForms.GunaComboBox();
            this.gunaLabel1 = new Guna.UI.WinForms.GunaLabel();
            this.txt_Leitor = new Guna.UI.WinForms.GunaTextBox();
            this.btn_Excluir = new Guna.UI.WinForms.GunaButton();
            this.btn_Editar = new Guna.UI.WinForms.GunaButton();
            this.btn_Voltar = new Guna.UI.WinForms.GunaButton();
            this.btn_Pesquisar = new Guna.UI.WinForms.GunaButton();
            this.Dgv_Consul_Funcionario = new Guna.UI.WinForms.GunaDataGridView();
            this.Col_Nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_Cpf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_Telefone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_Cep = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_Rua = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_NumRes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_Cidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_Bairro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_Usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_Senha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_Cargo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_Consul_Funcionario)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria Math", 35.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.label1.Location = new System.Drawing.Point(186, -83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(618, 262);
            this.label1.TabIndex = 64;
            this.label1.Text = "Consulta de Funcionário";
            // 
            // gunaLabel2
            // 
            this.gunaLabel2.AutoSize = true;
            this.gunaLabel2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaLabel2.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.gunaLabel2.Location = new System.Drawing.Point(605, 88);
            this.gunaLabel2.Name = "gunaLabel2";
            this.gunaLabel2.Size = new System.Drawing.Size(57, 21);
            this.gunaLabel2.TabIndex = 72;
            this.gunaLabel2.Text = "Filtros";
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
            "cpf",
            "telefone",
            "email",
            "nome",
            "cargo",
            "usuario",
            "senha",
            "cep",
            "rua",
            "numRes",
            "cidade",
            "bairro"});
            this.cmb_Filtro.Location = new System.Drawing.Point(609, 112);
            this.cmb_Filtro.Name = "cmb_Filtro";
            this.cmb_Filtro.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.cmb_Filtro.OnHoverItemForeColor = System.Drawing.Color.White;
            this.cmb_Filtro.Size = new System.Drawing.Size(179, 26);
            this.cmb_Filtro.TabIndex = 71;
            // 
            // gunaLabel1
            // 
            this.gunaLabel1.AutoSize = true;
            this.gunaLabel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaLabel1.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.gunaLabel1.Location = new System.Drawing.Point(90, 88);
            this.gunaLabel1.Name = "gunaLabel1";
            this.gunaLabel1.Size = new System.Drawing.Size(101, 21);
            this.gunaLabel1.TabIndex = 70;
            this.gunaLabel1.Text = "Funcionário";
            // 
            // txt_Leitor
            // 
            this.txt_Leitor.BaseColor = System.Drawing.Color.White;
            this.txt_Leitor.BorderColor = System.Drawing.Color.Silver;
            this.txt_Leitor.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_Leitor.FocusedBaseColor = System.Drawing.Color.White;
            this.txt_Leitor.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txt_Leitor.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txt_Leitor.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_Leitor.Location = new System.Drawing.Point(94, 112);
            this.txt_Leitor.Name = "txt_Leitor";
            this.txt_Leitor.PasswordChar = '\0';
            this.txt_Leitor.SelectedText = "";
            this.txt_Leitor.Size = new System.Drawing.Size(509, 26);
            this.txt_Leitor.TabIndex = 69;
            // 
            // btn_Excluir
            // 
            this.btn_Excluir.AnimationHoverSpeed = 0.07F;
            this.btn_Excluir.AnimationSpeed = 0.03F;
            this.btn_Excluir.BaseColor = System.Drawing.Color.SaddleBrown;
            this.btn_Excluir.BorderColor = System.Drawing.Color.Black;
            this.btn_Excluir.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btn_Excluir.FocusedColor = System.Drawing.Color.Empty;
            this.btn_Excluir.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Excluir.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.btn_Excluir.Image = null;
            this.btn_Excluir.ImageSize = new System.Drawing.Size(20, 20);
            this.btn_Excluir.Location = new System.Drawing.Point(170, 468);
            this.btn_Excluir.Name = "btn_Excluir";
            this.btn_Excluir.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.btn_Excluir.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btn_Excluir.OnHoverForeColor = System.Drawing.Color.White;
            this.btn_Excluir.OnHoverImage = null;
            this.btn_Excluir.OnPressedColor = System.Drawing.Color.Black;
            this.btn_Excluir.Size = new System.Drawing.Size(132, 42);
            this.btn_Excluir.TabIndex = 75;
            this.btn_Excluir.Text = "Excluir";
            this.btn_Excluir.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btn_Editar
            // 
            this.btn_Editar.AnimationHoverSpeed = 0.07F;
            this.btn_Editar.AnimationSpeed = 0.03F;
            this.btn_Editar.BaseColor = System.Drawing.Color.SaddleBrown;
            this.btn_Editar.BorderColor = System.Drawing.Color.Black;
            this.btn_Editar.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btn_Editar.FocusedColor = System.Drawing.Color.Empty;
            this.btn_Editar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Editar.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.btn_Editar.Image = null;
            this.btn_Editar.ImageSize = new System.Drawing.Size(20, 20);
            this.btn_Editar.Location = new System.Drawing.Point(687, 468);
            this.btn_Editar.Name = "btn_Editar";
            this.btn_Editar.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.btn_Editar.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btn_Editar.OnHoverForeColor = System.Drawing.Color.White;
            this.btn_Editar.OnHoverImage = null;
            this.btn_Editar.OnPressedColor = System.Drawing.Color.Black;
            this.btn_Editar.Size = new System.Drawing.Size(132, 42);
            this.btn_Editar.TabIndex = 74;
            this.btn_Editar.Text = "Editar";
            this.btn_Editar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btn_Editar.Click += new System.EventHandler(this.btn_Editar_Click_1);
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
            this.btn_Voltar.Location = new System.Drawing.Point(424, 524);
            this.btn_Voltar.Name = "btn_Voltar";
            this.btn_Voltar.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.btn_Voltar.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btn_Voltar.OnHoverForeColor = System.Drawing.Color.White;
            this.btn_Voltar.OnHoverImage = null;
            this.btn_Voltar.OnPressedColor = System.Drawing.Color.Black;
            this.btn_Voltar.Size = new System.Drawing.Size(132, 42);
            this.btn_Voltar.TabIndex = 73;
            this.btn_Voltar.Text = "Voltar";
            this.btn_Voltar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btn_Voltar.Click += new System.EventHandler(this.btn_Voltar_Click);
            // 
            // btn_Pesquisar
            // 
            this.btn_Pesquisar.AnimationHoverSpeed = 0.07F;
            this.btn_Pesquisar.AnimationSpeed = 0.03F;
            this.btn_Pesquisar.BaseColor = System.Drawing.Color.SaddleBrown;
            this.btn_Pesquisar.BorderColor = System.Drawing.Color.Black;
            this.btn_Pesquisar.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btn_Pesquisar.FocusedColor = System.Drawing.Color.Empty;
            this.btn_Pesquisar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Pesquisar.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.btn_Pesquisar.Image = null;
            this.btn_Pesquisar.ImageSize = new System.Drawing.Size(20, 20);
            this.btn_Pesquisar.Location = new System.Drawing.Point(794, 112);
            this.btn_Pesquisar.Name = "btn_Pesquisar";
            this.btn_Pesquisar.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.btn_Pesquisar.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btn_Pesquisar.OnHoverForeColor = System.Drawing.Color.White;
            this.btn_Pesquisar.OnHoverImage = null;
            this.btn_Pesquisar.OnPressedColor = System.Drawing.Color.Black;
            this.btn_Pesquisar.Size = new System.Drawing.Size(86, 26);
            this.btn_Pesquisar.TabIndex = 76;
            this.btn_Pesquisar.Text = "Pesquisar";
            this.btn_Pesquisar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btn_Pesquisar.Click += new System.EventHandler(this.btn_Pesquisar_Click);
            // 
            // Dgv_Consul_Funcionario
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.Dgv_Consul_Funcionario.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.Dgv_Consul_Funcionario.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Dgv_Consul_Funcionario.BackgroundColor = System.Drawing.Color.White;
            this.Dgv_Consul_Funcionario.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Dgv_Consul_Funcionario.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.Dgv_Consul_Funcionario.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Dgv_Consul_Funcionario.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.Dgv_Consul_Funcionario.ColumnHeadersHeight = 21;
            this.Dgv_Consul_Funcionario.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Col_Nome,
            this.Col_Cpf,
            this.Col_Email,
            this.Col_Telefone,
            this.Col_Cep,
            this.Col_Rua,
            this.Col_NumRes,
            this.Col_Cidade,
            this.Col_Bairro,
            this.Col_Usuario,

            this.Col_Senha,
            this.Col_Cargo});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Dgv_Consul_Funcionario.DefaultCellStyle = dataGridViewCellStyle3;
            this.Dgv_Consul_Funcionario.EnableHeadersVisualStyles = false;
            this.Dgv_Consul_Funcionario.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.Dgv_Consul_Funcionario.Location = new System.Drawing.Point(94, 144);
            this.Dgv_Consul_Funcionario.Name = "Dgv_Consul_Funcionario";
            this.Dgv_Consul_Funcionario.RowHeadersVisible = false;
            this.Dgv_Consul_Funcionario.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Dgv_Consul_Funcionario.Size = new System.Drawing.Size(786, 318);
            this.Dgv_Consul_Funcionario.TabIndex = 77;
            this.Dgv_Consul_Funcionario.Theme = Guna.UI.WinForms.GunaDataGridViewPresetThemes.Guna;
            this.Dgv_Consul_Funcionario.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.Dgv_Consul_Funcionario.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.Dgv_Consul_Funcionario.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.Dgv_Consul_Funcionario.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.Dgv_Consul_Funcionario.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.Dgv_Consul_Funcionario.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.Dgv_Consul_Funcionario.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.Dgv_Consul_Funcionario.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.Dgv_Consul_Funcionario.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.Dgv_Consul_Funcionario.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.Dgv_Consul_Funcionario.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.Dgv_Consul_Funcionario.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.Dgv_Consul_Funcionario.ThemeStyle.HeaderStyle.Height = 21;
            this.Dgv_Consul_Funcionario.ThemeStyle.ReadOnly = false;
            this.Dgv_Consul_Funcionario.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.Dgv_Consul_Funcionario.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.Dgv_Consul_Funcionario.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.Dgv_Consul_Funcionario.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.Dgv_Consul_Funcionario.ThemeStyle.RowsStyle.Height = 22;
            this.Dgv_Consul_Funcionario.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.Dgv_Consul_Funcionario.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.Dgv_Consul_Funcionario.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv_Consul_Funcionario_CellContentClick);
            // 
            // Col_Nome
            // 
            this.Col_Nome.HeaderText = "Nome";
            this.Col_Nome.Name = "Col_Nome";
            this.Col_Nome.ReadOnly = true;
            // 
            // Col_Cpf
            // 
            this.Col_Cpf.HeaderText = "Cpf";
            this.Col_Cpf.Name = "Col_Cpf";
            this.Col_Cpf.ReadOnly = true;
            // 
            // Col_Email
            // 
            this.Col_Email.HeaderText = "Email";
            this.Col_Email.Name = "Col_Email";
            this.Col_Email.ReadOnly = true;
            // 
            // Col_Telefone
            // 
            this.Col_Telefone.HeaderText = "Tel";
            this.Col_Telefone.Name = "Col_Telefone";
            this.Col_Telefone.ReadOnly = true;
            // 
            // Col_Cep
            // 
            this.Col_Cep.HeaderText = "CEP";
            this.Col_Cep.Name = "Col_Cep";
            this.Col_Cep.ReadOnly = true;
            // 
            // Col_Rua
            // 
            this.Col_Rua.HeaderText = "Rua";
            this.Col_Rua.Name = "Col_Rua";
            this.Col_Rua.ReadOnly = true;
            // 
            // Col_NumRes
            // 
            this.Col_NumRes.HeaderText = "N°Res";
            this.Col_NumRes.Name = "Col_NumRes";
            this.Col_NumRes.ReadOnly = true;
            // 
            // Col_Cidade
            // 
            this.Col_Cidade.HeaderText = "Cidade";
            this.Col_Cidade.Name = "Col_Cidade";
            this.Col_Cidade.ReadOnly = true;
            // 
            // Col_Bairro
            // 
            this.Col_Bairro.HeaderText = "Bairro";
            this.Col_Bairro.Name = "Col_Bairro";
            this.Col_Bairro.ReadOnly = true;
            // 
            // Col_Usuario
            // 
            this.Col_Usuario.HeaderText = "Usuário";
            this.Col_Usuario.Name = "Col_Usuario";
            this.Col_Usuario.ReadOnly = true;
            // 
            // Col_Senha
            // 
            this.Col_Senha.HeaderText = "Senha";
            this.Col_Senha.Name = "Col_Senha";
            this.Col_Senha.ReadOnly = true;
            // 
            // Col_Cargo
            // 
            this.Col_Cargo.HeaderText = "Cargo";
            this.Col_Cargo.Name = "Col_Cargo";
            this.Col_Cargo.ReadOnly = true;
            // 
            // frm_Consul_Funcionario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGreen;
            this.ClientSize = new System.Drawing.Size(980, 607);
            this.Controls.Add(this.Dgv_Consul_Funcionario);
            this.Controls.Add(this.btn_Pesquisar);
            this.Controls.Add(this.btn_Excluir);
            this.Controls.Add(this.btn_Editar);
            this.Controls.Add(this.btn_Voltar);
            this.Controls.Add(this.gunaLabel2);
            this.Controls.Add(this.cmb_Filtro);
            this.Controls.Add(this.gunaLabel1);
            this.Controls.Add(this.txt_Leitor);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "frm_Consul_Funcionario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consul_Funcinario";
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_Consul_Funcionario)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Guna.UI.WinForms.GunaLabel gunaLabel2;
        private Guna.UI.WinForms.GunaComboBox cmb_Filtro;
        private Guna.UI.WinForms.GunaLabel gunaLabel1;
        private Guna.UI.WinForms.GunaTextBox txt_Leitor;
        private Guna.UI.WinForms.GunaButton btn_Excluir;
        private Guna.UI.WinForms.GunaButton btn_Editar;
        private Guna.UI.WinForms.GunaButton btn_Voltar;
        private Guna.UI.WinForms.GunaButton btn_Pesquisar;
        private Guna.UI.WinForms.GunaDataGridView Dgv_Consul_Funcionario;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_Nome;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_Cpf;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_Telefone;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_Cep;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_Rua;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_NumRes;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_Cidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_Bairro;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_Usuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_Senha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_Cargo;
    }
}