/*
 * Title : Jump.cs
 * Authors : Titus Abele, Benjamin Mouchet, Guillaume Mouchet, Dorian Tan
 * Date : 26.08.2022
 * Source : 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{

    private Rigidbody2D rb;
    [SerializeField] private float launchForce;
    Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 canonPos = transform.GetChild(0).position;
        Vector2 mousePOs = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = mousePOs - canonPos;
        transform.GetChild(0).right = direction;

        if (Input.GetButtonDown("Jump"))
        {
            Jumped();
        }
    }

    private void Jumped()
    {
        rb.velocity = transform.GetChild(0).right * launchForce;
    }
}
