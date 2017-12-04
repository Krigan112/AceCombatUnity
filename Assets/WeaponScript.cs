using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour {

    [SerializeField]
    private Transform BulletStartPosition;

    [SerializeField]
    private Transform MissileStartPosition;

    [SerializeField]
    private GameObject PrefabBullet;

    [SerializeField]
    private GameObject Missile;

    public float reload = 0;

    public bool canMissile;

    public float reloadTime = 2;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        reload -= Time.deltaTime;

        if (Input.GetMouseButton(0) || Input.GetKey(KeyCode.K))
        {
            GameObject Bullet = Instantiate<GameObject>(PrefabBullet);
            Bullet.transform.position = BulletStartPosition.position;
            Bullet.GetComponent<Rigidbody>().AddForce(transform.forward * 100000);
        }

        if(canMissile == true)
        {
            if (Input.GetMouseButtonDown(1))
            {
                if (reload <= 0)
                {
                    GameObject missile = Instantiate<GameObject>(Missile);
                    missile.transform.position = MissileStartPosition.position;
                    missile.GetComponent<Rigidbody>().AddForce(transform.forward * 100000);
                    reload = reloadTime;
                }
            }
        }
    }
}
