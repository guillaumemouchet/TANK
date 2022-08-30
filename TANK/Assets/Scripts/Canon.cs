/*
 * Title : Canon.cs
 * Authors : Titus Abele, Benjamin Mouchet, Guillaume Mouchet, Dorian Tan
 * Date : 25.08.2022
 * Source : https://www.youtube.com/watch?v=tNwLaGUJTK4
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class Canon : MonoBehaviour
{

    private void Start()
    {
        photonView = this.GetComponent<PhotonView>();
        trajectory = new GameObject[numberOfPoints];
        for (int i = 0; i < numberOfPoints; i++)
        {
            trajectory[i] = Instantiate(circleObject, firePoint.position, Quaternion.identity);
        }
    }

    private void Update()
    {   
        Vector2 canonPos = transform.GetChild(0).position;
        Vector2 mousePOs = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        launchForce = magicForceScale * Mathf.Sqrt(Vector2.SqrMagnitude(canonPos - mousePOs)); 
        if (launchForce > maxLaunchForce)
        {
            launchForce = maxLaunchForce;
        }
        direction = mousePOs - canonPos;
        transform.GetChild(0).right = direction;

        if(Input.GetMouseButtonDown(1)) // mouse btn 0 = clicque droit
        {
            Shoot(missileObject);
        }

        for (int i = 0; i < numberOfPoints; i++)
        {
            trajectory[i].transform.position = PointPosition(i * spaceBetweenPoints);
        }
    }


    /***************************************************************\
     *                      Methodes public                        *
    \***************************************************************/

    public void Shoot(GameObject objectToShoot)
    {
        if (photonView.IsMine)
        {
            GameObject newMunition = Instantiate(objectToShoot, firePoint.position, firePoint.rotation);
            newMunition.GetComponent<Rigidbody2D>().velocity = transform.GetChild(0).right * launchForce;
        }
    }

    /***************************************************************\
     *                      Methodes private                       *
    \***************************************************************/

    private Vector2 PointPosition(float t)
    {
        Vector2 position = (Vector2)firePoint.position + (direction.normalized * launchForce * t ) + 0.5f * Physics2D.gravity * (t * t); // formule physique
        return position;
    }

    /***************************************************************\
     *                      Attributes private                     *
    \***************************************************************/

    // Tools
    private GameObject[] trajectory;
    private Vector2 direction; // Vecteur direction du entre canon et souris

    // Force
    [SerializeField] private float launchForce = 1f; // Force de tir choisie
    [SerializeField] private float maxLaunchForce = 15f; // Force maximale de tir
    [SerializeField] private float magicForceScale = 4f; // QoL pour ne pas devoir sortir de l'écran avec la souris

    [SerializeField] private int numberOfPoints; // Nombres de billes affichés à la projection de trajectoire
    [SerializeField] private float spaceBetweenPoints = 0.04f; // Espace entre les billes de projection

    // Components
    [SerializeField] private GameObject missileObject;
    [SerializeField] private GameObject grenadeObject;

    [SerializeField] private GameObject circleObject;
    [SerializeField] private Transform firePoint;

    // PhotonView
    private PhotonView photonView;


}
