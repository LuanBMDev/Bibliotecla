namespace Bibliotecla
{
    partial class frm_Consul_Exemplares
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
            this.btn_Excluir = new Guna.UI.WinForms.GunaButton();
            this.btn_Editar = new Guna.UI.WinForms.GunaButton();
            this.btn_Voltar = new Guna.UI.WinForms.GunaButton();
            this.gunaLabel2 = new Guna.UI.WinForms.GunaLabel();
            this.cmb_EstExemplar = new Guna.UI.WinForms.GunaComboBox();
            this.gunaLabel1 = new Guna.UI.WinForms.GunaLabel();
            this.txt_Titulo = new Guna.UI.WinForms.GunaTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Pesquisar = new Guna.UI.WinForms.GunaButton();
            this.Dgv_Consul_Exemplar = new Guna.UI.WinForms.GunaDataGridView();
            this.Col_Titulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_Ano_Publicado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_Editora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_Estado_Fisico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_Cod_Exemplar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_Consul_Exemplar)).BeginInit();
            this.SuspendLayout();
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
            this.btn_Excluir.Location = new System.Drawing.Point(85, 347);
            this.btn_Excluir.Name = "btn_Excluir";
            this.btn_Excluir.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.btn_Excluir.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btn_Excluir.OnHoverForeColor = System.Drawing.Color.White;
            this.btn_Excluir.OnHoverImage = null;
            this.btn_Excluir.OnPressedColor = System.Drawing.Color.Black;
            this.btn_Excluir.Size = new System.Drawing.Size(132, 42);
            this.btn_Excluir.TabIndex = 70;
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
            this.btn_Editar.Location = new System.Drawing.Point(602, 347);
            this.btn_Editar.Name = "btn_Editar";
            this.btn_Editar.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.btn_Editar.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btn_Editar.OnHoverForeColor = System.Drawing.Color.White;
            this.btn_Editar.OnHoverImage = null;
            this.btn_Editar.OnPressedColor = System.Drawing.Color.Black;
            this.btn_Editar.Size = new System.Drawing.Size(132, 42);
            this.btn_Editar.TabIndex = 69;
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
            this.btn_Voltar.Location = new System.Drawing.Point(350, 403);
            this.btn_Voltar.Name = "btn_Voltar";
            this.btn_Voltar.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.btn_Voltar.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btn_Voltar.OnHoverForeColor = System.Drawing.Color.White;
            this.btn_Voltar.OnHoverImage = null;
            this.btn_Voltar.OnPressedColor = System.Drawing.Color.Black;
            this.btn_Voltar.Size = new System.Drawing.Size(132, 42);
            this.btn_Voltar.TabIndex = 68;
            this.btn_Voltar.Text = "Voltar";
            this.btn_Voltar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btn_Voltar.Click += new System.EventHandler(this.btn_Voltar_Click);
            // 
            // gunaLabel2
            // 
            this.gunaLabel2.AutoSize = true;
            this.gunaLabel2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaLabel2.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.gunaLabel2.Location = new System.Drawing.Point(484, 82);
            this.gunaLabel2.Name = "gunaLabel2";
            this.gunaLabel2.Size = new System.Drawing.Size(57, 21);
            this.gunaLabel2.TabIndex = 67;
            this.gunaLabel2.Text = "Filtros";
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
            "codExemplar",
            "anopubli",
            "estadofisc",
            "editora",
            "titulo"});
            this.cmb_EstExemplar.Location = new System.Drawing.Point(488, 106);
            this.cmb_EstExemplar.Name = "cmb_EstExemplar";
            this.cmb_EstExemplar.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.cmb_EstExemplar.OnHoverItemForeColor = System.Drawing.Color.White;
            this.cmb_EstExemplar.Size = new System.Drawing.Size(154, 26);
            this.cmb_EstExemplar.TabIndex = 66;
            // 
            // gunaLabel1
            // 
            this.gunaLabel1.AutoSize = true;
            this.gunaLabel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaLabel1.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.gunaLabel1.Location = new System.Drawing.Point(81, 82);
            this.gunaLabel1.Name = "gunaLabel1";
            this.gunaLabel1.Size = new System.Drawing.Size(82, 21);
            this.gunaLabel1.TabIndex = 65;
            this.gunaLabel1.Text = "Exemplar";
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
            this.txt_Titulo.Location = new System.Drawing.Point(85, 106);
            this.txt_Titulo.Name = "txt_Titulo";
            this.txt_Titulo.PasswordChar = '\0';
            this.txt_Titulo.SelectedText = "";
            this.txt_Titulo.Size = new System.Drawing.Size(397, 26);
            this.txt_Titulo.TabIndex = 64;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria Math", 35.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.label1.Location = new System.Drawing.Point(106, -90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(610, 262);
            this.label1.TabIndex = 63;
            this.label1.Text = "Consulta de Exemplares";
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
            this.btn_Pesquisar.Location = new System.Drawing.Point(648, 106);
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
            // Dgv_Consul_Exemplar
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.Dgv_Consul_Exemplar.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.Dgv_Consul_Exemplar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Dgv_Consul_Exemplar.BackgroundColor = System.Drawing.Color.White;
            this.Dgv_Consul_Exemplar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Dgv_Consul_Exemplar.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.Dgv_Consul_Exemplar.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Dgv_Consul_Exemplar.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.Dgv_Consul_Exemplar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv_Consul_Exemplar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Col_Titulo,
            this.Col_Ano_Publicado,
            this.Col_Editora,
            this.Col_Estado_Fisico,
            this.Col_Cod_Exemplar});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Dgv_Consul_Exemplar.DefaultCellStyle = dataGridViewCellStyle6;
            this.Dgv_Consul_Exemplar.EnableHeadersVisualStyles = false;
            this.Dgv_Consul_Exemplar.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.Dgv_Consul_Exemplar.Location = new System.Drawing.Point(85, 138);
            this.Dgv_Consul_Exemplar.Name = "Dgv_Consul_Exemplar";
            this.Dgv_Consul_Exemplar.RowHeadersVisible = false;
            this.Dgv_Consul_Exemplar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Dgv_Consul_Exemplar.Size = new System.Drawing.Size(649, 203);
            this.Dgv_Consul_Exemplar.TabIndex = 73;
            this.Dgv_Consul_Exemplar.Theme = Guna.UI.WinForms.GunaDataGridViewPresetThemes.Guna;
            this.Dgv_Consul_Exemplar.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.Dgv_Consul_Exemplar.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.Dgv_Consul_Exemplar.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.Dgv_Consul_Exemplar.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.Dgv_Consul_Exemplar.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.Dgv_Consul_Exemplar.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.Dgv_Consul_Exemplar.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.Dgv_Consul_Exemplar.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.Dgv_Consul_Exemplar.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.Dgv_Consul_Exemplar.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.Dgv_Consul_Exemplar.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.Dgv_Consul_Exemplar.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv_Consul_Exemplar.ThemeStyle.HeaderStyle.Height = 21;
            this.Dgv_Consul_Exemplar.ThemeStyle.ReadOnly = false;
            this.Dgv_Consul_Exemplar.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.Dgv_Consul_Exemplar.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.Dgv_Consul_Exemplar.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.Dgv_Consul_Exemplar.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.Dgv_Consul_Exemplar.ThemeStyle.RowsStyle.Height = 22;
            this.Dgv_Consul_Exemplar.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.Dgv_Consul_Exemplar.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // Col_Titulo
            // 
            this.Col_Titulo.HeaderText = "Titulo";
            this.Col_Titulo.Name = "Col_Titulo";
            this.Col_Titulo.ReadOnly = true;
            // 
            // Col_Ano_Publicado
            // 
            this.Col_Ano_Publicado.HeaderText = "Ano Publicado";
            this.Col_Ano_Publicado.Name = "Col_Ano_Publicado";
            this.Col_Ano_Publicado.ReadOnly = true;
            // 
            // Col_Editora
            // 
            this.Col_Editora.HeaderText = "Editora";
            this.Col_Editora.Name = "Col_Editora";
            this.Col_Editora.ReadOnly = true;
            // 
            // Col_Estado_Fisico
            // 
            this.Col_Estado_Fisico.HeaderText = "Estado";
            this.Col_Estado_Fisico.Name = "Col_Estado_Fisico";
            this.Col_Estado_Fisico.ReadOnly = true;
            // 
            // Col_Cod_Exemplar
            // 
            this.Col_Cod_Exemplar.HeaderText = "ID";
            this.Col_Cod_Exemplar.Name = "Col_Cod_Exemplar";
            this.Col_Cod_Exemplar.ReadOnly = true;
            // 
            // frm_Consul_Exemplares
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGreen;
            this.ClientSize = new System.Drawing.Size(830, 457);
            this.Controls.Add(this.Dgv_Consul_Exemplar);
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
            this.Name = "frm_Consul_Exemplares";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consul_Exemplares";
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_Consul_Exemplar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI.WinForms.GunaButton btn_Excluir;
        private Guna.UI.WinForms.GunaButton btn_Editar;
        private Guna.UI.WinForms.GunaButton btn_Voltar;
        private Guna.UI.WinForms.GunaLabel gunaLabel2;
        private Guna.UI.WinForms.GunaComboBox cmb_EstExemplar;
        private Guna.UI.WinForms.GunaLabel gunaLabel1;
        private Guna.UI.WinForms.GunaTextBox txt_Titulo;
        private System.Windows.Forms.Label label1;
        private Guna.UI.WinForms.GunaButton btn_Pesquisar;
        private Guna.UI.WinForms.GunaDataGridView Dgv_Consul_Exemplar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_Titulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_Ano_Publicado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_Editora;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_Estado_Fisico;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_Cod_Exemplar;
    }
}