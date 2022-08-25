using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Tank", menuName = "Tanks")]
public class SO_Tanks : ScriptableObject
{

    public GameObject prefabs;

    public new string name;
    public int HP;
    public int weight;

    //public Sprite sprite;

    public string spell1;
    public string spell2;
    public string spell3;
    public string spell4;
}
