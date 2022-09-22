using System;
using System.Net.Mail;
using System.Windows.Forms;
using System.Diagnostics;
using MySql.Data.MySqlClient;
using System.Data;

namespace cadastro_remedios
{
    public partial class email : Form
    {
        private MailMessage Email;
        Stopwatch Stop = new Stopwatch();
        public email()
        {
            InitializeComponent();
            MessageBox.Show("Antes de prosseguir, leia a informação legal!", Config.lAlert);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Principal principal = new Principal();
            principal.Show();
        }

        private void email_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                Principal remedio = new Principal();
                remedio.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            email email = new email();
            email.Show();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {

            string op = (string)comboBox1.SelectedItem;
            switch (op)
            {
                case "Outlook":
                    try
                    {
                        Email = new MailMessage();
                        Email.To.Add(new MailAddress(txtPara.Text));
                        Email.From = (new MailAddress(txtDe.Text));
                        Email.Subject = txtAssunto.Text;
                        Email.IsBodyHtml = true;
                        Email.Body = txtMensagem.Text;
                        SmtpClient cliente = new SmtpClient(Credentials.lSmtpLive, Credentials.lSmtpLivePort);
                        using (cliente)
                        {
                            cliente.Credentials = new System.Net.NetworkCredential(txtDe.Text, txtPassword.Text);
                            cliente.EnableSsl = true;
                            cliente.Send(Email);
                        }
                        MessageBox.Show("E-mail enviado com sucesso, apenas aguarde alguns segundos", "E-mail enviado");
                        this.Close();
                        email email = new email();
                        email.Show();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(MessageBoxResult.lEmailError, ex.Message);
                        errorQuery lerrorQuery = new errorQuery();
                        MessageBox.Show(MessageBoxResult.lEmailError, Config.lAlert);
                        lerrorQuery.AddError(Principal.lUser, MessageBoxResult.lEmailError, ex.Message.Replace("'", ""), DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), "Venda");
                    }
                    break;

                case "Gmail":
                    try
                    {
                        Email = new MailMessage();
                        Email.To.Add(new MailAddress(txtPara.Text));
                        Email.From = (new MailAddress(txtDe.Text));
                        Email.Subject = txtAssunto.Text;
                        Email.IsBodyHtml = true;
                        Email.Body = txtMensagem.Text;
                        SmtpClient cliente1 = new SmtpClient(Credentials.lSmtpGmail, Credentials.lSmtpLivePort);
                        using (cliente1)
                        {
                            cliente1.Credentials = new System.Net.NetworkCredential(txtDe.Text, txtPassword.Text);
                            cliente1.EnableSsl = true;
                            cliente1.Send(Email);
                        }
                        MessageBox.Show("E-mail enviado com sucesso, apenas aguarde alguns segundos", "E-mail enviado");
                        this.Close();
                        email email1 = new email();
                        email1.Show();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(MessageBoxResult.lEmailError, ex.Message);
                        errorQuery lerrorQuery = new errorQuery();
                        MessageBox.Show(MessageBoxResult.lEmailError, Config.lAlert);
                        lerrorQuery.AddError(Principal.lUser, MessageBoxResult.lEmailError, ex.Message.Replace("'", ""), DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), "Venda");
                    }
                    break;
            }
        }




        private void label6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("A FarmaLife não armazena a senha do seu e-mail, apenas utiliza e o mesmo é descartável após o uso. Se desejar poderá ficar a vontade para olhar o código fonte do sistema. A invasão de dispositivo informático é crime de acordo com a lei (CP, art. 154-A)");
        }

        private void label7_Click(object sender, EventArgs e)
        {
            MessageBox.Show("O html é permitido, então sinta-se a vontade para utilizar as tags que bem entender, tais como: <br> <b> <i>... entre outras, use a criatividade :D");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label6.Visible = false;
            label7.Visible = false;
            button4.Visible = true;
            btnEnviar.Visible = false;
            button1.Visible = false;
            button3.Visible = false;
            dataGridView1.Visible = true;
            button2.Visible = false;

            MySqlConnection con = new MySqlConnection(Connection.lConnection);
            con.Open();
            string pesquisa = "SELECT empName as Nome,empCity as Cidade,empRole as Cargo,empEmail as 'E-mail do Funcionario' FROM employee WHERE empStatus = 'A'";
            MySqlDataAdapter ad = new MySqlDataAdapter(pesquisa, con);
            System.Data.DataTable table = new System.Data.DataTable ();
            ad.Fill(table);
            dataGridView1.DataSource = table;

            con.Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            label6.Visible = true;
            label7.Visible = true;
            button4.Visible = false;
            btnEnviar.Visible = true;
            button1.Visible = true;
            button3.Visible = true;
            dataGridView1.Visible = false;
            button2.Visible = true;
        }
    }
}
