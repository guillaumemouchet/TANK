/*
 * Title : GrenadeController.cs
 * Authors : Titus Abele, Benjamin Mouchet, Guillaume Mouchet, Dorian Tan
 * Date : 25.08.2022
 * Source : 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeController : MonoBehaviour
{
    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        Invoke("Explode", 5); // Appelle Explode() après 5 secondes
    }

    private void Update()
    {
        float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
    private void Explode()
    {
        // Boom
        Destroy(this.gameObject);
    }


    /***************************************************************\
     *                      Attributes private                     *
    \***************************************************************/

    // Components

    private Rigidbody2D rb;
    private float fuseInSeconds;
}
