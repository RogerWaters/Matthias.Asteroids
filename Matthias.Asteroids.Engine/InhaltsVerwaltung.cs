using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Matthias.Asteroids.Engine
{
    public static class InhaltsVerwaltung
    {
        public static Texture2D Hintergrund { get; private set; }
        public static Texture2D Schild { get; set; }
        public static Texture2D WaffenUpgrade { get; set; }
        public static Texture2D Raumschiff { get; set; }

        public static void LadeContent(ContentManager content)
        {
            Hintergrund = content.Load<Texture2D>("background");
            Schild = content.Load<Texture2D>("schildUpgrade");
            WaffenUpgrade = content.Load<Texture2D>("waffenUpgrade");
            Raumschiff = content.Load<Texture2D>("raumschiff");
            
        }
    }
}
