/*
 * Title : GrenadeController.cs
 * Authors : Titus Abele, Benjamin Mouchet, Guillaume Mouchet, Dorian Tan
 * Date : 25.08.2022
 * Source : 
 */

using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceGrenade : MonoBehaviourPunCallbacks
{
    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        Invoke("Explode", 5); // Appelle Explode() après 5 secondes
    }

    private void Update()
    {

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
