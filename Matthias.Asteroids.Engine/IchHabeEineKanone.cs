using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Matthias.Asteroids.Engine
{
    public interface IchHabeEineKanone
    {
        IEnumerable<Schuss> Schießt();
    }
}