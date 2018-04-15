using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nozama2.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nozama2.Models
{
    public class Item
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Name { get; set; }
        public int ID { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
        public float Price { get; set; }
        public string Image { get; set; }
        public Categories Categories { get; set; }

        //public int category;
    /*    public Item(string name, int id, string description, int amount, float price, Categories cat, Byte[] image)
        {
            Name = name;
            ID = id;
            Description = description;
            Amount = amount;
            Price = price;
            Categories = cat;
            Image = image;
        }
        */
    }

}
