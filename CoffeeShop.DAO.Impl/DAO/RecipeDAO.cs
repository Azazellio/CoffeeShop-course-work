using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Management.Automation;
using System.Text;
using DAO.Abstract;

namespace CoffeeShop.DAO.Impl.DAO
{
    public class RecipeDAO : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        [AllowNull]
        public int? DrinkDAOId { get; set; }  //foreign key to drink table
        [ForeignKey(nameof(DrinkDAOId))]
        public DrinkDAO DrinkDAO { get; set; }
    }
}
