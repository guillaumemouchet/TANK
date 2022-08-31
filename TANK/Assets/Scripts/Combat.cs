
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
    private void Start()
    {
        Debug.Log("Start Combat");
        tankController = tank.GetComponent<TankController>();
        //Faire toutes les actions des joueurs puis une fois fini fais les Happening
        ExecuteAction();
    }

    private void Update()
    {
        
    }

    /***************************************************************\
     *                      Méthodes private                       *
    \***************************************************************/

    private void ExecuteAction()
    {
        tankController.ExecuteAction();
    }


    /***************************************************************\
     *                      Attributes private                     *
    \***************************************************************/
    
    // Tools


    // Components
    private TankController tankController;
    [SerializeField] private GameObject tank;
}
