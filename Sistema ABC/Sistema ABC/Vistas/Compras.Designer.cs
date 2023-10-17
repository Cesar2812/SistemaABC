namespace Sistema_ABC.Vistas
{
    partial class Compras
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Compras));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboTipoDoc = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textFecha = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textRazonSocial = new System.Windows.Forms.TextBox();
            this.textDocumento = new System.Windows.Forms.TextBox();
            this.textIdProv = new System.Windows.Forms.TextBox();
            this.btnBuscarProv = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnAgregarCompra = new System.Windows.Forms.Button();
            this.textCantida = new System.Windows.Forms.NumericUpDown();
            this.textIdProd = new System.Windows.Forms.TextBox();
            this.textVenta = new System.Windows.Forms.TextBox();
            this.textCompra = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textProd = new System.Windows.Forms.TextBox();
            this.btnbuscarProducto = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.texCodProd = new System.Windows.Forms.TextBox();
            this.dataCompras = new System.Windows.Forms.DataGridView();
            this.idProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioDeCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioDeVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MontoTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.boton = new System.Windows.Forms.DataGridViewButtonColumn();
            this.textTotalPagar = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnBuscarProv)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textCantida)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnbuscarProducto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataCompras)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.comboTipoDoc);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textFecha);
            this.groupBox1.Location = new System.Drawing.Point(12, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(345, 91);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Información Compra";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(134, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Documento";
            // 
            // comboTipoDoc
            // 
            this.comboTipoDoc.FormattingEnabled = true;
            this.comboTipoDoc.Location = new System.Drawing.Point(137, 42);
            this.comboTipoDoc.Name = "comboTipoDoc";
            this.comboTipoDoc.Size = new System.Drawing.Size(192, 21);
            this.comboTipoDoc.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Fecha";
            // 
            // textFecha
            // 
            this.textFecha.Location = new System.Drawing.Point(6, 42);
            this.textFecha.Name = "textFecha";
            this.textFecha.Size = new System.Drawing.Size(125, 20);
            this.textFecha.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(295, 1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(172, 24);
            this.label4.TabIndex = 2;
            this.label4.Text = "Registrar Compra";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textRazonSocial);
            this.groupBox2.Controls.Add(this.textDocumento);
            this.groupBox2.Controls.Add(this.textIdProv);
            this.groupBox2.Controls.Add(this.btnBuscarProv);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(363, 36);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(475, 91);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Información Del Proveedor";
            // 
            // textRazonSocial
            // 
            this.textRazonSocial.Location = new System.Drawing.Point(192, 41);
            this.textRazonSocial.Name = "textRazonSocial";
            this.textRazonSocial.Size = new System.Drawing.Size(254, 20);
            this.textRazonSocial.TabIndex = 63;
            // 
            // textDocumento
            // 
            this.textDocumento.Location = new System.Drawing.Point(4, 42);
            this.textDocumento.Name = "textDocumento";
            this.textDocumento.Size = new System.Drawing.Size(136, 20);
            this.textDocumento.TabIndex = 62;
            // 
            // textIdProv
            // 
            this.textIdProv.Location = new System.Drawing.Point(399, 15);
            this.textIdProv.Name = "textIdProv";
            this.textIdProv.Size = new System.Drawing.Size(36, 20);
            this.textIdProv.TabIndex = 61;
            this.textIdProv.Visible = false;
            // 
            // btnBuscarProv
            // 
            this.btnBuscarProv.BackColor = System.Drawing.SystemColors.Control;
            this.btnBuscarProv.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscarProv.Image")));
            this.btnBuscarProv.Location = new System.Drawing.Point(146, 38);
            this.btnBuscarProv.Name = "btnBuscarProv";
            this.btnBuscarProv.Size = new System.Drawing.Size(40, 24);
            this.btnBuscarProv.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnBuscarProv.TabIndex = 59;
            this.btnBuscarProv.TabStop = false;
            this.btnBuscarProv.Click += new System.EventHandler(this.btnBuscarProv_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(189, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Razón Social";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "N° Documento";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnAgregarCompra);
            this.groupBox3.Controls.Add(this.textCantida);
            this.groupBox3.Controls.Add(this.textIdProd);
            this.groupBox3.Controls.Add(this.textVenta);
            this.groupBox3.Controls.Add(this.textCompra);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.textProd);
            this.groupBox3.Controls.Add(this.btnbuscarProducto);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.texCodProd);
            this.groupBox3.Location = new System.Drawing.Point(12, 132);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(826, 91);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Información De Producto";
            // 
            // btnAgregarCompra
            // 
            this.btnAgregarCompra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(97)))), ((int)(((byte)(141)))));
            this.btnAgregarCompra.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarCompra.FlatAppearance.BorderSize = 0;
            this.btnAgregarCompra.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnAgregarCompra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarCompra.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold);
            this.btnAgregarCompra.ForeColor = System.Drawing.Color.White;
            this.btnAgregarCompra.Image = global::Sistema_ABC.Properties.Resources.agregar_archivo;
            this.btnAgregarCompra.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregarCompra.Location = new System.Drawing.Point(642, 19);
            this.btnAgregarCompra.Margin = new System.Windows.Forms.Padding(2);
            this.btnAgregarCompra.Name = "btnAgregarCompra";
            this.btnAgregarCompra.Size = new System.Drawing.Size(115, 57);
            this.btnAgregarCompra.TabIndex = 70;
            this.btnAgregarCompra.Text = "Agregar";
            this.btnAgregarCompra.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregarCompra.UseVisualStyleBackColor = false;
            this.btnAgregarCompra.Click += new System.EventHandler(this.btnAgregarCompra_Click);
            // 
            // textCantida
            // 
            this.textCantida.Location = new System.Drawing.Point(573, 45);
            this.textCantida.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.textCantida.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.textCantida.Name = "textCantida";
            this.textCantida.Size = new System.Drawing.Size(46, 20);
            this.textCantida.TabIndex = 69;
            this.textCantida.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // textIdProd
            // 
            this.textIdProd.Location = new System.Drawing.Point(101, 19);
            this.textIdProd.Name = "textIdProd";
            this.textIdProd.Size = new System.Drawing.Size(30, 20);
            this.textIdProd.TabIndex = 68;
            this.textIdProd.Visible = false;
            // 
            // textVenta
            // 
            this.textVenta.Location = new System.Drawing.Point(481, 45);
            this.textVenta.Name = "textVenta";
            this.textVenta.Size = new System.Drawing.Size(82, 20);
            this.textVenta.TabIndex = 67;
            this.textVenta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textVenta_KeyPress);
            // 
            // textCompra
            // 
            this.textCompra.Location = new System.Drawing.Point(386, 44);
            this.textCompra.Name = "textCompra";
            this.textCompra.Size = new System.Drawing.Size(89, 20);
            this.textCompra.TabIndex = 66;
            this.textCompra.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textCompra_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(570, 29);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 13);
            this.label10.TabIndex = 65;
            this.label10.Text = "Cantidad";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(478, 30);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 13);
            this.label9.TabIndex = 64;
            this.label9.Text = "Precio Venta";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(386, 29);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 13);
            this.label8.TabIndex = 63;
            this.label8.Text = "Precio Compra";
            // 
            // textProd
            // 
            this.textProd.Location = new System.Drawing.Point(182, 44);
            this.textProd.Name = "textProd";
            this.textProd.Size = new System.Drawing.Size(198, 20);
            this.textProd.TabIndex = 62;
            // 
            // btnbuscarProducto
            // 
            this.btnbuscarProducto.BackColor = System.Drawing.SystemColors.Control;
            this.btnbuscarProducto.Image = ((System.Drawing.Image)(resources.GetObject("btnbuscarProducto.Image")));
            this.btnbuscarProducto.Location = new System.Drawing.Point(137, 42);
            this.btnbuscarProducto.Name = "btnbuscarProducto";
            this.btnbuscarProducto.Size = new System.Drawing.Size(40, 23);
            this.btnbuscarProducto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnbuscarProducto.TabIndex = 62;
            this.btnbuscarProducto.TabStop = false;
            this.btnbuscarProducto.Click += new System.EventHandler(this.btnbuscarProducto_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(183, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Producto";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Codigo Producto";
            // 
            // texCodProd
            // 
            this.texCodProd.Location = new System.Drawing.Point(6, 42);
            this.texCodProd.Name = "texCodProd";
            this.texCodProd.Size = new System.Drawing.Size(125, 20);
            this.texCodProd.TabIndex = 2;
            // 
            // dataCompras
            // 
            this.dataCompras.AllowUserToAddRows = false;
            this.dataCompras.BackgroundColor = System.Drawing.Color.White;
            this.dataCompras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataCompras.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idProducto,
            this.Producto,
            this.PrecioDeCompra,
            this.PrecioDeVenta,
            this.Cantidad,
            this.MontoTotal,
            this.boton});
            this.dataCompras.Location = new System.Drawing.Point(12, 229);
            this.dataCompras.Name = "dataCompras";
            this.dataCompras.Size = new System.Drawing.Size(709, 267);
            this.dataCompras.TabIndex = 63;
            this.dataCompras.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataCompras_CellContentClick);
            this.dataCompras.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataCompras_CellPainting);
            // 
            // idProducto
            // 
            this.idProducto.HeaderText = "idProducto";
            this.idProducto.Name = "idProducto";
            this.idProducto.Visible = false;
            // 
            // Producto
            // 
            this.Producto.HeaderText = "Producto";
            this.Producto.Name = "Producto";
            this.Producto.Width = 150;
            // 
            // PrecioDeCompra
            // 
            this.PrecioDeCompra.HeaderText = "PrecioCompra";
            this.PrecioDeCompra.Name = "PrecioDeCompra";
            // 
            // PrecioDeVenta
            // 
            this.PrecioDeVenta.HeaderText = "PrecioVenta";
            this.PrecioDeVenta.Name = "PrecioDeVenta";
            this.PrecioDeVenta.Visible = false;
            // 
            // Cantidad
            // 
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            // 
            // MontoTotal
            // 
            this.MontoTotal.HeaderText = "SubTotal";
            this.MontoTotal.Name = "MontoTotal";
            // 
            // boton
            // 
            this.boton.HeaderText = "";
            this.boton.Name = "boton";
            this.boton.Width = 35;
            // 
            // textTotalPagar
            // 
            this.textTotalPagar.Location = new System.Drawing.Point(726, 414);
            this.textTotalPagar.Name = "textTotalPagar";
            this.textTotalPagar.Size = new System.Drawing.Size(132, 20);
            this.textTotalPagar.TabIndex = 64;
            this.textTotalPagar.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(727, 398);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(71, 13);
            this.label11.TabIndex = 71;
            this.label11.Text = "Total a Pagar";
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(97)))), ((int)(((byte)(141)))));
            this.btnRegistrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegistrar.FlatAppearance.BorderSize = 0;
            this.btnRegistrar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnRegistrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrar.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold);
            this.btnRegistrar.ForeColor = System.Drawing.Color.White;
            this.btnRegistrar.Image = global::Sistema_ABC.Properties.Resources.anadir1;
            this.btnRegistrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRegistrar.Location = new System.Drawing.Point(726, 439);
            this.btnRegistrar.Margin = new System.Windows.Forms.Padding(2);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(133, 57);
            this.btnRegistrar.TabIndex = 71;
            this.btnRegistrar.Text = "Registrar";
            this.btnRegistrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRegistrar.UseVisualStyleBackColor = false;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // Compras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 506);
            this.Controls.Add(this.btnRegistrar);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.textTotalPagar);
            this.Controls.Add(this.dataCompras);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Compras";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Compras";
            this.Load += new System.EventHandler(this.Compras_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnBuscarProv)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textCantida)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnbuscarProducto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataCompras)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textFecha;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboTipoDoc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox btnBuscarProv;
        private System.Windows.Forms.TextBox textIdProv;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textProd;
        private System.Windows.Forms.PictureBox btnbuscarProducto;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox texCodProd;
        private System.Windows.Forms.TextBox textIdProd;
        private System.Windows.Forms.TextBox textVenta;
        private System.Windows.Forms.TextBox textCompra;
        private System.Windows.Forms.NumericUpDown textCantida;
        private System.Windows.Forms.DataGridView dataCompras;
        private System.Windows.Forms.Button btnAgregarCompra;
        private System.Windows.Forms.TextBox textTotalPagar;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.TextBox textRazonSocial;
        private System.Windows.Forms.TextBox textDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn idProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioDeCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioDeVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn MontoTotal;
        private System.Windows.Forms.DataGridViewButtonColumn boton;
    }
}