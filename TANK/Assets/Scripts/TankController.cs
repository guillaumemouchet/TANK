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
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class TankController : MonoBehaviour
{
    private void Start()
    {
        DontDestroyOnLoad(this);
        jumpActionLockedIn = false;
        ismissileActionLockedIn = false;
        perk1ActionLockedIn = false;
        perk2ActionLockedIn = false;
    }

    private void OnEnable()
    {
        Debug.Log("Enabling Tankcontroller");

        jump = this.GetComponent<Jump>();
        canon = this.GetComponent<Canon>();
        perk1 = this.GetComponent<Perk1>();
        perk2 = this.GetComponent<Perk2>();

        toggles = this.GetComponentsInChildren<Toggle>();

        toggles[0].transform.GetChild(0).GetComponent<Text>().text = tankSO.jumpPerk;
        toggles[1].transform.GetChild(0).GetComponent<Text>().text = tankSO.ismissilePerk;
        toggles[2].transform.GetChild(0).GetComponent<Text>().text = tankSO.perk1;
        toggles[3].transform.GetChild(0).GetComponent<Text>().text = tankSO.perk2;

        toggles[0].tag = tankSO.jumpPerk;
        toggles[1].tag = tankSO.ismissilePerk;
        toggles[2].tag = tankSO.perk1;
        toggles[3].tag = tankSO.perk2;

    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            LockIn();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*
        if (collision.gameObject.CompareTag("Ismissile"))
        {
            hitPoints -= missileDamage;
            Destroy(collision.gameObject);
        }*/
    }

    private void LockIn()
    {
        Toggle toggle = null;
        foreach (Toggle element in toggles)
        { 
            if (element.isOn)
            {
                toggle = element;
            }
        }
        if (toggle is not null)
        {
            if (toggle.name.Equals("Jump"))
            {
                Debug.Log("jump Lock IN");
                jump.LockIn();
                jumpActionLockedIn = true;
            }
            else if (toggle.name.Equals("Ismissile"))
            {
                Debug.Log("MISSILE Lock IN");
                canon.LockIn();
                ismissileActionLockedIn = true;
            }
            else if (toggle.name.Equals("Perk1"))
            {
                Debug.Log("perk1 Lock IN");
                perk1.LockIn();
                perk1ActionLockedIn = true;
            }
            else if (toggle.name.Equals("Perk2"))
            {
                Debug.Log("perk2 Lock IN");
                perk2.LockIn();
                perk2ActionLockedIn = true;
            }
            Disable();
        }
    }

    public void ExecuteAction()
    {
        //Debug.Log("ExecuteAction in TankController.cs");
        if (jumpActionLockedIn)
        {
            Debug.Log("jump Execute");
            jump.Execute();
            jump.enabled = false;
            jumpActionLockedIn = false;
        }
        else if (ismissileActionLockedIn)
        {
            Debug.Log("Missile Execute");
            canon.ShootIsmissile();
            canon.enabled = false;
            ismissileActionLockedIn = false;
        }
        else if (perk1ActionLockedIn)
        {
            Debug.Log("perk1 Execute");
            perk1.Execute();
            perk1.enabled = false;
            perk1ActionLockedIn = false;
        }
        else if (perk2ActionLockedIn)
        {
            Debug.Log("perk2s Execute");
            perk2.Execute();
            perk2.enabled = false;
            perk2ActionLockedIn = false;

        }
        //GetEnabled();
    }

    public void Enable()
    {
        foreach (Toggle toggle in toggles)
        {
            toggle.interactable = true;
        }
    }

    public void Disable()
    {
        foreach (Toggle toggle in toggles)
        {
            toggle.interactable = false;
        }
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

    private bool jumpActionLockedIn;
    private bool ismissileActionLockedIn;
    private bool perk1ActionLockedIn;
    private bool perk2ActionLockedIn;
    private Toggle[] toggles;

    [SerializeField] private int grenadeDamage;

    // Components
    private Canon canon;
    private Jump jump;
    private Perk1 perk1;
    private Perk2 perk2;

    [SerializeField] private SO_Tanks tankSO;



}
