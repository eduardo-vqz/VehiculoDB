using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VehiculoDB.Core.Clases;
using VehiculoDB.Core.Dao;

namespace VehiculoDB.Formularios.FromsPropietario
{
    public partial class frmInsertarPropietario : Form
    {
        public frmInsertarPropietario()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            PropietarioDao propietarioDao = new PropietarioDao();
            Propietario propietario = new Propietario()
            {
                Nombre = txtNombre.Text.Trim(),
                Apellido = txtApellido.Text.Trim(),
                DUI = mtxtDUI.Text.Trim(),
                Telefono = mtxtTelefono.Text.Trim(),
                Direccion = txtDirección.Text.Trim(),
            };

            try
            {
                var id = propietarioDao.Insert(propietario);

                if (id > 0)
                {
                    MessageBox.Show("Propietario ingresado con éxito", 
                        "Éxito", MessageBoxButtons.OK, 
                        MessageBoxIcon.Information);

                    DialogResult = DialogResult.OK;

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Propietario ingresado sin éxito",
                        "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }

            }
            catch (ApplicationException ex)
            {
                MessageBox.Show(ex.Message, "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
