using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Physics.Integration;
using UnityEngine;

namespace Assets.Physics
{
    public class Simulator : MonoBehaviour
    {

        public static Simulator Instance;

        public float Gravity = 0.981f;
        public IntegrationType IntegrationType = IntegrationType.Euler;

        private List<MassPoint> points = new List<MassPoint>();
        private List<Spring> springs = new List<Spring>();


        void Awake()
        {
            Instance = this;
        }

        void FixedUpdate()
        {
            foreach (var point in points)
                point.Prepare();

            Integrate();

            foreach (var point in points)
                point.CleanUp();
        }

        public void RegisterMassPoint(MassPoint point)
        {
            points.Add(point);
        }

        public void RegisterSpring(Spring spring)
        {
            springs.Add(spring);
        }

        private void Integrate()
        {
            ((LeapFrogIntegrator) IntegrationType.LeapFrog.GetIntegrator()).LeapFrogFirst =
                IntegrationType != IntegrationType.LeapFrog;

            IntegrationType.GetIntegrator().Integrate(points, Time.deltaTime);
        }

        // computes forces of spring forces, external forces and damping
        public Dictionary<MassPoint, Vector3> ComputeForces()
        {
            Dictionary<MassPoint, Vector3> forces = ComputeSpringForces();

            // adding spring forces and damping
            foreach (var point in forces.Keys.ToList())
                forces[point] += point.Force + (-point.Velocity * point.Damping);

            return forces;
        }

        // dependent on positions
        private Dictionary<MassPoint, Vector3> ComputeSpringForces()
        {
            var dict = new Dictionary<MassPoint, Vector3>();

            foreach (var spring in springs)
            {
                var forces = spring.CalculateElasticForces();

                if (!dict.ContainsKey(spring.Point1))
                    dict.Add(spring.Point1, Vector3.zero);

                if (!dict.ContainsKey(spring.Point2))
                    dict.Add(spring.Point2, Vector3.zero);

                dict[spring.Point1] += forces;
                dict[spring.Point2] -= forces;
            }

            return dict;
        }

    }
}