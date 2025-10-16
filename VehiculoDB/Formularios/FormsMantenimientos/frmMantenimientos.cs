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
    public partial class frmMantenimientos : Form
    {
        MantenimientosDao mantenimientosDao = new MantenimientosDao(); 
        public frmMantenimientos()
        {
            InitializeComponent();
        }

        private void frmMantenimientos_Load(object sender, EventArgs e)
        {
            ConfiguracionGrid();
            Cargar();
        }

        private void ConfiguracionGrid()
        {
            dgvMantenimientos.AutoGenerateColumns = false;
            dgvMantenimientos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMantenimientos.MultiSelect = false;
            dgvMantenimientos.AllowUserToAddRows = false;
            dgvMantenimientos.ReadOnly = true;
            dgvMantenimientos.Columns.Clear();

            dgvMantenimientos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "IdMantenimientoCol",
                HeaderText = "IdMantenimiento",
                DataPropertyName = "IdMantenimiento",
                Width = 110
            });

            
            dgvMantenimientos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "IdVehiculoCol",
                HeaderText = "IdVehiculo",
                DataPropertyName = "IdVehiculo", 
                Width = 90
            });
            dgvMantenimientos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "PlacaCol",
                HeaderText = "Placa",
                DataPropertyName = "Placa", 
                Width = 90
            });
            dgvMantenimientos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "FechaCol",
                HeaderText = "Fecha",
                DataPropertyName = "Fecha",
                Width = 110,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "yyyy-MM-dd" }
            });

            dgvMantenimientos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CostoCol",
                HeaderText = "Costo",
                DataPropertyName = "Costo",
                Width = 90,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N2", Alignment = DataGridViewContentAlignment.MiddleRight }
            });

            dgvMantenimientos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ObservacionesCol",
                HeaderText = "Observaciones",
                DataPropertyName = "Observaciones",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvMantenimientos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "IdTipoMantenimientoCol",
                HeaderText = "IdTipoMantenimiento",
                DataPropertyName = "IdTipoMantenimiento", // cambiado: propiedad plana en Mantenimientos
                Width = 130
            });
            dgvMantenimientos.Columns.Add(new DataGridViewTextBoxColumn
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
                dgvMantenimientos.DataSource = mantenimientosDao.GetAll();
                dgvMantenimientos.ClearSelection();
                dgvMantenimientos.CurrentCell = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado:" + ex);
            }
        }
    }
    
}
