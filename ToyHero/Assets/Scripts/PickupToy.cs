using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupToy : MonoBehaviour {

    //public GameObject reticle;

    public GameObject currentPickup;
    public GameObject inCollider;

    GameObject holdPos;

     

    public bool holding;
	// Use this for initialization
	void Start () {
        holdPos = GameObject.FindGameObjectWithTag("Hold");
        holding = false;
	}
	
	// Update is called once per frame
	void Update () {
       

        
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!holding)
            {
                if(inCollider == null)
                {
                    return;
                }
                currentPickup = inCollider;
                holding = true;
            }else
            {
                if(currentPickup == null)
                {
                    return;
                }

                holding = false;
                currentPickup.transform.rotation = holdPos.transform.rotation;
                currentPickup.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
                currentPickup = null;
            }
           
            
        } else if (Input.GetKeyDown(KeyCode.Q) && holding)
        {
            holding = false;
            currentPickup.transform.rotation = holdPos.transform.rotation;
            currentPickup.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            currentPickup.GetComponent<ToyManager>().thrust = 10;
            currentPickup.GetComponent<ToyManager>().yThrust = 3;
            currentPickup.GetComponent<ToyManager>().dir = Camera.main.transform.forward;
            currentPickup = null;
            
        }


        if(holding && currentPickup != null)
        {
            currentPickup.transform.position = holdPos.transform.position;
            currentPickup.transform.rotation = holdPos.transform.rotation;
        }
	}

    void OnTriggerEnter(Collider coll)
    {
        if(coll.gameObject.tag == "Toy")
        {
            inCollider = coll.gameObject;
        }
    }
    void OnTriggerExit(Collider coll)
    {
        if(coll.gameObject.tag == "Toy")
        {
            inCollider = null;
        }
    }
}
