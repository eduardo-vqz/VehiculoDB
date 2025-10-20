namespace VehiculoDB.Formularios.FormsMantenimientos
{
    partial class frmInsertarMantenimientos
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
            dateTimePicker1 = new DateTimePicker();
            btnAsociarVehiculo = new Button();
            txtPlaca = new TextBox();
            txtCosto = new TextBox();
            txtObservaciones = new TextBox();
            cbxTipoMantenimiento = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            btnCerrar = new Button();
            btnAgregar = new Button();
            SuspendLayout();
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(327, 83);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(522, 39);
            dateTimePicker1.TabIndex = 0;
            dateTimePicker1.Value = new DateTime(2025, 10, 18, 22, 13, 16, 0);
            // 
            // btnAsociarVehiculo
            // 
            btnAsociarVehiculo.Location = new Point(581, 26);
            btnAsociarVehiculo.Name = "btnAsociarVehiculo";
            btnAsociarVehiculo.Size = new Size(268, 46);
            btnAsociarVehiculo.TabIndex = 1;
            btnAsociarVehiculo.Text = "Asociar Vehiculo";
            btnAsociarVehiculo.UseVisualStyleBackColor = true;
            btnAsociarVehiculo.Click += btnAsociarVehiculo_Click;
            // 
            // txtPlaca
            // 
            txtPlaca.Enabled = false;
            txtPlaca.Location = new Point(327, 26);
            txtPlaca.Name = "txtPlaca";
            txtPlaca.Size = new Size(200, 39);
            txtPlaca.TabIndex = 2;
            // 
            // txtCosto
            // 
            txtCosto.Location = new Point(327, 158);
            txtCosto.Name = "txtCosto";
            txtCosto.Size = new Size(200, 39);
            txtCosto.TabIndex = 3;
            // 
            // txtObservaciones
            // 
            txtObservaciones.Location = new Point(327, 233);
            txtObservaciones.Name = "txtObservaciones";
            txtObservaciones.Size = new Size(522, 39);
            txtObservaciones.TabIndex = 4;
            // 
            // cbxTipoMantenimiento
            // 
            cbxTipoMantenimiento.FormattingEnabled = true;
            cbxTipoMantenimiento.Location = new Point(327, 306);
            cbxTipoMantenimiento.Name = "cbxTipoMantenimiento";
            cbxTipoMantenimiento.Size = new Size(242, 40);
            cbxTipoMantenimiento.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(33, 29);
            label1.Name = "label1";
            label1.Size = new Size(105, 32);
            label1.TabIndex = 6;
            label1.Text = "Vehiculo";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(33, 90);
            label2.Name = "label2";
            label2.Size = new Size(76, 32);
            label2.TabIndex = 7;
            label2.Text = "Fecha";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(33, 161);
            label3.Name = "label3";
            label3.Size = new Size(75, 32);
            label3.TabIndex = 8;
            label3.Text = "Costo";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(33, 236);
            label4.Name = "label4";
            label4.Size = new Size(169, 32);
            label4.TabIndex = 9;
            label4.Text = "Observaciones";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(44, 309);
            label5.Name = "label5";
            label5.Size = new Size(267, 32);
            label5.TabIndex = 10;
            label5.Text = "Tipo de Mantenimiento";
            // 
            // btnCerrar
            // 
            btnCerrar.Location = new Point(503, 397);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(228, 66);
            btnCerrar.TabIndex = 12;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = true;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(209, 397);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(228, 66);
            btnAgregar.TabIndex = 11;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // frmInsertarMantenimientos
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(877, 503);
            Controls.Add(btnCerrar);
            Controls.Add(btnAgregar);
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
            Controls.Add(dateTimePicker1);
            Name = "frmInsertarMantenimientos";
            Text = "frmInsertarMantenimientos";
            Load += frmInsertarMantenimientos_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker dateTimePicker1;
        private Button btnAsociarVehiculo;
        private TextBox txtPlaca;
        private TextBox txtCosto;
        private TextBox txtObservaciones;
        private ComboBox cbxTipoMantenimiento;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button btnCerrar;
        private Button btnAgregar;
    }
}