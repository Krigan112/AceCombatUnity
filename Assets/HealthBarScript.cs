using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarScript : MonoBehaviour {

    [SerializeField]
    private Transform LifeBar;

    private int HpMax;

    private int Hp;

    [SerializeField]
    private GameObject Plane;

	// Use this for initialization
	void Start () {
           
	}

    public void Damage(int dmg)
    {
        HpMax = Plane.GetComponent<AircraftDrivingScript>().maxHp;
        Hp = Plane.GetComponent<AircraftDrivingScript>().hp;
        if (Hp >= 0)
        {
            float fact = (float)Hp / (float)HpMax;
            LifeBar.localScale = new Vector3(fact, 1, 1);
        }
    }
	
	// Update is called once per frame
	void Update () {
        
	}
}
