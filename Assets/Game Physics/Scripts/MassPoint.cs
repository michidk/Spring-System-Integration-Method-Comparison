using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Physics.Integration;
using Assets.Physics.Integration.Helper;
using UnityEngine;

namespace Assets.Physics
{
    public class MassPoint : MonoBehaviour, IPhysicsComponent
    {

        public Vector3 Position { get { return State.Position; } }
        public Vector3 Velocity { get { return State.Velocity; } }

        public State State;
        public Derivative Derivative;

        public Vector3 ExternalAcceleration;
        public float Mass = 10f;
        public float Damping = 0.01f;
        public bool IsFixed = false;


        void Awake()
        {
            Simulator.Instance.RegisterMassPoint(this);

            // set initial position
            State.Position = this.transform.position;
        }

        public void Prepare() // : IPhysicsComponent
        {
            // get position from Unity (movement through unity editor etc)
            State.Position = this.transform.position;

            AddGravity();   // Note: could also be done directly after clearing forces or before integration
        }

        public void Apply()
        {
            this.transform.position = State.Position;
        }

        public void CleanUp() // : IPhysicsComponent
        {
            ClearAcceleration();
        }

        private void ClearAcceleration()
        {
            ExternalAcceleration = Vector3.zero;
        }

        private void AddGravity()
        {
            ExternalAcceleration += Vector3.down * Simulator.Instance.Gravity;
        }

        public void AddForce(Vector3 force)
        {
            ExternalAcceleration += force / Mass;
        }

        public void AddAcceleration(Vector3 acceleration)
        {
            ExternalAcceleration += acceleration;
        }

        // Visualize Force Vector
#if UNITY_EDITOR
        void OnDrawGizmos()
        {
            if (IsFixed)
                return;

            Gizmos.color = Color.cyan;
            Gizmos.DrawLine(State.Position, State.Position + State.Velocity);
        }
#endif

    }
}
