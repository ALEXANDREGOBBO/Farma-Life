using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace cadastro_remedios
{
    public partial class PesquisaCliente : Form
    {
        public PesquisaCliente()
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
                    string pesquisa = "SELECT pro_nome_comercial as Nome,pro_preco_de_venda as Preco,pro_descricao_do_produto as Descricao,pro_fabricante_do_produto as Fabricante,pro_obs as Observacoes FROM cadastro_remedios WHERE pro_nome_comercial LIKE @value";
                    MySqlDataAdapter ad = new MySqlDataAdapter(pesquisa, con);
                    ad.SelectCommand.Parameters.AddWithValue("value", txtSearch.Text + "%");
                    System.Data.DataTable table = new System.Data.DataTable ();
                    ad.Fill(table);
                    dataGridView1.DataSource = table;
                    con.Close();
                    break;

                case "Fabricante":
                    string pesquisa1 = "SELECT pro_nome_comercial as Nome,pro_preco_de_venda as Preco,pro_descricao_do_produto as Descricao,pro_fabricante_do_produto as Fabricante,pro_obs as Observacoes FROM cadastro_remedios WHERE pro_fabricante_do_produto LIKE @value";
                    MySqlDataAdapter ad1 = new MySqlDataAdapter(pesquisa1, con);
                    ad1.SelectCommand.Parameters.AddWithValue("value", txtSearch.Text + "%");
                    System.Data.DataTable table1 = new System.Data.DataTable ();
                    ad1.Fill(table1);
                    dataGridView1.DataSource = table1;
                    con.Close();
                    break;
            }
        }

        private void btnPequisar_Click(object sender, EventArgs e)
        {
            Pesquisar();
        }
        private void PesquisaCliente_Load(object sender, EventArgs e)
        {
            txtSearch.Focus();
        }
        private void PesquisaCliente_KeyDown(object sender, KeyEventArgs e)
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
        //pesquisar ao digitar
        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            Pesquisar();
        }
    }
}
