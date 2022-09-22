using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace cadastro_remedios
{

    public partial class AtualizarEstoque : Form
    {
        
        public AtualizarEstoque()
        {
            InitializeComponent();
        }

     

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            Product lProduct= new Product();
            MySqlConnection cn3 = new MySqlConnection(Connection.lConnection);
            MySqlCommand cmd3 = new MySqlCommand("SELECT pro_quantidade_no_estoque FROM cadastro_remedios WHERE pro_codigo = '" + txtId + "'", cn3);
            cn3.Open();
            MySqlDataReader reader3 = cmd3.ExecuteReader();

            if (reader3.Read())
            {
                string resultado = reader3.GetString(0);              
            }

            try
            {
                MySqlConnection connection = new MySqlConnection(Connection.lConnection);
                connection.Open();

                string update = "UPDATE cadastro_remedios SET pro_quantidade_no_estoque =  '" + txtQuantidade.Text + "' WHERE pro_codigo = '" + txtId.Text + "';";

                MySqlCommand command = new MySqlCommand(update, connection);
                MySqlDataReader myreader;
                myreader = command.ExecuteReader();

                    MessageBox.Show("Estoque Atualizado", Config.lAlert);
                    this.txtId.Text = string.Empty;
                    this.txtQuantidade.Text = string.Empty;
                    this.txtName.Text = string.Empty;
                    this.txtSearch.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(MessageBoxResult.lErrorCommand +ex.Message);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            
            MySqlConnection con = new MySqlConnection(Connection.lConnection);
            con.Open();
            string consulta = "SELECT pro_codigo,pro_nome_comercial,pro_quantidade_no_estoque FROM cadastro_remedios WHERE pro_codigo =  @codigo OR pro_nome_comercial =  @codigo ";
            MySqlCommand cmd = new MySqlCommand(consulta, con);
            //Passo o parametro
            cmd.Parameters.AddWithValue("@codigo", txtSearch.Text);
            MySqlDataReader leitor = cmd.ExecuteReader();

            while (leitor.Read())
            {
                txtId.Text = leitor["pro_codigo"].ToString();
                txtQuantidade.Text = leitor["pro_quantidade_no_estoque"].ToString();
                txtName.Text = leitor["pro_nome_comercial"].ToString();
            }
            con.Close();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            Principal remedio = new Principal();
            remedio.Show();
        }

        private void AtualizarEstoque_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {

                this.Close();
                Principal remedio = new Principal();
                remedio.Show();

            }
        }

        private void AtualizarEstoque_Load(object sender, EventArgs e)
        {
            txtSearch.Focus();
        }

        private void txtQuantidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Config.lEnterValue)
            {
                btnAlterar.Focus();
            }
            
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Config.lEnterValue)
            {
                txtQuantidade.Focus();
            }
           
        }
    }
}
    

        
    
