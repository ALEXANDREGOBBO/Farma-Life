using System;
using System.Net.Mail;
using System.Windows.Forms;
using System.Diagnostics;
using MySql.Data.MySqlClient;

namespace cadastro_remedios
{
    public partial class EsqueceuSenha : Form
    {
        private MailMessage Email;
        Stopwatch Stop = new Stopwatch();
        public EsqueceuSenha()
        {
            InitializeComponent();
        }

        //Cliente cliente = new Cliente();
        
        private void button1_Click(object sender, EventArgs e)
        {
            
            MySqlConnection con = new MySqlConnection(Connection.lConnection);
            con.Open();

            string consulta = "SELECT empUsername,empPassword,empName FROM employee WHERE empDocument = @cpf";
            MySqlCommand cmd = new MySqlCommand(consulta, con);
            //Passo o parametro
            cmd.Parameters.AddWithValue("@cpf", txtCpf.Text);
            MySqlDataReader leitor = cmd.ExecuteReader();
            string lSenha = string.Empty;
            string lLogin = string.Empty;
            string lNome = string.Empty;


            while (leitor.Read())
            {
                //passo os valores para o objeto cliente 
                //que será retornado 

                lSenha = leitor["empPassword"].ToString();
                lLogin = leitor["empUsername"].ToString();
                lNome = leitor["empName"].ToString();
            }
            try
            {
                Email = new MailMessage();
                Email.To.Add(new MailAddress(txtEmail.Text));
                Email.From = (new MailAddress(Credentials.lAdress));
                Email.Subject = "Suas Informações de Login como solicitado.";
                Email.IsBodyHtml = true;
                Email.Body = "Ceo:Giovanni Nascimento Santos <br/> FarmaLife Enterprise 2018 ® </br> <b>Aqui estão seus dados senhor(a) </br>" + lNome + "</b> </br> <i> Não responder esse e-mail</i></br> Login: " + lLogin + " </br> Senha : " + lSenha;
                SmtpClient cliente = new SmtpClient(Credentials.lSmtpLive, Credentials.lSmtpLivePort);
                using (cliente)
                {
                    cliente.Credentials = new System.Net.NetworkCredential(Credentials.lAdress, Credentials.lPassword);
                    cliente.EnableSsl = true;
                    cliente.Send(Email);
                }
                MessageBox.Show("E-mail enviado com sucesso, apenas aguarde alguns segundos", "E-mail enviado");
                this.Close();
                Login login = new Login();
                login.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(MessageBoxResult.lEmailError);
                errorQuery lerrorQuery = new errorQuery();
                MessageBox.Show(MessageBoxResult.lEmailError, Config.lAlert);
                lerrorQuery.AddError(Principal.lUser, MessageBoxResult.lEmailError, ex.Message.Replace("'", ""), DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), "Esqueceu Email");

            }
        }

        private void EsqueceuSenha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (MessageBox.Show("Deseja voltar ao login?", Config.lAlert, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.Close();
                    Login login = new Login();
                    login.Show();
                }

            }
        }
        private void EsqueceuSenha_Load(object sender, EventArgs e)
        {
            txtEmail.Focus();
        }
    }
}

        
        
            
                
           
    
        

    


