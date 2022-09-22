using System;
using cadastro_remedios.Models;
using MySql.Data.MySqlClient;

namespace cadastro_remedios
{
    class employeeQuery
    {
        public void Add(Employee emp)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(Connection.lConnection);
                connection.Open();

                 string insert = "INSERT INTO employee(empStatus,empName,empStreet,empDistrict, empNumber, empCity,empRegionState,empMarriageStatus,empBirthDate,empZipCode,empFixedTelephone," +
                "empCellphone,empEmail,empUsername,empPassword,empRole,empDocument)" + "values ('"
                 + emp.Status + "','" + emp.Name + "','" + emp.Street + "','" + emp.District + "','" + emp.Number + "','" + emp.City + "','" + emp.State + "','" + emp.CivilState + "','" + emp.BirthDate + "','"
                 + emp.ZipCode + "','" + emp.Telephone + "','" + emp.CellPhone + "','" + emp.Email + "','" + emp.Username + "','" + emp.Password + "','" + emp.Role + "','" + emp.Document + "')";
                MySqlCommand command = new MySqlCommand(insert, connection);
                MySqlDataReader myreader;
                myreader = command.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw new Exception(MessageBoxResult.lErrorCommand + ex.Message);
            }
        }
        internal void Update(Employee emp)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(Connection.lConnection);
                connection.Open();

                string update = "UPDATE employee set empStatus= '" +emp.Status + "',empName= '" + emp.Name + "',empNumber= '" + emp.Number + "',empStreet= '" + emp.Street + "',empDistrict= '" + emp.District + "',empCity= '" + emp.City +
                    "',empRegionState ='" + emp.State + "',empMarriageStatus= '" + emp.CivilState + "',empBirthDate='"
                    + emp.BirthDate + "',empZipCode='" + emp.ZipCode + "',empFixedTelephone='" + emp.Telephone + "',empCellphone='" + emp.CellPhone +
                    "',empEmail='" + emp.Email + "',empUsername='" + emp.Username + "',empPassword='" + emp.Password + "',empRole='" + emp.Role + "',empDocument='" + emp.Document + "' WHERE empId='" + emp.Id + "';";

                MySqlCommand command = new MySqlCommand(update, connection);
                MySqlDataReader myreader;
                myreader = command.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw new Exception(MessageBoxResult.lErrorCommand + ex.Message);
            }
        }

        public string GetEmployeeById(int emp)
        {
            string lEmployeeUserName = null;
            try
            {
                MySqlConnection connection = new MySqlConnection(Connection.lConnection);
                connection.Open();
                MySqlCommand command = new MySqlCommand("SELECT empUserName FROM employee WHERE empId = '" + emp.ToString()+ "'", connection);
                MySqlDataReader myreader;
                myreader = command.ExecuteReader();

                while(myreader.Read())
                {
                    lEmployeeUserName = myreader.GetString(0);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(MessageBoxResult.lErrorCommand + ex.Message);
            }
            return lEmployeeUserName;

        }
        public const string GetEmployeById = @" SELECT  	
                                                    empId             AS Codigo  		       , 
			                                        empName           AS Nome  			       ,
	                                                empStreet         AS Endereco		       ,
	                                                empDistrict 	  AS Bairro			       ,
                                                    empNumber         AS Numero                ,
		                                            empCity 		  AS Cidade			 	   ,
                                                    empRegionState    AS UF				       ,
	                                                empMarriageStatus AS 'Estado Civil'	 	   ,
			                                        empBirthDate      AS 'Data de Nascimento'  ,
			                                        empZipCode        AS Cep			       ,
			                                        empFixedTelephone AS Telefone		       ,
                                                    empCellphone      AS Celular		       ,
			                                        empEmail          AS Email			       ,
			                                        empUsername       AS Login			       ,
			                                        empRole           AS Cargo			       ,
			                                        empDocument       AS CPF			       ,
			                                        empStatus         AS Status  
                                            FROM employee 
                                           WHERE empId 
                                            LIKE @value 
	                                         AND empStatus= 'A';";

        public const string GetEmployeByName = @" SELECT  	
                                                    empId             AS Codigo  		       , 
			                                        empName           AS Nome  			       ,
	                                                empStreet         AS Endereco		       ,
	                                                empDistrict 	  AS Bairro			       ,
                                                    empNumber         AS Numero                ,
		                                            empCity 		  AS Cidade			 	   ,
                                                    empRegionState    AS UF				       ,
	                                                empMarriageStatus AS 'Estado Civil'	 	   ,
			                                        empBirthDate      AS 'Data de Nascimento'  ,
			                                        empZipCode        AS Cep			       ,
			                                        empFixedTelephone AS Telefone		       ,
                                                    empCellphone      AS Celular		       ,
			                                        empEmail          AS Email			       ,
			                                        empUsername       AS Login			       ,
			                                        empRole           AS Cargo			       ,
			                                        empDocument       AS CPF			       ,
			                                        empStatus         AS Status  
                                            FROM employee 
                                           WHERE empName 
                                            LIKE @value 
	                                         AND empStatus= 'A';";

        public const string GetActiveEmployee = @" SELECT  	
                                                    empId             AS Codigo  		       , 
			                                        empName           AS Nome  			       ,
	                                                empStreet         AS Endereco		       ,
	                                                empDistrict 	  AS Bairro			       ,
		                                            empCity 		  AS Cidade			 	   ,
                                                    empNumber         AS Numero                ,
                                                    empRegionState    AS UF				       ,
	                                                empMarriageStatus AS 'Estado Civil'	 	   ,
			                                        empBirthDate      AS 'Data de Nascimento'  ,
			                                        empZipCode        AS Cep			       ,
			                                        empFixedTelephone AS Telefone		       ,
                                                    empCellphone      AS Celular		       ,
			                                        empEmail          AS Email			       ,
			                                        empUsername       AS Login			       ,
			                                        empRole           AS Cargo			       ,
			                                        empDocument       AS CPF			       ,
			                                        empStatus         AS Status  
                                            FROM employee 
                                           WHERE empStatus= 'A';";

        public const string GetInativeEmployee = @" SELECT  	
                                                    empId             AS Codigo  		       , 
			                                        empName           AS Nome  			       ,
	                                                empStreet         AS Endereco		       ,
	                                                empDistrict 	  AS Bairro			       ,
		                                            empCity 		  AS Cidade			 	   ,
                                                    empRegionState    AS UF				       ,
	                                                empMarriageStatus AS 'Estado Civil'	 	   ,
                                                    empNumber         AS Numero                ,
			                                        empBirthDate      AS 'Data de Nascimento'  ,
			                                        empZipCode        AS Cep			       ,
			                                        empFixedTelephone AS Telefone		       ,
                                                    empCellphone      AS Celular		       ,
			                                        empEmail          AS Email			       ,
			                                        empUsername       AS Login			       ,
			                                        empRole           AS Cargo			       ,
			                                        empDocument       AS CPF			       ,
			                                        empStatus         AS Status  
                                            FROM employee 
                                           WHERE empStatus= 'I';";

        public const string GetAllEmployees = @" SELECT  	
                                                    empId             AS Codigo  		       , 
			                                        empName           AS Nome  			       ,
	                                                empStreet         AS Endereco		       ,
	                                                empDistrict 	  AS Bairro			       ,
		                                            empCity 		  AS Cidade			 	   ,
                                                    empNumber         AS Numero                ,
                                                    empRegionState    AS UF				       ,
	                                                empMarriageStatus AS 'Estado Civil'	 	   ,
			                                        empBirthDate      AS 'Data de Nascimento'  ,
			                                        empZipCode        AS Cep			       ,
			                                        empFixedTelephone AS Telefone		       ,
                                                    empCellphone      AS Celular		       ,
			                                        empEmail          AS Email			       ,
			                                        empUsername       AS Login			       ,
			                                        empRole           AS Cargo			       ,
			                                        empDocument       AS CPF			       ,
			                                        empStatus         AS Status  
                                            FROM employee;";

        public const string GetLoggedUser = @"SELECT  	
                     			                    empName AS Nome  			       
	                                        FROM employee 
                                           WHERE empId = @value ";
    }
}
            
        
    



