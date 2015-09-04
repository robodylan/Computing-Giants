using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExampleClient
{
    public class Tile
    {
        public int x;
        public int y;
        public int ID;

        public Tile(int x, int y, int ID)
        {
            this.x = x;
            this.y = y;
            this.ID = ID;
        } 
    }
}
