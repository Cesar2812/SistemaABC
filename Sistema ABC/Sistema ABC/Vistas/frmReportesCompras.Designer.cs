namespace Sistema_ABC.Vistas
{
    partial class frmReportesCompras
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReportesCompras));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxBuscarProv = new System.Windows.Forms.ComboBox();
            this.pictureBoxBuscarProv = new System.Windows.Forms.PictureBox();
            this.dataGridViewCompras = new System.Windows.Forms.DataGridView();
            this.FechaCreacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoDeDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumeroDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MontoTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UsuarioRegistro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DocumentoProveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RazonSocial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Marca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Categoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioDeCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioDeVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnoExcel = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBuscar = new System.Windows.Forms.ComboBox();
            this.textBusquedas = new System.Windows.Forms.TextBox();
            this.pictureBoxBuscar = new System.Windows.Forms.PictureBox();
            this.pictureLimparProv = new System.Windows.Forms.PictureBox();
            this.dateTimeFechainicio = new System.Windows.Forms.DateTimePicker();
            this.dateTimefechafin = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBuscarProv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCompras)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBuscar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLimparProv)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(259, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Reporte De Compras";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Fecha Inicio";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(150, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Fecha Fin";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(327, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "Proveedor";
            // 
            // comboBoxBuscarProv
            // 
            this.comboBoxBuscarProv.FormattingEnabled = true;
            this.comboBoxBuscarProv.Location = new System.Drawing.Point(404, 56);
            this.comboBoxBuscarProv.Name = "comboBoxBuscarProv";
            this.comboBoxBuscarProv.Size = new System.Drawing.Size(193, 21);
            this.comboBoxBuscarProv.TabIndex = 6;
            // 
            // pictureBoxBuscarProv
            // 
            this.pictureBoxBuscarProv.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxBuscarProv.Image = global::Sistema_ABC.Properties.Resources.buscar;
            this.pictureBoxBuscarProv.Location = new System.Drawing.Point(603, 57);
            this.pictureBoxBuscarProv.Name = "pictureBoxBuscarProv";
            this.pictureBoxBuscarProv.Size = new System.Drawing.Size(37, 21);
            this.pictureBoxBuscarProv.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxBuscarProv.TabIndex = 59;
            this.pictureBoxBuscarProv.TabStop = false;
            this.pictureBoxBuscarProv.Click += new System.EventHandler(this.pictureBoxBuscarProv_Click);
            // 
            // dataGridViewCompras
            // 
            this.dataGridViewCompras.AllowUserToAddRows = false;
            this.dataGridViewCompras.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewCompras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCompras.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FechaCreacion,
            this.TipoDeDocumento,
            this.NumeroDocumento,
            this.MontoTotal,
            this.UsuarioRegistro,
            this.DocumentoProveedor,
            this.RazonSocial,
            this.CodigoProducto,
            this.NombreProducto,
            this.Marca,
            this.Categoria,
            this.PrecioDeCompra,
            this.PrecioDeVenta,
            this.Cantidad,
            this.SubTotal});
            this.dataGridViewCompras.Location = new System.Drawing.Point(12, 115);
            this.dataGridViewCompras.Name = "dataGridViewCompras";
            this.dataGridViewCompras.Size = new System.Drawing.Size(925, 316);
            this.dataGridViewCompras.TabIndex = 60;
            // 
            // FechaCreacion
            // 
            this.FechaCreacion.HeaderText = "FechaCreacion";
            this.FechaCreacion.Name = "FechaCreacion";
            this.FechaCreacion.Width = 95;
            // 
            // TipoDeDocumento
            // 
            this.TipoDeDocumento.HeaderText = "TipoDeDocumento";
            this.TipoDeDocumento.Name = "TipoDeDocumento";
            // 
            // NumeroDocumento
            // 
            this.NumeroDocumento.HeaderText = "NumeroDocumento";
            this.NumeroDocumento.Name = "NumeroDocumento";
            // 
            // MontoTotal
            // 
            this.MontoTotal.HeaderText = "MontoTotal";
            this.MontoTotal.Name = "MontoTotal";
            this.MontoTotal.Width = 95;
            // 
            // UsuarioRegistro
            // 
            this.UsuarioRegistro.HeaderText = "UsuarioRegistro";
            this.UsuarioRegistro.Name = "UsuarioRegistro";
            // 
            // DocumentoProveedor
            // 
            this.DocumentoProveedor.HeaderText = "DocumentoProveedor";
            this.DocumentoProveedor.Name = "DocumentoProveedor";
            this.DocumentoProveedor.Width = 95;
            // 
            // RazonSocial
            // 
            this.RazonSocial.HeaderText = "RazonSocial";
            this.RazonSocial.Name = "RazonSocial";
            // 
            // CodigoProducto
            // 
            this.CodigoProducto.HeaderText = "CodigoProducto";
            this.CodigoProducto.Name = "CodigoProducto";
            // 
            // NombreProducto
            // 
            this.NombreProducto.HeaderText = "NombreProducto";
            this.NombreProducto.Name = "NombreProducto";
            // 
            // Marca
            // 
            this.Marca.HeaderText = "Marca";
            this.Marca.Name = "Marca";
            // 
            // Categoria
            // 
            this.Categoria.HeaderText = "Categoria";
            this.Categoria.Name = "Categoria";
            // 
            // PrecioDeCompra
            // 
            this.PrecioDeCompra.HeaderText = "PrecioDeCompra";
            this.PrecioDeCompra.Name = "PrecioDeCompra";
            // 
            // PrecioDeVenta
            // 
            this.PrecioDeVenta.HeaderText = "PrecioDeVenta";
            this.PrecioDeVenta.Name = "PrecioDeVenta";
            // 
            // Cantidad
            // 
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            // 
            // SubTotal
            // 
            this.SubTotal.HeaderText = "SubTotal";
            this.SubTotal.Name = "SubTotal";
            // 
            // btnoExcel
            // 
            this.btnoExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.btnoExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnoExcel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnoExcel.ForeColor = System.Drawing.Color.White;
            this.btnoExcel.Location = new System.Drawing.Point(63, 86);
            this.btnoExcel.Name = "btnoExcel";
            this.btnoExcel.Size = new System.Drawing.Size(84, 23);
            this.btnoExcel.TabIndex = 62;
            this.btnoExcel.Text = "Generar";
            this.btnoExcel.UseVisualStyleBackColor = false;
            this.btnoExcel.Click += new System.EventHandler(this.btnoExcel_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(12, 83);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(49, 26);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 61;
            this.pictureBox2.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(328, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 17);
            this.label5.TabIndex = 63;
            this.label5.Text = "Buscar Por:";
            // 
            // comboBuscar
            // 
            this.comboBuscar.FormattingEnabled = true;
            this.comboBuscar.Location = new System.Drawing.Point(404, 83);
            this.comboBuscar.Name = "comboBuscar";
            this.comboBuscar.Size = new System.Drawing.Size(127, 21);
            this.comboBuscar.TabIndex = 64;
            // 
            // textBusquedas
            // 
            this.textBusquedas.Location = new System.Drawing.Point(537, 83);
            this.textBusquedas.Name = "textBusquedas";
            this.textBusquedas.Size = new System.Drawing.Size(218, 20);
            this.textBusquedas.TabIndex = 65;
            // 
            // pictureBoxBuscar
            // 
            this.pictureBoxBuscar.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxBuscar.Image = global::Sistema_ABC.Properties.Resources.buscar;
            this.pictureBoxBuscar.Location = new System.Drawing.Point(761, 79);
            this.pictureBoxBuscar.Name = "pictureBoxBuscar";
            this.pictureBoxBuscar.Size = new System.Drawing.Size(40, 24);
            this.pictureBoxBuscar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxBuscar.TabIndex = 66;
            this.pictureBoxBuscar.TabStop = false;
            this.pictureBoxBuscar.Click += new System.EventHandler(this.pictureBoxBuscar_Click);
            // 
            // pictureLimparProv
            // 
            this.pictureLimparProv.Image = ((System.Drawing.Image)(resources.GetObject("pictureLimparProv.Image")));
            this.pictureLimparProv.Location = new System.Drawing.Point(807, 73);
            this.pictureLimparProv.Name = "pictureLimparProv";
            this.pictureLimparProv.Size = new System.Drawing.Size(37, 33);
            this.pictureLimparProv.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureLimparProv.TabIndex = 71;
            this.pictureLimparProv.TabStop = false;
            this.pictureLimparProv.Click += new System.EventHandler(this.pictureLimparProv_Click);
            // 
            // dateTimeFechainicio
            // 
            this.dateTimeFechainicio.CustomFormat = "yyyy/MM/dd";
            this.dateTimeFechainicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimeFechainicio.Location = new System.Drawing.Point(12, 57);
            this.dateTimeFechainicio.Name = "dateTimeFechainicio";
            this.dateTimeFechainicio.Size = new System.Drawing.Size(135, 20);
            this.dateTimeFechainicio.TabIndex = 72;
            this.dateTimeFechainicio.Value = new System.DateTime(2023, 10, 14, 0, 0, 0, 0);
            // 
            // dateTimefechafin
            // 
            this.dateTimefechafin.CustomFormat = "yyy/MM/dd";
            this.dateTimefechafin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimefechafin.Location = new System.Drawing.Point(153, 57);
            this.dateTimefechafin.Name = "dateTimefechafin";
            this.dateTimefechafin.Size = new System.Drawing.Size(135, 20);
            this.dateTimefechafin.TabIndex = 73;
            this.dateTimefechafin.Value = new System.DateTime(2023, 10, 16, 0, 0, 0, 0);
            // 
            // frmReportesCompras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(939, 443);
            this.Controls.Add(this.dateTimefechafin);
            this.Controls.Add(this.dateTimeFechainicio);
            this.Controls.Add(this.pictureLimparProv);
            this.Controls.Add(this.pictureBoxBuscar);
            this.Controls.Add(this.textBusquedas);
            this.Controls.Add(this.comboBuscar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnoExcel);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.dataGridViewCompras);
            this.Controls.Add(this.pictureBoxBuscarProv);
            this.Controls.Add(this.comboBoxBuscarProv);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmReportesCompras";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Reporte de compras";
            this.Load += new System.EventHandler(this.frmReportesCompras_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBuscarProv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCompras)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBuscar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLimparProv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxBuscarProv;
        private System.Windows.Forms.PictureBox pictureBoxBuscarProv;
        private System.Windows.Forms.DataGridView dataGridViewCompras;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaCreacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoDeDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumeroDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn MontoTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn UsuarioRegistro;
        private System.Windows.Forms.DataGridViewTextBoxColumn DocumentoProveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn RazonSocial;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Marca;
        private System.Windows.Forms.DataGridViewTextBoxColumn Categoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioDeCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioDeVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubTotal;
        private System.Windows.Forms.Button btnoExcel;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBuscar;
        private System.Windows.Forms.TextBox textBusquedas;
        private System.Windows.Forms.PictureBox pictureBoxBuscar;
        private System.Windows.Forms.PictureBox pictureLimparProv;
        private System.Windows.Forms.DateTimePicker dateTimeFechainicio;
        private System.Windows.Forms.DateTimePicker dateTimefechafin;
    }
}