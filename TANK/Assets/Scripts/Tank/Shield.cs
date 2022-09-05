/*
 * Title : Shield Controller
 * Authors : Titus Abele, Benjamin Mouchet, Guillaume Mouchet, Dorian Tan
 * Date : 05.09.2022
 * Source : 
 */


using UnityEngine;


public class Shield: MonoBehaviour
{
    private void OnEnable()
    {
        Debug.Log("Enabled Shield");
    }

    
    private void Update()
    {
        if (!lockedIn)
        {
            UpdatePlacement();
        }
    }

    private void OnDisable()
    {
        Destroy(this);
    }

    /***************************************************************\
     *                      Methodes publiques                     *
    \***************************************************************/

    public void LockIn()
    {
        lockInCanonPos = canonPos;
        lockInMousePos = mousePos;
        lockInDirection = direction;
        lockedIn = true;
    }

    public void Execute()
    {
        this.transform.position = lockInCanonPos;
        this.transform.right = lockInDirection;
        
        lockedIn = true;
    }
    public void Setup()
    {
        lockedIn = false;
    }

    public void SetLockIn()
    {
        lockedIn = true;
    }


    /***************************************************************\
     *                      Methodes private                       *
    \***************************************************************/

    private void UpdatePlacement()
    {
        canonPos = this.transform.position; // this.transform.parent.position;
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = mousePos - canonPos;
        this.transform.right = direction;
    }

    /***************************************************************\
     *                      Attributes private                     *
    \***************************************************************/

    // Tools
    private bool lockedIn;
    private bool shieldSelected;
    private Vector2 canonPos;
    private Vector2 mousePos;
    private Vector2 direction;
    private Vector2 lockInCanonPos;
    private Vector2 lockInMousePos;
    private Vector2 lockInDirection;


    // Components

}
