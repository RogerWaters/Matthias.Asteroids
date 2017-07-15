using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Matthias.Asteroids.Engine
{
    public class Spieler: IchKannGezeichnetWerden, IchAktualisereMich
    {
        private readonly Spielbereich _spielbereich;
        protected List<Raumschiff> Hangar;
        protected Raumschiff Schiff;

        public Spieler(Spielbereich spielbereich)
        {
            _spielbereich = spielbereich;
            Schiff=new Raumschiff(0,Vector2.Zero, this, new Rectangle((int) (_spielbereich.ZeichenBereich.Width*0.5-37.5), (int) (_spielbereich.ZeichenBereich.Height*0.2-37.5),75,75));
        }

        public List<Boni> Boni { get; } =new List<Boni>();

        public void Zeichnen(SpriteBatch blattPapier)
        {
            Schiff.Zeichnen(blattPapier);
        }

        public Rectangle ZeichenBereich
        {
            get
            {
                var bereich = _spielbereich.ZeichenBereich;
                var verschAufXAchse = ((int) (bereich.Width*0.6));
                var breite = bereich.Width-verschAufXAchse;
                var höhe = ((int) (bereich.Height*0.2));
                return new Rectangle(verschAufXAchse,0,breite,höhe);
            }
        }

        public Spielbereich Spielbereich
        {
            get { return _spielbereich; }
        }

        public void Aktualisieren(GameTime time)
        {
            Schiff.Aktualisieren(time);
            Schiff.Bewegen();
            if (Schiff.Position.X > _spielbereich.ZeichenBereich.Width)
            {
                Schiff.Position= new Vector2(0,Schiff.Position.Y);
            }
            if (Schiff.Position.X < 0)
            {
                Schiff.Position= new Vector2(_spielbereich.ZeichenBereich.Width,Schiff.Position.Y);
            }
            if (Schiff.Position.Y > _spielbereich.ZeichenBereich.Height)
            {
                Schiff.Position= new Vector2(Schiff.Position.X, 0);
            }
            if (Schiff.Position.Y < 0)
            {
                Schiff.Position= new Vector2(Schiff.Position.X, _spielbereich.ZeichenBereich.Height);
            }
        }

    }
}