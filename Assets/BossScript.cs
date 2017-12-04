using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour {

    public GameObject Explosion;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void destroyed()
    {
        Destroy(gameObject);
        GameObject boom = Instantiate<GameObject>(Explosion);
        boom.transform.position = transform.position;
        Destroy(boom, 5);
    }
}
