using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Matthias.Asteroids.Engine.Animation
{
    public class DrehAnimation
    {
        private bool _rückseite;
        private int _lastUpdateSecond;
        public Rectangle ZeichenBereich { get; private set; }

        public SpriteEffects FlipEffekt
        {
            get
            {
                return _rückseite ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
                
            }
        }


        public void AnimierterZeichenbereich(Rectangle originalerZeichenBereich,GameTime time)
        {
            var milliseconds = (time.TotalGameTime.Milliseconds) / 10;

            var breite = (int)(originalerZeichenBereich.Width - originalerZeichenBereich.Width / 100.0 * milliseconds);
            var verschiebungX = (originalerZeichenBereich.Width - breite) / 2;

            _rückseite = (int)(time.TotalGameTime.TotalSeconds % 2) == 0;

            if (_rückseite)
            {
                breite = originalerZeichenBereich.Width - breite;
                verschiebungX = (originalerZeichenBereich.Width - breite) / 2;
            }

            ZeichenBereich = new Rectangle(originalerZeichenBereich.X + verschiebungX, originalerZeichenBereich.Y, breite, originalerZeichenBereich.Height);
        }
    }
}
