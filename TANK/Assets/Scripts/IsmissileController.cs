/*
 * Title : IsmissileController.cs
 * Authors : Titus Abele, Benjamin Mouchet, Guillaume Mouchet, Dorian Tan
 * Date : 25.08.2022
 * Source : 
 */

using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsmissileController : MonoBehaviourPunCallbacks
{
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
    }

    /***************************************************************\
     *                      Attributes private                     *
    \***************************************************************/

    // Components
    private Rigidbody2D rb;
}
