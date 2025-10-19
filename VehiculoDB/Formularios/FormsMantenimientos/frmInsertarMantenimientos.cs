using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VehiculoDB.Formularios.FormsVehiculo;
using VehiculoDB.Formularios.FromsPropietario;

namespace VehiculoDB.Formularios.FormsMantenimientos
{
    public partial class frmInsertarMantenimientos : Form
    {
        public frmInsertarMantenimientos()
        {
            InitializeComponent();
        }

        private void btnAsociarVehiculo_Click(object sender, EventArgs e)
        {
            frmBuscarVehiculo frm = new frmBuscarVehiculo();
            frm.ShowDialog();
            //if (frm.ShowDialog() == DialogResult.OK) { }

        }
    }
}
