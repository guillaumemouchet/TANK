
/*
 * Title : Combat
 * Authors : Titus Abele, Benjamin Mouchet, Guillaume Mouchet, Dorian Tan
 * Date : 29.08.2022
 * Source :
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Combat : MonoBehaviour
{   
    private void OnEnable()
    {
        Debug.Log("Start Combat");
        //Faire toutes les actions des joueurs puis une fois fini fais les Happening
        this.GetComponent<TankController>().ExecuteAction();
    }

    private void Update()
    {
        
    }

    /***************************************************************\
     *                      Méthodes private                       *
    \***************************************************************/


    /***************************************************************\
     *                      Attributes private                     *
    \***************************************************************/
    
    // Tools


    // Components
}
