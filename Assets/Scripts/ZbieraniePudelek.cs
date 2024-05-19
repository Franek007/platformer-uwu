using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZbieraniePudelek : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Player")
            Destroy(this.gameObject);
    }
}
