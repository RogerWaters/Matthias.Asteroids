using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Matthias.Asteroids.Engine
{
    public class Raumschiff : SpielElement, IchHabeEineKanone, IchAktualisereMich
    {
        public void Rotieren(float grad)
        {
            _richtung = Vector2.Transform(_richtung, Matrix.CreateRotationX(MathHelper.ToRadians(grad)));
        }

        public Raumschiff(float geschwindigkeit, Vector2 richtung, Spieler spieler, Rectangle zeichenBereich) : base(geschwindigkeit, richtung,zeichenBereich)
        {
            Spieler = spieler;
            Position = new Vector2(zeichenBereich.X,zeichenBereich.Y);
        }

        public void Beschleunigen(float beschleunigung)
        {
            _geschwindigkeit += beschleunigung;
        }

        public IEnumerable<Schuss> Schießt()
        {
            yield break;
        }

        public override void Bewegen()
        {
            var tst = new Vector2((float)Math.Cos(MathHelper.ToRadians(_winkel)), (float)Math.Sin(MathHelper.ToRadians(_winkel)));
            tst.Normalize();
            var verschiebungsVector = tst * _geschwindigkeit; //*(float) _vergangeneSekunden;
            Position += verschiebungsVector;
             ZeichenBereich = new Rectangle((int) Position.X-37, (int) Position.Y-37,ZeichenBereich.Width,ZeichenBereich.Height);

            foreach (Boni boni in Spieler.Spielbereich.BeinhaltetBonis.ToArray())
            {
                if (boni.ZeichenBereich.Intersects(ZeichenBereich))
                {
                    Spieler.Spielbereich.BeinhaltetBonis.Remove(boni);
                    if (boni.Speicher == BoniSpeicher.Schiff)
                    {
                        AktiveBoni.Add(boni);
                    }
                    else
                    {
                        Spieler.Boni.Add(boni);
                    }
                    boni.Aufsammeln();
                    var random = new Random();
                    var x = random.Next(Spieler.Spielbereich.ZeichenBereich.Width);
                    var y = random.Next(Spieler.Spielbereich.ZeichenBereich.Height);
                    Boni b;
                    if (random.Next() % 2 == 0)
                    {
                        b= new Schild(new Rectangle(x,y,40,40));
                    }
                    else
                    {
                        b = new SchussUpgrade(new Rectangle(x, y, 40, 40));
                    }
                    Spieler.Spielbereich.BeinhaltetBonis.Add(b);
                }

                

            }
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

        public override void Zeichnen(SpriteBatch blattPapier)
        {
            Vector2 origin = new Vector2(InhaltsVerwaltung.Raumschiff.Width / 2, InhaltsVerwaltung.Raumschiff.Height / 2);
            var farbe = Color.White;
            if (AktiveBoni.Any())
            {
                farbe = Color.GreenYellow;
            }
            if (_mouseIstDrüber)
            {
                farbe = Color.Yellow;
            }
            blattPapier.Draw(InhaltsVerwaltung.Raumschiff,ZeichenBereich,null,farbe,MathHelper.ToRadians(_winkel+90), origin, SpriteEffects.None, 0 );
        }

        public List<Boni> AktiveBoni { get;} =new List<Boni>();
        public Spieler Spieler { get;  }
        public WaffenTyp WaffenTyp { get; set; } = WaffenTyp.Einfach;
        public Vector2 Position { get; set; }

        private float _winkel = 0;
        private double _vergangeneSekunden;
        private bool _mouseIstDrüber = false;


        public void Aktualisieren(GameTime time)
        {
            _vergangeneSekunden = time.ElapsedGameTime.Milliseconds/100f;            
            if (_geschwindigkeit > 0)
            {
                _geschwindigkeit -= 0.002f;
                if (_geschwindigkeit < 0)
                {
                    _geschwindigkeit = 0;
                }
            }
            _geschwindigkeit = Math.Min(_geschwindigkeit, 6);
            var random = new Random();
            var state = Keyboard.GetState();
            var mouseState = Mouse.GetState();
            var mouseCursor = new Rectangle(mouseState.X,mouseState.Y,1,1);
            if (mouseCursor.Intersects(ZeichenBereich))
            {
                _mouseIstDrüber = true;
            }
            else
            {
                _mouseIstDrüber = false;
            }
            if (state.IsKeyDown(Keys.Left) || random.Next() % 15 == 0)
            {
                _winkel -= 0.8f;
            }
            if (state.IsKeyDown(Keys.Right) || random.Next() % 19 == 0)
            {
                _winkel += 0.8f;
            }
            if (state.IsKeyDown(Keys.Up) || random.Next() % 2 == 0)
            {
                _geschwindigkeit += 0.01f;
            }
            if (state.IsKeyDown(Keys.Down))
            {
                _geschwindigkeit = -1.00f;
            }
        }
    }
    
}