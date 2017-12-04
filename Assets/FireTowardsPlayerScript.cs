using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTowardsPlayerScript : MonoBehaviour {

    [SerializeField]
    private GameObject Missile;

    private GameObject MissileStartPosition;

    [SerializeField]
    private GameObject Plane;

    private LineRenderer line;

    private RaycastHit hit;

    [SerializeField]
    private float RateOfFire;

    // Use this for initialization
    void Start () {
        line = GetComponent<LineRenderer>();
        MissileStartPosition = transform.GetChild(1).gameObject;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "Plane")
        {
            InvokeRepeating("FireTowardsPlayer", 0, RateOfFire);
        }
    }

    void OnTriggerExit(Collider c)
    {
        if(c.gameObject.tag == "Plane")
        {
            CancelInvoke("FireTowardsPlayer");
        }
        line.enabled = false;
    }

    void OnTriggerStay(Collider c)
    {
        if(c.gameObject.tag == "Plane")
        {
            if (Physics.Raycast(transform.position, Plane.transform.position - transform.position, out hit))
            {
                line.enabled = true;
                line.SetPosition(0, transform.position);
                line.SetPosition(1, hit.point);
            }
        }
    }

    void FireTowardsPlayer()
    {
        GameObject missile = Instantiate<GameObject>(Missile);
        missile.transform.position = MissileStartPosition.transform.position;
        missile.GetComponent<Rigidbody>().AddForce((Plane.transform.position - missile.transform.position).normalized * 50000);
    }
}
