namespace VehiculoDB.Formularios.FromsPropietario
{
    partial class frmPropietario
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
            dgvPropietario = new DataGridView();
            bntCerrar = new Button();
            btnEdiarPropietario = new Button();
            btnAgregarPropietario = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvPropietario).BeginInit();
            SuspendLayout();
            // 
            // dgvPropietario
            // 
            dgvPropietario.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPropietario.Location = new Point(12, 12);
            dgvPropietario.Name = "dgvPropietario";
            dgvPropietario.ReadOnly = true;
            dgvPropietario.RowHeadersWidth = 82;
            dgvPropietario.Size = new Size(1363, 538);
            dgvPropietario.TabIndex = 0;
            // 
            // bntCerrar
            // 
            bntCerrar.Location = new Point(1428, 425);
            bntCerrar.Name = "bntCerrar";
            bntCerrar.Size = new Size(228, 125);
            bntCerrar.TabIndex = 1;
            bntCerrar.Text = "Cerrar";
            bntCerrar.UseVisualStyleBackColor = true;
            // 
            // btnEdiarPropietario
            // 
            btnEdiarPropietario.Location = new Point(1428, 218);
            btnEdiarPropietario.Name = "btnEdiarPropietario";
            btnEdiarPropietario.Size = new Size(228, 125);
            btnEdiarPropietario.TabIndex = 2;
            btnEdiarPropietario.Text = "Editar";
            btnEdiarPropietario.UseVisualStyleBackColor = true;
            // 
            // btnAgregarPropietario
            // 
            btnAgregarPropietario.Location = new Point(1428, 12);
            btnAgregarPropietario.Name = "btnAgregarPropietario";
            btnAgregarPropietario.Size = new Size(228, 125);
            btnAgregarPropietario.TabIndex = 3;
            btnAgregarPropietario.Text = "Agregar";
            btnAgregarPropietario.UseVisualStyleBackColor = true;
            // 
            // frmPropietario
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1699, 562);
            Controls.Add(btnAgregarPropietario);
            Controls.Add(btnEdiarPropietario);
            Controls.Add(bntCerrar);
            Controls.Add(dgvPropietario);
            Name = "frmPropietario";
            Text = "Propietario";
            Load += frmPropietario_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPropietario).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvPropietario;
        private Button bntCerrar;
        private Button btnEdiarPropietario;
        private Button btnAgregarPropietario;
    }
}