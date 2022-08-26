/*
 * Title : Player Button 
 * Authors : Titus Abele, Benjamin Mouchet, Guillaume Mouchet, Dorian Tan
 * Date : 26.08.2022
 * Source : https://www.youtube.com/watch?v=onDorc3Qfn0 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using TMPro;

public class PlayerButton : MonoBehaviour
{
    [SerializeField] private TMP_Text playerName;

    public void DisplayPlayer()
    {
        Debug.Log("playername " + playerName.text);
    }

    public void SetPlayer(string nameInput)
    {
        Debug.Log(nameInput);
        playerName.text = nameInput;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
