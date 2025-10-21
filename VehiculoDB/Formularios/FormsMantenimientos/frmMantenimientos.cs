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
            dgvMantenimientos.AutoGenerateColumns = false;
            dgvMantenimientos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMantenimientos.MultiSelect = false;
            dgvMantenimientos.AllowUserToAddRows = false;
            dgvMantenimientos.ReadOnly = true;
            dgvMantenimientos.ScrollBars = ScrollBars.Vertical;
            dgvMantenimientos.Columns.Clear();

            configureCols(dgvMantenimientos, "PlacaCol", "Placa", "Placa");
            configureCols(dgvMantenimientos, "FechaCol", "Fecha", "Fecha");
            configureCols(dgvMantenimientos, "CostoCol", "Costo", "Costo");
            configureCols(dgvMantenimientos, "ObservacionesCol", "Observaciones", "Observaciones");
            configureCols(dgvMantenimientos, "NombreTipoCol", "NombreTipo", "NombreTipo");
            /*dgvMantenimientos.Columns.Add(new DataGridViewTextBoxColumn
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
                //DefaultCellStyle = new DataGridViewCellStyle { Format = "yyyy-MM-dd" }
            });

            dgvMantenimientos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CostoCol",
                HeaderText = "Costo",
                DataPropertyName = "Costo",
                Width = 90,
                //DefaultCellStyle = new DataGridViewCellStyle { Format = "N2", Alignment = DataGridViewContentAlignment.MiddleRight }
            });

            dgvMantenimientos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ObservacionesCol",
                HeaderText = "Observaciones",
                DataPropertyName = "Observaciones",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
            /*
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
            });*/
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

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmInsertarMantenimientos frm = new frmInsertarMantenimientos();
            if (frm.ShowDialog() == DialogResult.OK)
                Cargar();
        }

        private void dgvMantenimientos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private int? GetIdSeleccionado()
        {
            if (dgvMantenimientos.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar un registo", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            if (dgvMantenimientos.CurrentRow.DataBoundItem is Mantenimientos paMantenimientos)
                return paMantenimientos.IdMantenimiento;

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
            else
            {
                MessageBox.Show("Editar" + id.Value);
            }

            frmActualziarMantenimiento frm = new frmActualziarMantenimiento(id.Value);

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
                "¿Desea eliminar el registro seleccionado?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta == DialogResult.No)
                return;

            try
            {
                if (mantenimientosDao.Delete(id.Value))
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
                MessageBox.Show("No se pudo eliminar el registro" + ex.Message,
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
