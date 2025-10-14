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
    public partial class frmActualizarPropietario : Form
    {

        private PropietarioDao propietarioDao = new PropietarioDao();
        private int _id;

        public frmActualizarPropietario(int idPropietario)
        {
            InitializeComponent();
            _id = idPropietario;
        }

        private void frmActualizarPropietario_Load(object sender, EventArgs e)
        {
            var p = propietarioDao.GetById(_id);
            if (p == null)
            {
                MessageBox.Show("No se pudo encontrar el registro", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            txtNombre.Text = p.Nombre;
            txtApellido.Text = p.Apellido;
            mtxtDUI.Text = p.DUI;
            mtxtTelefono.Text = p.Telefono ?? "";
            txtDireccion.Text = p.Direccion ?? "";


        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Propietario propietario = new Propietario
            {
                IdPropietario = _id,
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                DUI = mtxtDUI.Text,
                Telefono = mtxtTelefono.Text,
                Direccion = txtDireccion.Text
            };

            try
            {
                if (propietarioDao.Update(propietario))
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show("No se pudon actualziar el registro", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch (ApplicationException ex)
            {
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            catch (Exception ex) {
                MessageBox.Show("Error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }

        }

    }
}
