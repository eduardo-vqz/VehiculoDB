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
using VehiculoDB.Formularios.FromsPropietario;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace VehiculoDB.Formularios.FormsVehiculo
{
    public partial class frmBuscarVehiculo : Form
    {
        VehiculoDao vehiculoDao = new VehiculoDao();
        internal Vehiculos? vehiculoSeleccionado;

        public frmBuscarVehiculo()
        {
            InitializeComponent();
        }

        private void frmBuscarVehiculo_Load(object sender, EventArgs e)
        {
            ConfiguracionGrid();
            Cargar();
        }

        private void configureCols(DataGridView dataGridView, string name, string headerText, string dataPropertyName)
        {
            dataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = name,
                HeaderText = headerText,
                DataPropertyName = dataPropertyName,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });
        }

        private void ConfiguracionGrid()
        {
            dgvVehiculos.AutoGenerateColumns = false;
            dgvVehiculos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVehiculos.MultiSelect = false;
            dgvVehiculos.AllowUserToAddRows = false;
            dgvVehiculos.ReadOnly = true;
            dgvVehiculos.Columns.Clear();

            configureCols(dgvVehiculos, "PlacaCol", "Placa", "Placa");
            configureCols(dgvVehiculos, "ModeloCol", "Modelo", "Modelo");
            configureCols(dgvVehiculos, "AnioCol", "Año", "Anio");
            configureCols(dgvVehiculos, "ColorCol", "Color", "Color");
            configureCols(dgvVehiculos, "NombreMarcaCol", "Marca", "NombreMarca");
            configureCols(dgvVehiculos, "DUICol", "DUI", "DUI");
            configureCols(dgvVehiculos, "Nombre", "Tipo", "NombreTipo");
        }

        private void Cargar(string filtro = "")
        {
            try
            {
                dgvVehiculos.DataSource = vehiculoDao.GetAll(filtro);
                dgvVehiculos.ClearSelection();
                dgvVehiculos.CurrentCell = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado:" + ex);
            }
        }

        private Vehiculos GetVehiculo()
        {
            if (dgvVehiculos.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar un registo", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            if (dgvVehiculos.CurrentRow.DataBoundItem is Vehiculos paVehiculo)
                return paVehiculo;

            return null;
        }

        

        private void txtBuscarVehiculo_KeyUp(object sender, KeyEventArgs e)
        {
            Cargar(txtBuscarVehiculo.Text);
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {

            if (GetVehiculo() == null)
            {
                MessageBox.Show("Seleccione una fila");
                return;
            }
            else
            {
                
                DialogResult = DialogResult.OK;
                vehiculoSeleccionado = GetVehiculo();
            }

        }
    }
}
