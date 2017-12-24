using System.Collections;
using System.Collections.Generic;
using Assets.Physics;
using UnityEngine;

namespace Assets.Physics.Integration
{
    public class MidpointIntegrator : Integrator
    {

        public override void Integrate(List<MassPoint> points, float delta)
        {
            foreach (var point in points)
            {
                var oldPos = point.Position;
                var oldVel = point.Velocity;

                Dictionary<MassPoint, Vector3> forces = Simulator.Instance.ComputeForces();

                // start with position
                point.IntegratePosition(delta * 0.5f);

                // then velocity
                if (forces.ContainsKey(point))
                    point.IntegrateVelocity(delta * 0.5f, forces[point]);


                forces = Simulator.Instance.ComputeForces();

                point.Position = oldPos;
                point.IntegratePosition(delta);

                point.Velocity = oldVel;
                if (forces.ContainsKey(point))
                    point.IntegrateVelocity(delta * 0.5f, forces[point]);
            }
        }

    }
}