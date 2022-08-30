/*
 * Title : GroundController.cs
 * Authors : Titus Abele, Benjamin Mouchet, Guillaume Mouchet, Dorian Tan
 * Date : 25.08.2022
 * Source : 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundController : MonoBehaviour
{
    /***************************************************************\
     *                      Methodes private                     *
    \***************************************************************/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ismissile"))
        {
            Destroy(collision.gameObject);
        }
    }

    /***************************************************************\
     *                      Attributes private                     *
    \***************************************************************/

    // Components
}
