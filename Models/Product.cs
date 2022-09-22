using System;

namespace cadastro_remedios
{
    public class Product
    {        //cadastro de uto

        public int Codigo { get; set; }
        public string CodigoBarras { get; set; }
        public string Descricao { get; set; }
        public string NomeGenerico { get; set; }
        public string NomeComercial { get; set; }
        public string Grupo { get; set; }
        public string Fabricante { get; set; }
        public string Unidade { get; set; }
        public string Armazenamento { get; set; }
        public string Marca { get; set; }
        public string Estoque { get; set; }
        public string DataCadastro { get; set; }
        public string PrecoCaixa { get; set; }
        public string UnidadeCaixa { get; set; }
        public string CompraUnidade { get; set; }
        public string Margem { get; set; }
        public string PrecoVenda { get; set; }
        public string DescontoPromocao { get; set; }
        public string MargemPromocao { get; set; }
        public string PrecoPromocao { get; set; }
        public string InicioPromocao { get; set; }
        public string FinalPromocao { get; set; }
        public string Obs { get; set; }
        public string Status { get; set; }

    }
}