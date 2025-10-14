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

namespace VehiculoDB.Formularios.FromsPropietario
{
    public partial class frmPropietario : Form
    {
        private PropietarioDao propietarioDao = new PropietarioDao();
        public frmPropietario()
        {
            InitializeComponent();
        }

        private void ConfiguracionGrid()
        {
            dgvPropietario.AutoGenerateColumns = false;
            dgvPropietario.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPropietario.MultiSelect = false;
            dgvPropietario.Columns.Clear();

            dgvPropietario.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "NombreCol", HeaderText = "Nombre", DataPropertyName = "Nombre", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvPropietario.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "ApellidoCol", HeaderText = "Nombre", DataPropertyName = "Nombre", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvPropietario.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "DUICol", HeaderText = "DUI", DataPropertyName = "DUI", Width = 120 });
            dgvPropietario.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "TelefonoCol", HeaderText = "Telefono", DataPropertyName = "Telefono", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvPropietario.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "DireccionCol", HeaderText = "Direción", DataPropertyName = "Direccion", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
        }

        private void Cargar(string filtro = "")
        {
            dgvPropietario.DataSource = propietarioDao.GetAll();
            dgvPropietario.ClearSelection();
        }

        private void frmPropietario_Load(object sender, EventArgs e)
        {
            ConfiguracionGrid();
            Cargar();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmInsertarPropietario frm = new frmInsertarPropietario();
            if (frm.ShowDialog() == DialogResult.OK)
                Cargar();
        }
    }
}
