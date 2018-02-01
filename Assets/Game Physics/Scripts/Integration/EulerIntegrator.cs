using System.Collections;
using System.Collections.Generic;
using Assets.Physics;
using UnityEngine;

namespace Assets.Physics.Integration
{
    public class EulerIntegrator : Integrator
    {

        public override void Integrate(List<MassPoint> points, float delta)
        {
            Dictionary<MassPoint, Vector3> forces = Simulator.Instance.ComputeForces();

            foreach (var point in points)
            {
                // start with position
                point.IntegratePosition(delta);

                // then velocity
                if (forces.ContainsKey(point))
                    point.IntegrateVelocity(delta, forces[point]);
            }
        }

    }
}