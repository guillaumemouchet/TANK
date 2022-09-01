/*
 * Title : HealthBar.cs
 * Authors : Titus Abele, Benjamin Mouchet, Guillaume Mouchet, Dorian Tan
 * Date : 31.08.2022
 * Source : https://www.youtube.com/watch?v=BLfNP4Sc_iA
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private void Start()
    {
        slider.value = so_Tank.HP;
        Debug.Log("so_HP : " + so_Tank.HP);
        Debug.Log("Health : " + slider.value);
    }

    // Update is called once per frame
    void Update()
    {
        slider.transform.position = Camera.main.WorldToScreenPoint(transform.position + offset);
    }

    public void SetMaxHealth(int maxHealth)
    {
        slider.maxValue = maxHealth;
        slider.value = maxHealth;
    }

    public void SetHealth(int health)
    {
        slider.value = health;
    }

    /***************************************************************\
     *                      Attributes private                     *
    \***************************************************************/


    [SerializeField] private Slider slider;
    [SerializeField] private Vector3 offset;

    [SerializeField] private SO_Tanks so_Tank;

}
