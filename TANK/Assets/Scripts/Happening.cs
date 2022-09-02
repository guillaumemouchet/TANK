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
    private void Start()
    {
        StartCoroutine(logEverySecond());
    }
    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator logEverySecond()
    {
        while (true)
        {

            yield return new WaitForSeconds(2);
            placeHP();
        }
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
        int i = Random.Range(0, HPPackPos.Length + 1); // +1 pour [a;b]

        GameObject go = Instantiate(healthpack, HPPackPos[i].transform.position, Quaternion.identity);
        currentNumberItem++;
    }

    /***************************************************************\
     *                      Attributes private                     *
    \***************************************************************/

    [SerializeField] private GameObject healthpack;
    [SerializeField] private GameObject[] HPPackPos;


    private int currentTurn = 0;
    private int happeningTurn = 4;
    private int MaximumItems = 5;
    private int currentNumberItem = 0;
    private GameObject happening = null;

}
