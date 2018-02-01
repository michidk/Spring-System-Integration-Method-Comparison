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
        //    // backup old points
        //    var oldPositions = new Vector3[points.Count];
        //    var oldVelocities = new Vector3[points.Count];

        //    Dictionary<MassPoint, Vector3> forces = Simulator.Instance.ComputeForces();

        //    int index = 0;
        //    foreach (var point in points)
        //    {
        //        // backup old positions and velocities
        //        oldPositions[index] = point.Position;
        //        oldVelocities[index] = point.Velocity;
        //        index++;
                
        //        // half step
        //        // start with position
        //        point.IntegratePosition(delta / 2.0f);

        //        // then velocity
        //        if (forces.ContainsKey(point))
        //            point.IntegrateVelocity(delta / 2.0f, forces[point]);
        //    }

        //    // use slope (forces) of half step for the full step
        //    forces = Simulator.Instance.ComputeForces();
        //    index = 0;
        //    foreach (var point in points)
        //    {
        //        point.Position = oldPositions[index];
        //        point.Velocity = oldVelocities[index];
        //        index++;

        //        point.IntegratePosition(delta);

        //        if (forces.ContainsKey(point))
        //            point.IntegrateVelocity(delta / 2.0f, forces[point]);
        //    }
        }

    }
}