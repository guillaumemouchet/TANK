/*
 * Title : Perk1.cs
 * Authors : Titus Abele, Benjamin Mouchet, Guillaume Mouchet, Dorian Tan
 * Date : 25.08.2022
 * Source : 
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Perk1 : MonoBehaviour
{
    void Start()
    {
    }

    void Update()
    {
        switch (togglePerk1.tag)
        {
            case "BounceGrenade":
                Debug.Log("coucou");
                BounceGrenade();
                break;
        }
    }
    private void Actions1()
    {

    }
    private void BounceGrenade()
    {
        throw new NotImplementedException();
    }


    /***************************************************************\
     *                      Attributes private                     *
    \***************************************************************/

    // Tools

    // Components
    [SerializeField] private GameObject gObject;
    [SerializeField] private Toggle togglePerk1;

}