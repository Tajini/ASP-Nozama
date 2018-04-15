using System;
using System.Collections.Generic;

namespace Nozama2.Models
{
    public class Client
    {
        public string Pseudo { get; set; }
        public string Password { get; set; }
        public string Mail { get; set; }
        public float Phone { get; set; }
        public string Adress { get; set; }
        public bool Businessman { get; set; }
        public int Id { get; set; }

  /*      public Client(string pseudo, string password, string mail, float phone, string adress, bool businessman)
        {
            pseudo = Pseudo;
            password = Password;
            mail = Mail;
            adress = Adress;
            phone = Phone;
            panier = Panier;
            businessman = Businessman;

        }
        */
    }
}