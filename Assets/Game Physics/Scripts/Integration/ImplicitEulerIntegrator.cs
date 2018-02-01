using System.Collections;
using System.Collections.Generic;
using Assets.Physics;
using UnityEngine;

namespace Assets.Physics.Integration
{
    public class ImplicitEulerIntegrator : Integrator
    {

        public override void Integrate(List<MassPoint> points, float delta)
        {
            var oldPositions = new Vector3[points.Count];
            var oldVelocities = new Vector3[points.Count];

            Dictionary<MassPoint, Vector3> forces = Simulator.Instance.ComputeForces();

            int index = 0;
            foreach (var point in points)
            {
                oldPositions[index] = point.Position;
                oldVelocities[index] = point.Velocity;

                index++;
 
                // interpolate
                // start with velocity
                if (forces.ContainsKey(point))
                {
                    point.IntegrateVelocity(delta, forces[point]);
                }

                // then integrate the position
                point.IntegratePosition(delta);
            }

            // use positions and velocities of previous full step to compute new forces (and use those as starting point for new calculations)
            forces = Simulator.Instance.ComputeForces();
            index = 0;
            foreach (var point in points)
            {
                point.Position = oldPositions[index];
                point.Velocity = oldVelocities[index];

                point.IntegratePosition(delta);

                if (forces.ContainsKey(point))
                    point.IntegrateVelocity(delta, forces[point]);

                index++;
            }
            
        }

    }
}