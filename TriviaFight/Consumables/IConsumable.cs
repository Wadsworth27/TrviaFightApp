using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriviaFight.Consumables
{
    public interface IConsumable
    {
        public void Use(Player player,Enemy enemy,Question question);
    }
}
