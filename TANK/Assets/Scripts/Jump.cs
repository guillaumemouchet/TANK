/*
 * Title : Jump.cs
 * Authors : Titus Abele, Benjamin Mouchet, Guillaume Mouchet, Dorian Tan
 * Date : 26.08.2022
 * Source : 
 */

using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviourPunCallbacks
{
    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        Debug.Log("Jump enabled");
        trajectoryLineEnabled = true;
        lockedIn = false;
        trajectory = new GameObject[numberOfPoints];
        for (int i = 0; i < numberOfPoints; i++)
        {
            trajectory[i] = Instantiate(circleObject, this.transform.position, Quaternion.identity, trajectoryLine);
        }
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
        Debug.Log("Jump disabled");
        DeleteTrajectoryLine();
    }

    /***************************************************************\
     *                      Methodes publiques                     *
    \***************************************************************/

    public void LockIn()
    {
        lockInLaunchforce = launchForce;
        lockedIn = true;
        trajectoryLineEnabled = false;
        DeleteTrajectoryLine();
    }

    public void Execute()
    {
        Debug.Log("jumping id :" + photonView.IsMine);
        rb.velocity = this.transform.GetChild(0).right * lockInLaunchforce;
    }

    /***************************************************************\
     *                      Methodes private                       *
    \***************************************************************/

    private void ActivateTrajectoryLine()
    {
        if (trajectoryLineEnabled)
        {
            Vector2 canonPos = transform.GetChild(0).position;
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            launchForce = Mathf.Sqrt(Vector2.SqrMagnitude(canonPos - mousePos)) * magicForceScale;

            if (launchForce > maxLaunchForce)
            {
                launchForce = maxLaunchForce;
            }
            direction = mousePos - canonPos;
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
        Vector2 position = (Vector2)this.transform.position + (direction.normalized * launchForce * t) + 0.5f * Physics2D.gravity * (t * t); // formule physique ( => maqique)
        return position;
    }



    /***************************************************************\
     *                      Attributes private                     *
    \***************************************************************/

    // Tools
    private Vector2 direction;
    private bool lockedIn;
    private GameObject[] trajectory;
    private bool trajectoryLineEnabled;
    

    // Force
    private float launchForce = 10f; // Force de tir choisie
    private float magicForceScale = 2f; // QoL pour ne pas devoir sortir de l'écran avec la souris
    //private Transform lockInTransform;
    private float lockInLaunchforce;

    // Params
    [SerializeField] private float maxLaunchForce = 15f; // Force maximale de tir
    [SerializeField] private float spaceBetweenPoints = 0.04f; // Espace entre les billes de projection
    [SerializeField] private int numberOfPoints = 25; // Nombres de billes affichés à la projection de trajectoire

    // Components
    private Rigidbody2D rb;
    [SerializeField] private GameObject circleObject;
    [SerializeField] private Transform trajectoryLine; // Container pour les cercles de la trajectoire (QoL)
}
