using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmAni : MonoBehaviour {

    public Transform origin;
    float timer;
    public int rotAmount;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 newPos = origin.position;
        transform.position = newPos;
        
        timer += Time.deltaTime;
        if(timer > 1.5f)
        {
            AudioSource audSou = GetComponent<AudioSource>();
            if(audSou != null)
            {
                //audSou.Play();

            }
            rotAmount = -rotAmount;
            transform.Rotate(rotAmount, 0, 0);
            timer = 0;
        }
        
	}
}
