using VehiculoDB.Core.Clases;
using VehiculoDB.Core.Dao;
using VehiculoDB.Formularios.FormsVehiculo;

namespace VehiculoDB.Formularios.FormsMantenimientos
{
    public partial class frmInsertarMantenimientos : Form
    {
        private int idVehiculo;

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
                idVehiculo = frm.vehiculoSeleccionado.IdVehiculo;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!ValidarFormulario(out decimal costo, out int idTipoMantenimiento))
                return;

            MantenimientosDao mantenimientosDao = new MantenimientosDao();
            Mantenimientos mantenimiento = new Mantenimientos()
            {
                IdVehiculo = idVehiculo,
                Fecha = dtpFechaMantenimiento.Value.Date,
                Costo = costo,
                Observaciones = txtObservaciones.Text.Trim(),
                IdTipoMantenimiento = idTipoMantenimiento
            };

            try
            {
                var id = mantenimientosDao.Insert(mantenimiento);

                if (id > 0)
                {
                    MessageBox.Show($"El mantenimiento se registro con exito. Codigo generado: {id}",
                        "Exito", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show("No se pudo registrar el mantenimiento.",
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

        private bool ValidarFormulario(out decimal costo, out int idTipoMantenimiento)
        {
            costo = 0;
            idTipoMantenimiento = 0;

            if (idVehiculo <= 0)
            {
                MessageBox.Show("Debe asociar un vehiculo antes de registrar el mantenimiento.", "Validacion",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!decimal.TryParse(txtCosto.Text, out costo) || costo <= 0)
            {
                MessageBox.Show("Ingrese un costo valido mayor que cero.", "Validacion",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCosto.Focus();
                return false;
            }

            if (cbxTipoMantenimiento.SelectedValue == null || !int.TryParse(cbxTipoMantenimiento.SelectedValue.ToString(), out idTipoMantenimiento) || idTipoMantenimiento <= 0)
            {
                MessageBox.Show("Seleccione un tipo de mantenimiento valido.", "Validacion",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbxTipoMantenimiento.Focus();
                return false;
            }

            return true;
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

            if (idSeleccionado.HasValue)
                cbxTipoMantenimiento.SelectedValue = idSeleccionado.Value;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
