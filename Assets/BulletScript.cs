using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Destroy(gameObject, 5);
	}
	
	// Update is called once per frame
	void Update () {

	}

    void OnCollisionEnter(Collision c)
    {
        if(c.gameObject.tag == "Helicopter")
        {
            c.gameObject.GetComponent<HelicopterScript>().takeDamage(10);
        }else if(c.gameObject.tag == "Tank")
        {
            c.gameObject.GetComponent<TankScript>().takeDamage(10);
        }
        else if(c.gameObject.tag == "Turret")
        {
            c.gameObject.GetComponent<TurretScript>().takeDamage(10);
        }
        Destroy(this.gameObject);
    }
}
