using VehiculoDB.Core.Clases;
using VehiculoDB.Core.Dao;

namespace VehiculoDB.Formularios.FromsPropietario
{
    public partial class frmPropietario : Form
    {
        private readonly PropietarioDao propietarioDao = new PropietarioDao();

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
            { Name = "ApellidoCol", HeaderText = "Apellido", DataPropertyName = "Apellido", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvPropietario.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "DUICol", HeaderText = "DUI", DataPropertyName = "DUI", Width = 120 });
            dgvPropietario.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "TelefonoCol", HeaderText = "Telefono", DataPropertyName = "Telefono", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvPropietario.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "DireccionCol", HeaderText = "Direccion", DataPropertyName = "Direccion", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
        }

        private void Cargar(string filtro = "")
        {
            try
            {
                dgvPropietario.DataSource = propietarioDao.GetAll(filtro);
                dgvPropietario.ClearSelection();
                dgvPropietario.CurrentCell = null;
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

        private void bntCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private int? GetIdSeleccionado()
        {
            if (dgvPropietario.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar un registro", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            if (dgvPropietario.CurrentRow.DataBoundItem is Propietario paPropietario)
                return paPropietario.IdPropietario;

            return null;
        }

        private void btnEdiarPropietario_Click(object sender, EventArgs e)
        {
            var id = GetIdSeleccionado();
            if (!id.HasValue)
            {
                MessageBox.Show("Seleccione una fila");
                return;
            }

            frmActualizarPropietario frm = new frmActualizarPropietario(id.Value);

            if (frm.ShowDialog() == DialogResult.OK)
                Cargar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            var id = GetIdSeleccionado();
            if (!id.HasValue)
            {
                MessageBox.Show("Seleccione un registro");
                return;
            }

            var respuesta = MessageBox.Show(
                "Desea eliminar el registro seleccionado?",
                "Confirmar eliminacion",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta == DialogResult.No)
                return;

            try
            {
                if (propietarioDao.Delete(id.Value))
                {
                    Cargar();
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el registro.",
                        "Aviso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (ApplicationException ex)
            {
                MessageBox.Show("No se pudo eliminar el registro. " + ex.Message,
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
