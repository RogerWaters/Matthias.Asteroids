using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Matthias.Asteroids.Engine
{
    public interface IchKannGezeichnetWerden
    {
        void Zeichnen(SpriteBatch blattPapier);
        Rectangle ZeichenBereich { get; }
    }
}