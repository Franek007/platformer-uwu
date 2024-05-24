using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LicznikPudelek : MonoBehaviour
{

    private int liczbaPudelek;
    public Text licznik;

    public void zebranoPudelko()
    {
        liczbaPudelek++;
        licznik.text = liczbaPudelek.ToString();
    }


    // Start is called before the first frame update
    void Start()
    {
        liczbaPudelek = 0;
        licznik.text = liczbaPudelek.ToString();
    }
}
