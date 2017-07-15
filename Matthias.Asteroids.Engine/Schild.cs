using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Matthias.Asteroids.Engine.Animation;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Matthias.Asteroids.Engine
{
    public class Schild : Boni
    {
        protected TimeSpan _schildZeit=TimeSpan.FromSeconds(3);

        private DrehAnimation _drehAnimation = new DrehAnimation();


        public Schild(Rectangle zeichenBereich) : base(BoniSpeicher.Spieler,zeichenBereich)
        {
        }

        public override void Aktualisieren(GameTime time)
        {
            _drehAnimation.AnimierterZeichenbereich(ZeichenBereich,time);
        }

        protected override void WenndeBoniAn(Raumschiff schiff)
        {
            schiff.AktiveBoni.Add(this);
            schiff.Spieler.Boni.Remove(this);
        }

        public override void Zeichnen(SpriteBatch blattPapier)
        {
            blattPapier.Draw(InhaltsVerwaltung.Schild,_drehAnimation.ZeichenBereich,null,Color.White,0,Vector2.Zero, _drehAnimation.FlipEffekt,0);
        }
    }

}