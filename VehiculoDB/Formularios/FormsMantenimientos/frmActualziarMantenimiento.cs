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

        public frmActualziarMantenimiento(int idMantenimiento)
        {
            InitializeComponent();
            _id = idMantenimiento;
            CargarTiposMantenimiento(_id);
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

            if (idSeleccionado.HasValue)
                cbxTipoMantenimiento.SelectedValue = idSeleccionado.Value;

        }
        private void frmActualziarMantenimiento_Load(object sender, EventArgs e)
        {

        }
    }
}
