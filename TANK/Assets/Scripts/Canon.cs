/*
 * Title : Canon.cs
 * Authors : Titus Abele, Benjamin Mouchet, Guillaume Mouchet, Dorian Tan
 * Date : 25.08.2022
 * Source : https://www.youtube.com/watch?v=tNwLaGUJTK4
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Canon : MonoBehaviour
{

    public GameObject missile;
    public float launchForce;
    public Transform firePoint;

    public GameObject point;
    GameObject[] points;
    public int numberOfPoints;
    public float spaceBetweenPoints;
    Vector2 direction;  

    private void Start()
    {
        points = new GameObject[numberOfPoints];
        for (int i = 0; i < numberOfPoints; i++)
        {
            points[i] = Instantiate(point, firePoint.position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {        
        Vector2 canonPos = transform.GetChild(0).position;
        Vector2 mousePOs = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = mousePOs - canonPos;
        transform.GetChild(0).right = direction;

        if(Input.GetMouseButtonDown(1)) // mouse btn 0 = clicque droit
        {
            Shoot();
        }

        for (int i = 0; i < numberOfPoints; i++)
        {
            points[i].transform.position = PointPosition(i * spaceBetweenPoints);
        }
    }

    void Shoot()
    {
        GameObject newMissile = Instantiate(missile, firePoint.position, firePoint.rotation);
        newMissile.GetComponent<Rigidbody2D>().velocity = transform.GetChild(0).right * launchForce;
    }

    Vector2 PointPosition(float t)
    {
        Vector2 position = (Vector2)firePoint.position + (direction.normalized * launchForce * t ) + 0.5f * Physics2D.gravity * (t * t); // rien compris
        return position;
    }
}
