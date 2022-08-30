/*
 * Title : ShieldController.cs
 * Authors : Titus Abele, Benjamin Mouchet, Guillaume Mouchet, Dorian Tan
 * Date : 25.08.2022
 * Source : 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldController: MonoBehaviour
{
    private void Start()
    {

    }

    private void Update()
    {
        UpdatePlacement();
    }

    /***************************************************************\
     *                      Methodes private                     *
    \***************************************************************/

    private void UpdatePlacement()
    {
        Vector2 canonPos = this.transform.parent.position;
        Vector2 mousePOs = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePOs - canonPos;
        this.transform.right = direction;
    }

    /***************************************************************\
     *                      Attributes private                     *
    \***************************************************************/

    // Tools


    // Components

}
