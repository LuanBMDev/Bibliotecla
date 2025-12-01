namespace Bibliotecla
{
    partial class frm_Multa
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
            this.gunaLabel2 = new Guna.UI.WinForms.GunaLabel();
            this.cmb_Filtro = new Guna.UI.WinForms.GunaComboBox();
            this.gunaLabel1 = new Guna.UI.WinForms.GunaLabel();
            this.txt_Pesquisa = new Guna.UI.WinForms.GunaTextBox();
            this.btn_Pago = new Guna.UI.WinForms.GunaButton();
            this.btn_Cancelar = new Guna.UI.WinForms.GunaButton();
            this.Dgv_Consul_multa = new Guna.UI.WinForms.GunaDataGridView();
            this.btn_Pesquisar_multa = new Guna.UI.WinForms.GunaButton();
            this.Col_Leitor_multa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_CodLeitor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_Nome_Exemplar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_exemplar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_dataemp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_prazo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_datedevl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Valor_Multa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_Consul_multa)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria Math", 35.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.label1.Location = new System.Drawing.Point(295, -87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(231, 262);
            this.label1.TabIndex = 65;
            this.label1.Text = "Multa";
            // 
            // gunaLabel2
            // 
            this.gunaLabel2.AutoSize = true;
            this.gunaLabel2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaLabel2.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.gunaLabel2.Location = new System.Drawing.Point(505, 81);
            this.gunaLabel2.Name = "gunaLabel2";
            this.gunaLabel2.Size = new System.Drawing.Size(57, 21);
            this.gunaLabel2.TabIndex = 77;
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
            this.cmb_Filtro.Location = new System.Drawing.Point(509, 105);
            this.cmb_Filtro.Name = "cmb_Filtro";
            this.cmb_Filtro.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.cmb_Filtro.OnHoverItemForeColor = System.Drawing.Color.White;
            this.cmb_Filtro.Size = new System.Drawing.Size(140, 26);
            this.cmb_Filtro.TabIndex = 76;
            // 
            // gunaLabel1
            // 
            this.gunaLabel1.AutoSize = true;
            this.gunaLabel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaLabel1.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.gunaLabel1.Location = new System.Drawing.Point(88, 81);
            this.gunaLabel1.Name = "gunaLabel1";
            this.gunaLabel1.Size = new System.Drawing.Size(77, 21);
            this.gunaLabel1.TabIndex = 75;
            this.gunaLabel1.Text = "Pesquisa";
            // 
            // txt_Pesquisa
            // 
            this.txt_Pesquisa.BaseColor = System.Drawing.Color.White;
            this.txt_Pesquisa.BorderColor = System.Drawing.Color.Silver;
            this.txt_Pesquisa.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_Pesquisa.FocusedBaseColor = System.Drawing.Color.White;
            this.txt_Pesquisa.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txt_Pesquisa.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txt_Pesquisa.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_Pesquisa.Location = new System.Drawing.Point(92, 105);
            this.txt_Pesquisa.Name = "txt_Pesquisa";
            this.txt_Pesquisa.PasswordChar = '\0';
            this.txt_Pesquisa.SelectedText = "";
            this.txt_Pesquisa.Size = new System.Drawing.Size(411, 26);
            this.txt_Pesquisa.TabIndex = 74;
            // 
            // btn_Pago
            // 
            this.btn_Pago.AnimationHoverSpeed = 0.07F;
            this.btn_Pago.AnimationSpeed = 0.03F;
            this.btn_Pago.BaseColor = System.Drawing.Color.SaddleBrown;
            this.btn_Pago.BorderColor = System.Drawing.Color.Black;
            this.btn_Pago.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btn_Pago.FocusedColor = System.Drawing.Color.Empty;
            this.btn_Pago.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Pago.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.btn_Pago.Image = null;
            this.btn_Pago.ImageSize = new System.Drawing.Size(20, 20);
            this.btn_Pago.Location = new System.Drawing.Point(560, 372);
            this.btn_Pago.Name = "btn_Pago";
            this.btn_Pago.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.btn_Pago.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btn_Pago.OnHoverForeColor = System.Drawing.Color.White;
            this.btn_Pago.OnHoverImage = null;
            this.btn_Pago.OnPressedColor = System.Drawing.Color.Black;
            this.btn_Pago.Size = new System.Drawing.Size(132, 42);
            this.btn_Pago.TabIndex = 79;
            this.btn_Pago.Text = "Pago";
            this.btn_Pago.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btn_Pago.Click += new System.EventHandler(this.btn_Pago_Click);
            // 
            // btn_Cancelar
            // 
            this.btn_Cancelar.AnimationHoverSpeed = 0.07F;
            this.btn_Cancelar.AnimationSpeed = 0.03F;
            this.btn_Cancelar.BaseColor = System.Drawing.Color.SaddleBrown;
            this.btn_Cancelar.BorderColor = System.Drawing.Color.Black;
            this.btn_Cancelar.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btn_Cancelar.FocusedColor = System.Drawing.Color.Empty;
            this.btn_Cancelar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Cancelar.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.btn_Cancelar.Image = null;
            this.btn_Cancelar.ImageSize = new System.Drawing.Size(20, 20);
            this.btn_Cancelar.Location = new System.Drawing.Point(143, 372);
            this.btn_Cancelar.Name = "btn_Cancelar";
            this.btn_Cancelar.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.btn_Cancelar.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btn_Cancelar.OnHoverForeColor = System.Drawing.Color.White;
            this.btn_Cancelar.OnHoverImage = null;
            this.btn_Cancelar.OnPressedColor = System.Drawing.Color.Black;
            this.btn_Cancelar.Size = new System.Drawing.Size(132, 42);
            this.btn_Cancelar.TabIndex = 78;
            this.btn_Cancelar.Text = "Cancelar";
            this.btn_Cancelar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btn_Cancelar.Click += new System.EventHandler(this.btn_Cancelar_Click);
            // 
            // Dgv_Consul_multa
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.Dgv_Consul_multa.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.Dgv_Consul_multa.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Dgv_Consul_multa.BackgroundColor = System.Drawing.Color.White;
            this.Dgv_Consul_multa.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Dgv_Consul_multa.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.Dgv_Consul_multa.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Dgv_Consul_multa.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.Dgv_Consul_multa.ColumnHeadersHeight = 21;
            this.Dgv_Consul_multa.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Col_Leitor_multa,
            this.Col_CodLeitor,
            this.Col_Nome_Exemplar,
            this.Col_exemplar,
            this.col_dataemp,
            this.col_prazo,
            this.col_datedevl,
            this.col_Valor_Multa});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Dgv_Consul_multa.DefaultCellStyle = dataGridViewCellStyle3;
            this.Dgv_Consul_multa.EnableHeadersVisualStyles = false;
            this.Dgv_Consul_multa.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.Dgv_Consul_multa.Location = new System.Drawing.Point(74, 137);
            this.Dgv_Consul_multa.Name = "Dgv_Consul_multa";
            this.Dgv_Consul_multa.RowHeadersVisible = false;
            this.Dgv_Consul_multa.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Dgv_Consul_multa.Size = new System.Drawing.Size(684, 212);
            this.Dgv_Consul_multa.TabIndex = 80;
            this.Dgv_Consul_multa.Theme = Guna.UI.WinForms.GunaDataGridViewPresetThemes.Guna;
            this.Dgv_Consul_multa.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.Dgv_Consul_multa.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.Dgv_Consul_multa.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.Dgv_Consul_multa.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.Dgv_Consul_multa.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.Dgv_Consul_multa.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.Dgv_Consul_multa.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.Dgv_Consul_multa.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.Dgv_Consul_multa.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.Dgv_Consul_multa.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.Dgv_Consul_multa.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.Dgv_Consul_multa.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.Dgv_Consul_multa.ThemeStyle.HeaderStyle.Height = 21;
            this.Dgv_Consul_multa.ThemeStyle.ReadOnly = false;
            this.Dgv_Consul_multa.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.Dgv_Consul_multa.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.Dgv_Consul_multa.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.Dgv_Consul_multa.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.Dgv_Consul_multa.ThemeStyle.RowsStyle.Height = 22;
            this.Dgv_Consul_multa.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.Dgv_Consul_multa.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.Dgv_Consul_multa.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv_Consul_multa_CellContentClick);
            // 
            // btn_Pesquisar_multa
            // 
            this.btn_Pesquisar_multa.AnimationHoverSpeed = 0.07F;
            this.btn_Pesquisar_multa.AnimationSpeed = 0.03F;
            this.btn_Pesquisar_multa.BaseColor = System.Drawing.Color.SaddleBrown;
            this.btn_Pesquisar_multa.BorderColor = System.Drawing.Color.Black;
            this.btn_Pesquisar_multa.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btn_Pesquisar_multa.FocusedColor = System.Drawing.Color.Empty;
            this.btn_Pesquisar_multa.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Pesquisar_multa.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.btn_Pesquisar_multa.Image = null;
            this.btn_Pesquisar_multa.ImageSize = new System.Drawing.Size(20, 20);
            this.btn_Pesquisar_multa.Location = new System.Drawing.Point(655, 105);
            this.btn_Pesquisar_multa.Name = "btn_Pesquisar_multa";
            this.btn_Pesquisar_multa.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.btn_Pesquisar_multa.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btn_Pesquisar_multa.OnHoverForeColor = System.Drawing.Color.White;
            this.btn_Pesquisar_multa.OnHoverImage = null;
            this.btn_Pesquisar_multa.OnPressedColor = System.Drawing.Color.Black;
            this.btn_Pesquisar_multa.Size = new System.Drawing.Size(86, 26);
            this.btn_Pesquisar_multa.TabIndex = 81;
            this.btn_Pesquisar_multa.Text = "Pesquisar";
            this.btn_Pesquisar_multa.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btn_Pesquisar_multa.Click += new System.EventHandler(this.btn_Pesquisar_multa_Click);
            // 
            // Col_Leitor_multa
            // 
            this.Col_Leitor_multa.HeaderText = "leitor";
            this.Col_Leitor_multa.Name = "Col_Leitor_multa";
            this.Col_Leitor_multa.ReadOnly = true;
            // 
            // Col_CodLeitor
            // 
            this.Col_CodLeitor.HeaderText = "CodLeitor";
            this.Col_CodLeitor.Name = "Col_CodLeitor";
            this.Col_CodLeitor.ReadOnly = true;
            // 
            // Col_Nome_Exemplar
            // 
            this.Col_Nome_Exemplar.HeaderText = "exemplar";
            this.Col_Nome_Exemplar.Name = "Col_Nome_Exemplar";
            this.Col_Nome_Exemplar.ReadOnly = true;
            // 
            // Col_exemplar
            // 
            this.Col_exemplar.HeaderText = "Cod exeplar";
            this.Col_exemplar.Name = "Col_exemplar";
            this.Col_exemplar.ReadOnly = true;
            // 
            // col_dataemp
            // 
            this.col_dataemp.HeaderText = "Emprestimo";
            this.col_dataemp.Name = "col_dataemp";
            this.col_dataemp.ReadOnly = true;
            // 
            // col_prazo
            // 
            this.col_prazo.HeaderText = "Prazo devoluçao";
            this.col_prazo.Name = "col_prazo";
            this.col_prazo.ReadOnly = true;
            // 
            // col_datedevl
            // 
            this.col_datedevl.HeaderText = "devoluçao ";
            this.col_datedevl.Name = "col_datedevl";
            this.col_datedevl.ReadOnly = true;
            // 
            // col_Valor_Multa
            // 
            this.col_Valor_Multa.HeaderText = "Valor";
            this.col_Valor_Multa.Name = "col_Valor_Multa";
            this.col_Valor_Multa.ReadOnly = true;
            // 
            // frm_Multa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGreen;
            this.ClientSize = new System.Drawing.Size(830, 457);
            this.Controls.Add(this.btn_Pesquisar_multa);
            this.Controls.Add(this.Dgv_Consul_multa);
            this.Controls.Add(this.btn_Pago);
            this.Controls.Add(this.btn_Cancelar);
            this.Controls.Add(this.gunaLabel2);
            this.Controls.Add(this.cmb_Filtro);
            this.Controls.Add(this.gunaLabel1);
            this.Controls.Add(this.txt_Pesquisa);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "frm_Multa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Multa";
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_Consul_multa)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Guna.UI.WinForms.GunaLabel gunaLabel2;
        private Guna.UI.WinForms.GunaComboBox cmb_Filtro;
        private Guna.UI.WinForms.GunaLabel gunaLabel1;
        private Guna.UI.WinForms.GunaTextBox txt_Pesquisa;
        private Guna.UI.WinForms.GunaButton btn_Pago;
        private Guna.UI.WinForms.GunaButton btn_Cancelar;
        private Guna.UI.WinForms.GunaDataGridView Dgv_Consul_multa;
        private Guna.UI.WinForms.GunaButton btn_Pesquisar_multa;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_Leitor_multa;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_CodLeitor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_Nome_Exemplar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_exemplar;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_dataemp;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_prazo;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_datedevl;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Valor_Multa;
    }
}