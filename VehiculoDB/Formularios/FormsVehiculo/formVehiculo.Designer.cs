namespace VehiculoDB.Formularios.FormsVehiculo
{
    partial class formVehiculo
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
            btnEliminar = new Button();
            btnAgregar = new Button();
            btnEdiarPropietario = new Button();
            bntCerrar = new Button();
            dgvVehiculos = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvVehiculos).BeginInit();
            SuspendLayout();
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(1443, 415);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(228, 125);
            btnEliminar.TabIndex = 14;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(1443, 12);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(228, 125);
            btnAgregar.TabIndex = 13;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            // 
            // btnEdiarPropietario
            // 
            btnEdiarPropietario.Location = new Point(1443, 218);
            btnEdiarPropietario.Name = "btnEdiarPropietario";
            btnEdiarPropietario.Size = new Size(228, 125);
            btnEdiarPropietario.TabIndex = 12;
            btnEdiarPropietario.Text = "Editar";
            btnEdiarPropietario.UseVisualStyleBackColor = true;
            // 
            // bntCerrar
            // 
            bntCerrar.Location = new Point(1443, 589);
            bntCerrar.Name = "bntCerrar";
            bntCerrar.Size = new Size(228, 125);
            bntCerrar.TabIndex = 11;
            bntCerrar.Text = "Cerrar";
            bntCerrar.UseVisualStyleBackColor = true;
            // 
            // dgvVehiculos
            // 
            dgvVehiculos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVehiculos.Location = new Point(27, 12);
            dgvVehiculos.Name = "dgvVehiculos";
            dgvVehiculos.ReadOnly = true;
            dgvVehiculos.RowHeadersWidth = 82;
            dgvVehiculos.Size = new Size(1363, 702);
            dgvVehiculos.TabIndex = 10;
            // 
            // formVehiculo
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1699, 726);
            Controls.Add(btnEliminar);
            Controls.Add(btnAgregar);
            Controls.Add(btnEdiarPropietario);
            Controls.Add(bntCerrar);
            Controls.Add(dgvVehiculos);
            Name = "formVehiculo";
            Text = "fromVehiculo";
            Load += formVehiculo_Load;
            ((System.ComponentModel.ISupportInitialize)dgvVehiculos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnEliminar;
        private Button btnAgregar;
        private Button btnEdiarPropietario;
        private Button bntCerrar;
        private DataGridView dgvVehiculos;
    }
}