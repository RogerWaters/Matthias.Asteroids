using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Matthias.Asteroids.Engine
{
    public abstract class Ufo : SpielElement, IchHabeEineKanone
    {
        public Ufo(float geschwindigkeit, Vector2 richtung, Rectangle zeichenBereich) : base(geschwindigkeit, richtung,zeichenBereich)
        {

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

        public abstract IEnumerable<Schuss> Schießt();

        
    }
}