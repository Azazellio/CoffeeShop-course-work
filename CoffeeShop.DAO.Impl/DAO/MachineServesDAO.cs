using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Management.Automation;
using System.Text;
using DAO.Abstract;

namespace CoffeeShop.DAO.Impl.DAO
{
    public class MachineServesDAO : IEntity
    {
        [Key]
        public int Id { get; set; }

        [AllowNull]
        public int? MachineDAOId { get; set; }    //Foreign key to machine table
        [ForeignKey(nameof(MachineDAOId))]
        public MachineDAO MachineDAO { get; set; }

        [AllowNull]
        public int? DrinkDAOId { get; set; }   //Foreign key to drink table
        [ForeignKey(nameof(DrinkDAOId))]
        public DrinkDAO DrinkDAO { get; set; }

        public int Count { get; set; }
    }
}
