using System;
using MySql.Data.MySqlClient;

namespace cadastro_remedios
{
    class productQuery
    {
        public void Insert(Product lProduct)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(Connection.lConnection);
                connection.Open();

                 string insert = "INSERT INTO cadastro_remedios(pro_codigo_de_barras,pro_descricao_do_produto,pro_nome_generico,pro_nome_comercial,pro_grupo,"
                    +"pro_fabricante_do_produto,pro_unidade,pro_local_de_armazenamento,pro_marca_fabricante,pro_quantidade_no_estoque,pro_data_de_cadastro," 
                    +"pro_preco_de_compra_por_caixa,pro_unid_caixa,pro_preco_de_compra_unitario,pro_margem,pro_preco_de_venda,pro_desconto_de_promocao,pro_margem_de_promocao," 
                    +"pro_preco_promocao,pro_inicio_da_promocao,pro_final_da_promocao,pro_obs,pro_status)" + "values ('"
                    + lProduct.CodigoBarras + "','" + lProduct.Descricao + "','" + lProduct.NomeGenerico + "','" + lProduct.NomeComercial + "','" + lProduct.Grupo + "','"
                    + lProduct.Fabricante + "','" + lProduct.Unidade + "','" + lProduct.Armazenamento + "','" + lProduct.Marca + "','"
                    + lProduct.Estoque + "','" + lProduct.DataCadastro + "','" + lProduct.PrecoCaixa.Replace(",", ".") + "','" + lProduct.UnidadeCaixa + "','" + lProduct.CompraUnidade.Replace(",", ".") + "','"
                    + lProduct.Margem.Replace(",", ".") + "','" + lProduct.PrecoVenda.Replace(",", ".") + "','" + lProduct.DescontoPromocao.Replace(",", ".") + "','" + lProduct.MargemPromocao.Replace(",", ".") + "','"
                    + lProduct.PrecoPromocao.Replace(",", ".") + "','" + lProduct.InicioPromocao + "','" + lProduct.FinalPromocao + "','" + lProduct.Obs + "','" + lProduct.Status + "')";
                MySqlCommand command = new MySqlCommand(insert, connection);
                MySqlDataReader myreader;
                myreader = command.ExecuteReader();
            }
            catch (MySqlException ex)
            {
                throw ex;
            }

        }

        internal void Update(Product lProduct)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(Connection.lConnection);
                connection.Open();

                string update = "UPDATE cadastro_remedios set pro_codigo_de_barras= '" + lProduct.CodigoBarras + "',pro_descricao_do_produto= '" + lProduct.Descricao + "',pro_nome_generico= '" + lProduct.NomeGenerico + "',pro_nome_comercial= '" + lProduct.NomeComercial +
                     "',pro_grupo ='" + lProduct.Grupo + "',pro_fabricante_do_produto= '" + lProduct.Fabricante + "',pro_unidade='"
                     + lProduct.Unidade + "',pro_local_de_armazenamento='" + lProduct.Armazenamento + "',pro_marca_fabricante='" + lProduct.Marca + "',pro_quantidade_no_estoque='" + lProduct.Estoque +
                     "',pro_data_de_cadastro='" + lProduct.DataCadastro + "',pro_preco_de_compra_por_caixa='" + lProduct.PrecoCaixa.Replace(",", ".") + "',pro_unid_caixa='" + lProduct.UnidadeCaixa + "',pro_preco_de_compra_unitario='" + lProduct.CompraUnidade.Replace(",", ".") +
                     "',pro_margem='" + lProduct.Margem.Replace(",", ".") + "',pro_preco_de_venda='" + lProduct.PrecoVenda.Replace(",", ".") + "',pro_desconto_de_promocao='" + lProduct.DescontoPromocao.Replace(",", ".") + "',pro_margem_de_promocao='" + lProduct.MargemPromocao.Replace(",", ".") +
                     "',pro_preco_promocao='" + lProduct.PrecoPromocao.Replace(",", ".") + "',pro_inicio_da_promocao='" + lProduct.InicioPromocao + "',pro_final_da_promocao='" + lProduct.FinalPromocao +
                     "',pro_obs='" + lProduct.Obs + "',pro_status='" + lProduct.Status + "' WHERE pro_codigo='" + lProduct.Codigo + "';";
                MySqlCommand command = new MySqlCommand(update, connection);
                MySqlDataReader myreader;
                myreader = command.ExecuteReader();
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
        }



        public const string GetAllProducts = @"  SELECT 
                                                        pro_codigo as Codigo, 
                                                        pro_codigo_de_barras as 'Codigo De Barras',
                                                        pro_descricao_do_produto as 'Descricao Produto',
                                                        pro_nome_generico as 'Nome Generico',
                                                        pro_nome_comercial as 'Nome Comercial',
                                                        pro_grupo as Grupo ,pro_fabricante_do_produto as 'Fabricante',
                                                        pro_unidade as Unidade,
                                                        pro_local_de_armazenamento as 'Local Armazenamento',
                                                        pro_marca_fabricante as 'Marca Fabricante',
                                                        pro_quantidade_no_estoque as 'Qntd Estoque',
                                                        pro_data_de_cadastro as 'Data Cadastro',
                                                        pro_preco_de_compra_por_caixa as 'Preco Compra Caixa',
                                                        pro_unid_caixa as 'Unidade Caixa',
                                                        pro_preco_de_compra_unitario as 'Preco Compra Unitario',
                                                        pro_margem as Margem,
                                                        pro_preco_de_venda as 'Preco Venda',
                                                        pro_desconto_de_promocao as 'Desconto Promocao',
                                                        pro_margem_de_promocao as 'Margem Promocao',
                                                        pro_preco_promocao as 'Preco Promocao',
                                                        pro_inicio_da_promocao as 'Inicio Promocao',
                                                        pro_final_da_promocao as 'Final Promocao',
                                                        pro_obs as Observacoes, 
                                                        pro_status as Status
                                                   FROM cadastro_remedios";

        public const string GetAllActiveProducts = @"    SELECT 
                                                                pro_codigo as Codigo, 
                                                                pro_codigo_de_barras as 'Codigo De Barras',
                                                                pro_descricao_do_produto as 'Descricao Produto',
                                                                pro_nome_generico as 'Nome Generico',
                                                                pro_nome_comercial as 'Nome Comercial',
                                                                pro_grupo as Grupo ,pro_fabricante_do_produto as 'Fabricante',
                                                                pro_unidade as Unidade,
                                                                pro_local_de_armazenamento as 'Local Armazenamento',
                                                                pro_marca_fabricante as 'Marca Fabricante',
                                                                pro_quantidade_no_estoque as 'Qntd Estoque',
                                                                pro_data_de_cadastro as 'Data Cadastro',
                                                                pro_preco_de_compra_por_caixa as 'Preco Compra Caixa',
                                                                pro_unid_caixa as 'Unidade Caixa',
                                                                pro_preco_de_compra_unitario as 'Preco Compra Unitario',
                                                                pro_margem as Margem,
                                                                pro_preco_de_venda as 'Preco Venda',
                                                                pro_desconto_de_promocao as 'Desconto Promocao',
                                                                pro_margem_de_promocao as 'Margem Promocao',
                                                                pro_preco_promocao as 'Preco Promocao',
                                                                pro_inicio_da_promocao as 'Inicio Promocao',
                                                                pro_final_da_promocao as 'Final Promocao',
                                                                pro_obs as Observacoes, 
                                                                pro_status as Status
                                                           FROM cadastro_remedios
                                                          WHERE pro_status = 'A'";

        public const string GetAllInactiveProducts = @"  SELECT 
                                                        pro_codigo as Codigo, 
                                                        pro_codigo_de_barras as 'Codigo De Barras',
                                                        pro_descricao_do_produto as 'Descricao Produto',
                                                        pro_nome_generico as 'Nome Generico',
                                                        pro_nome_comercial as 'Nome Comercial',
                                                        pro_grupo as Grupo ,pro_fabricante_do_produto as 'Fabricante',
                                                        pro_unidade as Unidade,
                                                        pro_local_de_armazenamento as 'Local Armazenamento',
                                                        pro_marca_fabricante as 'Marca Fabricante',
                                                        pro_quantidade_no_estoque as 'Qntd Estoque',
                                                        pro_data_de_cadastro as 'Data Cadastro',
                                                        pro_preco_de_compra_por_caixa as 'Preco Compra Caixa',
                                                        pro_unid_caixa as 'Unidade Caixa',
                                                        pro_preco_de_compra_unitario as 'Preco Compra Unitario',
                                                        pro_margem as Margem,
                                                        pro_preco_de_venda as 'Preco Venda',
                                                        pro_desconto_de_promocao as 'Desconto Promocao',
                                                        pro_margem_de_promocao as 'Margem Promocao',
                                                        pro_preco_promocao as 'Preco Promocao',
                                                        pro_inicio_da_promocao as 'Inicio Promocao',
                                                        pro_final_da_promocao as 'Final Promocao',
                                                        pro_obs as Observacoes, 
                                                        pro_status as Status
                                                   FROM cadastro_remedios
                                                  WHERE pro_status = 'I'";

        public const string GetById = @"  SELECT 
                                                        pro_codigo as Codigo, 
                                                        pro_codigo_de_barras as 'Codigo De Barras',
                                                        pro_descricao_do_produto as 'Descricao Produto',
                                                        pro_nome_generico as 'Nome Generico',
                                                        pro_nome_comercial as 'Nome Comercial',
                                                        pro_grupo as Grupo ,pro_fabricante_do_produto as 'Fabricante',
                                                        pro_unidade as Unidade,
                                                        pro_local_de_armazenamento as 'Local Armazenamento',
                                                        pro_marca_fabricante as 'Marca Fabricante',
                                                        pro_quantidade_no_estoque as 'Qntd Estoque',
                                                        pro_data_de_cadastro as 'Data Cadastro',
                                                        pro_preco_de_compra_por_caixa as 'Preco Compra Caixa',
                                                        pro_unid_caixa as 'Unidade Caixa',
                                                        pro_preco_de_compra_unitario as 'Preco Compra Unitario',
                                                        pro_margem as Margem,
                                                        pro_preco_de_venda as 'Preco Venda',
                                                        pro_desconto_de_promocao as 'Desconto Promocao',
                                                        pro_margem_de_promocao as 'Margem Promocao',
                                                        pro_preco_promocao as 'Preco Promocao',
                                                        pro_inicio_da_promocao as 'Inicio Promocao',
                                                        pro_final_da_promocao as 'Final Promocao',
                                                        pro_obs as Observacoes, 
                                                        pro_status as Status
                                                   FROM cadastro_remedios
                                                  WHERE pro_status = 'A'
                                                    AND pro_codigo LIKE @value";

        public const string GetByCompany = @"  SELECT 
                                                        pro_codigo as Codigo, 
                                                        pro_codigo_de_barras as 'Codigo De Barras',
                                                        pro_descricao_do_produto as 'Descricao Produto',
                                                        pro_nome_generico as 'Nome Generico',
                                                        pro_nome_comercial as 'Nome Comercial',
                                                        pro_grupo as Grupo ,pro_fabricante_do_produto as 'Fabricante',
                                                        pro_unidade as Unidade,
                                                        pro_local_de_armazenamento as 'Local Armazenamento',
                                                        pro_marca_fabricante as 'Marca Fabricante',
                                                        pro_quantidade_no_estoque as 'Qntd Estoque',
                                                        pro_data_de_cadastro as 'Data Cadastro',
                                                        pro_preco_de_compra_por_caixa as 'Preco Compra Caixa',
                                                        pro_unid_caixa as 'Unidade Caixa',
                                                        pro_preco_de_compra_unitario as 'Preco Compra Unitario',
                                                        pro_margem as Margem,
                                                        pro_preco_de_venda as 'Preco Venda',
                                                        pro_desconto_de_promocao as 'Desconto Promocao',
                                                        pro_margem_de_promocao as 'Margem Promocao',
                                                        pro_preco_promocao as 'Preco Promocao',
                                                        pro_inicio_da_promocao as 'Inicio Promocao',
                                                        pro_final_da_promocao as 'Final Promocao',
                                                        pro_obs as Observacoes, 
                                                        pro_status as Status
                                                   FROM cadastro_remedios
                                                  WHERE pro_status = 'A'
                                                    AND pro_fabricante_do_produto LIKE @value";


        public const string GetByGenericName = @"  SELECT 
                                                        pro_codigo as Codigo, 
                                                        pro_codigo_de_barras as 'Codigo De Barras',
                                                        pro_descricao_do_produto as 'Descricao Produto',
                                                        pro_nome_generico as 'Nome Generico',
                                                        pro_nome_comercial as 'Nome Comercial',
                                                        pro_grupo as Grupo ,pro_fabricante_do_produto as 'Fabricante',
                                                        pro_unidade as Unidade,
                                                        pro_local_de_armazenamento as 'Local Armazenamento',
                                                        pro_marca_fabricante as 'Marca Fabricante',
                                                        pro_quantidade_no_estoque as 'Qntd Estoque',
                                                        pro_data_de_cadastro as 'Data Cadastro',
                                                        pro_preco_de_compra_por_caixa as 'Preco Compra Caixa',
                                                        pro_unid_caixa as 'Unidade Caixa',
                                                        pro_preco_de_compra_unitario as 'Preco Compra Unitario',
                                                        pro_margem as Margem,
                                                        pro_preco_de_venda as 'Preco Venda',
                                                        pro_desconto_de_promocao as 'Desconto Promocao',
                                                        pro_margem_de_promocao as 'Margem Promocao',
                                                        pro_preco_promocao as 'Preco Promocao',
                                                        pro_inicio_da_promocao as 'Inicio Promocao',
                                                        pro_final_da_promocao as 'Final Promocao',
                                                        pro_obs as Observacoes, 
                                                        pro_status as Status
                                                   FROM cadastro_remedios
                                                  WHERE pro_status = 'A'
                                                    AND pro_nome_generico LIKE @value";


        public const string GetProductForSales = @"SELECT   pro_codigo as Codigo, 
                                                            pro_nome_generico as Nome, 
                                                            pro_preco_de_venda as Preco ,
                                                            pro_desconto_de_promocao as Desconto, 
                                                            pro_inicio_da_promocao as 'Inicio Promocao',
                                                            pro_final_da_promocao as 'Final Promocao' 
                                                    FROM cadastro_remedios 
                                                   WHERE pro_nome_generico LIKE @value 
                                                     AND pro_status = 'A'";

    }
}
      
        
    

