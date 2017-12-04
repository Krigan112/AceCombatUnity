using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript : MonoBehaviour {

    [SerializeField]
    private GameObject Explosion;

    [SerializeField]
    private float hp;

    // Use this for initialization
    void Start()
    {
        hp = 600;
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
            destroyed();
        }
    }

    public void destroyed()
    {
        Destroy(this.gameObject);
        GameObject boom = Instantiate<GameObject>(Explosion);
        boom.transform.position = transform.position;
        Destroy(boom, 3);
    }

    public void takeDamage(float damages)
    {
        hp -= damages;
    }
}
