/*
 * Title : Item Collector
 * Authors : Titus Abele, Benjamin Mouchet, Guillaume Mouchet, Dorian Tan
 * Date : 29.08.2022
 * Source :
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private GameObject healthPack;
    [SerializeField] private GameObject damagePack;
    [SerializeField] private GameObject cooldownPack;

    private void OnTriggerEnter2D(Collider2D collision)
       {
            if (collision.gameObject.CompareTag("UtilityObjects"))
            {


                if (collision.gameObject.Equals(healthPack))
                {
                    //heal the player who touch it

                }
                if (collision.gameObject.Equals(damagePack))
                {
                    //Buff damage of the player

                }
                if (collision.gameObject.Equals(cooldownPack))
                {
                    //reset the cooldown of the player

                }

                Destroy(collision.gameObject);

        }
    }
}
