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
            Force += Vector3.down * -Simulator.Instance.Gravity;
        }

        public void IntegratePosition()
        {
            Position = Position + Time.deltaTime * Velocity;
        }

        public void IntegrateVelocity()
        {
            if (IsFixed)
            {
                // Debug.LogError("Can't add forces to a fixed point."); 
                // just do nothing
            }
            else
            {
                Velocity += Force * (Time.deltaTime / Mass) * -Damping;
            }
        }

        public void AddForce(Vector3 force)
        {
            Force += force;
        }

    }
}
