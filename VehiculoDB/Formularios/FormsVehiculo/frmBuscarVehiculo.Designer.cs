namespace VehiculoDB.Formularios.FormsVehiculo
{
    partial class frmBuscarVehiculo
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
            btnSeleccionar = new Button();
            dgvVehiculos = new DataGridView();
            txtBuscarVehiculo = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvVehiculos).BeginInit();
            SuspendLayout();
            // 
            // btnSeleccionar
            // 
            btnSeleccionar.Location = new Point(695, 21);
            btnSeleccionar.Name = "btnSeleccionar";
            btnSeleccionar.Size = new Size(227, 58);
            btnSeleccionar.TabIndex = 13;
            btnSeleccionar.Text = "Seleccionar";
            btnSeleccionar.UseVisualStyleBackColor = true;
            // 
            // dgvVehiculos
            // 
            dgvVehiculos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVehiculos.Location = new Point(29, 107);
            dgvVehiculos.Name = "dgvVehiculos";
            dgvVehiculos.ReadOnly = true;
            dgvVehiculos.RowHeadersWidth = 82;
            dgvVehiculos.Size = new Size(1363, 493);
            dgvVehiculos.TabIndex = 10;
            // 
            // txtBuscarVehiculo
            // 
            txtBuscarVehiculo.Location = new Point(29, 31);
            txtBuscarVehiculo.Name = "txtBuscarVehiculo";
            txtBuscarVehiculo.Size = new Size(508, 39);
            txtBuscarVehiculo.TabIndex = 14;
            // 
            // frmBuscarVehiculo
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1422, 629);
            Controls.Add(txtBuscarVehiculo);
            Controls.Add(btnSeleccionar);
            Controls.Add(dgvVehiculos);
            Name = "frmBuscarVehiculo";
            Text = "frmBuscarVehiculo";
            Load += frmBuscarVehiculo_Load;
            ((System.ComponentModel.ISupportInitialize)dgvVehiculos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSeleccionar;
        private DataGridView dgvVehiculos;
        private TextBox txtBuscarVehiculo;
    }
}