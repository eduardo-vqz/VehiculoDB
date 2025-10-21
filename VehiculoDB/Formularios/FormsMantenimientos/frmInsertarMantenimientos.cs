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
using VehiculoDB.Formularios.FormsVehiculo;
using VehiculoDB.Formularios.FromsPropietario;

namespace VehiculoDB.Formularios.FormsMantenimientos
{
    public partial class frmInsertarMantenimientos : Form
    {
        int id_vehiculo;


        public frmInsertarMantenimientos()
        {
            InitializeComponent();
        }

        private void btnAsociarVehiculo_Click(object sender, EventArgs e)
        {
            frmBuscarVehiculo frm = new frmBuscarVehiculo();
            if (frm.ShowDialog() == DialogResult.OK && frm.vehiculoSeleccionado != null)
            {
                txtPlaca.Text = frm.vehiculoSeleccionado.Placa;
                id_vehiculo = frm.vehiculoSeleccionado.IdVehiculo;
            }

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            MantenimientosDao mantenimientosDao = new MantenimientosDao();
            Mantenimientos mantenimiento = new Mantenimientos()
            {
                IdVehiculo = id_vehiculo,
                Fecha = dtpFechaMantenimiento.Value.Date,
                Costo = decimal.Parse(txtCosto.Text),
                Observaciones = txtObservaciones.Text,
                IdTipoMantenimiento = Convert.ToInt32(cbxTipoMantenimiento.SelectedValue)
            };
            /*MessageBox.Show($"{mantenimiento.IdVehiculo}\n {mantenimiento.Fecha}\n {mantenimiento.Costo}\n {mantenimiento.Observaciones}\n {mantenimiento.IdTipoMantenimiento}");
            return;*/

            try
            {
                var id = mantenimientosDao.Insert(mantenimiento);


                if (id > 0)
                {
                    MessageBox.Show("El mantenimiento se registro con éxito" + id,
                        "Éxito", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    DialogResult = DialogResult.OK;

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Mantenimiento registrado sin éxito",
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

        private void frmInsertarMantenimientos_Load(object sender, EventArgs e)
        {
            CargarTiposMantenimiento();

        }

        private void CargarTiposMantenimiento(int? idSeleccionado = null)
        {
            TiposMantenimientoDao tiposMantenimientoDao = new TiposMantenimientoDao();
            var tipos = tiposMantenimientoDao.GetAll(); 


            tipos.Insert(0, new TiposMantenimiento
            {
                IdTipoMantenimiento = 0,
                NombreTipo = "-- Seleccione --"
            });

            cbxTipoMantenimiento.DataSource = tipos;
            cbxTipoMantenimiento.DisplayMember = "NombreTipo";
            cbxTipoMantenimiento.ValueMember = "IdTipoMantenimiento";

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
