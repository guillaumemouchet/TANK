/*
 * Title : TankController.cs
 * Authors : Titus Abele, Benjamin Mouchet, Guillaume Mouchet, Dorian Tan
 * Date : 25.08.2022
 * Source :
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    void Start()
    {
        canon = this.GetComponent<Canon>();
        currentHealth = so_Tank.HP;
        healthBar.SetMaxHealth(currentHealth);
    }

    void Update()
    {
        if (lockedIn && ready)
        {
            if (isShootableMunition) // dans le cas d'un missile ou d'une grenade
            {
                //GameObject munition = TankDisplay.GetMunition();
                //canon.Shoot(munition);
            }
            else // Shield, jump...
            {
                
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ismissile"))
        {
            currentHealth -= missileDamage;
            healthBar.SetHealth(currentHealth);

            Destroy(collision.gameObject);
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
    private Canon canon;
    private int maxHealth;
    [SerializeField] private int currentHealth;


    [SerializeField] private int missileDamage = 10;
    [SerializeField] private int grenadeDamage;

    [SerializeField] private HealthBar healthBar;
    [SerializeField] private SO_Tanks so_Tank;

    // Components


}
