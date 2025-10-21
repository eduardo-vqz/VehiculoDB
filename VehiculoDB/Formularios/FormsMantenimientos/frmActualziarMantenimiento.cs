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

namespace VehiculoDB.Formularios.FormsMantenimientos
{
    public partial class frmActualziarMantenimiento : Form
    {
        MantenimientosDao mantenimientosDao = new MantenimientosDao();
        private int _id;
        int id_vehiculo;

        public frmActualziarMantenimiento(int idMantenimiento)
        {
            InitializeComponent();
            _id = idMantenimiento;
            var p = mantenimientosDao.GetById(_id);
            if (p == null)
            {
                MessageBox.Show("No se pudo encontrar el registro", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            id_vehiculo = p.IdVehiculo;
            txtPlaca.Text = p.Placa;
            txtCosto.Text = p.Costo.ToString();
            dtpFechaMantenimiento.Value = p.Fecha.Date;
            txtObservaciones.Text = p.Observaciones ?? "";

            CargarTiposMantenimiento(p.IdTipoMantenimiento);
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
        private void frmActualziarMantenimiento_Load(object sender, EventArgs e)
        {

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Mantenimientos mantenimiento = new Mantenimientos()
            {
                IdVehiculo = id_vehiculo,
                Fecha = dtpFechaMantenimiento.Value.Date,
                Costo = decimal.Parse(txtCosto.Text),
                Observaciones = txtObservaciones.Text,
                IdTipoMantenimiento = Convert.ToInt32(cbxTipoMantenimiento.SelectedValue),
                IdMantenimiento = _id
            };

            try
            {
                if (mantenimientosDao.Update(mantenimiento))
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
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
        }
    }
}
