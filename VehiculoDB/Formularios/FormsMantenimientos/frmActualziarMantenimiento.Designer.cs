namespace VehiculoDB.Formularios.FormsMantenimientos
{
    partial class frmActualziarMantenimiento
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
            btnCerrar = new Button();
            btnActualizar = new Button();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            cbxTipoMantenimiento = new ComboBox();
            txtObservaciones = new TextBox();
            txtCosto = new TextBox();
            txtPlaca = new TextBox();
            btnAsociarVehiculo = new Button();
            dtpFechaMantenimiento = new DateTimePicker();
            SuspendLayout();
            // 
            // btnCerrar
            // 
            btnCerrar.Location = new Point(500, 404);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(228, 66);
            btnCerrar.TabIndex = 25;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // btnActualizar
            // 
            btnActualizar.Location = new Point(206, 404);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(228, 66);
            btnActualizar.TabIndex = 24;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(41, 316);
            label5.Name = "label5";
            label5.Size = new Size(267, 32);
            label5.TabIndex = 23;
            label5.Text = "Tipo de Mantenimiento";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(30, 243);
            label4.Name = "label4";
            label4.Size = new Size(169, 32);
            label4.TabIndex = 22;
            label4.Text = "Observaciones";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(30, 168);
            label3.Name = "label3";
            label3.Size = new Size(75, 32);
            label3.TabIndex = 21;
            label3.Text = "Costo";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(30, 97);
            label2.Name = "label2";
            label2.Size = new Size(76, 32);
            label2.TabIndex = 20;
            label2.Text = "Fecha";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(30, 36);
            label1.Name = "label1";
            label1.Size = new Size(105, 32);
            label1.TabIndex = 19;
            label1.Text = "Vehiculo";
            // 
            // cbxTipoMantenimiento
            // 
            cbxTipoMantenimiento.FormattingEnabled = true;
            cbxTipoMantenimiento.Location = new Point(324, 313);
            cbxTipoMantenimiento.Name = "cbxTipoMantenimiento";
            cbxTipoMantenimiento.Size = new Size(242, 40);
            cbxTipoMantenimiento.TabIndex = 18;
            // 
            // txtObservaciones
            // 
            txtObservaciones.Location = new Point(324, 240);
            txtObservaciones.Name = "txtObservaciones";
            txtObservaciones.Size = new Size(522, 39);
            txtObservaciones.TabIndex = 17;
            // 
            // txtCosto
            // 
            txtCosto.Location = new Point(324, 165);
            txtCosto.Name = "txtCosto";
            txtCosto.Size = new Size(200, 39);
            txtCosto.TabIndex = 16;
            // 
            // txtPlaca
            // 
            txtPlaca.Location = new Point(324, 33);
            txtPlaca.Name = "txtPlaca";
            txtPlaca.Size = new Size(200, 39);
            txtPlaca.TabIndex = 15;
            // 
            // btnAsociarVehiculo
            // 
            btnAsociarVehiculo.Location = new Point(578, 33);
            btnAsociarVehiculo.Name = "btnAsociarVehiculo";
            btnAsociarVehiculo.Size = new Size(268, 46);
            btnAsociarVehiculo.TabIndex = 14;
            btnAsociarVehiculo.Text = "Asociar Vehiculo";
            btnAsociarVehiculo.UseVisualStyleBackColor = true;
            // 
            // dtpFechaMantenimiento
            // 
            dtpFechaMantenimiento.Location = new Point(324, 90);
            dtpFechaMantenimiento.Name = "dtpFechaMantenimiento";
            dtpFechaMantenimiento.Size = new Size(522, 39);
            dtpFechaMantenimiento.TabIndex = 13;
            dtpFechaMantenimiento.Value = new DateTime(2025, 10, 18, 22, 13, 16, 0);
            // 
            // frmActualziarMantenimiento
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(877, 503);
            Controls.Add(btnCerrar);
            Controls.Add(btnActualizar);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cbxTipoMantenimiento);
            Controls.Add(txtObservaciones);
            Controls.Add(txtCosto);
            Controls.Add(txtPlaca);
            Controls.Add(btnAsociarVehiculo);
            Controls.Add(dtpFechaMantenimiento);
            Name = "frmActualziarMantenimiento";
            Text = "frmActualziarMantenimiento";
            Load += frmActualziarMantenimiento_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCerrar;
        private Button btnActualizar;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private ComboBox cbxTipoMantenimiento;
        private TextBox txtObservaciones;
        private TextBox txtCosto;
        private TextBox txtPlaca;
        private Button btnAsociarVehiculo;
        private DateTimePicker dtpFechaMantenimiento;
    }
}