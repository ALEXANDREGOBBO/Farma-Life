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
    public partial class Cadastro_Funcionario : Form
    {
        private MailMessage Email;
        Stopwatch Stop = new Stopwatch();
        public Cadastro_Funcionario()
        {
            InitializeComponent();
        }
        //botão limpar
        private void btnClean_Click(object sender, EventArgs e)
        {
            CleanMethod();
        }
        public void CleanMethod()
        {
            txtId.Text = string.Empty;
            txtName.Text = string.Empty;
            txtStreet.Text = string.Empty;
            txtDistrict.Text = string.Empty;
            txtCity.Text = string.Empty;
            txtState.Text = string.Empty;
            txtCivilState.Text = string.Empty;
            txtBirthDate.Text = string.Empty;
            txtCep.Text = string.Empty;
            txtFone.Text = string.Empty;
            txtCellphone.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtUsername.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtRole.Text = string.Empty;
            txtCPF.Text = string.Empty;
            txtStatus.SelectedItem = string.Empty;
            txtNumber.Text = string.Empty;

            txtState.ReadOnly = true;
            txtCity.ReadOnly = true;
            txtDistrict.ReadOnly = true;
            txtStreet.ReadOnly = true;
        }
        //botão cadastrar
        private void btnAdd_Click(object sender, EventArgs e)
        {
            RegisterEmploye();
        }

        public void RegisterEmploye()
        {
            Employee lEmployee = new Employee();
            employeeQuery da = new employeeQuery();

            //Verificar se é um funcionario novo ou ja existente
            if (txtId.Text != string.Empty)
            {
                lEmployee.Id = Convert.ToInt32(txtId.Text);
                if (txtName.Text != string.Empty)
                    lEmployee.Name = txtName.Text;
                else
                    MessageBox.Show(Config.lFied + "NOME" + Config.lRequired, Config.lAlert);

                if (txtCep.Text != string.Empty)
                    lEmployee.ZipCode = txtCep.Text;
                else
                    MessageBox.Show(Config.lFied + "CEP" + Config.lRequired, Config.lAlert);

                lEmployee.CivilState = txtCivilState.Text;
                lEmployee.BirthDate = txtBirthDate.Text;
                lEmployee.Telephone = txtFone.Text;
                lEmployee.Number = txtNumber.Text;
                lEmployee.State = txtState.Text;
                lEmployee.City = txtCity.Text;
                lEmployee.Street = txtStreet.Text;
                lEmployee.District = txtDistrict.Text;

                if (txtCellphone.Text != string.Empty)
                    lEmployee.CellPhone = txtCellphone.Text;
                else
                    MessageBox.Show(Config.lFied + "CELULAR" + Config.lRequired, Config.lAlert);

                if (txtEmail.Text != string.Empty)
                    lEmployee.Email = txtEmail.Text;
                else
                    MessageBox.Show(Config.lFied + "E-MAIL" + Config.lRequired, Config.lAlert);

                if (txtUsername.Text != string.Empty)
                    lEmployee.Username = txtUsername.Text;
                else
                    MessageBox.Show(Config.lFied + "LOGIN" + Config.lRequired, Config.lAlert);

                if (txtPassword.Text != string.Empty)
                    if (txtPassword.Text.Length >= 8)
                        lEmployee.Password = txtPassword.Text;
                    else
                        MessageBox.Show("A senha deve conter pelo menos 8 caracteres", Config.lAlert);
                else
                    MessageBox.Show(Config.lFied + "SENHA" + Config.lRequired, Config.lAlert);

                if (txtRole.Text != string.Empty)
                    lEmployee.Role = txtRole.Text;
                else
                    MessageBox.Show(Config.lFied + "CARGO" + Config.lRequired, Config.lAlert);

                if (txtCPF.Text != string.Empty)
                    lEmployee.Document = txtCPF.Text;
                else
                    MessageBox.Show(Config.lFied + "CPF" + Config.lRequired, Config.lAlert);

                if (txtStatus.Text == "Ativo" && txtStatus.Text != string.Empty)
                    lEmployee.Status = "A";
                else if (txtStatus.Text != string.Empty)
                    lEmployee.Status = "I";
                else
                    MessageBox.Show(Config.lFied + "STATUS" + Config.lRequired, Config.lAlert);


                if (txtName.Text != string.Empty && txtStreet.Text != string.Empty && txtCity.Text != string.Empty && txtState.Text != string.Empty
                    && txtCellphone.Text != string.Empty && txtEmail.Text != string.Empty && txtUsername.Text != string.Empty && txtPassword.Text != string.Empty
                    && txtRole.Text != string.Empty && txtCPF.Text != string.Empty && txtStatus.Text != string.Empty && txtPassword.Text.Length >= 8)
                {
                    da.Update(lEmployee);
                    MessageBox.Show(MessageBoxResult.lUpdate);
                    CleanMethod();
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
                string consulta = "SELECT empUsername,empDocument, empEmail FROM employee WHERE empDocument = @CPF OR empUsername = @LOGIN OR empEmail = @EMAIL";
                MySqlCommand cmd = new MySqlCommand(consulta, con);

                //Passo o parametro
                cmd.Parameters.Add("@CPF", MySqlDbType.VarChar).Value = txtCPF.Text;
                cmd.Parameters.Add("@LOGIN", MySqlDbType.VarChar).Value = txtUsername.Text;
                cmd.Parameters.Add("@EMAIL", MySqlDbType.VarChar).Value = txtEmail.Text;

                MySqlDataReader le = null;
                le = cmd.ExecuteReader();

                //se o usuario já estiver cadastrado
                if (le.Read())
                {
                    if (MessageBox.Show("Este usuario já está cadastrado, gostaria de pesquisar o mesmo?", Config.lAlert, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        tabControl1.SelectedTab = tabPage2;
                    }
                }
                //se não estiver
                else
                {

                    if (txtName.Text != string.Empty)
                        lEmployee.Name = txtName.Text;
                    else
                        MessageBox.Show(Config.lFied + "NOME" + Config.lRequired, Config.lAlert);

                    if (txtCep.Text != string.Empty)
                        lEmployee.ZipCode = txtCep.Text;
                    else
                        MessageBox.Show(Config.lFied + "CEP" + Config.lRequired, Config.lAlert);

                    lEmployee.State = txtState.Text;
                    lEmployee.City = txtCity.Text;
                    lEmployee.Street = txtStreet.Text;
                    lEmployee.District = txtDistrict.Text;

                    lEmployee.CivilState = txtCivilState.Text;
                    lEmployee.BirthDate = txtBirthDate.Text;
                    lEmployee.Telephone = txtFone.Text;
                    lEmployee.Number = txtNumber.Text;

                    if (txtCellphone.Text != string.Empty)
                        lEmployee.CellPhone = txtCellphone.Text;
                    else
                        MessageBox.Show(Config.lFied + "CELULAR" + Config.lRequired, Config.lAlert);

                    if (txtEmail.Text != string.Empty)
                        lEmployee.Email = txtEmail.Text;
                    else
                        MessageBox.Show(Config.lFied + "E-MAIL" + Config.lRequired, Config.lAlert);

                    if (txtUsername.Text != string.Empty)
                        lEmployee.Username = txtUsername.Text;
                    else
                        MessageBox.Show(Config.lFied + "LOGIN" + Config.lRequired, Config.lAlert);

                    if (txtPassword.Text != string.Empty)
                        if (txtPassword.Text.Length >= 8)
                            lEmployee.Password = txtPassword.Text;
                        else
                            MessageBox.Show("A senha deve conter pelo menos 8 caracteres", Config.lAlert);
                    else
                        MessageBox.Show(Config.lFied + "SENHA" + Config.lRequired, Config.lAlert);

                    if (txtRole.Text != string.Empty)
                        lEmployee.Role = txtRole.Text;
                    else
                        MessageBox.Show(Config.lFied + "CARGO" + Config.lRequired, Config.lAlert);

                    if (txtCPF.Text != string.Empty)
                        lEmployee.Document = txtCPF.Text;
                    else
                        MessageBox.Show(Config.lFied + "CPF" + Config.lRequired, Config.lAlert);

                    if (txtStatus.Text == "Ativo" && txtStatus.Text != string.Empty)
                        lEmployee.Status = "A";
                    else if (txtStatus.Text != string.Empty)
                        lEmployee.Status = "I";
                    else
                        MessageBox.Show(Config.lFied + "STATUS" + Config.lRequired, Config.lAlert);

                    if (txtName.Text != string.Empty && txtStreet.Text != string.Empty && txtCity.Text != string.Empty && txtState.Text != string.Empty
                        && txtCellphone.Text != string.Empty && txtEmail.Text != string.Empty && txtUsername.Text != string.Empty && txtPassword.Text != string.Empty
                        && txtRole.Text != string.Empty && txtCPF.Text != string.Empty && txtStatus.Text != string.Empty && txtPassword.Text.Length >= 8)
                    {
                        da.Add(lEmployee);
                        MessageBox.Show(MessageBoxResult.lSucess);
                        CleanMethod();
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
                string consulta = "SELECT empUsername,empDocument, empEmail FROM employee WHERE empDocument = @CPF OR empUsername = @LOGIN OR empEmail = @EMAIL";
                MySqlCommand cmd = new MySqlCommand(consulta, con);

                //Passo o parametro
                cmd.Parameters.Add("@CPF", MySqlDbType.VarChar).Value = txtCPF.Text;
                cmd.Parameters.Add("@LOGIN", MySqlDbType.VarChar).Value = txtUsername.Text;
                cmd.Parameters.Add("@EMAIL", MySqlDbType.VarChar).Value = txtEmail.Text;

                MySqlDataReader le = null;
                le = cmd.ExecuteReader();


                //se o usuario já estiver cadastrado
                if (le.Read())
                {
                    if (MessageBox.Show("Este usuario já está cadastrado, gostaria de pesquisar o mesmo?", Config.lAlert, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        tabControl1.SelectedTab = tabPage2;
                    }
                }
                else
                {
                    if (txtName.Text != string.Empty)
                        lEmployee.Name = txtName.Text;
                    else
                        MessageBox.Show(Config.lFied + "NOME" + Config.lRequired, Config.lAlert);

                    lEmployee.State = txtState.Text;
                    lEmployee.City = txtCity.Text;
                    lEmployee.Street = txtStreet.Text;
                    lEmployee.District = txtDistrict.Text;

                    lEmployee.CivilState = txtCivilState.Text;
                    lEmployee.BirthDate = txtBirthDate.Text;
                    lEmployee.Telephone = txtFone.Text;
                    lEmployee.Number = txtNumber.Text;

                    if (txtCellphone.Text != string.Empty)
                        lEmployee.CellPhone = txtCellphone.Text;
                    else
                        MessageBox.Show(Config.lFied + "CELULAR" + Config.lRequired, Config.lAlert);

                    if (txtEmail.Text != string.Empty)
                        lEmployee.Email = txtEmail.Text;
                    else
                        MessageBox.Show(Config.lFied + "E-MAIL" + Config.lRequired, Config.lAlert);

                    if (txtUsername.Text != string.Empty)
                        lEmployee.Username = txtUsername.Text;
                    else
                        MessageBox.Show(Config.lFied + "LOGIN" + Config.lRequired, Config.lAlert);

                    if (txtPassword.Text != string.Empty)
                        if (txtPassword.Text.Length >= 8)
                            lEmployee.Password = txtPassword.Text;
                        else
                            MessageBox.Show("A senha deve conter pelo menos 8 caracteres", Config.lAlert);
                    else
                        MessageBox.Show(Config.lFied + "SENHA" + Config.lRequired, Config.lAlert);

                    if (txtRole.Text != string.Empty)
                        lEmployee.Role = txtRole.Text;
                    else
                        MessageBox.Show(Config.lFied + "CARGO" + Config.lRequired, Config.lAlert);

                    if (txtCPF.Text != string.Empty)
                        lEmployee.Document = txtCPF.Text;
                    else
                        MessageBox.Show(Config.lFied + "CPF" + Config.lRequired, Config.lAlert);

                    if (txtStatus.Text == "Ativo" && txtStatus.Text != string.Empty)
                        lEmployee.Status = "A";
                    else if (txtStatus.Text != string.Empty)
                        lEmployee.Status = "I";
                    else
                        MessageBox.Show(Config.lFied + "STATUS" + Config.lRequired, Config.lAlert);

                    if (txtName.Text != string.Empty && txtCep.Text != string.Empty && txtStreet.Text != string.Empty && txtCity.Text != string.Empty && txtState.Text != string.Empty
                        && txtCellphone.Text != string.Empty && txtEmail.Text != string.Empty && txtUsername.Text != string.Empty && txtPassword.Text != string.Empty
                        && txtRole.Text != string.Empty && txtCPF.Text != string.Empty && txtStatus.Text != string.Empty && txtPassword.Text.Length >= 8)
                    {
                        da.Add(lEmployee);
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
                        string consulta1 = "SELECT empName,empEmail FROM employee WHERE empEmail = @empEmail";
                        MySqlCommand cmd1 = new MySqlCommand(consulta1, conn);
                        //Passo o parametro
                        cmd1.Parameters.AddWithValue("@empEmail", txtEmail.Text);
                        MySqlDataReader reader = cmd1.ExecuteReader();
                        string lEmail = string.Empty;
                        string lName = string.Empty;
                        while (reader.Read())
                        {
                            lName = reader["empName"].ToString();
                            lEmail = reader["empEmail"].ToString();
                        }
                        Email = new MailMessage();
                        Email.To.Add(new MailAddress(lEmail));
                        Email.From = (new MailAddress(Credentials.lAdress));
                        Email.Subject = "Bem Vindo a Farmalife";
                        Email.IsBodyHtml = true;
                        Email.Body = "Ceo:Giovanni Nascimento Santos <br/> FarmaLife Enterprise 2018 ® </br> <b>Bem vindo a nossa equipe senhor(a)," + lName + " seu cadastro foi concluído perfeitamente e o senhor(a) já pode utilizar nosso sistema.</br> </b> </br> <i> Não responder esse e-mail</i></br>";
                        SmtpClient employee = new SmtpClient(Credentials.lSmtpLive, Credentials.lSmtpLivePort);
                        using (employee)
                        {
                            employee.Credentials = new System.Net.NetworkCredential(Credentials.lAdress, Credentials.lPassword);
                            employee.EnableSsl = true;
                            employee.Send(Email);
                        }
                        conn.Close();
                        CleanMethod();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, MessageBoxResult.lEmailError);
                        errorQuery lerrorQuery = new errorQuery();
                        lerrorQuery.AddError(Principal.lUser, MessageBoxResult.lEmailError, ex.Message.Replace("'", ""), DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), "Cadastro Funcionario");
                    }
                }
            }
        }
        //botão pesquisar
        private void Search()
        {
            MySqlConnection con = new MySqlConnection(Connection.lConnection);
            con.Open();
            string op = (string)comboBox1.SelectedItem;
            switch (op)
            {
                case "ID":
                    txtSearch.Enabled = true;
                    string pesquisa = employeeQuery.GetEmployeById;
                    MySqlDataAdapter ad = new MySqlDataAdapter(pesquisa, con);
                    ad.SelectCommand.Parameters.AddWithValue("value", txtSearch.Text + "%");
                    System.Data.DataTable table = new System.Data.DataTable();
                    ad.Fill(table);
                    dataGridView.DataSource = table;
                    con.Close();
                    break;
                case "Nome":
                    txtSearch.Enabled = true;
                    string pesquisa2 = employeeQuery.GetEmployeByName;
                    MySqlDataAdapter ad1 = new MySqlDataAdapter(pesquisa2, con);
                    ad1.SelectCommand.Parameters.AddWithValue("value", txtSearch.Text + "%");
                    System.Data.DataTable table1 = new System.Data.DataTable();
                    ad1.Fill(table1);
                    dataGridView.DataSource = table1;
                    con.Close();
                    break;

                case "Ativo":
                    txtSearch.Enabled = false;
                    string pesquisa3 = employeeQuery.GetActiveEmployee;
                    MySqlDataAdapter ad3 = new MySqlDataAdapter(pesquisa3, con);
                    System.Data.DataTable table3 = new System.Data.DataTable();
                    ad3.Fill(table3);
                    dataGridView.DataSource = table3;
                    con.Close();
                    break;

                case "Inativo":
                    txtSearch.Enabled = false;
                    string pesquisa4 = employeeQuery.GetInativeEmployee;
                    MySqlDataAdapter ad4 = new MySqlDataAdapter(pesquisa4, con);
                    System.Data.DataTable table4 = new System.Data.DataTable();
                    ad4.Fill(table4);
                    dataGridView.DataSource = table4;
                    con.Close();
                    break;

                case "Todos":
                    txtSearch.Enabled = false;
                    string pesquisa5 = employeeQuery.GetAllEmployees;
                    MySqlDataAdapter ad5 = new MySqlDataAdapter(pesquisa5, con);
                    System.Data.DataTable table5 = new System.Data.DataTable();
                    ad5.Fill(table5);
                    dataGridView.DataSource = table5;
                    con.Close();
                    break;
            }
        }
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
        // ir para alterar dados 
        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string codigo;
            codigo = Convert.ToString(dataGridView.CurrentRow.Cells[0].Value);


            MySqlConnection cn = new MySqlConnection(Connection.lConnection);
            cn.Open();

            MySqlCommand cmd2 = new MySqlCommand("SELECT empId, empName,empStreet,empDistrict, empCity,empRegionState ,empMarriageStatus,empBirthDate," +
           "empZipCode,empFixedTelephone,empCellphone,empEmail,empUsername,empPassword,empRole,empDocument,empStatus, empNumber FROM employee WHERE empId= '" + codigo + "'", cn);
            MySqlDataReader reader = null;
            reader = cmd2.ExecuteReader();

            while (reader.Read())
            {
                txtId.Text = reader.GetString(0);
                txtName.Text = reader.GetString(1);
                txtStreet.Text = reader.GetString(2);
                txtDistrict.Text = reader.GetString(3);
                txtCity.Text = reader.GetString(4);
                txtState.Text = reader.GetString(5);
                txtCivilState.Text = reader.GetString(6);
                txtBirthDate.Text = reader.GetString(7);
                txtCep.Text = reader.GetString(8);
                txtFone.Text = reader.GetString(9);
                txtCellphone.Text = reader.GetString(10);
                txtEmail.Text = reader.GetString(11);
                txtUsername.Text = reader.GetString(12);
                txtPassword.Text = reader.GetString(13);
                txtRole.Text = reader.GetString(14);
                txtCPF.Text = reader.GetString(15);
                txtStatus.Text = reader.GetString(16);
                txtNumber.Text = reader.GetString(17);
                if (txtStatus.Text == "A")
                    txtStatus.Text = "Ativo";
                else
                    txtStatus.Text = "Inativo";
            }
            cn.Close();
            tabControl1.SelectedTab = tabPage1;
        }
        // voltar ao principal através da tecla esc
        private void Cadastro_Funcionario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
                Principal remedio = new Principal();
                remedio.Show();
            }
        }
        //pesquisar com enter
        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            Search();
        }

        private void Cadastro_Funcionario_Load(object sender, EventArgs e)
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
                    lerrorQuery.AddError(Principal.lUser, Errors.lZipCodeInvalid, ex.Message.Replace("'", ""), DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), "Cadastro Funcionario");
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
            sfd.FileName = "Funcionarios_" + DateTime.Now.ToString("dd-MM-yyyy");
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

        private void txtPassword_Leave(object sender, EventArgs e)
        {

        }
    }
}












