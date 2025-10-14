namespace VehiculoDB.Formularios.FromsPropietario
{
    partial class frmActualizarPropietario
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
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            txtDirección = new TextBox();
            mtxtTelefono = new MaskedTextBox();
            mtxtDUI = new MaskedTextBox();
            txtApellido = new TextBox();
            txtNombre = new TextBox();
            btnCerrar = new Button();
            btnActualizar = new Button();
            SuspendLayout();
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(68, 346);
            label5.Name = "label5";
            label5.Size = new Size(114, 32);
            label5.TabIndex = 23;
            label5.Text = "Dirección";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(68, 268);
            label4.Name = "label4";
            label4.Size = new Size(112, 32);
            label4.TabIndex = 22;
            label4.Text = "Telefono:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(68, 188);
            label3.Name = "label3";
            label3.Size = new Size(58, 32);
            label3.TabIndex = 21;
            label3.Text = "DUI:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(68, 114);
            label2.Name = "label2";
            label2.Size = new Size(107, 32);
            label2.TabIndex = 20;
            label2.Text = "Apellido:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(68, 43);
            label1.Name = "label1";
            label1.Size = new Size(107, 32);
            label1.TabIndex = 19;
            label1.Text = "Nombre:";
            // 
            // txtDirección
            // 
            txtDirección.Location = new Point(316, 339);
            txtDirección.Name = "txtDirección";
            txtDirección.Size = new Size(420, 39);
            txtDirección.TabIndex = 18;
            // 
            // mtxtTelefono
            // 
            mtxtTelefono.Location = new Point(316, 261);
            mtxtTelefono.Mask = "0000-0000";
            mtxtTelefono.Name = "mtxtTelefono";
            mtxtTelefono.Size = new Size(420, 39);
            mtxtTelefono.TabIndex = 17;
            // 
            // mtxtDUI
            // 
            mtxtDUI.Location = new Point(316, 181);
            mtxtDUI.Mask = "00000000-0";
            mtxtDUI.Name = "mtxtDUI";
            mtxtDUI.Size = new Size(420, 39);
            mtxtDUI.TabIndex = 16;
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(316, 107);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(420, 39);
            txtApellido.TabIndex = 15;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(316, 36);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(420, 39);
            txtNombre.TabIndex = 14;
            // 
            // btnCerrar
            // 
            btnCerrar.Location = new Point(434, 414);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(228, 66);
            btnCerrar.TabIndex = 13;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = true;
            // 
            // btnActualizar
            // 
            btnActualizar.Location = new Point(140, 414);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(228, 66);
            btnActualizar.TabIndex = 12;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            // 
            // frmActualizarPropietario
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
            Controls.Add(btnActualizar);
            Name = "frmActualizarPropietario";
            Text = "Actualizar Propietario";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox txtDirección;
        private MaskedTextBox mtxtTelefono;
        private MaskedTextBox mtxtDUI;
        private TextBox txtApellido;
        private TextBox txtNombre;
        private Button btnCerrar;
        private Button btnActualizar;
    }
}