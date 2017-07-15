using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Matthias.Asteroids.Engine
{
    public abstract class Planet : SpielElement
    {
        private float _radius;

        public Planet(float radius, float geschwindigkeit, Vector2 richtung, Rectangle zeichenBereich) : base(geschwindigkeit,richtung,zeichenBereich)
        {
            _radius = radius;

        }

        public Planet(float geschwindigkeit, Vector2 richtung, Rectangle zeichenBereich) : this(3, geschwindigkeit, richtung, zeichenBereich)
        {}

        public override IEnumerable<SpielElement> Zerstören()
        {
            if (!_istZerstört)
            {
                _istZerstört = true;
                OnWennIchZerstörtWurde();
                if (_radius >=2)
                { 
                    Vector2 richtung = _richtung;
                    var richtungP1 = Vector2.Transform(richtung, Matrix.CreateRotationX(MathHelper.ToRadians(35)));
                    yield return BuildPlanet(_radius / 2, _geschwindigkeit * 1.5f, richtungP1);
                    var richtungP2 = Vector2.Transform(richtung, Matrix.CreateRotationX(MathHelper.ToRadians(-35)));
                    yield return BuildPlanet(_radius / 2, _geschwindigkeit * 1.5f, richtungP2);
                }
            }

        }

        protected abstract Planet BuildPlanet(float radius, float geschwindigkeit, Vector2 richtung);
    }
}