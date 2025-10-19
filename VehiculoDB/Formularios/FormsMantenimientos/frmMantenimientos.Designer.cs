namespace VehiculoDB.Formularios.FormsMantenimientos
{
    partial class frmMantenimientos
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
            dgvMantenimientos = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvMantenimientos).BeginInit();
            SuspendLayout();
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(1443, 415);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(228, 125);
            btnEliminar.TabIndex = 9;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(1443, 12);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(228, 125);
            btnAgregar.TabIndex = 8;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnEdiarPropietario
            // 
            btnEdiarPropietario.Location = new Point(1443, 218);
            btnEdiarPropietario.Name = "btnEdiarPropietario";
            btnEdiarPropietario.Size = new Size(228, 125);
            btnEdiarPropietario.TabIndex = 7;
            btnEdiarPropietario.Text = "Editar";
            btnEdiarPropietario.UseVisualStyleBackColor = true;
            // 
            // bntCerrar
            // 
            bntCerrar.Location = new Point(1443, 589);
            bntCerrar.Name = "bntCerrar";
            bntCerrar.Size = new Size(228, 125);
            bntCerrar.TabIndex = 6;
            bntCerrar.Text = "Cerrar";
            bntCerrar.UseVisualStyleBackColor = true;
            // 
            // dgvMantenimientos
            // 
            dgvMantenimientos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMantenimientos.Location = new Point(27, 12);
            dgvMantenimientos.Name = "dgvMantenimientos";
            dgvMantenimientos.ReadOnly = true;
            dgvMantenimientos.RowHeadersWidth = 82;
            dgvMantenimientos.Size = new Size(1363, 702);
            dgvMantenimientos.TabIndex = 5;
            // 
            // frmMantenimientos
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1699, 726);
            Controls.Add(btnEliminar);
            Controls.Add(btnAgregar);
            Controls.Add(btnEdiarPropietario);
            Controls.Add(bntCerrar);
            Controls.Add(dgvMantenimientos);
            Name = "frmMantenimientos";
            Text = "Mantenimientos";
            Load += frmMantenimientos_Load;
            ((System.ComponentModel.ISupportInitialize)dgvMantenimientos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnEliminar;
        private Button btnAgregar;
        private Button btnEdiarPropietario;
        private Button bntCerrar;
        private DataGridView dgvMantenimientos;
    }
}