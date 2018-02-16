using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public float baseMoveSpeed;
    public float jumpPower;
    public float baseSensitivity;


    private float currentMoveSpeed;
    private float currentSensitivity;
    private Camera mainCam;
    private GameObject GameManager;
	// Use this for initialization
	void Start () {
        

        currentMoveSpeed = baseMoveSpeed;
        currentSensitivity = baseSensitivity;
        mainCam = Camera.main;
        GameManager = GameObject.FindGameObjectWithTag("GameController");
	}
	
	// Update is called once per frame
	void Update () {
        if (GameManager.GetComponent<GameManager>().roundOver)
        {
            return;
        }
        float xRot = Input.GetAxis("Mouse X") * Time.deltaTime * currentSensitivity;
        float yRot = -Input.GetAxis("Mouse Y") * Time.deltaTime * currentSensitivity;
        float movementFor = Input.GetAxis("Vertical") * Time.deltaTime * currentMoveSpeed;
        float movementSide = -Input.GetAxis("Horizontal") * Time.deltaTime * currentMoveSpeed;

        Vector3 dwn = transform.TransformDirection(Vector3.down);
         //&& Physics.Raycast(transform.position, dwn, 15f
        if (Input.GetKeyDown(KeyCode.Space) && Physics.Raycast(transform.position, dwn, 0.5f))
        {
            
            GetComponent<Rigidbody>().velocity = new Vector3(0,jumpPower,0);
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            movementFor = Input.GetAxis("Vertical") * Time.deltaTime * currentMoveSpeed * 1.5f;
            movementSide = -Input.GetAxis("Horizontal") * Time.deltaTime * currentMoveSpeed * 1.5f;
        }

        transform.Rotate(0, xRot, 0);
        mainCam.transform.Rotate(yRot, 0, 0);
        transform.Translate(movementFor, 0, movementSide);
	}
}
