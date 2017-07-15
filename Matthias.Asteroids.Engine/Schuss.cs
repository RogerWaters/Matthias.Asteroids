using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Matthias.Asteroids.Engine
{
    public abstract class Schuss : SpielElement
    {
        private IchHabeEineKanone _quelle;
        private float _reichweite=4;

        public Schuss(float geschwindigkeit, Vector2 richtung, IchHabeEineKanone quelle, Rectangle zeichenBereich) : base(geschwindigkeit, richtung,zeichenBereich)
        {
            _quelle = quelle;

        }
        public override IEnumerable<SpielElement> Zerstören()
        {
            if (!_istZerstört)
            {
                _istZerstört = true;
                OnWennIchZerstörtWurde();

            }
            yield break;
        }
    }
}