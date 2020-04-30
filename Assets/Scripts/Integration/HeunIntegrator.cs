using System.Collections;
using System.Collections.Generic;
using Assets.Physics;
using UnityEngine;

namespace Assets.Physics.Integration
{
    public class HeunIntegrator : Integrator
    {

        public override void Integrate(List<MassPoint> points, float delta)
        {
            var oldPositions = new Vector3[points.Count];
            var oldVelocities = new Vector3[points.Count];

            // calculate force
            Dictionary<MassPoint, Vector3> oldForces = Simulator.Instance.ComputeForces();

            // then perform a implicit euler step
            int index = 0;
            foreach (var point in points)
            {
                oldPositions[index] = point.Position;
                oldVelocities[index] = point.Velocity;
                index++;
 
                // interpolate
                // start with velocity
                if (oldForces.ContainsKey(point))
                {
                    point.IntegrateVelocity(delta, oldForces[point]);
                }

                // then integrate the position
                point.IntegratePosition(delta);
            }

            // restores positions and velocities and perform euler step together with implicit euler
            Dictionary<MassPoint, Vector3> newForces = Simulator.Instance.ComputeForces();
            index = 0;
            foreach (var point in points)
            {
                point.Position = oldPositions[index];
                point.Velocity = oldVelocities[index];
                index++;

                point.IntegratePosition(delta);

                if (oldForces.ContainsKey(point))
                    point.IntegrateVelocity(delta / 2, oldForces[point]);

                if (newForces.ContainsKey(point))
                    point.IntegrateVelocity(delta / 2, newForces[point]);
            }
            
        }

    }
}