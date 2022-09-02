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
        toggleList = new List<Toggle>()
        {
            toggleJump,
            toggleIsmissile,
            togglePerk1,
            togglePerk2
        };

        Debug.Log("Enabling Tankcontroller");

        toggleJump.transform.GetChild(0).GetComponent<Text>().text = tank.jumpPerk;
        toggleIsmissile.transform.GetChild(0).GetComponent<Text>().text = tank.ismissilePerk;
        togglePerk1.transform.GetChild(0).GetComponent<Text>().text = tank.perk1;
        togglePerk2.transform.GetChild(0).GetComponent<Text>().text = tank.perk2;

        toggleJump.tag = tank.jumpPerk;
        toggleIsmissile.tag = tank.ismissilePerk;
        togglePerk1.tag = tank.perk1;
        togglePerk2.tag = tank.perk2;
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
        foreach (Toggle element in toggleList)
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
                //Debug.Log("jump Lock IN");
                jump.LockIn();
                jumpActionLockedIn = true;
            }
            else if (toggle.name.Equals("Ismissile"))
            {
                //Debug.Log("MISSILE Lock IN");
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
        foreach (Toggle toggle in toggleList)
        {
            toggle.interactable = true;
        }
    }

    public void Disable()
    {
        foreach (Toggle toggle in toggleList)
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
    private List<Toggle> toggleList;

    [SerializeField] private int grenadeDamage;

    // Components
    [SerializeField] private Canon canon;
    [SerializeField] private Jump jump;
    [SerializeField] private Perk1 perk1;
    [SerializeField] private Perk2 perk2;

    [SerializeField] private Toggle toggleJump;
    [SerializeField] private Toggle toggleIsmissile;
    [SerializeField] private Toggle togglePerk1;
    [SerializeField] private Toggle togglePerk2;

    [SerializeField] private SO_Tanks tank;



}
