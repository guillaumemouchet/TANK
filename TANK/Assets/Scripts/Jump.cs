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
    private void Start()
    {
        lockedIn = false;
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        trajectory = new GameObject[numberOfPoints];
        for (int i = 0; i < numberOfPoints; i++)
        {
            trajectory[i] = Instantiate(circleObject, this.transform.position, Quaternion.identity, trajectoryLine.transform);
        }
        Debug.Log("Jump enabled");
    }

    private void Update()
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

        ActivateTrajectoryLine();
        if (Input.GetButtonDown("Jump"))
        {
            Execute();
        }

        if (lockedIn)
        {
            if (execute)
            {
                Execute();
            }
        }
    }

    private void OnDisable()
    {
        DeleteTrajectoryLine();
        Debug.Log("Jump disabled");
    }

    /***************************************************************\
     *                      Methodes publiques                     *
    \***************************************************************/

    public void LockIn()
    {
        lockedIn = true;
    }

    public void Execute()
    {
        rb.velocity = transform.GetChild(0).right * launchForce;
    }

    /***************************************************************\
     *                      Methodes private                       *
    \***************************************************************/

    private void ActivateTrajectoryLine()
    {
        for (int i = 0; i < numberOfPoints; i++)
        {
            trajectory[i].transform.position = PointPosition(i * spaceBetweenPoints);
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
    private bool jumpSelected = false;
    private Vector2 direction;
    private bool lockedIn;
    private bool execute;
    private GameObject[] trajectory;
    [SerializeField] private Transform trajectoryLine; // Container pour les cercles de la trajectoire (QoL)
    [SerializeField] private int numberOfPoints = 25; // Nombres de billes affichés à la projection de trajectoire

    // Force
    [SerializeField] private float launchForce = 1f; // Force de tir choisie
    [SerializeField] private float maxLaunchForce = 15f; // Force maximale de tir
    [SerializeField] private float magicForceScale = 2f; // QoL pour ne pas devoir sortir de l'écran avec la souris
    [SerializeField] private float spaceBetweenPoints = 0.04f; // Espace entre les billes de projection


    // Components
    private Rigidbody2D rb;
    [SerializeField] private GameObject circleObject;
}
