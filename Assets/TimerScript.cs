using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour {

    public float timer;

    private Text t;

    [SerializeField]
    private GameObject HelicopterSquad;

    [SerializeField]
    private GameObject TankSquad;

    [SerializeField]
    private GameObject Boss;

    [SerializeField]
    private GameObject Plane;

    private bool oneTime = true;

    private bool oneSecondTime = true;

    [SerializeField]
    private GameObject WinScreen;

    [SerializeField]
    private GameObject Tuto1;

    [SerializeField]
    private GameObject Tuto2;

    [SerializeField]
    private GameObject Tuto3;

    // Use this for initialization
    void Start () {
        t = GetComponent<Text>();
        timer = 120;
        TankSquad.SetActive(false);
        Boss.SetActive(false);
        oneTime = true;
        oneSecondTime = true;
        WinScreen.SetActive(false);
        Destroy(Tuto1, 10);
        Tuto2.SetActive(false);
        Tuto3.SetActive(false);
    }

    // Update is called once per frame
    void Update () {
        t.text = (timer.ToString());

        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }

        if(timer <= 0 && (HelicopterSquad.transform.childCount > 0 || TankSquad.transform.childCount > 0 || Boss.transform.childCount > 1))
        {
            timer = 0;
            t.color = new Color(255f, 0f, 0f);
            StartCoroutine(Plane.GetComponent<AircraftDrivingScript>().GameOver("Votre base a été détruite"));
        }

        if(timer > 0 && HelicopterSquad.transform.childCount <= 0)
        {
            if (oneTime == true)
            {
                TankSquad.SetActive(true);
                timer = 120;
                Plane.GetComponent<WeaponScript>().canMissile = true;
                Plane.GetComponent<WeaponScript>().reloadTime = 3;
                Tuto2.SetActive(true);
                Destroy(Tuto2, 10);
                oneTime = false;
            }
        }

        if(timer > 0 && TankSquad.transform.childCount <= 0)
        {
            if (oneSecondTime == true)
            {
                Boss.SetActive(true);
                timer = 180;
                Tuto3.SetActive(true);
                Destroy(Tuto3, 10);
                Plane.GetComponent<WeaponScript>().reloadTime = 0;
                oneSecondTime = false;
            }
        }
        if(Boss.transform.childCount <= 1)
        {
            Boss.GetComponent<BossScript>().destroyed();
            StartCoroutine(Win());
        }
	}

    public IEnumerator Win()
    {
        yield return new WaitForSeconds(3.0f);
        WinScreen.SetActive(true);
    }
}
