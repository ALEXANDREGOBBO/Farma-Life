using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace cadastro_remedios
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        public static int lUser;


        // nível de hierarquia ao logar
        private void Principal_Load(object sender, EventArgs e)
        {
            if (Login.lType == "1")
            {
                //visible
                cadastrarPesquisarFuncionarioToolStripMenuItem.Visible = true;
                cadastrarPesquisarRemédiosToolStripMenuItem.Visible = true;
                controleDeVendasToolStripMenuItem.Visible = true;
                pesquisarRemédiosToolStripMenuItem.Visible = false;
                apagarBancoDeDadosToolStripMenuItem.Visible = false;

                //enable
                cadastrarPesquisarFuncionarioToolStripMenuItem.Enabled = true;
                cadastrarPesquisarRemédiosToolStripMenuItem.Enabled = true;
                controleDeVendasToolStripMenuItem.Enabled = true;
                pesquisarRemédiosToolStripMenuItem.Enabled = false;
                apagarBancoDeDadosToolStripMenuItem.Enabled = false;
            }
            if (Login.lType == "2")
            {
                //visible
                cadastrarPesquisarFuncionarioToolStripMenuItem.Visible = false;
                cadastrarPesquisarRemédiosToolStripMenuItem.Visible = true;
                controleDeVendasToolStripMenuItem.Visible = true;
                pesquisarRemédiosToolStripMenuItem.Visible = false;
                apagarBancoDeDadosToolStripMenuItem.Visible = false;

                //enable
                cadastrarPesquisarFuncionarioToolStripMenuItem.Enabled = false;
                cadastrarPesquisarRemédiosToolStripMenuItem.Enabled = true;
                controleDeVendasToolStripMenuItem.Enabled = true;
                pesquisarRemédiosToolStripMenuItem.Enabled = false;
                apagarBancoDeDadosToolStripMenuItem.Enabled = false;
            }
            if (Login.lType == "3")
            {
                //visible
                cadastrarPesquisarFuncionarioToolStripMenuItem.Visible = false;
                cadastrarPesquisarRemédiosToolStripMenuItem.Visible = false;
                controleDeVendasToolStripMenuItem.Visible = true;
                pesquisarRemédiosToolStripMenuItem.Visible = true;
                apagarBancoDeDadosToolStripMenuItem.Visible = false;
                //enable
                cadastrarPesquisarFuncionarioToolStripMenuItem.Enabled = false;
                cadastrarPesquisarRemédiosToolStripMenuItem.Enabled = false;
                controleDeVendasToolStripMenuItem.Enabled = true;
                pesquisarRemédiosToolStripMenuItem.Enabled = true;
                apagarBancoDeDadosToolStripMenuItem.Enabled = false;
            }
            if (Login.lType == "0")
            {
                //visible
                cadastrarPesquisarFuncionarioToolStripMenuItem.Visible = true;
                cadastrarPesquisarRemédiosToolStripMenuItem.Visible = true;
                controleDeVendasToolStripMenuItem.Visible = true;
                pesquisarRemédiosToolStripMenuItem.Visible = true;
                apagarBancoDeDadosToolStripMenuItem.Visible = true;
                //enable
                cadastrarPesquisarFuncionarioToolStripMenuItem.Enabled = true;
                cadastrarPesquisarRemédiosToolStripMenuItem.Enabled = true;
                controleDeVendasToolStripMenuItem.Enabled = true;
                pesquisarRemédiosToolStripMenuItem.Enabled = true;
                apagarBancoDeDadosToolStripMenuItem.Enabled = true;
            }
            lblDate.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

            if (Login.lType != "0")
            {
                employeeQuery lEmployeeQuery = new employeeQuery();
                lblUser.Text = lEmployeeQuery.GetEmployeeById(lUser);
            }
            else
            {
                lblUser.Text = "Admin";

            }
        }

        // teclas de atalho

        private void Principal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                this.Close();
                Help HelpSobre = new Help();
                HelpSobre.Show();
            }
            if (e.KeyCode == Keys.F4)
            {
                if (Login.lType == "1" || Login.lType == "0")
                {
                    this.Close();
                    Cadastro_Funcionario cliente = new Cadastro_Funcionario();
                    cliente.Show();
                }
                else
                {
                    MessageBox.Show("Você não tem acesso a este comando.", "Erro");
                }
            }
            if (e.KeyCode == Keys.F5)
            {
                if (Login.lType == "3" || Login.lType == "0")
                    MessageBox.Show("Você não tem acesso a este comando.", "Erro");
                else
                {
                    this.Close();
                    Cadastro_Remedio remedio = new Cadastro_Remedio();
                    remedio.Show();
                }
            }
            if (e.KeyCode == Keys.F6)
            {
                this.Close();
                cadastrar_cliente cliente = new cadastrar_cliente();
                cliente.Show();
            }
            if (e.KeyCode == Keys.F7)
            {
                this.Close();
                Venda venda = new Venda();
                venda.Show();
            }
            if (e.KeyCode == Keys.Escape)
            {
                if (MessageBox.Show("Deseja voltar ao login?", Config.lAlert, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Login.lType = string.Empty;
                    this.Close();
                    Login login = new Login();
                    login.Show();
                }
            }

            if (e.KeyCode == Keys.F8)
            {
                this.Close();
                PesquisaVenda pesquisa = new PesquisaVenda();
                pesquisa.Show();
            }
            if (e.KeyCode == Keys.F9)
            {
                if (Login.lType == "3" || Login.lType == "0")
                {
                    this.Close();
                    Pesquisa pesquisa = new Pesquisa();
                    pesquisa.Show();
                }
                else
                    MessageBox.Show("Você não tem acesso a este comando.", "Erro");
            }

            if (e.KeyCode == Keys.F3)
            {
                this.Close();
                AtualizarEstoque estoque = new AtualizarEstoque();
                estoque.Show();
            }

            if (e.KeyCode == Keys.F2)
            {
                this.Close();
                Sobre sobre = new Sobre();
                sobre.Show();
            }

            if (e.KeyCode == Keys.F10)
            {
                Calculadora calculadora = new Calculadora();
                calculadora.Show();
            }

            if (e.KeyCode == Keys.F11)
            {
                this.Close();
                email email = new email();
                email.Show();
            }
        }

        //abertura dos forms atraves de menustrip

        private void cadastrarPesquisarFuncionarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Cadastro_Funcionario funcionario = new Cadastro_Funcionario();
            funcionario.Show();
        }

        private void cadastrarPesquisarClienteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
            cadastrar_cliente cliente = new cadastrar_cliente();
            cliente.Show();
        }

        private void cadastrarPesquisarRemédiosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Cadastro_Remedio remedio = new Cadastro_Remedio();
            remedio.Show();
        }

        private void vendasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Venda venda = new Venda();
            venda.Show();
        }

        private void sairToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja voltar ao login?", Config.lAlert, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
                Login login = new Login();
                login.Show();
            }
        }


        private void pesquisaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Pesquisa pesquisa = new Pesquisa();
            pesquisa.Show();
        }

        private void ajudaSobreToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
            Help HelpSobre = new Help();
            HelpSobre.Show();
        }

        private void pesquisarVendasF5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            PesquisaVenda pesquisa = new PesquisaVenda();
            pesquisa.Show();
        }

        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Sobre sobre = new Sobre();
            sobre.Show();
        }

        private void atualizarEstoqueToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
            AtualizarEstoque estoque = new AtualizarEstoque();
            estoque.Show();
        }

        private void apagarBancoDeDadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            ApagarDB apaga = new ApagarDB();
            apaga.Show();
        }

        private void calculadoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Calculadora calcuradora = new Calculadora();
            calcuradora.Show();
        }

        private void sistemaDeEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            email email = new email();
            email.Show();
        }
    }
}
