using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Microsoft.Office.Interop.Excel;


namespace cadastro_remedios
{
    public partial class Pesquisa : Form
    {
        public Pesquisa()
        {
            InitializeComponent();
        }
        private void Pesquisar()
        {

            MySqlConnection con = new MySqlConnection(Connection.lConnection);
            con.Open();
            string op = (string)comboBox1.SelectedItem;
            switch (op)
            {

                case "Nome":
                    string pesquisa = "SELECT pro_codigo as Codigo,pro_nome_comercial as Nome,pro_preco_de_venda as Preco,pro_descricao_do_produto as Descricao,pro_fabricante_do_produto as Fabricante,pro_quantidade_no_estoque as Estoque FROM cadastro_remedios WHERE pro_nome_comercial LIKE @value";
                    MySqlDataAdapter ad = new MySqlDataAdapter(pesquisa, con);
                    ad.SelectCommand.Parameters.AddWithValue("value", txtSearch.Text + "%");
                    System.Data.DataTable table = new System.Data.DataTable();
                    ad.Fill(table);
                    dataGridView1.DataSource = table;
                    con.Close();
                    break;

                case "Fabricante":
                    string pesquisa1 = "SELECT pro_codigo as Codigo, pro_nome_comercial as Nome,pro_preco_de_venda as Preco,pro_descricao_do_produto as Descricao,pro_fabricante_do_produto as Fabricante,pro_quantidade_no_estoque as Estoque FROM cadastro_remedios FROM cadastro_remedios WHERE pro_fabricante_do_produto LIKE @value";
                    MySqlDataAdapter ad1 = new MySqlDataAdapter(pesquisa1, con);
                    ad1.SelectCommand.Parameters.AddWithValue("value", txtSearch.Text + "%");
                    System.Data.DataTable table1 = new System.Data.DataTable();
                    ad1.Fill(table1);
                    dataGridView1.DataSource = table1;
                    con.Close();
                    break;
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            Pesquisar();
            btnExport.Enabled = true;
        }
        //botão voltar
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            Principal principal = new Principal();
            principal.Show();
        }

        private void Pesquisa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {

                this.Close();
                Principal remedio = new Principal();
                remedio.Show();

            }
        }

        //pesquisa com enter
        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            Pesquisar();
        }

        private void Pesquisa_Load(object sender, EventArgs e)
        {
            txtSearch.Focus();
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
            sfd.FileName = "Produtos_" + DateTime.Now.ToString("dd-MM-yyyy");
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                // Copy DataGridView results to clipboard
                copyAlltoClipboard();
                try
                {
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
                    dataGridView1.ClearSelection();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, MessageBoxResult.lExportError);
                    errorQuery lerrorQuery = new errorQuery();
                    lerrorQuery.AddError(Principal.lUser, MessageBoxResult.lExportError, ex.Message.Replace("'", ""), DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), "Cadastro Funcionario");
                }
            }
        }

        private void copyAlltoClipboard()
        {
            dataGridView1.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            dataGridView1.SelectAll();
            DataObject dataObj = dataGridView1.GetClipboardContent();
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
