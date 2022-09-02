/*
 * Title : TankDisplay.cs
 * Authors : Titus Abele, Benjamin Mouchet, Guillaume Mouchet, Dorian Tan
 * Date : 25.08.2022
 * Source : 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class TankDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        toggleList = new List<Toggle>() 
        { 
            toggleJump, 
            toggleIsmissile, 
            togglePerk1, 
            togglePerk2
        };

        Enable();

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
        
    }

    /***************************************************************\
     *                      Méthodes publiques                     *
    \***************************************************************/

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
    private List<Toggle> toggleList;

    // Components
    [SerializeField] private SO_Tanks tank;

    [SerializeField] private Toggle toggleJump;
    [SerializeField] private Toggle toggleIsmissile;
    [SerializeField] private Toggle togglePerk1;
    [SerializeField] private Toggle togglePerk2;
}
