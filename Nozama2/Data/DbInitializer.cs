using Nozama2.Models;
using Nozama2.Models.Enums;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Net;
using Microsoft.Extensions.DependencyInjection;
using System.IO;

namespace Nozama2.Data
{

    public static class DbInitializer
    {

        public static void Initialize(Context context)
        {
            context.Database.EnsureCreated();
            // Look for any students.
            if (context.Clients.Any())
            {
                
                return;   // DB has been seeded
            } 

            var clients = new Client[]
            {
            new Client{ Pseudo = "Tajini", Password = "coucou123" , Mail = "email@emil.fr", Phone = 06222516, Adress = "15 rue de la Ronsette", Businessman = true},
            new Client{ Pseudo = "Gabi", Password = "couc23" , Mail = "email@emal.fr", Phone = 06222656, Adress = "12 rue de la Robette", Businessman = false },
            new Client{ Pseudo = "Prucie", Password = "coou123" , Mail = "email@emil.fr", Phone = 06226516, Adress = "14 rue de la Robinsette", Businessman = false},
            new Client{ Pseudo = "Paulie", Password = "couc123" , Mail = "email@eail.fr", Phone = 06226516, Adress = "18 rue de la Rette", Businessman = false }


            };
            
            
                context.Clients.AddRange(clients);
                       context.SaveChanges();
           
            var items = new Item[]
            {
            new Item{Name = "Lecteur DVD", Description = "Lecteur DVD BluRay", Amount = 452, Price = 150, Categories = Categories.HighTech, Image = "https://image.darty.com/hifi_video/dvd/lecteur_dvd/sony_dvdsr760hb_ec1_s1407214030540A_131010809.jpg"},
            new Item{Name = "Lecteur VD", Description = "Lecteur DVD BluRay", Amount = 452, Price = 150, Categories = Categories.HighTech, Image ="https://image.darty.com/hifi_video/dvd/lecteur_dvd/sony_dvdsr760hb_ec1_s1407214030540A_131010809.jpg"},
            new Item{Name = "Lecteur D", Description = "Lecteur DVD BluRay", Amount = 452, Price = 150, Categories = Categories.HighTech, Image  = "https://image.darty.com/hifi_video/dvd/lecteur_dvd/sony_dvdsr760hb_ec1_s1407214030540A_131010809.jpg"},

            };
          
            context.Items.AddRange(items);

            context.SaveChanges();

        }
    }
}