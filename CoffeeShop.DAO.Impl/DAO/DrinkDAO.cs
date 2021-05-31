using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Management.Automation;
using DAO.Abstract;

namespace CoffeeShop.DAO.Impl.DAO
{
    public class DrinkDAO:IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [AllowNull]
        public int? MachineDAOId { get; set; }    //Foreign key to machine table
        [ForeignKey(nameof(MachineDAOId))]
        public MachineDAO MachineDAO { get; set; }
    }
}
