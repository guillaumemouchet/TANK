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

public class TankController : MonoBehaviour
{
    void OnEnable()
    {
        toggleList = new List<Toggle>()
        {
            toggleJump,
            toggleIsmissile,
            togglePerk1,
            togglePerk2
        };

        toggleJump.transform.GetChild(0).GetComponent<Text>().text = tank.jumpPerk;
        toggleIsmissile.transform.GetChild(0).GetComponent<Text>().text = tank.ismissilePerk;
        togglePerk1.transform.GetChild(0).GetComponent<Text>().text = tank.perk1;
        togglePerk2.transform.GetChild(0).GetComponent<Text>().text = tank.perk2;

        toggleJump.tag = tank.jumpPerk;
        toggleIsmissile.tag = tank.ismissilePerk;
        togglePerk1.tag = tank.perk1;
        togglePerk2.tag = tank.perk2;

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
        Debug.Log("Tank controller Lock IN");
        if (this.GetComponent<Jump>().isActiveAndEnabled)
        {
            Debug.Log("jump Lock IN");
            jump.LockIn();
        }
        else if (this.GetComponent<Ismissile>().isActiveAndEnabled)
        {
            Debug.Log("MISSILE Lock IN");

            canon.LockIn();
        }
        else if (this.GetComponent<Perk1>().isActiveAndEnabled)
        {
            Debug.Log("perk1 Lock IN");
            perk1.LockIn();
        }
        else if (this.GetComponent<Perk2>().isActiveAndEnabled)
        {
            Debug.Log("perk2 Lock IN");
            perk2.LockIn();
        }

        Disable();
    }

    public void ExecuteAction()
    {

        Debug.Log("Tank controller Execute");
        Debug.Log(toggleJump.isOn);
        Debug.Log(toggleIsmissile.isOn);
        Debug.Log(togglePerk1.isOn);
        Debug.Log(togglePerk2.isOn);
        
        if (this.GetComponent<Jump>().isActiveAndEnabled)
        {
            Debug.Log("jump Execute");
            jump.Execute();
            jump.enabled = false;
        }
        else if (this.GetComponent<Ismissile>().isActiveAndEnabled)
        {
            Debug.Log("Missile Execute");

            canon.Shoot(ismissileObject);
            canon.enabled = false;
        }
        else if (this.GetComponent<Perk1>().isActiveAndEnabled)
        {
            Debug.Log("perk1 Execute");
            perk1.Execute();
            perk1.enabled = false;
        }
        else if (this.GetComponent<Perk2>().isActiveAndEnabled)
        {
            Debug.Log("perk2s Execute");
            perk2.Execute();
            perk2.enabled = false;
        }
        //Enable();
        Debug.Log("RIENNNNNNNNNNNNNNN Execute");
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
    private List<Toggle> toggleList;

    [SerializeField] private int missileDamage = 1;
    [SerializeField] private int grenadeDamage;

    // Components
    private Canon canon;
    private Jump jump;
    private Perk1 perk1;
    private Perk2 perk2;
    [SerializeField] private GameObject ismissileObject;

    [SerializeField] private Toggle toggleJump;
    [SerializeField] private Toggle toggleIsmissile;
    [SerializeField] private Toggle togglePerk1;
    [SerializeField] private Toggle togglePerk2;

    [SerializeField] private SO_Tanks tank;



}
