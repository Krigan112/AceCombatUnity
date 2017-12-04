using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AircraftDrivingScript : MonoBehaviour {

    [SerializeField]
    public float speed;

    [SerializeField]
    private float rotationSpeed;

    [SerializeField]
    private float tiltSpeed;

    [SerializeField]
    private float maxSpeed;

    [SerializeField]
    private float acceleration;

    private Rigidbody planeRigidbody;

    private Vector3 target;

    [SerializeField]
    private GameObject Explosion;

    [SerializeField]
    public int hp;

    [SerializeField]
    public int maxHp;

    [SerializeField]
    private GameObject HealthBar;

    [SerializeField]
    private Canvas GameOverCanvas;

    private MeshRenderer planeRenderer;

    // Use this for initialization
    void Start () {
        GameOverCanvas.enabled = false;
        speed = 0;
        maxSpeed = 25;
        maxHp = 200;
        rotationSpeed = 2;
        tiltSpeed = 2;
        acceleration = 4;
        planeRigidbody = GetComponent<Rigidbody>();
        planeRenderer = GetComponent<MeshRenderer>();
        hp = maxHp;
	}

    void OnCollisionEnter(Collision c)
    {
        if (speed >= 10)
        {
            hp = 0;
        }
    }

    public IEnumerator GameOver(string message)
    {
        yield return new WaitForSeconds(3.0f);
        GameOverCanvas.transform.GetChild(0).GetComponent<Text>().text = message;
        GameOverCanvas.enabled = true;
    }

    public void takeDamage(int damages)
    {
        hp -= damages;
        HealthBar.GetComponent<HealthBarScript>().Damage(damages);
        if(hp <= 0)
        {
            destroyed();
        }
    }

    void destroyed()
    {
        gameObject.transform.GetComponent<MeshRenderer>().enabled = false;
        planeRigidbody.isKinematic = true;
        GameObject boom = Instantiate<GameObject>(Explosion);
        boom.transform.position = transform.position;
        Destroy(boom, 3);
        StartCoroutine(GameOver("Vous êtes mort"));
    }
	
	// Update is called once per frame
	void Update () {

        planeRigidbody.AddForce(transform.forward * speed);

        if (maxSpeed > 0)
        {
            planeRigidbody.AddForce(Vector3.up * speed / maxSpeed);
        }

        if (speed < maxSpeed)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                speed += Time.deltaTime * acceleration;

            }
        }

        if(speed > 0)
        {
            if (Input.GetKey(KeyCode.LeftControl))
            {
                speed -= Time.deltaTime * acceleration * 2;
            }
        }

        if(Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, -rotationSpeed, 0);
        }
        
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(0, rotationSpeed, 0);
        }

        if (Input.GetKey(KeyCode.Z))
        {
            transform.Rotate(rotationSpeed, 0, 0);

            planeRigidbody.AddForce(transform.up * -speed);
        }
        
        if (Input.GetKey(KeyCode.S))
        {

            transform.Rotate(-rotationSpeed, 0, 0);

            planeRigidbody.AddForce(transform.up * speed);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(0, 0, rotationSpeed * 2);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 0, -rotationSpeed * 2);
        }

    }
}
