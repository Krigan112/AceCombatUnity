using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileScript : MonoBehaviour {

    [SerializeField]
    private GameObject LittleExplosion;

	// Use this for initialization
	void Start () {
        Destroy(gameObject, 5);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision c)
    {
        if(c.gameObject.tag == "Plane" && gameObject.tag != "PlaneMissile")
        {
            explode();
            c.gameObject.GetComponent<AircraftDrivingScript>().takeDamage(10);
        }
        else if(c.gameObject.tag == "Plane" && gameObject.tag == "PlaneMissile")
        {
        }
        else if(c.gameObject.tag == "Helicopter" && gameObject.tag == "PlaneMissile")
        {
            explode();
            c.gameObject.GetComponent<HelicopterScript>().takeDamage(100);
        }else if(c.gameObject.tag == "Tank" && gameObject.tag == "PlaneMissile")
        {
            explode();
            c.gameObject.GetComponent<TankScript>().takeDamage(100);
        }else if(c.gameObject.tag == "Turret" && gameObject.tag == "PlaneMissile")
        {
            explode();
            c.gameObject.GetComponent<TurretScript>().takeDamage(100);
        }
    }

    void OnTriggerEnter(Collider c)
    {
        if(c.gameObject.tag == "Plane" && gameObject.tag == "Missile")
        {
            explode();
            c.gameObject.GetComponent<AircraftDrivingScript>().takeDamage(10);
        }
    }

    void explode()
    {
        Destroy(gameObject);
        GameObject boom = Instantiate<GameObject>(LittleExplosion);
        boom.transform.position = transform.position;
        Destroy(boom, 3);
    }
}
