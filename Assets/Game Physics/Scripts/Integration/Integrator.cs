using System.Collections;
using System.Collections.Generic;
using Assets.Physics;
using Assets.Physics.Integration.Helper;
using UnityEngine;

namespace Assets.Physics.Integration
{
    public abstract class Integrator
    {

        public abstract void Integrate(List<MassPoint> points, float deltaTime);

        public static void EulerIntegrateMassPoint(MassPoint point, Vector3 force, float deltaTime)
        {
            if (!point.IsFixed)
            {
                point.Derivative = PerformEulerIntegrationStep(ref point.State, point.Derivative, force, deltaTime);
            }
        }

        public static Derivative PerformEulerIntegrationStep(ref State state, Derivative derivative, Vector3 force, float deltaTime)
        {
            IntegratePosition(ref state, derivative, deltaTime);
            IntegrateVelocity(ref state, derivative, deltaTime);

            Derivative output;
            output.Velocity = state.Velocity;
            output.Force = force;

            return output;
        }

        public static void IntegratePosition(ref State currentState, Derivative derivative, float deltaTime)
        {
            currentState.Position = IntegrateVector(currentState.Position, derivative.Velocity, deltaTime);
        }

        public static void IntegrateVelocity(ref State currentState, Derivative derivative, float deltaTime)
        {
            currentState.Velocity = IntegrateVector(currentState.Velocity, derivative.Force, deltaTime);
        }
        
        private static Vector3 IntegrateVector(Vector3 value, Vector3 derivative, float deltaTime)
        {
            return value + derivative * deltaTime;
        }

    }
}