using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Classes
{
    class Guesser
    {
        public Dictionary<Machine, DateTime> guessed = new Dictionary<Machine, DateTime>();
        private Net net;
        public Guesser(Net net)
        {
            this.net = net;
        }
        public Dictionary<Machine, DateTime> Guess()
        {
            var tempDict = new Dictionary<Machine, DateTime>();
            foreach(Machine machine in net.machines)
            {
                var shift = machine.GetShift();
                var dateShift = DateTime.Now.AddDays(shift);
                tempDict.Add(machine, dateShift);
            }
            guessed = tempDict;
            return tempDict;
        }
        public string GuessFor(Machine machine)
        {
            return guessed[machine].ToString();
        }
    }
}
