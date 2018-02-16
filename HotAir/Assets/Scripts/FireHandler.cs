using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireHandler : MonoBehaviour {


    bool fireOn = true;
    float timeOnFire;

	public void FireOn()
    {
        GetComponent<SpriteRenderer>().enabled = true;
        fireOn = true;
        timeOnFire = 0;
    }

    public void FireOff()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        fireOn = false;
    }

    void Update()
    {
        if(fireOn)
        {
            timeOnFire += Time.deltaTime;

            if(timeOnFire >= 2.5f)
            {
                FireOff();
            }
        }
    }
}
