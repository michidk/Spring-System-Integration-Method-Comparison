using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Physics
{
    [RequireComponent(typeof(MassPoint))]
    public class ForceInteractor : MonoBehaviour
    {

        public float ForceMultiplyer;

        private MassPoint point;


        void Awake()
        {
            point = this.GetComponent<MassPoint>();
        }

        void Update()
        {
            Vector3 inputForce = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));

            point.AddForce(inputForce * ForceMultiplyer);
        }

    }
}
