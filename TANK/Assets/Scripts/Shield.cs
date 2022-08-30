/*
 * Title : ShieldController.cs
 * Authors : Titus Abele, Benjamin Mouchet, Guillaume Mouchet, Dorian Tan
 * Date : 25.08.2022
 * Source : 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield: MonoBehaviour
{
    private void Start()
    {
        lockedIn = false;
    }

    private void OnEnable()
    {
        Debug.Log("Enabled Shield");
    }

    private void Update()
    {
        UpdatePlacement();
    }

    private void OnDisable()
    {
        Destroy(this);
    }

    /***************************************************************\
     *                      Methodes publiques                     *
    \***************************************************************/

    public void LockIn()
    {
        lockedIn = true;
    }

    /***************************************************************\
     *                      Methodes private                       *
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
    private bool lockedIn;
    private bool shieldSelected;


    // Components

}
