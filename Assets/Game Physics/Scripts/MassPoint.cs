using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Physics
{
    public class MassPoint : MonoBehaviour
    {

        public Vector3 Position
        {
            get { return this.transform.position; }
            set { this.transform.position = value; }
        }

        public Vector3 Velocity;
        public Vector3 Force;
        public float Mass = 10f;
        public float Damping = 0.01f;
        public bool IsFixed = false;


        void Awake()
        {
            Simulator.Instance.RegisterMassPoint(this);
        }

        public void ClearForce()
        {
            Force = Vector3.zero;
        }

        public void AddGravity()
        {
            Force += Vector3.down * Simulator.Instance.Gravity;
        }

        public void Dampen()
        {
            // Damping
            Force -= Velocity * Damping;
        }

        public void IntegratePosition(float delta)
        {
            Position = Position + delta * Velocity;
        }
        
        public void IntegrateVelocity(float delta, Vector3 force)
        {
            if (IsFixed)
            {
                // Debug.LogError("Can't add forces to a fixed point."); 
                // just do nothing
            }
            else
            {


                // Apply force
                Velocity += force * (delta / Mass);
            }
        }

        public void AddForce(Vector3 force)
        {
            Force += force;
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
