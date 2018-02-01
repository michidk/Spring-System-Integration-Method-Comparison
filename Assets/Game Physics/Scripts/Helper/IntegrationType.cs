using System.Collections;
using System.Collections.Generic;
using Assets.Physics;
using UnityEngine;

namespace Assets.Physics.Integration.Helper
{
    // type comparison: https://codepen.io/michidk/pen/VymawG?editors=0010#0
    public enum IntegrationType
    {
        Euler,
        ImplicitEuler,
        Heun,
        LeapFrog,
        Midpoint
    }

    public static class IntegrationTypeExtensions
    {
        private static EulerIntegrator euler = new EulerIntegrator();
        private static ImplicitEulerIntegrator implicitEuler = new ImplicitEulerIntegrator();
        private static HeunIntegrator heun = new HeunIntegrator();
        private static LeapFrogIntegrator leapFrog = new LeapFrogIntegrator();
        private static MidpointIntegrator midpoint = new MidpointIntegrator();

        public static Integrator GetIntegrator(this IntegrationType type)
        {
            switch (type)
            {
                default:
                case IntegrationType.Euler:
                    return euler;
                case IntegrationType.ImplicitEuler:
                    return implicitEuler;
                case IntegrationType.Heun:
                    return heun;
                case IntegrationType.LeapFrog:
                    return leapFrog;
                case IntegrationType.Midpoint:
                    return midpoint;
            }
        }
    }
}