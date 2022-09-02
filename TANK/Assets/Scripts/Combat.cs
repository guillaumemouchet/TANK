
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
    public Happening hp;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start Combat");
        //Faire toutes les actions des joueurs puis une fois fini fais les Happening
        ExecuteAction();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ExecuteAction()
    {
        tankController.ExecuteAction();
    }

    // Components

    [SerializeField] private TankController tankController;
}
