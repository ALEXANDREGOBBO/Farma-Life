using System;
using cadastro_remedios.Models;
using MySql.Data.MySqlClient;

namespace cadastro_remedios
{
    public class clientQuery
    {
        public void Add(Client lClient)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(Connection.lConnection);

                connection.Open();

                 string insert = "INSERT INTO cadastro_cliente(for_nome,for_cpf,for_cep,for_endereco,for_bairro,for_cidade,for_uf,for_fone,for_email)" + "values ('"
                 + lClient.Name + "','" + lClient.Document + "','" + lClient.ZipCode + "','" + lClient.Street + "','" + lClient.District + "','" + lClient.City + "','" + lClient.State + "','"
                 + lClient.Telephone + "','" + lClient.Email + "')";
                MySqlCommand command = new MySqlCommand(insert, connection);
                MySqlDataReader myreader;
                myreader = command.ExecuteReader();
            }
            catch (Exception ex)
            {
                errorQuery lerrorQuery = new errorQuery();
                lerrorQuery.AddError(Principal.lUser, MessageBoxResult.lError, ex.Message.Replace("'", ""), DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), "Cadastro Funcionario");
            }
        }
        public void Update(Client lClient)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(Connection.lConnection);
                connection.Open();

                string update = "UPDATE cadastro_cliente set for_nome= '" + lClient.Name + "',for_endereco= '" + lClient.Street + "',for_bairro= '" + lClient.District + "',for_cidade= '" + lClient.City +
                    "',for_uf ='" + lClient.State + "',for_cpf= '" + lClient.Document + "',for_cep='" + lClient.ZipCode + "',for_fone='" + lClient.Telephone +
                    "',for_email='" + lClient.Email + "' WHERE for_cod='" + lClient.Id + "';";

                MySqlCommand command = new MySqlCommand(update, connection);
                MySqlDataReader myreader;
                myreader = command.ExecuteReader();
            }
            catch (Exception ex)
            {
                errorQuery lerrorQuery = new errorQuery();
                lerrorQuery.AddError(Principal.lUser, MessageBoxResult.lErrorUpdate, ex.Message.Replace("'", ""), DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), "Cadastro Cliente");
            }
        }
    }
}


            
        
    


