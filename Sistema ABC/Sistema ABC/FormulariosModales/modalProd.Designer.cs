namespace Sistema_ABC.FormulariosModales
{
    partial class modalProd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(modalProd));
            this.label9 = new System.Windows.Forms.Label();
            this.comboOptions = new System.Windows.Forms.ComboBox();
            this.txtBusquedas = new System.Windows.Forms.TextBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dataProdModal = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataProdModal)).BeginInit();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label9.Location = new System.Drawing.Point(7, 26);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(93, 21);
            this.label9.TabIndex = 58;
            this.label9.Text = "Buscar por:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // comboOptions
            // 
            this.comboOptions.FormattingEnabled = true;
            this.comboOptions.Items.AddRange(new object[] {
            "Nombre",
            "Categoria",
            "Codigo"});
            this.comboOptions.Location = new System.Drawing.Point(105, 29);
            this.comboOptions.Name = "comboOptions";
            this.comboOptions.Size = new System.Drawing.Size(149, 21);
            this.comboOptions.TabIndex = 57;
            this.comboOptions.Text = "Seleccione una opcion";
           
            // 
            // txtBusquedas
            // 
            this.txtBusquedas.Location = new System.Drawing.Point(260, 30);
            this.txtBusquedas.Name = "txtBusquedas";
            this.txtBusquedas.Size = new System.Drawing.Size(191, 20);
            this.txtBusquedas.TabIndex = 59;
            this.txtBusquedas.TextChanged += new System.EventHandler(this.txtBusquedas_TextChanged);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Black;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(457, 30);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(40, 24);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 60;
            this.pictureBox3.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label3.Location = new System.Drawing.Point(206, 3);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(174, 21);
            this.label3.TabIndex = 61;
            this.label3.Text = " LISTA DE PRODUCTOS";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dataProdModal
            // 
            this.dataProdModal.AllowUserToAddRows = false;
            this.dataProdModal.BackgroundColor = System.Drawing.Color.White;
            this.dataProdModal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataProdModal.Location = new System.Drawing.Point(11, 56);
            this.dataProdModal.Name = "dataProdModal";
            this.dataProdModal.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataProdModal.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dataProdModal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataProdModal.Size = new System.Drawing.Size(486, 171);
            this.dataProdModal.TabIndex = 62;
            this.dataProdModal.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataProdModal_CellContentDoubleClick);
            // 
            // modalProd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 239);
            this.Controls.Add(this.dataProdModal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.txtBusquedas);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.comboOptions);
            this.Name = "modalProd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "modalProd";
            this.Load += new System.EventHandler(this.modalProd_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataProdModal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboOptions;
        private System.Windows.Forms.TextBox txtBusquedas;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataProdModal;
    }
}