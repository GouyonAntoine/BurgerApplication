using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class Burger : Product
    {
        [Column("BurgerWeight")]
        public int Weight { get; set; }
        public int BeefWeight { get; set; }
        //public int Stockpiled { get; set; }
    }
}