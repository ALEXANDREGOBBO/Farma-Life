using System;
using cadastro_remedios.Models;
using MySql.Data.MySqlClient;

namespace cadastro_remedios
{
    public class sellQuery
    {
        public void SellMethod(Product lProduct, Employee lEmployee, Client lClient, Sell lSell)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(Connection.lConnection);
                connection.Open();

                 string insert = "INSERT INTO venda(ven_data,ven_total_liq,ven_total_bruto,ven_status,desc_venda,cli_cod,func_cod,cod_prod,ven_horario)  values  ('" + lSell.sellDate + "','" + lSell.sellNetAmount.Replace(",", ".") +
                    "','" + lSell.sellGrossAmount.Replace(",", ".") + "','" + lSell.sellStatus + "','" + lSell.sellDiscount.Replace(",", ".") + "','" + lClient.Id + "','"  + lEmployee.Id + "','" + lProduct.Codigo + "','" + lSell.sellHour + "')";
                MySqlCommand command = new MySqlCommand(insert, connection);
                MySqlDataReader myreader;
                myreader = command.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw new Exception(MessageBoxResult.lErrorCommand + ex.Message);
            }
        }
        public void ItemSellMethod(Product lProduct,Sell lSell, ItemSell lItemSell)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(Connection.lConnection);
                connection.Open();

                 string insert = "INSERT INTO item_venda(id_prod,Qtde_prod,Valor_Venda,total_item,id_venda) values ('" + lProduct.Codigo + "','" + lItemSell.itemQuantity + "','" + lProduct.PrecoVenda + "','" + lItemSell.itemTotal + "','" + lSell.sellId + "')";
                MySqlCommand command = new MySqlCommand(insert, connection);
                MySqlDataReader myreader;
                myreader = command.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw new Exception(MessageBoxResult.lErrorCommand + ex.Message);
            }
        }
    }
}
