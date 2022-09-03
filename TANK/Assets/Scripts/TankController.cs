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

public class TankController : MonoBehaviour, IPunInstantiateMagicCallback
{
    private void Start()
    {
        currentHealth = so_Tank.HP;
        healthBar.SetMaxHealth(currentHealth);
    }

    public void OnPhotonInstantiate(PhotonMessageInfo info)
    {
        /*foreach (Player p in PhotonNetwork.PlayerList)
        {
            if (p == PhotonNetwork.LocalPlayer)
            {
                p.TagObject = this.gameObject;
            }
        }*/
    }

    private void OnEnable()
    {
        toggleGroup = this.GetComponentInChildren<ToggleGroup>();

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
        
        if (collision.gameObject.CompareTag("Ismissile"))
        {
            currentHealth -= missileDamage;
            Debug.Log("degat Ismissile est : " + missileDamage);
            Debug.Log("Donc current health est : " + currentHealth);
            healthBar.SetHealth(currentHealth);

            Destroy(collision.gameObject);
        }else if (collision.gameObject.CompareTag("Projectile"))
        {
            currentHealth -= grenadeDamage;
            healthBar.SetHealth(currentHealth);

            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("HealPack"))
        {
            currentHealth = maxHealth;
            healthBar.SetHealth(currentHealth);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("HealPack"))
        {
            currentHealth = 0;
            healthBar.SetHealth(currentHealth);
        }
    }

    private void LockIn()
    {
        //Debug.Log("Tank controller Lock IN");
        if (this.GetComponent<Jump>().isActiveAndEnabled)
        {
            //Debug.Log("jump Lock IN");
            jump.LockIn();
            jumpActionLockedIn = true;
        }
        else if (this.GetComponent<Ismissile>().isActiveAndEnabled)
        {
            Debug.Log("MISSILE Lock IN");
            canon.LockIn();
            ismissileActionLockedIn = true;
        }
        else if (this.GetComponent<Perk1>().isActiveAndEnabled)
        {
            Debug.Log("perk1 Lock IN");
            perk1.LockIn();
            perk1ActionLockedIn = true;
        }
        else if (this.GetComponent<Perk2>().isActiveAndEnabled)
        {
            Debug.Log("perk2 Lock IN");
            perk2.LockIn();
            perk2ActionLockedIn = true;
        }

        Disable();
    }

    public void ExecuteAction()
    {
        // Si jamais le joueur n'a rien fait quand même bloquer
        Disable(); 
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
    private int perk3MunitionCount;
    private int perk4MunitionCount;
    private bool lockedIn;
    private bool ready;
    private bool isShootableMunition;

    private int maxHealth = 100;
    [SerializeField] private int currentHealth;



    [SerializeField] private int missileDamage = 10;
    private bool jumpActionLockedIn = false;
    private bool ismissileActionLockedIn;
    private bool perk1ActionLockedIn = false;
    private bool perk2ActionLockedIn = false;
    private List<Toggle> toggleList;
    private ToggleGroup toggleGroup;

    [SerializeField] private int grenadeDamage = 30;

    [SerializeField] private HealthBar healthBar;
    [SerializeField] private SO_Tanks so_Tank;

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
