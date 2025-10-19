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

            configureCols(dgvVehiculos, "IdVechiculoCol", "Id Vehiculo", "IdVehiculo");
            dgvVehiculos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "IdMantenimientoCol",
                HeaderText = "IdMantenimiento",
                DataPropertyName = "IdMantenimiento",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });


            dgvVehiculos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "IdVehiculoCol",
                HeaderText = "IdVehiculo",
                DataPropertyName = "IdVehiculo",
                Width = 90
            });
            dgvVehiculos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "PlacaCol",
                HeaderText = "Placa",
                DataPropertyName = "Placa",
                Width = 90
            });
            dgvVehiculos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "FechaCol",
                HeaderText = "Fecha",
                DataPropertyName = "Fecha",
                Width = 110,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "yyyy-MM-dd" }
            });

            dgvVehiculos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CostoCol",
                HeaderText = "Costo",
                DataPropertyName = "Costo",
                Width = 90,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N2", Alignment = DataGridViewContentAlignment.MiddleRight }
            });

            dgvVehiculos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ObservacionesCol",
                HeaderText = "Observaciones",
                DataPropertyName = "Observaciones",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvVehiculos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "IdTipoMantenimientoCol",
                HeaderText = "IdTipoMantenimiento",
                DataPropertyName = "IdTipoMantenimiento", // cambiado: propiedad plana en Mantenimientos
                Width = 130
            });
            dgvVehiculos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "NombreTipoCol",
                HeaderText = "Tipo Mantenimiento",
                DataPropertyName = "NombreTipo", // cambiado: propiedad plana en Mantenimientos
                Width = 130
            });
        }

        private void Cargar(string filtro = "")
        {
            try
            { 
                dgvVehiculos.DataSource = vehiculoDao.GetAll();
                dgvVehiculos.ClearSelection();
                dgvVehiculos.CurrentCell = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado:" + ex);
            }
        }
    }
}
