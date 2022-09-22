using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace cadastro_remedios

{
    public partial class Login : Form
    {


        public Login()
        {
            InitializeComponent();
        }

        public static string lRole, lType, lUser, lStatus;


        // hierarquia dos roles
        private void btnEnter_Click(object sender, EventArgs e)
        {
            loginVerify();
        }

        //tecla enter
        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Config.lEnterValue)
            {
                txtPassword.Focus();
            }
        }
        private void loginVerify()
        {
            MySqlConnection cn = new MySqlConnection(Connection.lConnection);
            MySqlCommand cmd = new MySqlCommand("SELECT empUsername,empEmail,empPassword,empRole,empId,empStatus FROM employee WHERE empUsername =?user AND empPassword =?pass OR empEmail =?user AND empPassword =?pass", cn);
            cmd.Parameters.Add("?user", MySqlDbType.VarChar).Value = txtUsername.Text;
            cmd.Parameters.Add("?pass", MySqlDbType.VarChar).Value = txtPassword.Text;
            cn.Open();
            MySqlDataReader le = null;
            le = cmd.ExecuteReader();
            if (le.Read())
            {
                lRole = le.GetString(3);
                Principal.lUser = int.Parse(le.GetString(4));
                lStatus = le.GetString(5);

                if (lStatus == "A")
                {

                    if (lRole == "Gerente")
                    {
                        lType = "1";
                    }
                    if (lRole == "Farmacêutico")
                    {
                        lType = "2";
                    }
                    if (lRole == "Caixa")
                    {
                        lType = "3";
                    }
                    this.Hide();
                    Principal menu = new Principal();
                    menu.Show();
                }
                else if (lStatus == "I")
                {
                    MessageBox.Show("Usuário Inativo, contate o adminstrador do sistema.",Config.lAlert);
                }
                else
                {
                    MessageBox.Show(MessageBoxResult.lErrorCommand, Config.lAlert);
                }
            }
            else if (txtPassword.Text == Credentials.lAdminPassword && txtUsername.Text == Credentials.lAdminUsername)
            {
                lType = "0";
                this.Hide();
                Principal menu = new Principal();
                menu.Show();
            }
            else
            {
                MessageBox.Show("Falha no Login, Usuario e/ou senha incorreto(s)");
                this.txtPassword.Text = null;
            }
        }

        // hierarquia dos roles
        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Config.lEnterValue)
            {
                loginVerify();
            }
        }
        // sair 
        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja Sair?", Config.lAlert, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            EsqueceuSenha senha = new EsqueceuSenha();
            senha.Show();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            txtUsername.Focus();
        }

        //usuario tela
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            PesquisaCliente pesquisa = new PesquisaCliente();
            pesquisa.ShowDialog();
        }
    }
}






