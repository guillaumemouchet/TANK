/*
 * Title : SO_Tanks.cs
 * Authors : Titus Abele, Benjamin Mouchet, Guillaume Mouchet, Dorian Tan
 * Date : 25.08.2022
 * Source : https://www.youtube.com/watch?v=aPXvoWVabPY
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Tank", menuName = "Tanks")]
public class SO_Tanks : ScriptableObject
{


    /***************************************************************\
     *                      Attributes private                     *
    \***************************************************************/
    [SerializeField] private GameObject prefab;

    public new string name;
    public int HP;
    public int weight;

    public string jumpPerk;
    public string ismissilePerk;
    public string perk1;
    public string perk2;
}
