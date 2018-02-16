using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour {


    Rigidbody2D RB2;

    public Transform binderBottom;
    public Transform binderTop;


    // Use this for initialization
    void Start () {
        RB2 = GetComponent<Rigidbody2D>();
	}
	
    bool CheckInBounds(Vector3 pos)
    {
        bool isInBounds = true;

        if(pos.x < binderBottom.position.x || pos.y < binderBottom.position.y || pos.x > binderTop.position.x || pos.y > binderTop.position.y)
        {
            isInBounds = false;
        }

        return isInBounds;
    }

	// Update is called once per frame
	void Update () {
        float upwardsMove = Input.GetAxis("Vertical");
        float sidewaysMove = Input.GetAxis("Horizontal");


        Vector3 newPos = transform.position;
        newPos.x += sidewaysMove;
        newPos.y += upwardsMove;

        if(CheckInBounds(newPos))
        {
            transform.position = newPos;
        }
    }
}
