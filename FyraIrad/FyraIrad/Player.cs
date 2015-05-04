using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FyraIrad
{
    class Player
    {
        public string Name { get; set; }
        public static int IdCounter =1;
        public int Id {get;set;}
        public string Color { get; set; }

        public Player(string name,string color) {
            
            Name = name;

            Color = color;


            Id = IdCounter;
            IdCounter++;
       
            
        
        }
    }
}
