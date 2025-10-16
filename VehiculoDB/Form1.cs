using VehiculoDB.Core.Lib;
using VehiculoDB.Formularios.FormsMantenimientos;
using VehiculoDB.Formularios.FromsPropietario;

namespace VehiculoDB
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }
        Cnn cnn = new Cnn();
        private void btnOpen_Click(object sender, EventArgs e)
        {

            cnn.OpenDb();
            if (cnn != null)
            {
                MessageBox.Show("Conexion lista");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            cnn.CloseDb();
        }

        private void btnPropietarios_Click(object sender, EventArgs e)
        {
            frmPropietario form = new frmPropietario();
            form.Show();
        }

        private void btnMantenimientos_Click(object sender, EventArgs e)
        {
            frmMantenimientos form = new frmMantenimientos();
            form.Show();
        }
    }
}
