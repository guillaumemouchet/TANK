/*
 * Title : TankController.cs
 * Authors : Titus Abele, Benjamin Mouchet, Guillaume Mouchet, Dorian Tan
 * Date : 25.08.2022
 * Source :
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    void Start()
    {
        canon = this.GetComponent<Canon>();
        jump = this.GetComponent<Jump>();
        perk1 = this.GetComponent<Perk1>();
        perk2 = this.GetComponent<Perk2>();

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            LockIn();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ismissile"))
        {
            hitPoints -= missileDamage;
            Destroy(collision.gameObject);
        }
    }

    private void LockIn()
    {
        if (this.GetComponent<Jump>().isActiveAndEnabled)
        {
            jump.LockIn();
        }
        else if (this.GetComponent<Ismissile>().isActiveAndEnabled)
        {
            canon.LockIn();
        }
        else if (this.GetComponent<Perk1>().isActiveAndEnabled)
        {
            perk1.LockIn();
        }
        else if (this.GetComponent<Perk2>().isActiveAndEnabled)
        {
            perk2.LockIn();
        }

        TankDisplay tD = gameManager.GetComponent<TankDisplay>();   
        tD.Disable();
    }

    public void ExecuteAction()
    {
        if (this.GetComponent<Jump>().isActiveAndEnabled)
        {
            jump.Execute();
        }
        else if (this.GetComponent<Ismissile>().isActiveAndEnabled)
        {
            canon.Shoot(ismissileObject);
        }
        else if (this.GetComponent<Perk1>().isActiveAndEnabled)
        {
            perk1.Execute();
        }
        else if (this.GetComponent<Perk2>().isActiveAndEnabled)
        {
            perk2.Execute();
        }
        TankDisplay tD = gameManager.GetComponent<TankDisplay>();
        tD.Enable();
    }

    /***************************************************************\
     *                      Attributes private                     *
    \***************************************************************/

    // Tools
    private int hitPoints = 30;
    private int perk3MunitionCount;
    private int perk4MunitionCount;
    private bool lockedIn;
    private bool ready;
    private bool isShootableMunition;

    [SerializeField] private int missileDamage = 1;
    [SerializeField] private int grenadeDamage;

    // Components
    private Canon canon;
    private Jump jump;
    private Perk1 perk1;
    private Perk2 perk2;
    [SerializeField] private GameObject ismissileObject;
    [SerializeField] private GameObject gameManager;


}
