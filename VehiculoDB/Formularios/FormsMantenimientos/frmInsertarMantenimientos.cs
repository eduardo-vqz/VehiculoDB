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

        }

        private void frmInsertarMantenimientos_Load(object sender, EventArgs e)
        {
            CargarTiposMantenimiento();

        }

        private void CargarTiposMantenimiento(int? idSeleccionado = null)
        {
            TiposMantenimientoDao tiposMantenimientoDao = new TiposMantenimientoDao();
            var tipos = tiposMantenimientoDao.GetAll(); // List<TiposMantenimiento>

            // (Opcional) agrega item "-- Seleccione --"
            tipos.Insert(0, new TiposMantenimiento
            {
                IdTipoMantenimiento = 0,
                NombreTipo = "-- Seleccione --"
            });

            cbxTipoMantenimiento.DataSource = tipos;
            cbxTipoMantenimiento.DisplayMember = "NombreTipo";
            cbxTipoMantenimiento.ValueMember = "IdTipoMantenimiento";

        }
        }
}
