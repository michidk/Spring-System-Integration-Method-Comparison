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

        void Update()
        {
            PreparePoints();
            PrepareSprings();

            // ... evaluate other forces, eg. user interaction...
            // Update() of other objects is executed (see ScriptExecutionOrder)
        }

        void LateUpdate()
        {
            Integrate();
        }

        public void RegisterMassPoint(MassPoint point)
        {
            points.Add(point);
        }

        public void RegisterSpring(Spring spring)
        {
            springs.Add(spring);
        }

        private void PreparePoints()
        {
            foreach (var point in points)
            {
                point.ClearForce();
                point.AddGravity();
            }
        }

        private void PrepareSprings()
        {
            foreach (var spring in springs)
            {
                spring.ApplyElasticForces();
            }
        }

        private void Integrate()
        {
            foreach (var point in points)
            {
                point.Dampen();
                IntegrationType.GetIntegrator().Integrate(point, Time.deltaTime);
            }
        }

    }
}