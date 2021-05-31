using DAO.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoffeeShop.DAO.Impl.DAO
{
    public class IngredientDAO:IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
