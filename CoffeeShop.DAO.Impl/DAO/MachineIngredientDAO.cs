using System;
using DAO.Abstract;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Management.Automation;

namespace CoffeeShop.DAO.Impl.DAO
{
    public class MachineIngredientDAO : IEntity
    {
        [Key]
        public int Id { get; set; }

        [AllowNull]
        public int? MachineDAOId { get; set; } // Foreign Key to machine table
        [ForeignKey(nameof(MachineDAOId))]
        public MachineDAO MachineDAO { get; set; }

        [AllowNull]
        public int? IngredientDAOId { get; set; }   //foreign key to ingredient table
        [ForeignKey(nameof(IngredientDAOId))]
        public IngredientDAO IngredientDAO { get; set; }

        public int MaxCapacityIngredient { get; set; }

        public int CurrentCapacityIngredient { get; set; }

    }
}
