using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Matthias.Asteroids.Engine
{
    public abstract class Boni : IchKannGezeichnetWerden, IchAktualisereMich
    {
        private bool _istGesammelt;

        protected Boni(BoniSpeicher speicher, Rectangle zeichenBereich)
        {
            Speicher = speicher;
            ZeichenBereich = zeichenBereich;
        }

        public BoniSpeicher Speicher { get; }

        private bool _istAktiv;

        public Boni Aufsammeln()
        {
            if (!_istGesammelt)
            {
                _istGesammelt = true;
                return this;
            
            }
            return null;

        }

        public void Benutzen(Raumschiff schiff)
        {
            if (!_istAktiv)
            {
                _istAktiv = true;
                WenndeBoniAn(schiff);
            }
        }

        public abstract void Aktualisieren(GameTime time);

        protected abstract void WenndeBoniAn(Raumschiff schiff);
        public abstract void Zeichnen(SpriteBatch blattPapier);
        public Rectangle ZeichenBereich { get; }
    }
}