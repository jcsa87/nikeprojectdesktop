using nikeproject.Data;
using nikeproject.DataAccess;
using nikeproject.Helpers;
using nikeproject.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace nikeproject.Forms
{
    public partial class VentaControl : UserControl
    {
        private int idVentaSeleccionada = 0;
        private Cliente clienteSeleccionado = null;
        private Usuario vendedorActual = null;
        private List<DetalleVenta> listaDetalles = new List<DetalleVenta>();

        // 👇 Constructor vacío (para el diseñador y uso simple)
        public VentaControl()
        {
            InitializeComponent();
            Inicializar();
        }

        // 👇 Constructor opcional si querés pasar el usuario logueado
        public VentaControl(Usuario usuarioLogueado) : this()
        {
            vendedorActual = usuarioLogueado;
        }

        private void Inicializar()
        {
            CargarVentas();
            CargarClientes();
            CargarProductos();

            dgvVentas.CellClick += dgvVentas_CellClick;
            dgvClientesVenta.CellClick += dgvClientesVenta_CellClick;
            dgvProductosVenta.CellClick += dgvProductosVenta_CellClick;

            GridHelper.PintarInactivos(dgvVentas);
        }

        private void CargarVentas()
        {
            dgvVentas.DataSource = null;
            dgvVentas.DataSource = VentaData.ListarVentas();
        }

        private void CargarClientes()
        {
            ClienteData clienteData = new ClienteData();
            dgvClientesVenta.DataSource = clienteData.ListarClientes();
        }


        private void CargarProductos()
        {
            dgvProductosVenta.DataSource = null;
            dgvProductosVenta.DataSource = ProductoData.ListarProductos();
        }

        // ------------------ CRUD ------------------

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (clienteSeleccionado == null)
            {
                MessageBox.Show("⚠️ Seleccione un cliente.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (listaDetalles.Count == 0)
            {
                MessageBox.Show("⚠️ Agregue al menos un producto a la venta.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Venta nuevaVenta = new Venta
            {
                IdCliente = clienteSeleccionado.IdCliente,
                IdUsuario = vendedorActual.IdUsuario,
                NumeroDocumento = Guid.NewGuid().ToString().Substring(0, 8), // número único temporal
                FechaRegistro = DateTime.Now,
                MontoTotal = listaDetalles.Sum(d => d.SubTotal),
                Estado = true,
                Detalles = listaDetalles
            };

            if (VentaData.RegistrarVenta(nuevaVenta))
            {
                MessageBox.Show("✅ Venta registrada correctamente.");
                CargarVentas();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("❌ Error al registrar la venta.");
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("✏️ Generalmente no se editan ventas. Si necesitás, deberías anular y registrar otra.");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idVentaSeleccionada == 0)
            {
                MessageBox.Show("⚠️ Seleccione una venta.");
                return;
            }

            bool reactivar = (btnEliminar.Text == "Reactivar Venta");
            string msgConfirm = reactivar ? "¿Reactivar venta?" : "¿Dar de baja esta venta?";

            if (MessageBox.Show(msgConfirm, "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (VentaData.AnularVenta(idVentaSeleccionada))
                {
                    MessageBox.Show(reactivar ? "✅ Venta reactivada." : "🗑️ Venta anulada.");
                    CargarVentas();
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("❌ No se pudo actualizar la venta.");
                }
            }
        }

        // ------------------ EVENTOS GRILLAS ------------------

        private void dgvClientesVenta_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var cliente = dgvClientesVenta.Rows[e.RowIndex].DataBoundItem as Cliente;
            if (cliente == null) return;

            clienteSeleccionado = cliente;
            txtClienteSeleccionado.Text = cliente.Nombre + " " + cliente.Apellido;
            txtNumeroDocumento.Text = cliente.Documento;
        }

        private void dgvProductosVenta_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var prod = dgvProductosVenta.Rows[e.RowIndex].DataBoundItem as Producto;
            if (prod == null) return;

            int cantidad = 1; // ⚠️ en un escenario real lo pedís con un input
            var detalle = new DetalleVenta
            {
                IdProducto = prod.IdProducto,
                Cantidad = cantidad,
                PrecioUnitario = prod.PrecioVenta,
                SubTotal = cantidad * prod.PrecioVenta,
                Producto = prod
            };

            listaDetalles.Add(detalle);
            RefrescarDetalle();
        }

        private void dgvVentas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var venta = dgvVentas.Rows[e.RowIndex].DataBoundItem as Venta;
            if (venta == null) return;

            idVentaSeleccionada = venta.IdVenta;
            txtClienteSeleccionado.Text = venta.Cliente.Nombre;
            txtNumeroDocumento.Text = venta.NumeroDocumento;
            txtMontoTotal.Text = venta.MontoTotal.ToString("0.00");

            // Cargar detalle
            listaDetalles = VentaData.ListarDetallesPorVenta(venta.IdVenta);
            RefrescarDetalle();

            // Botón dinámico
            if (venta.Estado)
            {
                btnEliminar.Text = "Dar de Baja";
                btnEliminar.BackColor = Color.Firebrick;
            }
            else
            {
                btnEliminar.Text = "Reactivar Venta";
                btnEliminar.BackColor = Color.SeaGreen;
            }
        }

        // ------------------ AUXILIARES ------------------

        private void RefrescarDetalle()
        {
            dgvDetalleVenta.DataSource = null;
            dgvDetalleVenta.DataSource = listaDetalles;

            txtMontoTotal.Text = listaDetalles.Sum(d => d.SubTotal).ToString("0.00");
        }

        private void LimpiarCampos()
        {
            idVentaSeleccionada = 0;
            clienteSeleccionado = null;
            listaDetalles = new List<DetalleVenta>();

            txtClienteSeleccionado.Text = "";
            txtNumeroDocumento.Text = "";
            txtMontoTotal.Text = "";

            dgvDetalleVenta.DataSource = null;
        }
    }
}
