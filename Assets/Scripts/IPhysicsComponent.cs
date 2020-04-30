using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Physics
{
    public interface IPhysicsComponent
    {
        void Prepare(); // called before running anything each frame
        //void PostProcess(); // called before integration
        void CleanUp(); // called after integration
    }
}
