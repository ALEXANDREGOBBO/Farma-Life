using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using cadastro_remedios.Models;
using MySql.Data.MySqlClient;
using Microsoft.Office.Interop.Excel;
namespace cadastro_remedios
{
    public partial class PesquisaVenda : Form
    {
        public PesquisaVenda()
        {
            InitializeComponent();
        }

        private void PesquisaVenda_Load(object sender, EventArgs e)
        {
            txtSearch.Focus();
        }

        //teclas de atalho
        private void PesquisaVenda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {

                this.Close();
                Principal principal = new Principal();
                principal.Show();

            }

            if (e.KeyCode == Keys.F7)
            {

                this.Close();
                Venda venda = new Venda();
                venda.Show();

            }
        }

        //voltar a tela principal
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            Principal principal = new Principal();
            principal.Show();
        }
        private void Pesquisar()
        {

            MySqlConnection con = new MySqlConnection(Connection.lConnection);
            con.Open();
            string op = (string)comboBox1.SelectedItem;
            switch (op)
            {
                case "Código da Venda":
                    string pesquisa = "SELECT ven_cod as Codigo,ven_data as Data,ven_total_liq as Liquido,ven_total_bruto as Bruto,ven_status as Status,cli_cod as Cliente, Func_cod as Funcionario, desc_venda as Desconto,cod_prod as Produto,ven_horario as 'Hora da Venda' FROM venda WHERE ven_cod LIKE @value";
                    MySqlDataAdapter ad = new MySqlDataAdapter(pesquisa, con);
                    ad.SelectCommand.Parameters.AddWithValue("value", txtSearch.Text + "%");
                    System.Data.DataTable table = new System.Data.DataTable();
                    ad.Fill(table);
                    dataGridViewSearch.DataSource = table;
                    con.Close();
                    break;

                case "Data da Venda":
                    string pesquisa1 = "SELECT ven_cod as Codigo,ven_data as Data,ven_total_liq as Liquido,ven_total_bruto as Bruto,ven_status as Status,cli_cod as Cliente, Func_cod as Funcionario, desc_venda as Desconto,cod_prod as Produto,ven_horario as 'Hora da Venda' FROM venda WHERE ven_data LIKE @value";
                    MySqlDataAdapter ad1 = new MySqlDataAdapter(pesquisa1, con);
                    ad1.SelectCommand.Parameters.AddWithValue("value", txtSearch.Text + "%");
                    System.Data.DataTable table1 = new System.Data.DataTable();
                    ad1.Fill(table1);
                    dataGridViewSearch.DataSource = table1;
                    con.Close();
                    break;

                case "Código do Funcionário":
                    string pesquisa2 = "SELECT ven_cod as Codigo,ven_data as Data,ven_total_liq as Liquido,ven_total_bruto as Bruto,ven_status as Status,cli_cod as Cliente, Func_cod as Funcionario, desc_venda as Desconto,cod_prod as Produto,ven_horario as 'Hora da Venda' FROM venda WHERE Func_cod LIKE @value";
                    MySqlDataAdapter ad2 = new MySqlDataAdapter(pesquisa2, con);
                    ad2.SelectCommand.Parameters.AddWithValue("value", txtSearch.Text + "%");
                    System.Data.DataTable table2 = new System.Data.DataTable();
                    ad2.Fill(table2);
                    dataGridViewSearch.DataSource = table2;
                    con.Close();
                    break;
            }
        }

        //pesquisar venda
        private void btnSearch_Click(object sender, EventArgs e)
        {
            Pesquisar();
            btnExport.Enabled = true;
        }
        //pesquisa com enter
        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            Pesquisar();

        }

        #region Exportar Excel.
        private void btnExport_Click(object sender, EventArgs e)
        {
            ExportExcel();
        }

        private void ExportExcel()
        {

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Documents (*.xls)|*.xls";
            sfd.FileName = "Vendas_" + DateTime.Now.ToString("dd-MM-yyyy");
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                // Copy DataGridView results to clipboard
                copyAlltoClipboard();

                object misValue = System.Reflection.Missing.Value;
                Microsoft.Office.Interop.Excel.Application xlexcel = new Microsoft.Office.Interop.Excel.Application();

                xlexcel.DisplayAlerts = false; // Without this you will get two confirm overwrite prompts
                Workbook xlWorkBook = xlexcel.Workbooks.Add(misValue);
                Worksheet xlWorkSheet = (Worksheet)xlWorkBook.Worksheets.get_Item(1);

                // Paste clipboard results to worksheet range
                Range CR = (Range)xlWorkSheet.Cells[1, 1];
                CR.Select();

                xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
                xlWorkSheet.Rows.AutoFit();
                xlWorkSheet.Columns.AutoFit();

                // Delete blank column A and select cell A1
                Range delRng = xlWorkSheet.get_Range("A:A").Cells;
                delRng.Delete(Type.Missing);
                xlWorkSheet.get_Range("A1").Select();

                // Save the excel file under the captured location from the SaveFileDialog
                xlWorkBook.SaveAs(sfd.FileName, XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlexcel.DisplayAlerts = true;
                xlWorkBook.Close(true, misValue, misValue);
                xlexcel.Quit();

                releaseObject(xlWorkSheet);
                releaseObject(xlWorkBook);
                releaseObject(xlexcel);

                // Clear Clipboard and DataGridView selection
                Clipboard.Clear();
                dataGridViewSearch.ClearSelection();
            }
        }

        private void copyAlltoClipboard()
        {
            dataGridViewSearch.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            dataGridViewSearch.SelectAll();
            DataObject dataObj = dataGridViewSearch.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show(MessageBoxResult.lErrorCommand + ex.ToString());
            }
        }
        #endregion
    }
}
