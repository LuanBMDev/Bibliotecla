namespace Bibliotecla
{
    partial class frm_Colsul_Titulos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_Titulo = new Guna.UI.WinForms.GunaTextBox();
            this.gunaLabel1 = new Guna.UI.WinForms.GunaLabel();
            this.cmb_EstExemplar = new Guna.UI.WinForms.GunaComboBox();
            this.gunaLabel2 = new Guna.UI.WinForms.GunaLabel();
            this.btn_Excluir = new Guna.UI.WinForms.GunaButton();
            this.btn_Editar = new Guna.UI.WinForms.GunaButton();
            this.btn_Voltar = new Guna.UI.WinForms.GunaButton();
            this.btn_Pesquisar = new Guna.UI.WinForms.GunaButton();
            this.Dgv_Consul_Titulo = new Guna.UI.WinForms.GunaDataGridView();
            this.Col_Titulo_Titulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_Autor_Titulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_Genero_Titulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_Consul_Titulo)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria Math", 35.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.label1.Location = new System.Drawing.Point(159, -82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(514, 262);
            this.label1.TabIndex = 10;
            this.label1.Text = "Consulta de Títulos";
            // 
            // txt_Titulo
            // 
            this.txt_Titulo.BaseColor = System.Drawing.Color.White;
            this.txt_Titulo.BorderColor = System.Drawing.Color.Silver;
            this.txt_Titulo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_Titulo.FocusedBaseColor = System.Drawing.Color.White;
            this.txt_Titulo.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txt_Titulo.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txt_Titulo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_Titulo.Location = new System.Drawing.Point(86, 106);
            this.txt_Titulo.Name = "txt_Titulo";
            this.txt_Titulo.PasswordChar = '\0';
            this.txt_Titulo.SelectedText = "";
            this.txt_Titulo.Size = new System.Drawing.Size(397, 26);
            this.txt_Titulo.TabIndex = 44;
            // 
            // gunaLabel1
            // 
            this.gunaLabel1.AutoSize = true;
            this.gunaLabel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaLabel1.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.gunaLabel1.Location = new System.Drawing.Point(82, 82);
            this.gunaLabel1.Name = "gunaLabel1";
            this.gunaLabel1.Size = new System.Drawing.Size(55, 21);
            this.gunaLabel1.TabIndex = 45;
            this.gunaLabel1.Text = "Título";
            // 
            // cmb_EstExemplar
            // 
            this.cmb_EstExemplar.BackColor = System.Drawing.Color.Transparent;
            this.cmb_EstExemplar.BaseColor = System.Drawing.Color.White;
            this.cmb_EstExemplar.BorderColor = System.Drawing.Color.Silver;
            this.cmb_EstExemplar.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmb_EstExemplar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_EstExemplar.FocusedColor = System.Drawing.Color.Empty;
            this.cmb_EstExemplar.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmb_EstExemplar.ForeColor = System.Drawing.Color.Black;
            this.cmb_EstExemplar.FormattingEnabled = true;
            this.cmb_EstExemplar.Items.AddRange(new object[] {
            "nome titulo ",
            "autor",
            "genero"});
            this.cmb_EstExemplar.Location = new System.Drawing.Point(489, 106);
            this.cmb_EstExemplar.Name = "cmb_EstExemplar";
            this.cmb_EstExemplar.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.cmb_EstExemplar.OnHoverItemForeColor = System.Drawing.Color.White;
            this.cmb_EstExemplar.Size = new System.Drawing.Size(154, 26);
            this.cmb_EstExemplar.TabIndex = 58;
            // 
            // gunaLabel2
            // 
            this.gunaLabel2.AutoSize = true;
            this.gunaLabel2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaLabel2.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.gunaLabel2.Location = new System.Drawing.Point(485, 82);
            this.gunaLabel2.Name = "gunaLabel2";
            this.gunaLabel2.Size = new System.Drawing.Size(57, 21);
            this.gunaLabel2.TabIndex = 59;
            this.gunaLabel2.Text = "Filtros";
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
            this.btn_Excluir.Location = new System.Drawing.Point(86, 347);
            this.btn_Excluir.Name = "btn_Excluir";
            this.btn_Excluir.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.btn_Excluir.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btn_Excluir.OnHoverForeColor = System.Drawing.Color.White;
            this.btn_Excluir.OnHoverImage = null;
            this.btn_Excluir.OnPressedColor = System.Drawing.Color.Black;
            this.btn_Excluir.Size = new System.Drawing.Size(132, 42);
            this.btn_Excluir.TabIndex = 62;
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
            this.btn_Editar.Location = new System.Drawing.Point(603, 347);
            this.btn_Editar.Name = "btn_Editar";
            this.btn_Editar.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.btn_Editar.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btn_Editar.OnHoverForeColor = System.Drawing.Color.White;
            this.btn_Editar.OnHoverImage = null;
            this.btn_Editar.OnPressedColor = System.Drawing.Color.Black;
            this.btn_Editar.Size = new System.Drawing.Size(132, 42);
            this.btn_Editar.TabIndex = 61;
            this.btn_Editar.Text = "Editar";
            this.btn_Editar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            this.btn_Voltar.Location = new System.Drawing.Point(351, 403);
            this.btn_Voltar.Name = "btn_Voltar";
            this.btn_Voltar.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.btn_Voltar.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btn_Voltar.OnHoverForeColor = System.Drawing.Color.White;
            this.btn_Voltar.OnHoverImage = null;
            this.btn_Voltar.OnPressedColor = System.Drawing.Color.Black;
            this.btn_Voltar.Size = new System.Drawing.Size(132, 42);
            this.btn_Voltar.TabIndex = 60;
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
            this.btn_Pesquisar.Location = new System.Drawing.Point(649, 106);
            this.btn_Pesquisar.Name = "btn_Pesquisar";
            this.btn_Pesquisar.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.btn_Pesquisar.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btn_Pesquisar.OnHoverForeColor = System.Drawing.Color.White;
            this.btn_Pesquisar.OnHoverImage = null;
            this.btn_Pesquisar.OnPressedColor = System.Drawing.Color.Black;
            this.btn_Pesquisar.Size = new System.Drawing.Size(86, 26);
            this.btn_Pesquisar.TabIndex = 72;
            this.btn_Pesquisar.Text = "Pesquisar";
            this.btn_Pesquisar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btn_Pesquisar.Click += new System.EventHandler(this.btn_Pesquisar_Click);
            // 
            // Dgv_Consul_Titulo
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.Dgv_Consul_Titulo.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.Dgv_Consul_Titulo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Dgv_Consul_Titulo.BackgroundColor = System.Drawing.Color.White;
            this.Dgv_Consul_Titulo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Dgv_Consul_Titulo.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.Dgv_Consul_Titulo.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Dgv_Consul_Titulo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.Dgv_Consul_Titulo.ColumnHeadersHeight = 21;
            this.Dgv_Consul_Titulo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Col_Titulo_Titulo,
            this.Col_Autor_Titulo,
            this.Col_Genero_Titulo});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Dgv_Consul_Titulo.DefaultCellStyle = dataGridViewCellStyle3;
            this.Dgv_Consul_Titulo.EnableHeadersVisualStyles = false;
            this.Dgv_Consul_Titulo.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.Dgv_Consul_Titulo.Location = new System.Drawing.Point(86, 138);
            this.Dgv_Consul_Titulo.Name = "Dgv_Consul_Titulo";
            this.Dgv_Consul_Titulo.RowHeadersVisible = false;
            this.Dgv_Consul_Titulo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Dgv_Consul_Titulo.Size = new System.Drawing.Size(649, 195);
            this.Dgv_Consul_Titulo.TabIndex = 73;
            this.Dgv_Consul_Titulo.Theme = Guna.UI.WinForms.GunaDataGridViewPresetThemes.Guna;
            this.Dgv_Consul_Titulo.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.Dgv_Consul_Titulo.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.Dgv_Consul_Titulo.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.Dgv_Consul_Titulo.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.Dgv_Consul_Titulo.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.Dgv_Consul_Titulo.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.Dgv_Consul_Titulo.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.Dgv_Consul_Titulo.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.Dgv_Consul_Titulo.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.Dgv_Consul_Titulo.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.Dgv_Consul_Titulo.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.Dgv_Consul_Titulo.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.Dgv_Consul_Titulo.ThemeStyle.HeaderStyle.Height = 21;
            this.Dgv_Consul_Titulo.ThemeStyle.ReadOnly = false;
            this.Dgv_Consul_Titulo.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.Dgv_Consul_Titulo.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.Dgv_Consul_Titulo.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.Dgv_Consul_Titulo.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.Dgv_Consul_Titulo.ThemeStyle.RowsStyle.Height = 22;
            this.Dgv_Consul_Titulo.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.Dgv_Consul_Titulo.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.Dgv_Consul_Titulo.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv_Consul_Titulo_CellContentClick);
            // 
            // Col_Titulo_Titulo
            // 
            this.Col_Titulo_Titulo.HeaderText = "Titulo";
            this.Col_Titulo_Titulo.Name = "Col_Titulo_Titulo";
            this.Col_Titulo_Titulo.ReadOnly = true;
            // 
            // Col_Autor_Titulo
            // 
            this.Col_Autor_Titulo.HeaderText = "Autor";
            this.Col_Autor_Titulo.Name = "Col_Autor_Titulo";
            this.Col_Autor_Titulo.ReadOnly = true;
            // 
            // Col_Genero_Titulo
            // 
            this.Col_Genero_Titulo.HeaderText = "Genero";
            this.Col_Genero_Titulo.Name = "Col_Genero_Titulo";
            this.Col_Genero_Titulo.ReadOnly = true;
            // 
            // frm_Colsul_Titulos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGreen;
            this.ClientSize = new System.Drawing.Size(830, 457);
            this.Controls.Add(this.Dgv_Consul_Titulo);
            this.Controls.Add(this.btn_Pesquisar);
            this.Controls.Add(this.btn_Excluir);
            this.Controls.Add(this.btn_Editar);
            this.Controls.Add(this.btn_Voltar);
            this.Controls.Add(this.gunaLabel2);
            this.Controls.Add(this.cmb_EstExemplar);
            this.Controls.Add(this.gunaLabel1);
            this.Controls.Add(this.txt_Titulo);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "frm_Colsul_Titulos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Colsul_Titulos";
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_Consul_Titulo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Guna.UI.WinForms.GunaTextBox txt_Titulo;
        private Guna.UI.WinForms.GunaLabel gunaLabel1;
        private Guna.UI.WinForms.GunaComboBox cmb_EstExemplar;
        private Guna.UI.WinForms.GunaLabel gunaLabel2;
        private Guna.UI.WinForms.GunaButton btn_Excluir;
        private Guna.UI.WinForms.GunaButton btn_Editar;
        private Guna.UI.WinForms.GunaButton btn_Voltar;
        private Guna.UI.WinForms.GunaButton btn_Pesquisar;
        private Guna.UI.WinForms.GunaDataGridView Dgv_Consul_Titulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_Titulo_Titulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_Autor_Titulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_Genero_Titulo;
    }
}