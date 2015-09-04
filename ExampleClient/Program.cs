using System;

namespace ExampleClient
{
#if WINDOWS || LINUX
    public static class Program
    {
        public static Game1 game;
        static void Main()
        {
            game = new Game1();
            game.Run();
        }
    }
#endif
}
