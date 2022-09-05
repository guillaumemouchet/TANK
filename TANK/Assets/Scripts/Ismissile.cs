/*
 * Title : Missile
 * Authors : Titus Abele, Benjamin Mouchet, Guillaume Mouchet, Dorian Tan
 * Date : 25.08.2022
 * Source :
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ismissile : MonoBehaviour
{
    private void OnEnable()
    {
        canon = this.GetComponent<Canon>();
        canon.enabled = true;
        Debug.Log("Ismissile enabled");
    }

    void Update()
    {

    }

    private void OnDisable()
    {
        canon.enabled = false;
    } 
    private void OnDestroy() // appelé au Destroy()
    {
        Explode();
    }

    /***************************************************************\
     *                      Methodes private                       *
    \***************************************************************/

    private void Explode()
    {
        Debug.Log("BOOM CHAKALAKA");
    }

    /***************************************************************\
     *                      Attributes private                     *
    \***************************************************************/

    // Components
    [SerializeField] private GameObject ismissileObject;
    private Canon canon;
}
