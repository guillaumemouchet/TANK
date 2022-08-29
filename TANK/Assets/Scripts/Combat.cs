
/*
 * Title : Combat
 * Authors : Titus Abele, Benjamin Mouchet, Guillaume Mouchet, Dorian Tan
 * Date : 29.08.2022
 * Source :
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    public Happening hp;
    // Start is called before the first frame update
    void Start()
    {
        hp = GetComponent<Happening>();
        Debug.Log("Start Combat");
        //Faire toutes les actions des joueurs puis une fois fini fais les Happening
        StartCoroutine(waiter());

        
    }

    IEnumerator waiter()
    {
        Debug.Log("Faire les actions");
        //fais les actions des joueurs

        yield return new WaitForSeconds(4);

        Debug.Log("wait");
        yield return new WaitForSeconds(4);
        Debug.Log("wait");

        yield return new WaitForSeconds(4);
        Debug.Log("wait");

        yield return new WaitForSeconds(4);
        Debug.Log("wait");

        yield return new WaitForSeconds(4);
        Debug.Log("end wait");


        Debug.Log("Faire les Happenings");
        //fais les Happenings
        hp.StartHappening();

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
