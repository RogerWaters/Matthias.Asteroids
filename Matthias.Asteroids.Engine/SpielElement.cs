using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace Matthias.Asteroids.Engine
{
    public abstract class SpielElement: IchKannGezeichnetWerden
    {
        protected bool _istZerstört=false;

        protected float _geschwindigkeit;

        protected Vector2 _richtung;

        public event EventHandler WennIchZerstörtWurde;

        public abstract void Bewegen();


        public abstract IEnumerable<SpielElement> Zerstören();

        protected SpielElement(float geschwindigkeit, Vector2 richtung, Rectangle zeichenBereich)
        {
            _geschwindigkeit = geschwindigkeit;
            _richtung = richtung;
            ZeichenBereich = zeichenBereich;
        }

        protected virtual void OnWennIchZerstörtWurde()
        {
            WennIchZerstörtWurde?.Invoke(this, EventArgs.Empty);
        }

        public abstract void Zeichnen(SpriteBatch blattPapier);
        public Rectangle ZeichenBereich { get; set; }
    
    }
}