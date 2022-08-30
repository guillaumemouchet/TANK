/*
 * Title : Missile.cs
 * Authors : Titus Abele, Benjamin Mouchet, Guillaume Mouchet, Dorian Tan
 * Date : 25.08.2022
 * Source : https://www.youtube.com/watch?v=tNwLaGUJTK4
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Missile : MonoBehaviour
{
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
    }

    /***************************************************************\
     *                      Methodes private                     *
    \***************************************************************/

    private void OnDestroy() // appelé au Destroy()
    {
        Explode();
    }

    private void Explode()
    {
        Debug.Log("BOOM CHAKALAKA");
    }

    /***************************************************************\
     *                      Attributes private                     *
    \***************************************************************/

    // Components
    private Rigidbody2D rb;
}
