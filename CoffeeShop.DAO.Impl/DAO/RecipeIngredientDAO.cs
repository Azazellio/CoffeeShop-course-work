using DAO.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Management.Automation;
using System.Text;

namespace CoffeeShop.DAO.Impl.DAO
{
    public class RecipeIngredientDAO : IEntity
    {
        [Key]
        public int Id { get; set; }

        public int Amount { get; set; }

        [AllowNull]
        public int? IngredientDAOId { get; set; }
        [ForeignKey(nameof(IngredientDAOId))]
        public IngredientDAO IngredientDAO { get; set; }

        [AllowNull]
        public int? RecipeDAOId { get; set; }
        [ForeignKey(nameof(RecipeDAOId))]
        public RecipeDAO RecipeDAO { get; set; }

    }
}
