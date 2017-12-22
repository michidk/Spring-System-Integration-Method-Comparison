using System.Collections;
using System.Collections.Generic;
using Assets.Physics;
using UnityEngine;

namespace Assets.Physics.Integration
{
    public abstract class Integrator
    {

        public abstract void Integrate(MassPoint point, float delta);

    }
}