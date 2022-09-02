/*
 * Title : HealthBar.cs
 * Authors : Titus Abele, Benjamin Mouchet, Guillaume Mouchet, Dorian Tan
 * Date : 31.08.2022
 * Source : https://www.youtube.com/watch?v=v1UGTTeQzbo
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + offset);
    }

    public void SetHealth(float health, float maxHealth)
    {
        slider.gameObject.SetActive(health < maxHealth);
        slider.value = health;
        slider.maxValue = maxHealth;
    }

    /***************************************************************\
     *                      Attributes private                     *
    \***************************************************************/


    [SerializeField] private Slider slider;
    [SerializeField] private Color low;
    [SerializeField] private Color High;
    [SerializeField] private Vector3 offset;

}
