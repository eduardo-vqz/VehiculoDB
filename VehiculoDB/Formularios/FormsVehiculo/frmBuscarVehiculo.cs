using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VehiculoDB.Core.Dao;

namespace VehiculoDB.Formularios.FormsVehiculo
{
    public partial class frmBuscarVehiculo : Form
    {
        VehiculoDao vehiculoDao = new VehiculoDao();
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
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
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

        

        private void txtBuscarVehiculo_KeyUp(object sender, KeyEventArgs e)
        {
            Cargar(txtBuscarVehiculo.Text);
        }
    }
}
