/*
 * Title : ActionManager.cs
 * Authors : Titus Abele, Benjamin Mouchet, Guillaume Mouchet, Dorian Tan
 * Date : 25.08.2022
 * Source : 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// USELESS
public class ActionManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Canon>().enabled = true;
        gameObject.GetComponent<Jump>().enabled = false;

    }
    /***************************************************************\
     *                      Methodes private                       *
    \***************************************************************/


    /***************************************************************\
     *                      Methodes publiques                     *
    \***************************************************************/
    public void Jump()
    {
        gameObject.GetComponent<Jump>().enabled = true;
        gameObject.GetComponent<Canon>().enabled = false;
    }

    public void Canon()
    {
        gameObject.GetComponent<Jump>().enabled = false;
        gameObject.GetComponent<Canon>().enabled = true;
    }

    public void Perk1()
    {

    }

    public void Perk2()
    {

    }
    /***************************************************************\
     *                      Attributes private                     *
    \***************************************************************/
    public Button btnJump;
    public Button btnIsmissile;
    public Button btnPerk1;
    public Button btnPerk2;
}
