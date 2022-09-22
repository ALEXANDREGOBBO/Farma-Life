using System;
using System.Windows.Forms;

namespace cadastro_remedios
{
    public partial class Calculadora : Form
    {
        Double valor = 0;
        string operador = string.Empty;
        bool operador_pressed = false;
        public Calculadora()
        {
            InitializeComponent();
        }
        // voltar
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        // CE
        private void btnClean_Click(object sender, EventArgs e)
        {
            this.txtDisplay.Text = "0";
        }
        //1
        private void button_Click(object sender, EventArgs e)
        {
            if ((txtDisplay.Text == "0") || (operador_pressed))
            {
                txtDisplay.Clear();
            }
            operador_pressed = false;
            Button b = (Button)sender;
            txtDisplay.Text = txtDisplay.Text + b.Text;
        }
         // c
        private void button11_Click(object sender, EventArgs e)
        {
            txtDisplay.Clear();
            valor = 0;
        }
        
        // =
        private void btnIgual_Click(object sender, EventArgs e)
        {
            equacao.Text = string.Empty;
            switch(operador)
            {
                case "+": 
                    txtDisplay.Text = (valor + Double.Parse(txtDisplay.Text)).ToString();
                    break;
                case "-":
                    txtDisplay.Text = (valor - Double.Parse(txtDisplay.Text)).ToString();
                    break;
                case "/":
                    txtDisplay.Text = (valor / Double.Parse(txtDisplay.Text)).ToString();
                    break;
                case "*":
                    txtDisplay.Text = (valor * Double.Parse(txtDisplay.Text)).ToString();
                    break;
                default:
                    break;
                   
            } // fim do switch
           
        }
        // operacao
        private void operador_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            operador = b.Text;
            valor = Double.Parse(txtDisplay.Text);
            operador_pressed = true;
            equacao.Text = valor + " " + operador;

        }

        private void Calculadora_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
