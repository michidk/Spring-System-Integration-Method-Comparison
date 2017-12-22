using System.Collections;
using System.Collections.Generic;
using Assets.Physics;
using UnityEngine;

namespace Assets.Physics.Integration
{
    public class LeapFrogIntegrator : Integrator
    {

        public override void Integrate(MassPoint point, float delta)
        {
            point.IntegrateVelocity(delta);

            point.IntegratePosition(delta);
        }

    }
}