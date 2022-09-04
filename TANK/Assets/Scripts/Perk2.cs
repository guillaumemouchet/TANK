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
                shieldShield = (Shield)shield.GetComponent<Shield>();
                Shield();
                break;
            case "Katana":
                katana.enabled = true;
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
     *                       Méthodes publics                      *
    \***************************************************************/

    public void LockIn()
    {
        switch (togglePerk2.tag)
        {
            case "Shield":
                shieldShield.LockIn();
                break;
        }
    }

    public void Execute()
    {
        switch (togglePerk2.tag)
        {
            case "Shield":
                break;
        }
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
    private Shield shieldShield;

    // Components
    [SerializeField] private GameObject shieldObject;
    [SerializeField] private Toggle togglePerk2;
    [SerializeField] private Katana katana;
}