/*
 * Title : Perk2.cs
 * Authors : Titus Abele, Benjamin Mouchet, Guillaume Mouchet, Dorian Tan
 * Date : 25.08.2022
 * Source : 
 */

using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Perk2 : MonoBehaviour
{ 

    private void OnEnable()
    {
        Debug.Log("Perk2 enabled");
        lockin = false;
        switch (togglePerk2.tag)
        {
            case "Shield":
                shield = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "Shield"), new Vector3(this.transform.position.x,this.transform.position.y,0), Quaternion.identity);
                shieldShield = (Shield)shield.GetComponent<Shield>();
                shieldShield.Setup();
                break;
            case "Katana":
                katana.enabled = true;
                break;
        }
    }

    private void OnDisable()
    {
        Debug.Log("Perk2 disabled");
        if(!lockin)
        {
            Destroy(shield.gameObject);
            lockin = false;
        }
    }

    /***************************************************************\
     *                       Méthodes publics                      *
    \***************************************************************/

    public void LockIn()
    {
        switch (togglePerk2.tag)
        {
            case "Shield":
                shieldShield.LockIn();
                shieldShield.SetLockIn();
                lockin = true;
                break;
        }
    }

    public void Execute()
    {
        switch (togglePerk2.tag)
        {
            case "Shield":
                shieldShield.Execute();
                
                break;
        }
    }


    /***************************************************************\
     *                       Méthodes private                      *
    \***************************************************************/


    /***************************************************************\
     *                      Attributes private                     *
    \***************************************************************/

    // Tools
    private GameObject shield;
    private Shield shieldShield;
    private bool lockin;

    // Components
    [SerializeField] private GameObject shieldObject;
    [SerializeField] private Toggle togglePerk2;
    [SerializeField] private Katana katana;

    //Audios
    [SerializeField] private AudioSource shieldAudio;
}