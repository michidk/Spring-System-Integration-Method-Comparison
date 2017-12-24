using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Physics
{
    public class MassPoint : MonoBehaviour, IPhysicsComponent
    {

        public Vector3 Position
        {
            get { return this.transform.position; }
            set { this.transform.position = value; }
        }

        public Vector3 Velocity;
        public Vector3 Force;   // wihtout spring forces and damping
        public float Mass = 10f;
        public float Damping = 0.01f;
        public bool IsFixed = false;


        void Awake()
        {
            Simulator.Instance.RegisterMassPoint(this);
        }

        public void Prepare() // : IPhysicsComponent
        {
            AddGravity();   // Note: could also be done directly after clearing forces or before integration
        }

        public void CleanUp() // : IPhysicsComponent
        {
            ClearForces();
        }

        private void ClearForces()
        {
            Force = Vector3.zero;
        }

        private void AddGravity()
        {
            Force += Vector3.down * Simulator.Instance.Gravity * Mass; // multiply with mass, because acceleration is mass independet
        }

        public void AddForce(Vector3 force)
        {
            Force += force;
        }

        public void IntegratePosition(float delta)
        {
            Position = Position + delta * Velocity;
        }
        
        public void IntegrateVelocity(float delta, Vector3 computedForce)
        {
            if (IsFixed)
            {
                // Debug.LogError("Can't add forces to a fixed point."); 
                // just do nothing
            }
            else
            {
                // Apply force
                Velocity += computedForce * (delta / Mass);
            }
        }

        // Visualize Force Vector
#if UNITY_EDITOR
        void OnDrawGizmos()
        {
            if (IsFixed)
                return;

            Gizmos.color = Color.cyan;
            Gizmos.DrawLine(Position, Position + Force);
        }
#endif

    }
}
