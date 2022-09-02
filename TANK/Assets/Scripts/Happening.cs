/*
 * Title : Happening
 * Authors : Titus Abele, Benjamin Mouchet, Guillaume Mouchet, Dorian Tan
 * Date : 29.08.2022
 * Source :
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class Happening : MonoBehaviour
{
    /***************************************************************\
     *                      Methodes publics                       *
    \***************************************************************/

    public void OnEnable()
    {
        isOver = false;
        StartHappening();
    }
    public void StartHappening()
    {
        Debug.Log("Start Happening");
        //maximum d'objets de soutien pas atteint
        if (currentNumberItems <= MaximumItems)
        {
            Debug.Log("RESOLVE");
            ResolveHappening();
        }

        //retour à la phase d'Analyse
        isOver = true;
    }

    public bool IsOver()
    {
        return isOver;
    }

    /***************************************************************\
     *                      Methodes private                       *
    \***************************************************************/

    private void ResolveHappening()
    {
        PlaceHP();
        //set happening to null
        //happening = null;
    }
    
    private void AnnonceHappening()
    {
        //annonce happening
    }

    private void PlaceHP()
    {

        int i = Random.Range(0, HPPackPos.Length ); // +1 pour [a;b]

        GameObject go = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "Health Pack"), HPPackPos[i].transform.position, Quaternion.identity);
        currentNumberItems++;

    }

    /***************************************************************\
     *                      Attributes private                     *
    \***************************************************************/


    [SerializeField] private GameObject healthpack;
    [SerializeField] private GameObject[] HPPackPos;


    private int currentTurn = 0;
    private int happeningTurn = 4;
    private int MaximumItems = 5;

    private int currentNumberItems = 0;
    //private GameObject happening = null;
    private bool isOver = false;

    // Components

}
