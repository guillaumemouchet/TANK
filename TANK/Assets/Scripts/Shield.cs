/*
 * Title : ShieldController.cs
 * Authors : Titus Abele, Benjamin Mouchet, Guillaume Mouchet, Dorian Tan
 * Date : 25.08.2022
 * Source : 
 */

using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield: MonoBehaviourPunCallbacks
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
        lockInTransform = this.transform;
        lockedIn = true;
    }

    public void Execute()
    {
        this.transform.position = lockInTransform.position;
        this.transform.rotation = lockInTransform.rotation;
    }

    /***************************************************************\
     *                      Methodes private                       *
    \***************************************************************/

    private void UpdatePlacement()
    {
        canonPos = this.transform.parent.position;
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
    private Transform lockInTransform;


    // Components

}
