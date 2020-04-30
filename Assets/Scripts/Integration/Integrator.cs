using System.Collections;
using System.Collections.Generic;
using Assets.Physics;
using UnityEngine;

namespace Assets.Physics.Integration
{
    public abstract class Integrator
    {

        public abstract void Integrate(List<MassPoint> points, float delta);

        public static Vector3 PerformIntegrationStep(Vector3 value, Vector3 derivative, float delta)
        {
            return value + derivative * delta;
        }

    }
}