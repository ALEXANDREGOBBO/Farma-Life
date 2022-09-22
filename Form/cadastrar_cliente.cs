using System;
using System.Data;
using System.Net.Mail;
using System.Windows.Forms;
using System.Diagnostics;
using MySql.Data.MySqlClient;
using cadastro_remedios.Models;
using Microsoft.Office.Interop.Excel;


namespace cadastro_remedios
{

    public partial class cadastrar_cliente : Form
    {
        private MailMessage Email;
        Stopwatch Stop = new Stopwatch();
        public cadastrar_cliente()
        {
            InitializeComponent();
        }
        // botão limpar
        private void btnClean_Click(object sender, EventArgs e)
        {
            Clean();
        }

        public void Clean()
        {
            txtState.ReadOnly = true;
            txtCity.ReadOnly = true;
            txtDistrict.ReadOnly = true;
            txtStreet.ReadOnly = true;

            this.txtId.Text = string.Empty;
            this.txtName.Text = string.Empty;
            this.txtCpf.Text = string.Empty;
            this.txtCep.Text = string.Empty;
            this.txtStreet.Text = string.Empty;
            this.txtDistrict.Text = string.Empty;
            this.txtCity.Text = string.Empty;
            this.txtState.Text = string.Empty;
            this.txtCellphone.Text = string.Empty;
            this.txtEmail.Text = string.Empty;
            this.txtStatus.Text = string.Empty;
        }
        // botão cadastrar
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtId.Text != string.Empty)
            {
                Client lClient = new Client();
                clientQuery da = new clientQuery();

                lClient.Id = Convert.ToInt16(txtId.Text);
                if (txtName.Text != string.Empty)
                    lClient.Name = txtName.Text;
                else
                    MessageBox.Show(Config.lFied + "NOME" + Config.lRequired, Config.lAlert);

                if (txtCpf.Text != string.Empty)
                    lClient.Document = txtCpf.Text;
                else
                    MessageBox.Show(Config.lFied + "CPF" + Config.lRequired, Config.lAlert);

                if (txtCep.Text != string.Empty)
                    lClient.ZipCode = txtCep.Text;
                else
                    MessageBox.Show(Config.lFied + "CEP" + Config.lRequired, Config.lAlert);

                lClient.Street = txtStreet.Text;
                lClient.District = txtDistrict.Text;
                lClient.City = txtCity.Text;
                lClient.State = txtState.Text;
                lClient.Telephone = txtCellphone.Text;

                if (txtEmail.Text != string.Empty)
                    lClient.Email = txtEmail.Text;
                else
                    MessageBox.Show(Config.lFied + "E-MAIL" + Config.lRequired, Config.lAlert);

                if (txtStatus.Text == "Ativo" && txtStatus.Text != string.Empty)
                    lClient.Status = "A";
                else if (txtStatus.Text != string.Empty)
                    lClient.Status = "I";
                else
                    MessageBox.Show(Config.lFied + "STATUS" + Config.lRequired, Config.lAlert);


                if (txtName.Text != string.Empty && txtCep.Text != string.Empty && txtEmail.Text != string.Empty
                    && txtCpf.Text != string.Empty && txtStatus.Text != string.Empty)
                {
                    da.Update(lClient);
                    MessageBox.Show(MessageBoxResult.lUpdate);
                    Clean();
                }
                else
                {
                    MessageBox.Show(Config.lErrorRegister, MessageBoxResult.lErrorUpdate);
                }

            }
            else if (MessageBox.Show("Deseja receber um e-mail para confirmar o cadastro?", Config.lAlert, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                MySqlConnection con = new MySqlConnection(Connection.lConnection);
                con.Open();
                string consulta = "SELECT for_cpf FROM cadastro_cliente WHERE for_cpf = @cpf";
                MySqlCommand cmd = new MySqlCommand(consulta, con);

                //Passo o parametro
                cmd.Parameters.AddWithValue("@cpf", txtCpf.Text);
                MySqlDataReader read = cmd.ExecuteReader();

                //se o cliente já estiver cadastrado
                if (read.Read())
                {
                    if (MessageBox.Show("Cliente já está cadastrado, gostaria de pesquisar o mesmo?", Config.lAlert, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        tabControl1.SelectedTab = tabPage2;
                    }
                }
                //se não estiver
                else
                {
                    Client lClient = new Client();
                    clientQuery da = new clientQuery();
                    if (txtName.Text != string.Empty)
                        lClient.Name = txtName.Text;
                    else
                        MessageBox.Show(Config.lFied + "NOME" + Config.lRequired, Config.lAlert);

                    if (txtCpf.Text != string.Empty)
                        lClient.Document = txtCpf.Text;
                    else
                        MessageBox.Show(Config.lFied + "CPF" + Config.lRequired, Config.lAlert);

                    if (txtCep.Text != string.Empty)
                        lClient.ZipCode = txtCep.Text;
                    else
                        MessageBox.Show(Config.lFied + "CEP" + Config.lRequired, Config.lAlert);

                    lClient.Street = txtStreet.Text;
                    lClient.District = txtDistrict.Text;
                    lClient.City = txtCity.Text;
                    lClient.State = txtState.Text;
                    lClient.Telephone = txtCellphone.Text;

                    if (txtEmail.Text != string.Empty)
                        lClient.Email = txtEmail.Text;
                    else
                        MessageBox.Show(Config.lFied + "E-MAIL" + Config.lRequired, Config.lAlert);

                    if (txtStatus.Text == "Ativo" && txtStatus.Text != string.Empty)
                        lClient.Status = "A";
                    else if (txtStatus.Text != string.Empty)
                        lClient.Status = "I";
                    else
                        MessageBox.Show(Config.lFied + "STATUS" + Config.lRequired, Config.lAlert);


                    if (txtName.Text != string.Empty && txtCep.Text != string.Empty && txtEmail.Text != string.Empty
                        && txtCpf.Text != string.Empty && txtStatus.Text != string.Empty)
                    {
                        da.Add(lClient);
                        MessageBox.Show(MessageBoxResult.lSucess);
                        Clean();
                    }
                    else
                    {
                        MessageBox.Show(Config.lErrorRegister, MessageBoxResult.lError);
                    }
                }
            }
            else
            {

                MySqlConnection con = new MySqlConnection(Connection.lConnection);
                con.Open();
                string consulta = "SELECT for_cpf FROM cadastro_cliente WHERE for_cpf = @cpf";
                MySqlCommand cmd = new MySqlCommand(consulta, con);

                //Passo o parametro
                cmd.Parameters.AddWithValue("@cpf", txtCpf.Text);
                MySqlDataReader read = cmd.ExecuteReader();

                //se o cliente já estiver cadastrado
                if (read.Read())
                {
                    if (MessageBox.Show("Cliente já está cadastrado, gostaria de pesquisar o mesmo?", Config.lAlert, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        tabControl1.SelectedTab = tabPage2;
                    }
                }
                //se não estiver
                else
                {
                    Client lClient = new Client();
                    clientQuery da = new clientQuery();
                    if (txtName.Text != string.Empty)
                        lClient.Name = txtName.Text;
                    else
                        MessageBox.Show(Config.lFied + "NOME" + Config.lRequired, Config.lAlert);

                    if (txtCpf.Text != string.Empty)
                        lClient.Document = txtCpf.Text;
                    else
                        MessageBox.Show(Config.lFied + "CPF" + Config.lRequired, Config.lAlert);

                    if (txtCep.Text != string.Empty)
                        lClient.ZipCode = txtCep.Text;
                    else
                        MessageBox.Show(Config.lFied + "CEP" + Config.lRequired, Config.lAlert);

                    lClient.Street = txtStreet.Text;
                    lClient.District = txtDistrict.Text;
                    lClient.City = txtCity.Text;
                    lClient.State = txtState.Text;
                    lClient.Telephone = txtCellphone.Text;

                    if (txtEmail.Text != string.Empty)
                        lClient.Email = txtEmail.Text;
                    else
                        MessageBox.Show(Config.lFied + "E-MAIL" + Config.lRequired, Config.lAlert);

                    if (txtStatus.Text == "Ativo" && txtStatus.Text != string.Empty)
                        lClient.Status = "A";
                    else if (txtStatus.Text != string.Empty)
                        lClient.Status = "I";
                    else
                        MessageBox.Show(Config.lFied + "STATUS" + Config.lRequired, Config.lAlert);


                    if (txtName.Text != string.Empty && txtCep.Text != string.Empty && txtEmail.Text != string.Empty
                        && txtCpf.Text != string.Empty && txtStatus.Text != string.Empty)
                    {
                        da.Add(lClient);
                        MessageBox.Show(MessageBoxResult.lSucess);
                    }
                    else
                    {
                        MessageBox.Show(Config.lErrorRegister, MessageBoxResult.lError);
                    }

                    try
                    {
                        MySqlConnection conn = new MySqlConnection(Connection.lConnection);
                        conn.Open();
                        string consulta1 = "SELECT for_nome,for_email FROM cadastro_cliente WHERE for_email = @for_email";
                        MySqlCommand cmd1 = new MySqlCommand(consulta1, conn);
                        //Passo o parametro
                        cmd1.Parameters.AddWithValue("@for_email", txtEmail.Text);
                        MySqlDataReader leitor = cmd1.ExecuteReader();
                        string lEmail = string.Empty;
                        string lName = string.Empty;

                        while (leitor.Read())
                        {
                            lName = leitor["for_nome"].ToString();
                            lEmail = leitor["for_email"].ToString();
                        }
                        Email = new MailMessage();
                        Email.To.Add(new MailAddress(lEmail));
                        Email.From = (new MailAddress(Credentials.lAdress));
                        Email.Subject = "Bem Vindo a Farmalife";
                        Email.IsBodyHtml = true;
                        Email.Body = "Ceo:Giovanni Nascimento Santos <br/> FarmaLife Enterprise 2018 ® </br> <b>Parabéns! Seu cadastrado foi concluído com exito e o(a) senhor(a)" + lName + " já pode desfrutar de todos os nossos produtos. Fique atento no e-mail que estaremos sempre encaminhando descontos para agradar os nossos clientes. </b></br>Com atenção, FarmaLife</br> <i>Não responder esse e-mail</i></br>";
                        SmtpClient cliente = new SmtpClient(Credentials.lSmtpLive, Credentials.lSmtpLivePort);
                        using (cliente)
                        {
                            cliente.Credentials = new System.Net.NetworkCredential(Credentials.lAdress, Credentials.lPassword);
                            cliente.EnableSsl = true;
                            cliente.Send(Email);
                        }
                        conn.Close();
                        con.Close();
                        Clean();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao enviar email de confirmação para cliente:" + ex.Message);
                        errorQuery lerrorQuery = new errorQuery();
                        lerrorQuery.AddError(Principal.lUser, MessageBoxResult.lEmailError, ex.Message.Replace("'", ""), DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), "Cadastro Funcionario");
                    }
                }
            }
        }
        private void Pesquisar()
        {

            MySqlConnection con = new MySqlConnection(Connection.lConnection);
            con.Open();
            string op = (string)comboBox1.SelectedItem;
            switch (op)
            {
                case "Nome":
                    string pesquisa = "SELECT for_cod as Codigo, for_nome as Nome ,for_endereco as Endereco,for_cpf as CPF,for_cep as Cep,for_bairro as Bairro,for_cidade as Cidade,for_uf as UF,for_fone as Telefone," +
                       "for_email as Email FROM cadastro_cliente WHERE for_nome LIKE @value AND for_status = 'A'";
                    MySqlDataAdapter ad = new MySqlDataAdapter(pesquisa, con);
                    ad.SelectCommand.Parameters.AddWithValue("value", txtSearch.Text + "%");
                    System.Data.DataTable table = new System.Data.DataTable();
                    ad.Fill(table);
                    dataGridView1.DataSource = table;
                    con.Close();
                    break;

                case "ID":
                    string pesquisa2 = "SELECT for_cod as Codigo, for_nome as Nome ,for_endereco as Endereco,for_cpf as CPF,for_cep as Cep,for_bairro as Bairro,for_cidade as Cidade,for_uf as UF,for_fone as Telefone," +
                       "for_email as Email FROM cadastro_cliente WHERE for_cod LIKE @value AND for_status = 'A'";
                    MySqlDataAdapter ad2 = new MySqlDataAdapter(pesquisa2, con);
                    ad2.SelectCommand.Parameters.AddWithValue("value", txtSearch.Text + "%");
                    System.Data.DataTable table2 = new System.Data.DataTable();
                    ad2.Fill(table2);
                    dataGridView1.DataSource = table2;
                    con.Close();
                    break;

                case "Ativo":
                    string pesquisa3 = "SELECT for_cod as Codigo, for_nome as Nome ,for_endereco as Endereco,for_cpf as CPF,for_cep as Cep,for_bairro as Bairro,for_cidade as Cidade,for_uf as UF,for_fone as Telefone," +
                       "for_email as Email,for_status as Status FROM cadastro_cliente WHERE for_status = 'A'";
                    MySqlDataAdapter ad3 = new MySqlDataAdapter(pesquisa3, con);
                    System.Data.DataTable table3 = new System.Data.DataTable();
                    ad3.Fill(table3);
                    dataGridView1.DataSource = table3;
                    con.Close();
                    break;

                case "Inativo":
                    string pesquisa4 = "SELECT for_cod as Codigo, for_nome as Nome ,for_endereco as Endereco,for_cpf as CPF,for_cep as Cep,for_bairro as Bairro,for_cidade as Cidade,for_uf as UF,for_fone as Telefone," +
                       "for_email as Email,for_status as Status FROM cadastro_cliente WHERE for_status = 'I'";
                    MySqlDataAdapter ad4 = new MySqlDataAdapter(pesquisa4, con);
                    System.Data.DataTable table4 = new System.Data.DataTable();
                    ad4.Fill(table4);
                    dataGridView1.DataSource = table4;
                    con.Close();
                    break;

                case "Todos":
                    string pesquisa5 = "SELECT for_cod as Codigo, for_nome as Nome ,for_endereco as Endereco,for_cpf as CPF,for_cep as Cep,for_bairro as Bairro,for_cidade as Cidade,for_uf as UF,for_fone as Telefone," +
                      "for_email as Email,for_status as Status FROM cadastro_cliente";
                    MySqlDataAdapter ad5 = new MySqlDataAdapter(pesquisa5, con);
                    System.Data.DataTable table5 = new System.Data.DataTable();
                    ad5.Fill(table5);
                    dataGridView1.DataSource = table5;
                    con.Close();
                    break;
            }
        }

        // botão pesquisar
        private void btnSearch_Click(object sender, EventArgs e)
        {
            Pesquisar();
            btnExport.Enabled = true;

        }
        //botão voltar
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            Principal remedio = new Principal();
            remedio.Show();
        }
        //clicar na cell do datagrid
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string codigo;
            codigo = Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value);


            MySqlConnection cn = new MySqlConnection(Connection.lConnection);
            cn.Open();

            MySqlCommand cmd2 = new MySqlCommand("SELECT for_cod, for_nome,for_endereco,for_bairro,for_cidade,for_uf ,for_cpf," +
          "for_cep,for_fone,for_email,for_status FROM cadastro_cliente WHERE for_cod = '" + codigo + "'", cn);
            MySqlDataReader reader = null;
            reader = cmd2.ExecuteReader();

            if (reader.Read())
            {
                txtId.Text = reader.GetString(0);
                txtName.Text = reader.GetString(1);
                txtStreet.Text = reader.GetString(2);
                txtDistrict.Text = reader.GetString(3);
                txtCity.Text = reader.GetString(4);
                txtState.Text = reader.GetString(5);
                txtCpf.Text = reader.GetString(6);
                txtCep.Text = reader.GetString(7);
                txtCellphone.Text = reader.GetString(8);
                txtEmail.Text = reader.GetString(9);
                txtStatus.Text = reader.GetString(10);
                if (txtStatus.Text == "A")
                    txtStatus.Text = "Ativo";
                else
                    txtStatus.Text = "Inativo";
            }
            cn.Close();
            tabControl1.SelectedTab = tabPage1;
        }
        // voltar ao principal através da tecla esc
        private void cadastrar_cliente_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                Principal remedio = new Principal();
                remedio.Show();
            }
        }
        //pesquisar ao digitar
        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            Pesquisar();
        }

        private void cadastrar_cliente_Load(object sender, EventArgs e)
        {
            txtName.Focus();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string op = (string)comboBox1.SelectedItem;
            switch (op)
            {
                case "ID":
                    txtSearch.Enabled = true;
                    break;
                case "Nome":
                    txtSearch.Enabled = true;
                    break;
                case "Ativo":
                    txtSearch.Enabled = false;
                    txtSearch.Text = string.Empty;
                    break;
                case "Inativo":
                    txtSearch.Enabled = false;
                    txtSearch.Text = string.Empty;
                    break;
                case "Todos":
                    txtSearch.Enabled = false;
                    txtSearch.Text = string.Empty;
                    break;
            }
        }

        private void txtCep_Leave(object sender, EventArgs e)
        {
            string lZipCode = txtCep.Text.Replace("-", string.Empty);
            if (lZipCode != string.Empty && lZipCode.Length == 8)
            {
                try
                {
                    using (var ws = new WSCorreios.AtendeClienteClient())
                    {
                        var result = ws.consultaCEP(lZipCode);
                        txtState.Text = result.uf;
                        txtCity.Text = result.cidade;
                        txtDistrict.Text = result.bairro;
                        txtStreet.Text = result.end;

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    errorQuery lerrorQuery = new errorQuery();
                    lerrorQuery.AddError(Principal.lUser, Errors.lZipCodeInvalid, ex.Message.Replace("'", ""), DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), "Cadastro Cliente");
                }

            }
            else
                MessageBox.Show(Errors.lZipCodeInvalid);
        }

        private void checkBox1_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtState.ReadOnly = false;
                txtCity.ReadOnly = false;
                txtDistrict.ReadOnly = false;
                txtStreet.ReadOnly = false;
            }
            else
            {
                txtState.ReadOnly = true;
                txtCity.ReadOnly = true;
                txtDistrict.ReadOnly = true;
                txtStreet.ReadOnly = true;
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
            sfd.FileName = "Clientes_" + DateTime.Now.ToString("dd-MM-yyyy");
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
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
