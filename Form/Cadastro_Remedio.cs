using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Microsoft.Office.Interop.Excel;


namespace cadastro_remedios
{
    public partial class Cadastro_Remedio : Form
    {
        public Cadastro_Remedio()
        {
            InitializeComponent();
        }
        //botão cadastrar 
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtId.Text == string.Empty)
            {
                Product lProduct = new Product();
                productQuery da = new productQuery();

                if (txtIdBarras.Text != string.Empty)
                    lProduct.CodigoBarras = txtIdBarras.Text;
                else
                    MessageBox.Show(Config.lFied + "CÓDIGO DE BARRAS" + Config.lRequired, Config.lAlert);

                lProduct.Descricao = txtDescricao.Text;
                lProduct.NomeGenerico = txtNameGenerico.Text;

                if (txtNameComercial.Text != string.Empty)
                    lProduct.NomeComercial = txtNameComercial.Text;
                else
                    MessageBox.Show(Config.lFied + "NOME COMERCIAL" + Config.lRequired, Config.lAlert);

                lProduct.Grupo = txtGrupo.Text;

                if (txtFabricante.Text != string.Empty)
                    lProduct.Fabricante = txtFabricante.Text;
                else
                    MessageBox.Show(Config.lFied + "FABRICANTE" + Config.lRequired, Config.lAlert);

                lProduct.Unidade = txtUnidade.Text;
                lProduct.Armazenamento = txtArmazenamento.Text;
                lProduct.Marca = txtMarca.Text;

                if (txtQuantidade.Text != string.Empty)
                    lProduct.Estoque = txtQuantidade.Text;
                else
                    MessageBox.Show(Config.lFied + "QUANTIDADE NO ESTOQUE" + Config.lRequired, Config.lAlert);

                if (txtDateCadastro.Text != string.Empty)
                    lProduct.DataCadastro = txtDateCadastro.Text;
                else
                    MessageBox.Show(Config.lFied + "DATA DO CADASTRO" + Config.lRequired, Config.lAlert);

                lProduct.PrecoCaixa = txtPrecoCaixa.Text;
                lProduct.UnidadeCaixa = txtUnidadeCaixa.Text;
                lProduct.CompraUnidade = txtPrecoCompraUnidade.Text;
                lProduct.Margem = txtMargem.Text;

                if (txtPrecoVenda.Text != string.Empty)
                    lProduct.PrecoVenda = txtPrecoVenda.Text;
                else
                    MessageBox.Show(Config.lFied + "PREÇO DE VENDA" + Config.lRequired, Config.lAlert);


                lProduct.DescontoPromocao = txtDiscountPromocao.Text;
                lProduct.MargemPromocao = txtMargemPromocao.Text;
                lProduct.PrecoPromocao = txtPrecoPromocao.Text;
                lProduct.InicioPromocao = txtInicioPromocao.Text;
                lProduct.FinalPromocao = txtFinalPromocao.Text;
                lProduct.Obs = txtObs.Text;

                if (txtStatus.Text == "Ativo" && txtStatus.Text != string.Empty)
                    lProduct.Status = "A";
                else if (txtStatus.Text != string.Empty)
                    lProduct.Status = "I";
                else
                    MessageBox.Show(Config.lFied + "STATUS" + Config.lRequired, Config.lAlert);


                if (txtIdBarras.Text != string.Empty && txtNameComercial.Text != string.Empty && txtFabricante.Text != string.Empty && txtQuantidade.Text != string.Empty
                    && txtDateCadastro.Text != string.Empty && txtPrecoVenda.Text != string.Empty && txtStatus.Text != string.Empty)
                {
                    da.Insert(lProduct);
                    MessageBox.Show(MessageBoxResult.lSucess);
                    Clean();
                }
                else
                {
                    MessageBox.Show(Config.lErrorRegister, MessageBoxResult.lError);
                }
            }
            else
            {
                Product lProduct = new Product();
                productQuery da = new productQuery();
                if (txtIdBarras.Text != string.Empty)
                    lProduct.CodigoBarras = txtIdBarras.Text;
                else
                    MessageBox.Show(Config.lFied + "CÓDIGO DE BARRAS" + Config.lRequired, Config.lAlert);

                lProduct.Descricao = txtDescricao.Text;
                lProduct.NomeGenerico = txtNameGenerico.Text;

                if (txtNameComercial.Text != string.Empty)
                    lProduct.NomeComercial = txtNameComercial.Text;
                else
                    MessageBox.Show(Config.lFied + "NOME COMERCIAL" + Config.lRequired, Config.lAlert);

                lProduct.Grupo = txtGrupo.Text;

                if (txtFabricante.Text != string.Empty)
                    lProduct.Fabricante = txtFabricante.Text;
                else
                    MessageBox.Show(Config.lFied + "FABRICANTE" + Config.lRequired, Config.lAlert);

                lProduct.Unidade = txtUnidade.Text;
                lProduct.Armazenamento = txtArmazenamento.Text;
                lProduct.Marca = txtMarca.Text;

                if (txtQuantidade.Text != string.Empty)
                    lProduct.Estoque = txtQuantidade.Text;
                else
                    MessageBox.Show(Config.lFied + "QUANTIDADE NO ESTOQUE" + Config.lRequired, Config.lAlert);

                if (txtDateCadastro.Text != string.Empty)
                    lProduct.DataCadastro = txtDateCadastro.Text;
                else
                    MessageBox.Show(Config.lFied + "DATA DO CADASTRO" + Config.lRequired, Config.lAlert);

                lProduct.PrecoCaixa = txtPrecoCaixa.Text;
                lProduct.UnidadeCaixa = txtUnidadeCaixa.Text;
                lProduct.CompraUnidade = txtPrecoCompraUnidade.Text;
                lProduct.Margem = txtMargem.Text;

                if (txtPrecoVenda.Text != string.Empty)
                    lProduct.PrecoVenda = txtPrecoVenda.Text;
                else
                    MessageBox.Show(Config.lFied + "PREÇO DE VENDA" + Config.lRequired, Config.lAlert);


                lProduct.DescontoPromocao = txtDiscountPromocao.Text;
                lProduct.MargemPromocao = txtMargemPromocao.Text;
                lProduct.PrecoPromocao = txtPrecoPromocao.Text;
                lProduct.InicioPromocao = txtInicioPromocao.Text;
                lProduct.FinalPromocao = txtFinalPromocao.Text;
                lProduct.Obs = txtObs.Text;

                if (txtStatus.Text == "Ativo" && txtStatus.Text != string.Empty)
                    lProduct.Status = "A";
                else if (txtStatus.Text != string.Empty)
                    lProduct.Status = "I";
                else
                    MessageBox.Show(Config.lFied + "STATUS" + Config.lRequired, Config.lAlert);


                if (txtIdBarras.Text != string.Empty && txtNameComercial.Text != string.Empty && txtFabricante.Text != string.Empty && txtQuantidade.Text != string.Empty
                    && txtDateCadastro.Text != string.Empty && txtPrecoVenda.Text != string.Empty && txtStatus.Text != string.Empty)
                {
                    da.Update(lProduct);
                    MessageBox.Show(MessageBoxResult.lUpdate);
                    Clean();
                }
                else
                {
                    MessageBox.Show(Config.lErrorRegister, MessageBoxResult.lErrorUpdate);
                }
            }
        }
        //botão limpar
        private void btnClean_Click(object sender, EventArgs e)
        {
            Clean();
        }

        private void Clean()
        {
            txtId.Text = string.Empty;
            txtIdBarras.Text = string.Empty;
            txtDescricao.Text = string.Empty;
            txtNameGenerico.Text = string.Empty;
            txtNameComercial.Text = string.Empty;
            txtGrupo.Text = string.Empty;
            txtFabricante.Text = string.Empty;
            txtUnidade.Text = string.Empty;
            txtArmazenamento.Text = string.Empty;
            txtMarca.Text = string.Empty;
            txtQuantidade.Text = string.Empty;
            txtDateCadastro.Text = string.Empty;
            txtPrecoCaixa.Text = string.Empty;
            txtUnidadeCaixa.Text = string.Empty;
            txtPrecoCompraUnidade.Text = string.Empty;
            txtMargem.Text = string.Empty;
            txtPrecoVenda.Text = string.Empty;
            txtDiscountPromocao.Text = string.Empty;
            txtMargemPromocao.Text = string.Empty;
            txtPrecoPromocao.Text = string.Empty;
            txtInicioPromocao.Text = string.Empty;
            txtFinalPromocao.Text = string.Empty;
            txtObs.Text = string.Empty;
        }

        private void Search()
        {
            MySqlConnection con = new MySqlConnection(Connection.lConnection);
            con.Open();
            string op = (string)comboBox1.SelectedItem;
            switch (op)
            {

                case "Código":
                    MySqlDataAdapter ad = new MySqlDataAdapter(productQuery.GetById, con);
                    ad.SelectCommand.Parameters.AddWithValue("value", txtSearch.Text + "%");
                    System.Data.DataTable table = new System.Data.DataTable();
                    ad.Fill(table);
                    dataGridView.DataSource = table;
                    con.Close();
                    break;
                case "Fabricante":
                    MySqlDataAdapter ad1 = new MySqlDataAdapter(productQuery.GetByCompany, con);
                    ad1.SelectCommand.Parameters.AddWithValue("value", txtSearch.Text + "%");
                    System.Data.DataTable table1 = new System.Data.DataTable();
                    ad1.Fill(table1);
                    dataGridView.DataSource = table1;
                    con.Close();
                    break;
                case "Nome Genérico":
                    MySqlDataAdapter ad2 = new MySqlDataAdapter(productQuery.GetByGenericName, con);
                    ad2.SelectCommand.Parameters.AddWithValue("value", txtSearch.Text + "%");
                    System.Data.DataTable table2 = new System.Data.DataTable();
                    ad2.Fill(table2);
                    dataGridView.DataSource = table2;
                    con.Close();
                    break;
                case "Todos":
                    MySqlDataAdapter ad3 = new MySqlDataAdapter(productQuery.GetAllProducts, con);
                    ad3.SelectCommand.Parameters.AddWithValue("value", txtSearch.Text + "%");
                    System.Data.DataTable table3 = new System.Data.DataTable();
                    ad3.Fill(table3);
                    dataGridView.DataSource = table3;
                    con.Close();
                    break;
                case "Ativo":
                    MySqlDataAdapter ad4 = new MySqlDataAdapter(productQuery.GetAllActiveProducts, con);
                    ad4.SelectCommand.Parameters.AddWithValue("value", txtSearch.Text + "%");
                    System.Data.DataTable table4 = new System.Data.DataTable();
                    ad4.Fill(table4);
                    dataGridView.DataSource = table4;
                    con.Close();
                    break;
                case "Inativo":
                    MySqlDataAdapter ad5 = new MySqlDataAdapter(productQuery.GetAllInactiveProducts, con);
                    ad5.SelectCommand.Parameters.AddWithValue("value", txtSearch.Text + "%");
                    System.Data.DataTable table5 = new System.Data.DataTable();
                    ad5.Fill(table5);
                    dataGridView.DataSource = table5;
                    con.Close();
                    break;
            }
        }
        //botão pesquisar
        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
            btnExport.Enabled = true;

        }
        //botão voltar
        private void btnBack_Click(object sender, EventArgs e)
        {
            Close();
            Principal remedio = new Principal();
            remedio.Show();
        }
        //clicar na celula do datagrid
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string codigo;
            codigo = Convert.ToString(dataGridView.CurrentRow.Cells[0].Value);

            MySqlConnection cn = new MySqlConnection(Connection.lConnection);
            cn.Open();

            MySqlCommand cmd2 = new MySqlCommand("SELECT pro_codigo, pro_codigo_de_barras,pro_descricao_do_produto,pro_nome_generico,pro_nome_comercial,pro_grupo ,pro_fabricante_do_produto,pro_unidade," +
            "pro_local_de_armazenamento,pro_marca_fabricante,pro_quantidade_no_estoque,pro_data_de_cadastro,pro_preco_de_compra_por_caixa,pro_unid_caixa,pro_preco_de_compra_unitario," +
            "pro_margem,pro_preco_de_venda,pro_desconto_de_promocao,pro_margem_de_promocao,pro_preco_promocao,pro_inicio_da_promocao,pro_final_da_promocao,pro_obs,pro_status FROM cadastro_remedios WHERE pro_codigo = '" + codigo + "'", cn);
            MySqlDataReader reader = null;
            reader = cmd2.ExecuteReader();

            if (reader.Read())
            {
                txtId.Text = reader.GetString(0);
                txtIdBarras.Text = reader.GetString(1);
                txtDescricao.Text = reader.GetString(2);
                txtNameGenerico.Text = reader.GetString(3);
                txtNameComercial.Text = reader.GetString(4);
                txtGrupo.Text = reader.GetString(5);
                txtFabricante.Text = reader.GetString(6);
                txtUnidade.Text = reader.GetString(7);
                txtArmazenamento.Text = reader.GetString(8);
                txtMarca.Text = reader.GetString(9);
                txtQuantidade.Text = reader.GetString(10);
                txtDateCadastro.Text = reader.GetString(11);
                txtPrecoCaixa.Text = reader.GetString(12);
                txtUnidadeCaixa.Text = reader.GetString(13);
                txtPrecoCompraUnidade.Text = reader.GetString(14);
                txtMargem.Text = reader.GetString(15);
                txtPrecoVenda.Text = reader.GetString(16);
                txtDiscountPromocao.Text = reader.GetString(17);
                txtMargemPromocao.Text = reader.GetString(18);
                txtPrecoPromocao.Text = reader.GetString(19);
                txtInicioPromocao.Text = reader.GetString(20);
                txtFinalPromocao.Text = reader.GetString(21);
                txtObs.Text = reader.GetString(22);
                txtStatus.Text = reader.GetString(23);
                if (txtStatus.Text == "A")
                    txtStatus.Text = "Ativo";
                else
                    txtStatus.Text = "Inativo";

            }
            cn.Close();
            tabControl1.SelectedTab = tabPage1;
        }
        // voltar ao principal através da tecla esc
        private void Cadastro_Remedio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
                Principal remedio = new Principal();
                remedio.Show();
            }
        }
        // pesquisar ao digitar 
        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            Search();
        }

        private void Cadastro_Remedio_Load(object sender, EventArgs e)
        {
            txtIdBarras.Focus();
            txtDateCadastro.Text = DateTime.Now.ToString();
            txtDiscountPromocao.ReadOnly = true;
            txtFinalPromocao.ReadOnly = true;
            txtInicioPromocao.ReadOnly = true;
            txtPrecoPromocao.ReadOnly = true;
            txtMargemPromocao.ReadOnly = true;
        }

        private void checkBox1_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtDiscountPromocao.ReadOnly = false;
                txtFinalPromocao.ReadOnly = false;
                txtInicioPromocao.ReadOnly = false;
                txtPrecoPromocao.ReadOnly = false;
                txtMargemPromocao.ReadOnly = false;
            }
            else
            {
                txtDiscountPromocao.ReadOnly = true;
                txtFinalPromocao.ReadOnly = true;
                txtInicioPromocao.ReadOnly = true;
                txtPrecoPromocao.ReadOnly = true;
                txtMargemPromocao.ReadOnly = true;
            }
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
                    dataGridView.ClearSelection();
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
            dataGridView.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            dataGridView.SelectAll();
            DataObject dataObj = dataGridView.GetClipboardContent();
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