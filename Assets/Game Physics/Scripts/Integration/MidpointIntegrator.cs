using System.Collections;
using System.Collections.Generic;
using Assets.Physics;
using UnityEngine;

namespace Assets.Physics.Integration
{
    public class MidpointIntegrator : Integrator
    {

        public override void Integrate(MassPoint point, float delta)
        {
            Vector3 oldPos = point.Position;
            Vector3 oldVel = point.Velocity;

            var forces = Vector3.back; //TODO: calculate spring forces for point
            //point.Dampen();


            point.IntegratePosition(delta * 0.5f);
            point.IntegrateVelocity(delta * 0.5f, forces);

            forces = Vector3.back; //TODO: calculate springe forces
            //point.Dampen();
            point.Position = oldPos;
            point.IntegratePosition(delta);

            point.Velocity = oldVel;
            point.IntegrateVelocity(delta, forces);
        }

    }
}