using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZbieraniePudelek : MonoBehaviour
{

    private LicznikPudelek licznikP;

    // Start is called before the first frame update
    void Start()
    {
        licznikP = GameObject.Find("Manager").GetComponent<LicznikPudelek>();
        if (licznikP == null)
        {
            Debug.LogError("LicznikPudelek nie znaleziony");
        }
    }


    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("GameObject1 collided with " + col.name);
        if (col.gameObject.name == "Player") //Tutaj wstaw nazwê obiektu-gracza
        {
            Destroy(this.gameObject);
            licznikP.zebranoPudelko();
        }
    }


}
