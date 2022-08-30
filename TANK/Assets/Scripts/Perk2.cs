/*
 * Title : Perk2.cs
 * Authors : Titus Abele, Benjamin Mouchet, Guillaume Mouchet, Dorian Tan
 * Date : 25.08.2022
 * Source : 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Perk2 : MonoBehaviour
{
    private void Start()
    {
        /*switch (togglePerk2.tag)
        {
            case "Shield":
                Shield();
                break;
        }*/
    }

    private void OnEnable()
    {
        Debug.Log("Perk2 enabled"); 
        switch (togglePerk2.tag)
        {
            case "Shield":
                shield = Instantiate(shieldObject, this.transform);
                Shield();
                break;
        }
    }

    private void Update()
    {

    }

    private void OnDisable()
    {
        Debug.Log("Perk2 disabled");
        Destroy(shield);
    }

    /***************************************************************\
     *                       Méthodes private                      *
    \***************************************************************/

    private void Actions2()
    {

    }

    private void Shield()
    {
        Debug.Log("Shield() called in Perk2.cs");
    }

    /***************************************************************\
     *                      Attributes private                     *
    \***************************************************************/

    // Tools
    private GameObject shield;

    // Components
    [SerializeField] private GameObject shieldObject;
    [SerializeField] private Toggle togglePerk2;
}