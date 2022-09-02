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
using System.IO;

public class Canon : MonoBehaviour
{

    private void Start()
    {
        trajectoryLineEnabled = true;
        lockedIn = false;
        photonView = gameObject.GetComponent<PhotonView>();
    }

    private void OnEnable()
    {
        trajectory = new GameObject[numberOfPoints];
        for (int i = 0; i < numberOfPoints; i++)
        {
            trajectory[i] = Instantiate(circleObject, firePoint.position, Quaternion.identity, trajectoryLine);
        }
        Debug.Log("Canon enabled");
    }

    private void Update()
    {   
        if (!lockedIn)
        {
            ActivateTrajectoryLine();
        }
    }
    private void OnDisable()
    {
        trajectoryLineEnabled = true;
        lockedIn = false;
        Debug.Log("Canon disabled");
        DeleteTrajectoryLine();
    }


    /***************************************************************\
     *                      Methodes public                        *
    \***************************************************************/

    public void LockIn()
    {
        lockInLaunchForce = launchForce;
        lockInTransform = this.transform.GetChild(0);
        lockInFirePoint = firePoint;
        lockedIn = true;
        trajectoryLineEnabled = false;
        DeleteTrajectoryLine();
    }

    public void ShootIsmissile()
    {
        this.Shoot(ismissileObject);
    }
    public void Shoot(GameObject objectToShoot) // TODO faire passer la bonne munition
    {
        if (photonView.IsMine)
        {
            string name = objectToShoot.name;
            GameObject newMunition = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", objectToShoot.name), lockInFirePoint.position, lockInFirePoint.rotation);
            newMunition.GetComponent<Rigidbody2D>().velocity = lockInTransform.right * lockInLaunchForce;
        }
    }

    /***************************************************************\
     *                      Methodes private                       *
    \***************************************************************/
    private void ActivateTrajectoryLine()
    {
        if (trajectoryLineEnabled)
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
            for (int i = 0; i < numberOfPoints; i++)
            {
                trajectory[i].transform.position = PointPosition(i * spaceBetweenPoints);
            }
        }
    }

    private void DeleteTrajectoryLine()
    {
        for (int i = 0; i < trajectory.Length; i++)
        {
            Destroy(trajectory[i]);
        }
        // Ne pas détruire trajectoryLine parce que c'est le container - on en aura besoin pour recréer une nouvelle ligne
    }

    private Vector2 PointPosition(float t)
    {
        Vector2 position = (Vector2)firePoint.position + (direction.normalized * launchForce * t ) + 0.5f * Physics2D.gravity * (t * t); // formule physique ( => maqique)
        return position;
    }

    /***************************************************************\
     *                      Attributes private                     *
    \***************************************************************/

    // Tools
    private GameObject[] trajectory;
    private Vector2 direction; // Vecteur direction du entre canon et souris
    private bool lockedIn;
    private float lockInLaunchForce;
    private Transform lockInTransform;
    private Transform lockInFirePoint;
    private bool trajectoryLineEnabled;
    [SerializeField] private Transform trajectoryLine; // Container pour les cercles de la trajectoire (QoL)

    // Force
    [SerializeField] private float launchForce = 1f; // Force de tir choisie
    [SerializeField] private float maxLaunchForce = 15f; // Force maximale de tir
    [SerializeField] private float magicForceScale = 4f; // QoL pour ne pas devoir sortir de l'écran avec la souris
    [SerializeField] private float spaceBetweenPoints = 0.04f; // Espace entre les billes de projection

    // Components
    [SerializeField] private GameObject circleObject;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject ismissileObject;

    [SerializeField] private int numberOfPoints = 50; // Nombres de billes affichés à la projection de trajectoire

    // PhotonView
    private PhotonView photonView;
}
