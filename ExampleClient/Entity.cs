using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExampleClient
{
    public class Entity
    {
        public bool isMoving = false;
        public string username;
        public int x;
        public int y;
        public Direction direction = Direction.Forward;
        public int health;
        public Entity(string username, int x, int y)
        {
            this.username = username;
            this.x = x;
            this.y = y;
            this.health = 100;
        }

        public enum Direction
        {
            Forward,
            Backward,
            Left,
            Right
        }
    }
}
