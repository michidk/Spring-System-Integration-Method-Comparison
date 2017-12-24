using System.Collections;
using System.Collections.Generic;
using Assets.Physics;
using UnityEngine;

namespace Assets.Physics.Integration
{
    // type comparison: https://codepen.io/michidk/pen/VymawG?editors=0010#0
    public enum IntegrationType
    {
        Euler,
        LeapFrog,
        Midpoint
    }

    public static class IntegrationTypeExtensions
    {
        private static EulerIntegrator euler = new EulerIntegrator();
        private static LeapFrogIntegrator leapFrog = new LeapFrogIntegrator();
        private static MidpointIntegrator midpoint = new MidpointIntegrator();

        public static Integrator GetIntegrator(this IntegrationType type)
        {
            switch (type)
            {
                default:
                case IntegrationType.Euler:
                    return euler;
                case IntegrationType.LeapFrog:
                    return leapFrog;
                case IntegrationType.Midpoint:
                    return midpoint;
            }
        }
    }
}