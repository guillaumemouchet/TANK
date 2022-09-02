using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseController : MonoBehaviour
{
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        if(timerObject.IsFinished())
        {
            preparationPanel.SetActive(false);
            combatPanel.SetActive(true);
        }
    }

    /***************************************************************\
     *                      Méthodes publiques                     *
    \***************************************************************/

    public void InitiatePreparation()
    {
        // Lancer timer fait par panel de prép
        preparationPanel.SetActive(true);
    }

    /***************************************************************\
     *                      Méthodes privates                      *
    \***************************************************************/


    /***************************************************************\
     *                      Attributes private                     *
    \***************************************************************/

    // Components
    [SerializeField] private GameObject preparationPanel;
    [SerializeField] private GameObject combatPanel;
    [SerializeField] private GameObject happeningPanel;
    [SerializeField] private GameObject analisysPanel;
    [SerializeField] private Timer timerObject;



}
