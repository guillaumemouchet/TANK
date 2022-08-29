/*
 * Title : Happening
 * Authors : Titus Abele, Benjamin Mouchet, Guillaume Mouchet, Dorian Tan
 * Date : 29.08.2022
 * Source :
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Happening : MonoBehaviour
{
    [SerializeField] private GameObject healthpack;


    private int currentTurn = 0;
    private int happeningTurn = 4;
    private int MaximumItems = 5;
    private int currentNumberItem = 0;
    private GameObject happening = null;
    // Update is called once per frame
    void Update()
    {

    }

    public void StartHappening()
    {
        //debut de la phase de happening
        if(happening == null)
        {
            //Choose Happening
        }
        //calculer le tour de happening
        currentTurn++;
        //Tour d'un happening
        if(currentTurn%happeningTurn ==  0)
        {
            //resoudre le happening
            ResolveHappening();
        } //tour avant le happening
        else if(currentTurn % happeningTurn == 1)
        {
            //annoncer le happening
            AnnonceHappening();
        }

        //maximum d'objets de soutien pas atteint
        if(currentNumberItem<=MaximumItems)
        {
            placeHP();
        }

        //retour à la phase d'Analyse
        Debug.Log("Fin des Happenings");

    }

    private void ResolveHappening()
    {
        //resolve happening

        //set happening to null
        happening = null;
    }
    
    private void AnnonceHappening()
    {
        //annonce happening
    }


    private void placeHP()
    {
        GameObject go = Instantiate(healthpack, new Vector2(200, 200), Quaternion.identity);
        currentNumberItem++;
    }

}
