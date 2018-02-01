using System.Collections;
using System.Collections.Generic;
using Assets.Physics;
using UnityEngine;

namespace Assets.Physics.Integration
{
    public class LeapFrogIntegrator : Integrator
    {

        public bool LeapFrogFirst = true;

        public override void Integrate(List<MassPoint> points, float delta)
        {
            //Dictionary<MassPoint, Vector3> forces = Simulator.Instance.ComputeForces();

            //foreach (var point in points)
            //{
            //    // start with velocity (and use half the delta if object just started moving)
            //    if (forces.ContainsKey(point))
            //    {
            //        if (LeapFrogFirst)
            //            point.IntegrateVelocity(delta / 2.0f, forces[point]);
            //        else
            //            point.IntegrateVelocity(delta, forces[point]);
            //    }

            //    // then integrate the position
            //    point.IntegratePosition(delta);
            //}

            //LeapFrogFirst = false;
        }

    }
}