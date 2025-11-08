using Capa_Logica;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Font = iTextSharp.text.Font;
using System.ComponentModel;
using ClosedXML.Excel;
using System.Diagnostics;



//agregar using de charts
using System.Windows.Forms.DataVisualization.Charting;

namespace ArimaERP.Administrador
{
    public partial class FormReportes : Form
    {
        ClassReporteLogica reporteLogica = new ClassReporteLogica();
        public FormReportes()
        {
            InitializeComponent();
            ConfigurarTabs();
            ConfigurarCharts();
            ConfigurarGraficoVentasMes((Chart)tabGraficos.TabPages[0].Controls[0]);
            ConfigurarGraficoTopProductos((Chart)tabGraficos.TabPages[1].Controls[0]);
            ConfigurarGraficoComparativa((Chart)tabGraficos.TabPages[2].Controls[0]);
            ConfigurarGraficoTopProducto((Chart)tabGraficos.TabPages[3].Controls[0]);
            ConfigurarGraficoPorVendedor((Chart)tabGraficos.TabPages[4].Controls[0]);
            
        }
        private void ActualizarGraficoYTabla(int index)
        {
            tabGraficos.SelectedIndex = index;

            string grafico = tabGraficos.TabPages[index].Text;
            DateTime mes = dateTimePickerMes.Value;

            switch (grafico)
            {
                case "Ventas del Mes":
                    ConfigurarGraficoVentasMes((Chart)tabGraficos.TabPages[index].Controls[0]);
                    var datosMes = reporteLogica.ObtenerVentasConcretadasPorSemana(mes)
                        .Select(d => new { Semana = d.Item1, Total = d.Item2 })
                        .ToList();
                    dataGridViewDatos.DataSource = datosMes;
                    break;

                case "Productos Más Vendidos":
                    ConfigurarGraficoTopProductos((Chart)tabGraficos.TabPages[index].Controls[0]);
                    var datosFamilias = reporteLogica.ObtenerTopFamiliasVendidas(mes)
                        .Select(f => new { Familia = f.familia, Cantidad = f.cantidad })
                        .ToList();
                    dataGridViewDatos.DataSource = datosFamilias;
                    break;

                case "Comparativa Mensual":
                    ConfigurarGraficoComparativa((Chart)tabGraficos.TabPages[index].Controls[0]);
                    var datosComparativa = reporteLogica.ObtenerVentasConcretadasPorSemanaComparativa(mes)
                        .Select(c => new { Semana = c.Item1, Total = c.Item2 })
                        .ToList();
                    dataGridViewDatos.DataSource = datosComparativa;
                    break;

                case "Top Producto":
                    ConfigurarGraficoTopProducto((Chart)tabGraficos.TabPages[index].Controls[0]);
                    var datosTopProducto = reporteLogica.ObtenerTopProductosVendidos(mes)
                        .Select(p => new { Producto = p.producto, Cantidad = p.cantidad })
                        .ToList();
                    dataGridViewDatos.DataSource = datosTopProducto;
                    break;

                case "Ventas por Vendedor":
                    ConfigurarGraficoPorVendedor((Chart)tabGraficos.TabPages[index].Controls[0]);
                    var datosVendedor = reporteLogica.ObtenerVentasPorVendedor(mes)
                        .Select(v => new { Vendedor = v.vendedor, Total = v.total })
                        .ToList();
                    dataGridViewDatos.DataSource = datosVendedor;
                    break;
            }
        }

        private void ExportarTablaActualAExcelyAbrir(string rutaArchivo)
        {
            var wb = new XLWorkbook();
            var hoja = wb.Worksheets.Add("Datos");
            // Obtener el tab activo
            int index = tabGraficos.SelectedIndex;
            ActualizarGraficoYTabla(index);

            // Encabezados
            for (int col = 0; col < dataGridViewDatos.Columns.Count; col++)
            {
                hoja.Cell(1, col + 1).Value = dataGridViewDatos.Columns[col].HeaderText;
                hoja.Cell(1, col + 1).Style.Font.Bold = true;
                hoja.Cell(1, col + 1).Style.Fill.BackgroundColor = XLColor.LightGray;
                hoja.Cell(1, col + 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            }

            // Filas
            for (int fila = 0; fila < dataGridViewDatos.Rows.Count; fila++)
            {
                for (int col = 0; col < dataGridViewDatos.Columns.Count; col++)
                {
                    var valor = dataGridViewDatos.Rows[fila].Cells[col].Value;

                    if (valor is DateTime dt)
                        hoja.Cell(fila + 2, col + 1).Value = dt;
                    else if (valor is int i)
                        hoja.Cell(fila + 2, col + 1).Value = i;
                    else if (valor is double d)
                        hoja.Cell(fila + 2, col + 1).Value = d;
                    else
                        hoja.Cell(fila + 2, col + 1).Value = valor?.ToString();

                }
            }

            hoja.Columns().AdjustToContents(); // Autoajuste de ancho

            wb.SaveAs(rutaArchivo);
            Process.Start(new ProcessStartInfo
            {
                FileName = rutaArchivo,
                UseShellExecute = true
            });
        }
        private void ConfigurarTabs()
        {
            // Limpiar tabs existentes
            tabGraficos.TabPages.Clear();

            // Crear los 3 tabs
            TabPage tabVentasMes = new TabPage("Ventas del Mes");
            TabPage tabTopProductos = new TabPage("Productos Más Vendidos");
            TabPage tabComparativa = new TabPage("Comparativa Mensual");
            TabPage tabTopProducto = new TabPage("Top Producto");
            TabPage tabTopVendedor = new TabPage("Ventas por Vendedor");


            // Agregar al TabControl
            tabGraficos.TabPages.Add(tabVentasMes);
            tabGraficos.TabPages.Add(tabTopProductos);
            tabGraficos.TabPages.Add(tabComparativa);
            tabGraficos.TabPages.Add(tabTopProducto);
            tabGraficos.TabPages.Add(tabTopVendedor);
        }

        private void ConfigurarCharts()
        {
            // TAB 1 - Ventas del Mes (Gráfico de Barras)
            Chart chartVentasMes = new Chart();
            chartVentasMes.Dock = DockStyle.Fill;
            chartVentasMes.BackColor = Color.White;
            tabGraficos.TabPages[0].Controls.Add(chartVentasMes);

            // TAB 2 - Top Productos (Gráfico de Torta)
            Chart chartTopProductos = new Chart();
            chartTopProductos.Dock = DockStyle.Fill;
            chartTopProductos.BackColor = Color.White;
            tabGraficos.TabPages[1].Controls.Add(chartTopProductos);

            // TAB 3 - Comparativa (Gráfico de Líneas)
            Chart chartComparativa = new Chart();
            chartComparativa.Dock = DockStyle.Fill;
            chartComparativa.BackColor = Color.White;
            tabGraficos.TabPages[2].Controls.Add(chartComparativa);

            Chart chartTopProducto = new Chart(); // Nuevo chart
            chartTopProducto.Dock = DockStyle.Fill;
            chartTopProducto.BackColor = Color.White;
            tabGraficos.TabPages[3].Controls.Add(chartTopProducto);

            Chart chartTopVendedor = new Chart();
            chartTopVendedor.Dock = DockStyle.Fill;
            chartTopVendedor.BackColor = Color.White;
            tabGraficos.TabPages[4].Controls.Add(chartTopVendedor);
        }


        private void ConfigurarGraficoVentasMes(Chart chart)
        {
            // Limpiar áreas y series anteriores para evitar duplicados
            chart.Series.Clear();
            chart.ChartAreas.Clear();
            chart.Titles.Clear();
            // Crear área del gráfico
            ChartArea area = new ChartArea("VentasArea");
            chart.ChartAreas.Add(area);

            // Crear serie de datos
            Series serie = new Series("Ventas");
            serie.ChartType = SeriesChartType.Column; // Barras
            serie.IsValueShownAsLabel = true;
            chart.Series.Add(serie);

            // Obtener datos reales
            DateTime mesSeleccionado = dateTimePickerMes.Value;
            DateTime inicioMes = new DateTime(mesSeleccionado.Year, mesSeleccionado.Month, 1);

            var ventasPorSemana = reporteLogica.ObtenerVentasConcretadasPorSemana(inicioMes);
            decimal totalMensual = 0;
            foreach (var item in ventasPorSemana)
            {
                serie.Points.AddXY(item.semana, item.total);
                totalMensual += item.total;
            }
            // Agregar título dinámico con nombre del mes
            string nombreMes = inicioMes.ToString("MMMM yyyy"); 
            chart.Titles.Add($"Ventas concretadas en {nombreMes} - Total: {totalMensual:C}");
        }
        private void dateTimePickerMes_ValueChanged(object sender, EventArgs e)
        {
            ConfigurarGraficoVentasMes((Chart)tabGraficos.TabPages[0].Controls[0]);
            ConfigurarGraficoTopProductos((Chart)tabGraficos.TabPages[1].Controls[0]);
            ConfigurarGraficoComparativa((Chart)tabGraficos.TabPages[2].Controls[0]);
            ConfigurarGraficoTopProducto((Chart)tabGraficos.TabPages[3].Controls[0]);
            ConfigurarGraficoPorVendedor((Chart)tabGraficos.TabPages[4].Controls[0]);
            ActualizarTablaDatos();

        }
        private Dictionary<string, Color> ColoresPorFamilia = new Dictionary<string, Color>
        {
            { "Comidas", Color.SandyBrown },
            { "Bebidas", Color.CornflowerBlue },
            { "Lácteos", Color.LightSkyBlue },
            { "Higiene Personal", Color.MediumOrchid },
            { "Bebidas alcohólicas", Color.Firebrick },
            { "Cuidado doméstico", Color.DarkSeaGreen },
            { "Pilas-Velas-Encendedores", Color.Goldenrod }
        };

        private void ConfigurarGraficoTopProductos(Chart chart)
        {
            chart.Series.Clear();
            chart.ChartAreas.Clear();
            chart.Titles.Clear();
            chart.Legends.Clear();

            ChartArea area = new ChartArea("ProductosArea");
            chart.ChartAreas.Add(area);

            Series serie = new Series("Productos");
            serie.ChartType = SeriesChartType.Pie;
            serie.IsValueShownAsLabel = true;
            chart.Legends.Add(new Legend("Familias"));
            serie.Legend = "Familias";
            serie.IsVisibleInLegend = true;
            chart.Series.Add(serie);

            // Obtener mes seleccionado
            DateTime mesSeleccionado = dateTimePickerMes.Value;
            DateTime inicioMes = new DateTime(mesSeleccionado.Year, mesSeleccionado.Month, 1);

            var familiasVendidas = reporteLogica.ObtenerTopFamiliasVendidas(inicioMes);

            int total = 0;
            foreach (var item in familiasVendidas)
            {
                int puntoIndex = serie.Points.AddXY(item.familia, item.cantidad);

                // Asignar color personalizado
                if (ColoresPorFamilia.TryGetValue(item.familia, out Color color))
                {
                    serie.Points[puntoIndex].Color = color;
                }
                else
                {
                    serie.Points[puntoIndex].Color = Color.LightGray; // color por defecto si no está definido
                }

                total += item.cantidad;
            }

            string nombreMes = inicioMes.ToString("MMMM yyyy");
            chart.Titles.Add($"Distribución de productos vendidos por familia en {nombreMes} - Total: {total}");
        }

        private void ConfigurarGraficoComparativa(Chart chart)
        {         
            chart.Series.Clear();
            chart.ChartAreas.Clear();
            chart.Titles.Clear();

            ChartArea area = new ChartArea("ComparativaArea");
            chart.ChartAreas.Add(area);

            Series serieActual = new Series("Mes Actual");
            serieActual.ChartType = SeriesChartType.Line;
            serieActual.BorderWidth = 3;
            serieActual.Color = Color.SteelBlue;
            serieActual.IsValueShownAsLabel = true;

            Series serieAnterior = new Series("Mes Anterior");
            serieAnterior.ChartType = SeriesChartType.Line;
            serieAnterior.BorderDashStyle = ChartDashStyle.Dash;
            serieAnterior.Color = Color.OrangeRed;
            serieAnterior.IsValueShownAsLabel = true;

            chart.Series.Add(serieActual);
            chart.Series.Add(serieAnterior);

            DateTime mesSeleccionado = dateTimePickerMes.Value;
            DateTime inicioMes = new DateTime(mesSeleccionado.Year, mesSeleccionado.Month, 1);
            DateTime inicioMesAnterior = inicioMes.AddMonths(-1);

            var ventasActual = reporteLogica.ObtenerVentasConcretadasPorSemana(inicioMes);
            var ventasAnterior = reporteLogica.ObtenerVentasConcretadasPorSemana(inicioMesAnterior);

            foreach (var item in ventasActual)
            {
                serieActual.Points.AddXY($"Sem {item.semana}", item.total);
            }

            foreach (var item in ventasAnterior)
            {
                serieAnterior.Points.AddXY($"Sem {item.semana}", item.total);
            }

            string titulo = $"Comparativa semanal: {inicioMes.ToString("MMMM yyyy")} vs {inicioMesAnterior.ToString("MMMM yyyy")}";
            chart.Titles.Add(titulo);
        }

        private void ConfigurarGraficoTopProducto(Chart chart)
        {
            chart.Series.Clear();
            chart.ChartAreas.Clear();
            chart.Titles.Clear();

            ChartArea area = new ChartArea("TopProductosArea");
            chart.ChartAreas.Add(area);

            Series serie = new Series("Productos Vendidos");
            serie.ChartType = SeriesChartType.Bar;
            serie.IsValueShownAsLabel = true;
            serie.Color = Color.MediumSeaGreen;

            chart.Series.Add(serie);

            DateTime mesSeleccionado = dateTimePickerMes.Value;
            var productos = reporteLogica.ObtenerTopProductosVendidos(mesSeleccionado);

            foreach (var item in productos)
            {
                serie.Points.AddXY(item.producto, item.cantidad);
            }

            chart.Titles.Add($"Top productos vendidos - {mesSeleccionado.ToString("MMMM yyyy")}");
        }

        private void ConfigurarGraficoPorVendedor(Chart chart)
        {
            chart.Series.Clear();
            chart.ChartAreas.Clear();
            chart.Titles.Clear();

            ChartArea area = new ChartArea("VendedorArea");
            chart.ChartAreas.Add(area);

            Series serie = new Series("Ventas por Vendedor");
            serie.ChartType = SeriesChartType.Bar;
            serie.IsValueShownAsLabel = true;
            serie.Color = Color.DarkSlateBlue;

            chart.Series.Add(serie);

            DateTime mesSeleccionado = dateTimePickerMes.Value;
            var ventas = reporteLogica.ObtenerVentasPorVendedor(mesSeleccionado);

            foreach (var item in ventas)
            {
                serie.Points.AddXY(item.vendedor, item.total);
            }

            chart.Titles.Add($"Ventas por vendedor - {mesSeleccionado.ToString("MMMM yyyy")}");
        }

        private void ExportarGraficoActualAPDF()
        {
            // Obtener el gráfico actual desde el tab seleccionado
            TabPage tabActual = tabGraficos.SelectedTab;
            Chart chartActual = tabActual.Controls.OfType<Chart>().FirstOrDefault();

            if (chartActual == null)
            {
                MessageBox.Show("No se encontró ningún gráfico en el tab seleccionado.");
                return;
            }

            // Renderizar el gráfico como imagen
            using (MemoryStream ms = new MemoryStream())
            {
                chartActual.SaveImage(ms, ChartImageFormat.Png);
                ms.Position = 0;

                // Crear documento PDF
                Document doc = new Document(PageSize.A4, 50, 50, 50, 50);
                string nombreArchivo = $"Grafico_{tabActual.Text.Replace(" ", "_")}_{DateTime.Now:yyyyMMdd_HHmm}.pdf";
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Filter = "PDF files (*.pdf)|*.pdf";
                dialog.FileName = nombreArchivo;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    using (FileStream fs = new FileStream(dialog.FileName, FileMode.Create))
                    {
                        PdfWriter writer = PdfWriter.GetInstance(doc, fs);
                        doc.Open();

                        // Agregar título
                        Font tituloFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16);
                        Paragraph titulo = new Paragraph(tabActual.Text, tituloFont);
                        titulo.Alignment = Element.ALIGN_CENTER;
                        doc.Add(titulo);
                        doc.Add(new Paragraph("\n"));
                        // Texto adicional según gráfico
                        Font textoFont = FontFactory.GetFont(FontFactory.HELVETICA, 12);
                        DateTime mesSeleccionado = dateTimePickerMes.Value;
                        DateTime inicioMes = new DateTime(mesSeleccionado.Year, mesSeleccionado.Month, 1);

                        if (tabActual.Text.Contains("Comparativa"))
                        {
                            DateTime mesAnterior = inicioMes.AddMonths(-1);
                            doc.Add(new Paragraph($"Mes actual: {inicioMes.ToString("MMMM yyyy")}", textoFont));
                            doc.Add(new Paragraph($"Mes anterior: {mesAnterior.ToString("MMMM yyyy")}", textoFont));
                        }
                        else
                        {
                            doc.Add(new Paragraph($"Mes: {inicioMes.ToString("MMMM yyyy")}", textoFont));
                            if (tabActual.Text.Contains("Vendedor"))
                            {
                                doc.Add(new Paragraph("Incluye vendedores con roles: Preventista, Empleado Clientes, Otro Rol", textoFont));
                            }
                        }

                        doc.Add(new Paragraph("\n"));

                        // Agregar imagen del gráfico
                        iTextSharp.text.Image graficoImg = iTextSharp.text.Image.GetInstance(ms);
                        graficoImg.Alignment = Element.ALIGN_CENTER;
                        graficoImg.ScaleToFit(500f, 400f);
                        doc.Add(graficoImg);

                        doc.Close();
                    }

                    MessageBox.Show($"PDF generado correctamente:\n{nombreArchivo}", "Exportación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    System.Diagnostics.Process.Start(dialog.FileName);
                }
            }
        }


        private void tabGraficos_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarTablaDatos();
        }

        private void FormReportes_Load(object sender, EventArgs e)
        {
            // Ventas del Mes
            ConfigurarGraficoVentasMes((Chart)tabGraficos.TabPages[0].Controls[0]);

            // Productos Más Vendidos
            ConfigurarGraficoTopProductos((Chart)tabGraficos.TabPages[1].Controls[0]);

            // Comparativa Mensual
            ConfigurarGraficoComparativa((Chart)tabGraficos.TabPages[2].Controls[0]);

            // Top Producto
            ConfigurarGraficoTopProducto((Chart)tabGraficos.TabPages[3].Controls[0]);

            // Ventas por Vendedor
            ConfigurarGraficoPorVendedor((Chart)tabGraficos.TabPages[4].Controls[0]);
            dataGridViewDatos.RowTemplate.Height = 28;
            tabGraficos.SelectedIndex = 0;
            ActualizarTablaDatos();

        }

        private void btnExportarPDF_Click(object sender, EventArgs e)
        {
            ExportarGraficoActualAPDF();
        }
        private string ObtenerGraficoActivo()
        {
            return tabGraficos.SelectedTab?.Text ?? "";
        }
        private void ActualizarTablaDatos()
        {
            string grafico = ObtenerGraficoActivo();
            DateTime mes = dateTimePickerMes.Value;

            if (grafico == "Ventas por Vendedor")
            {
                var datos = reporteLogica.ObtenerVentasPorVendedor(mes)
                    .Select(v => new { Vendedor = v.vendedor, Total = v.total })
                    .ToList();
                dataGridViewDatos.DataSource = datos;
            }
            else if (grafico == "Top Producto")
            {
                var datos = reporteLogica.ObtenerTopProductosVendidos(mes)
                    .Select(p => new { Producto = p.producto, Cantidad = p.cantidad })
                    .ToList();
                dataGridViewDatos.DataSource = datos;
            }
            else if (grafico == "Productos Más Vendidos")
            {
                var datos = reporteLogica.ObtenerTopFamiliasVendidas(mes)
                    .Select(f => new { Familia = f.familia, Cantidad = f.cantidad })
                    .ToList();
                dataGridViewDatos.DataSource = datos;
            }
            else if (grafico == "Ventas del Mes")
            {
                var datos = reporteLogica.ObtenerVentasConcretadasPorSemana(mes)
                    .Select(d => new { Semana = d.semana, Total = d.total })
                    .ToList();
                dataGridViewDatos.DataSource = datos;
            }
            else if (grafico == "Comparativa Mensual")
            {
                var datos = reporteLogica.ObtenerVentasConcretadasPorSemanaComparativa(mes)
                    .Select(c => new { Semana = c.Item1, Total = c.Item2})
                    .ToList();
                dataGridViewDatos.DataSource = datos;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //cerrar
            this.Close();
        }
        

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "Excel (*.xlsx)|*.xlsx",
                FileName = "TablaActual.xlsx"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                ExportarTablaActualAExcelyAbrir(sfd.FileName);
                MessageBox.Show("Exportación completada.");
            }
        }  


    }
}
