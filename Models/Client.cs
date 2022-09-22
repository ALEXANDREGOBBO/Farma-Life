using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cadastro_remedios.Models
{
    public class Client
    {
        //cadastro e
        public int Id { get; set; }
        public string Name { get; set; }
        public string Document { get; set; }
        public string ZipCode { get; set; }
        public string Street { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }


    }
}
