using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Matthias.Asteroids.Engine.Animation;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Matthias.Asteroids.Engine
{
    public class SchussUpgrade : Boni
    {
        private DrehAnimation _drehAnimation = new DrehAnimation();

        public SchussUpgrade(Rectangle zeichenBereich) : base(BoniSpeicher.Schiff,zeichenBereich)
        { }

        public override void Aktualisieren(GameTime time)
        {
            _drehAnimation.AnimierterZeichenbereich(ZeichenBereich, time);
        }

        protected override void WenndeBoniAn(Raumschiff schiff)
        {
            schiff.WaffenTyp = WaffenTyp.Doppel;
        }

        public override void Zeichnen(SpriteBatch blattPapier)
        {
            blattPapier.Draw(InhaltsVerwaltung.WaffenUpgrade,_drehAnimation.ZeichenBereich,null,Color.White,0,Vector2.Zero, _drehAnimation.FlipEffekt,0);
        }
    }

    public enum WaffenTyp
    {
        Einfach, Doppel
    }
}