using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToyManager : MonoBehaviour {

    public bool isSafe;
    public float thrust;
    public Vector3 dir;
    public float yThrust;
	// Use this for initialization
	void Start () {
        thrust = 0;
	}
	
	// Update is called once per frame
	void Update () {

        
        dir.y = yThrust;
        GetComponent<Rigidbody>().AddForce(dir * thrust);
        if(thrust > 0)
        {
            thrust -= Time.deltaTime * 10;
        }
        if(yThrust > -5)
        {
            yThrust -= Time.deltaTime * 10;
        }

        if(transform.position.y <= -0.2f)
        {
            Vector3 newPos = transform.position;
            newPos.y = 0.2f;
            transform.position = newPos;
        }
    }

    void OnTriggerEnter(Collider coll)
    {
        if(coll.gameObject.tag == "Safe")
        {
            isSafe = true;
        }
    }
}
