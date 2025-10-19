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
            SuspendLayout();
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(282, 50);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(522, 39);
            dateTimePicker1.TabIndex = 0;
            // 
            // btnAsociarVehiculo
            // 
            btnAsociarVehiculo.Location = new Point(475, 200);
            btnAsociarVehiculo.Name = "btnAsociarVehiculo";
            btnAsociarVehiculo.Size = new Size(268, 46);
            btnAsociarVehiculo.TabIndex = 1;
            btnAsociarVehiculo.Text = "Asociar Vehiculo";
            btnAsociarVehiculo.UseVisualStyleBackColor = true;
            btnAsociarVehiculo.Click += btnAsociarVehiculo_Click;
            // 
            // frmInsertarMantenimientos
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(992, 652);
            Controls.Add(btnAsociarVehiculo);
            Controls.Add(dateTimePicker1);
            Name = "frmInsertarMantenimientos";
            Text = "frmInsertarMantenimientos";
            ResumeLayout(false);
        }

        #endregion

        private DateTimePicker dateTimePicker1;
        private Button btnAsociarVehiculo;
    }
}