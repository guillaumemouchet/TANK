/*
 * Title : ShieldController.cs
 * Authors : Titus Abele, Benjamin Mouchet, Guillaume Mouchet, Dorian Tan
 * Date : 25.08.2022
 * Source : 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class Shield: MonoBehaviour
{
    private void OnEnable()
    {
        Debug.Log("Enabled Shield");
    }

    public void Setup()
    {
        lockedIn = false;
    }

    public void SetLockIn()
    {
        lockedIn=true;
    }

    private void Update()
    {
        if (!lockedIn)
        {
            UpdatePlacement();
        }
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
        lockInCanonPos = canonPos;
        lockInMousePos = mousePos;
        lockInDirection = direction;
        lockedIn = true;
    }

    public void Execute()
    {
        this.transform.position = lockInCanonPos;
        this.transform.right = lockInDirection;
        
        lockedIn = true;
    }

    /***************************************************************\
     *                      Methodes private                       *
    \***************************************************************/

    private void UpdatePlacement()
    {
        canonPos = this.transform.position; // this.transform.parent.position;
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = mousePos - canonPos;
        this.transform.right = direction;
    }

    /***************************************************************\
     *                      Attributes private                     *
    \***************************************************************/

    // Tools
    private bool lockedIn;
    private bool shieldSelected;
    private Vector2 canonPos;
    private Vector2 mousePos;
    private Vector2 direction;
    private Vector2 lockInCanonPos;
    private Vector2 lockInMousePos;
    private Vector2 lockInDirection;


    // Components

}
