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
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(gObject, this.transform);
    }

    // Update is called once per frame
    void Update()
    {
        switch (togglePerk2.tag)
        {
            case "Shield":
                Debug.Log("coucou");
                Shield();
                break;
        }
    }

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

    // Components
    [SerializeField] private GameObject gObject;
    [SerializeField] private Toggle togglePerk2;
}