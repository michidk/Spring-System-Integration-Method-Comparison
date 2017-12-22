using System.Collections;
using System.Collections.Generic;
using Assets.Physics;
using UnityEngine;

namespace Assets.Physics.Integration
{
    public enum IntegrationType
    {
        Euler,
        LeapFrog
    }

    public static class IntegrationTypeExtensions
    {
        private static EulerIntegrator euler = new EulerIntegrator();
        private static LeapFrogIntegrator leapFrog = new LeapFrogIntegrator();

        public static Integrator GetIntegrator(this IntegrationType type)
        {
            switch (type)
            {
                default:
                case IntegrationType.Euler:
                    return euler;
                case IntegrationType.LeapFrog:
                    return leapFrog;
            }
        }
    }
}