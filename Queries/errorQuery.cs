using System;
using cadastro_remedios.Models;
using MySql.Data.MySqlClient;

namespace cadastro_remedios
{
    public class errorQuery
    {
        public void AddError(int IdEmployee,string Name, string Description, string Date, string Form)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(Connection.lConnection);

                connection.Open();

                string insert = "INSERT INTO systemerrors(empId,errorName,errorDescription,errorDate,errorStatus,errorForm)" + "values ('"
                 + IdEmployee + "','" + Name + "','" + Description + "','" + Date + "','" + "A" + "','" + Form + "')";
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

