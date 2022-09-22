using System;
using System.Windows.Forms;

namespace cadastro_remedios
{
    public partial class Help : Form
    {
        public Help() => InitializeComponent();

        private void AjudaSobre_KeyDown(object sender, KeyEventArgs e)
        {
            this.Close();
            Principal remedio = new Principal();
            remedio.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Easter Egg");
        }

        private void voltar3_Click(object sender, EventArgs e)
        {
            this.Close();
            Principal remedio = new Principal();
            remedio.Show();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
}
