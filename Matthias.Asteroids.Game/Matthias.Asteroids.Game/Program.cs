using System;

namespace Matthias.Asteroids.Game
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (MasterBuster game = new MasterBuster())
            {
                game.Run();
            }
        }
    }
#endif
}

