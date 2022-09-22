using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace cadastro_remedios
{
    public partial class ApagarDB : Form
    {
        public static string lTable, lPassword;
        MySqlConnection con = new MySqlConnection(Connection.lConnection);
        public ApagarDB()
        {
            InitializeComponent();
        }

        private void btnApagar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente limpar os registros de '" + lTable + "'?", Config.lAlert, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (MessageBox.Show("DESEJA REALMENTE REALIZAR ESSA AÇÃO?", Config.lAlert, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    panel1.Visible = true;
                    txtPassword.Visible = true;
                    btnConfirm.Visible = true;
                    label1.Visible = true;

                }
            }
        }

        public void CleanRows()
        {
            bool lVerify;
            lVerify = VerifyPassword();
            if (lVerify == true)
            { 
                switch (lTable)
                {
                    case "Cliente":
                        try
                        {
                            con.Open();
                            string deletar = "DELETE FROM cadastro_cliente";
                            MySqlCommand cmd = new MySqlCommand(deletar, con);
                            MySqlDataReader myreader;
                            myreader = cmd.ExecuteReader();
                            MessageBox.Show(Config.lDelete, Config.lAlert);
                            con.Close();
                            dataGridView1.Columns.Clear();
                            dataGridView1.Refresh();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(MessageBoxResult.lDeleteError + ex.Message);
                            errorQuery lerrorQuery = new errorQuery();
                            lerrorQuery.AddError(Principal.lUser, MessageBoxResult.lDeleteError, ex.Message.Replace("'", ""), DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), "ApagarDB");
                            con.Close();
                        }
                        break;

                    case "Produto":
                        try
                        {
                            con.Open();
                            string deletar = "DELETE FROM cadastro_remedios";
                            MySqlCommand cmd = new MySqlCommand(deletar, con);
                            MySqlDataReader myreader;
                            myreader = cmd.ExecuteReader();
                            MessageBox.Show(Config.lDelete, Config.lAlert);
                            con.Close();
                            dataGridView1.Columns.Clear();
                            dataGridView1.Refresh();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(MessageBoxResult.lDeleteError + ex.Message);
                            errorQuery lerrorQuery = new errorQuery();
                            lerrorQuery.AddError(Principal.lUser, MessageBoxResult.lDeleteError, ex.Message.Replace("'", ""), DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), "ApagarDB");
                            con.Close();
                        }
                        break;

                    case "Venda":
                        try
                        {
                            con.Open();
                            string deletar = "DELETE FROM venda";
                            MySqlCommand cmd = new MySqlCommand(deletar, con);
                            MySqlDataReader myreader;
                            myreader = cmd.ExecuteReader();
                            MessageBox.Show(Config.lDelete, Config.lAlert);
                            con.Close();
                            dataGridView1.Columns.Clear();
                            dataGridView1.Refresh();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(MessageBoxResult.lDeleteError + ex.Message);
                            errorQuery lerrorQuery = new errorQuery();
                            lerrorQuery.AddError(Principal.lUser, MessageBoxResult.lDeleteError, ex.Message.Replace("'", ""), DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), "ApagarDB");
                            con.Close();
                        }
                        break;

                    case "Item Venda":
                        try
                        {
                            con.Open();
                            string deletar = "DELETE FROM item_venda";
                            MySqlCommand cmd = new MySqlCommand(deletar, con);
                            MySqlDataReader myreader;
                            myreader = cmd.ExecuteReader();
                            MessageBox.Show(Config.lDelete, Config.lAlert);
                            con.Close();
                            dataGridView1.Columns.Clear();
                            dataGridView1.Refresh();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(MessageBoxResult.lDeleteError + ex.Message);
                            errorQuery lerrorQuery = new errorQuery();
                            lerrorQuery.AddError(Principal.lUser, MessageBoxResult.lDeleteError, ex.Message.Replace("'", ""), DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), "ApagarDB");
                            con.Close();
                        }
                        break;

                    case "Funcionario":
                        try
                        {
                            con.Open();
                            string deletar = "DELETE FROM employee";
                            MySqlCommand cmd = new MySqlCommand(deletar, con);
                            MySqlDataReader myreader;
                            myreader = cmd.ExecuteReader();
                            MessageBox.Show(Config.lDelete, Config.lAlert);
                            con.Close();
                            dataGridView1.Columns.Clear();
                            dataGridView1.Refresh();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(MessageBoxResult.lDeleteError + ex.Message);
                            errorQuery lerrorQuery = new errorQuery();
                            lerrorQuery.AddError(Principal.lUser, MessageBoxResult.lDeleteError, ex.Message.Replace("'", ""), DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), "ApagarDB");
                            con.Close();
                        }
                        break;

                    case "Erros":
                        try
                        {
                            con.Open();
                            string deletar = "DELETE FROM systemerrors";
                            MySqlCommand cmd = new MySqlCommand(deletar, con);
                            MySqlDataReader myreader;
                            myreader = cmd.ExecuteReader();
                            MessageBox.Show(Config.lDelete, Config.lAlert);
                            con.Close();
                            dataGridView1.Columns.Clear();
                            dataGridView1.Refresh();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(MessageBoxResult.lDeleteError + ex.Message);
                            errorQuery lerrorQuery = new errorQuery();
                            lerrorQuery.AddError(Principal.lUser, MessageBoxResult.lDeleteError, ex.Message.Replace("'", ""), DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), "ApagarDB");
                            con.Close();
                        }
                        break;
                }
                panel1.Visible = false;
                txtPassword.Visible = false;
                btnConfirm.Visible = false;
                label1.Visible = false;
                txtPassword.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("Senha Incorreta", Config.lAlert);
                panel1.Visible = false;
                txtPassword.Visible = false;
                btnConfirm.Visible = false;
                label1.Visible = false;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            Principal principal = new Principal();
            principal.Show();
        }

        private void ApagarDB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                Principal remedio = new Principal();
                remedio.Show();
            }
        }
        private void btnSelect_Click(object sender, EventArgs e)
        {
            lTable = sender.ToString().Replace("System.Windows.Forms.Button, Text: ", "");
            con.Open();
            string pesquisa = "SELECT * FROM cadastro_cliente";
            MySqlDataAdapter ad = new MySqlDataAdapter(pesquisa, con);
            System.Data.DataTable table = new System.Data.DataTable();
            ad.Fill(table);
            dataGridView1.DataSource = table;
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            lTable = sender.ToString().Replace("System.Windows.Forms.Button, Text: ", "");
            con.Open();
            string pesquisa = "SELECT * FROM cadastro_remedios";
            MySqlDataAdapter ad = new MySqlDataAdapter(pesquisa, con);
            System.Data.DataTable table = new System.Data.DataTable();
            ad.Fill(table);
            dataGridView1.DataSource = table;
            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            lTable = sender.ToString().Replace("System.Windows.Forms.Button, Text: ", "");
            con.Open();
            string pesquisa = "SELECT * FROM item_venda";
            MySqlDataAdapter ad = new MySqlDataAdapter(pesquisa, con);
            System.Data.DataTable table = new System.Data.DataTable();
            ad.Fill(table);
            dataGridView1.DataSource = table;
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lTable = sender.ToString().Replace("System.Windows.Forms.Button, Text: ", "");
            con.Open();
            string pesquisa = "SELECT * FROM employee";
            MySqlDataAdapter ad = new MySqlDataAdapter(pesquisa, con);
            System.Data.DataTable table = new System.Data.DataTable();
            ad.Fill(table);
            dataGridView1.DataSource = table;
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            lTable = sender.ToString().Replace("System.Windows.Forms.Button, Text: ", "");
            con.Open();
            string pesquisa = "SELECT * FROM venda";
            MySqlDataAdapter ad = new MySqlDataAdapter(pesquisa, con);
            System.Data.DataTable table = new System.Data.DataTable();
            ad.Fill(table);
            dataGridView1.DataSource = table;
            con.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            lTable = sender.ToString().Replace("System.Windows.Forms.Button, Text: ", "");
            con.Open();
            string pesquisa = "SELECT * FROM systemerrors";
            MySqlDataAdapter ad = new MySqlDataAdapter(pesquisa, con);
            System.Data.DataTable table = new System.Data.DataTable();
            ad.Fill(table);
            dataGridView1.DataSource = table;
            con.Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            lPassword = txtPassword.Text;
            CleanRows();
        }

        public bool VerifyPassword()
        {
            if (lPassword == Credentials.lAdminPassword)
            {
                return true;
            }
            else
                return false;
        }
    }
}
