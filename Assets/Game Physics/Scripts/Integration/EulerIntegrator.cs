using System.Collections;
using System.Collections.Generic;
using Assets.Physics;
using UnityEngine;

namespace Assets.Physics.Integration
{
    public class EulerIntegrator : Integrator
    {

        public override void Integrate(MassPoint point, float delta)
        {
            point.IntegratePosition(delta);

            point.IntegrateVelocity(delta);
        }

    }
}