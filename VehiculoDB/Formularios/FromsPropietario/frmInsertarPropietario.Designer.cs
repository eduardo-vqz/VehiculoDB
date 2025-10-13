namespace VehiculoDB.Formularios.FromsPropietario
{
    partial class frmInsertarPropietario
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
            btnAgregar = new Button();
            btnCerrar = new Button();
            txtNombre = new TextBox();
            txtApellido = new TextBox();
            mtxtDUI = new MaskedTextBox();
            mtxtTelefono = new MaskedTextBox();
            txtDirección = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            SuspendLayout();
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(135, 426);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(228, 66);
            btnAgregar.TabIndex = 0;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            // 
            // btnCerrar
            // 
            btnCerrar.Location = new Point(429, 426);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(228, 66);
            btnCerrar.TabIndex = 1;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = true;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(311, 48);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(420, 39);
            txtNombre.TabIndex = 2;
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(311, 119);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(420, 39);
            txtApellido.TabIndex = 3;
            // 
            // mtxtDUI
            // 
            mtxtDUI.Location = new Point(311, 193);
            mtxtDUI.Mask = "00000000-0";
            mtxtDUI.Name = "mtxtDUI";
            mtxtDUI.Size = new Size(420, 39);
            mtxtDUI.TabIndex = 4;
            // 
            // mtxtTelefono
            // 
            mtxtTelefono.Location = new Point(311, 273);
            mtxtTelefono.Mask = "0000-0000";
            mtxtTelefono.Name = "mtxtTelefono";
            mtxtTelefono.Size = new Size(420, 39);
            mtxtTelefono.TabIndex = 5;
            // 
            // txtDirección
            // 
            txtDirección.Location = new Point(311, 351);
            txtDirección.Name = "txtDirección";
            txtDirección.Size = new Size(420, 39);
            txtDirección.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(63, 55);
            label1.Name = "label1";
            label1.Size = new Size(107, 32);
            label1.TabIndex = 7;
            label1.Text = "Nombre:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(63, 126);
            label2.Name = "label2";
            label2.Size = new Size(107, 32);
            label2.TabIndex = 8;
            label2.Text = "Apellido:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(63, 200);
            label3.Name = "label3";
            label3.Size = new Size(58, 32);
            label3.TabIndex = 9;
            label3.Text = "DUI:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(63, 280);
            label4.Name = "label4";
            label4.Size = new Size(112, 32);
            label4.TabIndex = 10;
            label4.Text = "Telefono:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(63, 358);
            label5.Name = "label5";
            label5.Size = new Size(114, 32);
            label5.TabIndex = 11;
            label5.Text = "Dirección";
            // 
            // frmInsertarPropietario
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 514);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtDirección);
            Controls.Add(mtxtTelefono);
            Controls.Add(mtxtDUI);
            Controls.Add(txtApellido);
            Controls.Add(txtNombre);
            Controls.Add(btnCerrar);
            Controls.Add(btnAgregar);
            Name = "frmInsertarPropietario";
            Text = "Agregar Propietario";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAgregar;
        private Button btnCerrar;
        private TextBox txtNombre;
        private TextBox txtApellido;
        private MaskedTextBox mtxtDUI;
        private MaskedTextBox mtxtTelefono;
        private TextBox txtDirección;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
    }
}