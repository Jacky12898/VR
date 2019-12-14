using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Valve.VR.InteractionSystem
{

    public class SnowballGunScript : MonoBehaviour
    {
        public SteamVR_Input_Sources handType;
        public SteamVR_Action_Boolean grabPinchAction = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("GrabPinch");
        public SteamVR_Action_Boolean grabGripAction = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("GrabGrip");
        public float snowballSpeed;
        public TextMesh ammoText;
        public GameObject barrelEnd;
        public GameObject snowBall;
        private int ammoLeft = 0;
        public AudioSource load;
        public AudioSource shoot;

        // Start is called before the first frame update
        void Start()
        {
            ammoText.text = ammoLeft.ToString();
        }

        // Update is called once per frame
        void Update()
        {
            if (grabPinchAction.GetStateDown(handType) && ammoLeft > 0)
            {
                GameObject newSnowball = Instantiate(snowBall, barrelEnd.transform.position, Quaternion.identity);
                Rigidbody rb = newSnowball.GetComponent<Rigidbody>();
                rb.velocity = (barrelEnd.transform.forward) * snowballSpeed;
                shoot.Play();
                ammoLeft--;
                ammoText.text = ammoLeft.ToString();
            }
        }

        void OnCollisionStay(Collision collision)
        {
            if (grabGripAction.GetStateDown(handType))
            {
                if(collision.gameObject.tag == "Snowball")
                {
                    Destroy(collision.gameObject);
                    load.Play();
                    ammoLeft++;
                    ammoText.text = ammoLeft.ToString();
                }
            }
        }
    }
}
