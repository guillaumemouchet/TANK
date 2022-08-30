/*
 * Title : TankDisplay.cs
 * Authors : Titus Abele, Benjamin Mouchet, Guillaume Mouchet, Dorian Tan
 * Date : 25.08.2022
 * Source : 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TankDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        jumpPerk.text = tank.jumpPerk;
        ismissilePerk.text = tank.ismissilePerk;
        perk1.text = tank.perk1;
        perk2.text = tank.perk2;

        toggleJump.tag = tank.jumpPerk;
        toggleIsmissile.tag = tank.ismissilePerk;
        togglePerk1.tag = tank.perk1;
        togglePerk2.tag = tank.perk2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /***************************************************************\
     *                      Attributes private                     *
    \***************************************************************/

    // Components
    [SerializeField] private SO_Tanks tank;

    [SerializeField] private Text jumpPerk;
    [SerializeField] private Text ismissilePerk;
    [SerializeField] private Text perk1;
    [SerializeField] private Text perk2;

    [SerializeField] private Toggle toggleJump;
    [SerializeField] private Toggle toggleIsmissile;
    [SerializeField] private Toggle togglePerk1;
    [SerializeField] private Toggle togglePerk2;



}
