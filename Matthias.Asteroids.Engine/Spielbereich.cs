using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Matthias.Asteroids.Engine
{
    public class Spielbereich : IchKannGezeichnetWerden,IchAktualisereMich
    {
        private readonly GraphicsDevice _device;

        public Spielbereich(GraphicsDevice device)
        {
            _device = device;
        }

        public List<SpielElement> BeinhaltetSpielElemente { get; } = new List<SpielElement>();
        public List<Boni> BeinhaltetBonis { get; } = new List<Boni>();
        public List<Spieler> BeinhaltetSpieler { get; } = new List<Spieler>();

        public void Zeichnen(SpriteBatch blattPapier)
        {
            blattPapier.Draw(InhaltsVerwaltung.Hintergrund, new Rectangle(0, 0, blattPapier.GraphicsDevice.Viewport.Width, blattPapier.GraphicsDevice.Viewport.Height), Color.White);
            foreach (var boni in BeinhaltetBonis)
            {
              boni.Zeichnen(blattPapier); 
                
            }
            foreach (var spieler in BeinhaltetSpieler)
            {
                spieler.Zeichnen(blattPapier);
            }
        }


        public Rectangle ZeichenBereich
        {
            get
            {
                return new Rectangle(0, 0, _device.Viewport.Width, _device.Viewport.Height);
            }
        }

        public void Aktualisieren(GameTime time)
        {
            foreach (var boni in BeinhaltetBonis)
            {
                boni.Aktualisieren(time);
            }
            foreach (var spieler in BeinhaltetSpieler)
            {
                spieler.Aktualisieren(time);
            }
        }
    }
}