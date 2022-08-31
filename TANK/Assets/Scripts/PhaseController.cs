using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseController : MonoBehaviour
{
    private void Start()
    {
        InitiatePreparation();
    }

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(5);
        takt = true;
    }
    private void Update()
    {
        if (takt)
        {
            Debug.Log("Entering takt");
            PhaseLogic();
            takt = false;
            StartCoroutine(waiter());
        }

    }


    /***************************************************************\
     *                      Méthodes publiques                     *
    \***************************************************************/


    /***************************************************************\
     *                      Méthodes privates                      *
    \***************************************************************/

    private void PhaseLogic()
    {
        if (!prepPhaseDone)
        {
            if (timer.IsFinished())
            {
                Debug.Log("PREP DONE");
                preparationPanel.SetActive(false);
                prepPhaseDone = true;
                combatPanel.SetActive(true);
            }
        }
        else if (!combatPhaseDone)
        {
            if (CombatOver())
            {
                Debug.Log("COMBAT DONE");
                combatPanel.SetActive(false);
                combatPhaseDone = true;
                analysisPanel.SetActive(true);
            }
        }
        else if (!analPhase1Done)
        {
            if (AnalysisOver())
            {
                Debug.Log("Analysis 1 DONE");
                analysisPanel.SetActive(false);
                analPhase1Done = true;
                happeningPanel.SetActive(true);
            }
        }
        else if (!happeningPhaseDone)
        {
            if (HappeningOver())
            {
                Debug.Log("happening DONE");
                happeningPanel.SetActive(false);
                happeningPhaseDone = true;
                analysisPanel.SetActive(true);
            }
        }
        else
        {
            if (AnalysisOver())
            {
                Debug.Log("Analysis 2 DONE");
                analysisPanel.SetActive(false);
                prepPhaseDone = false;
                combatPhaseDone = false;
                analPhase1Done = false;
                InitiatePreparation();
            }
        }
    }

    private void InitiatePreparation()
    {
        // Lancer timer fait par panel de prép
        Destroy(timer);
        timer = Instantiate(timerObject, preparationPanel.transform);
        preparationPanel.SetActive(true);
    }

    private bool CombatOver()
    {
        // Tester si projectiles ont explosé
        gameObjectArray = GameObject.FindGameObjectsWithTag("Ismissile");
        if (gameObjectArray.Length != 0)
        {
            return false;
        }
        gameObjectArray = GameObject.FindGameObjectsWithTag("BounceGrenade");
        if (gameObjectArray.Length != 0)
        {
            return false;
        }
        // Tester si joueurs sont immobiles
        return !PlayerMoving();
    }

    private bool AnalysisOver()
    {
        Analysis analsysis = analysisPanel.GetComponent<Analysis>();
        return analsysis.IsOver();
    }

    private bool HappeningOver()
    {
        Happening happening = happeningPanel.GetComponent<Happening>();
        return happening.IsOver();

    }

    private bool PlayerMoving()
    {
        GameObject tank = GameObject.FindGameObjectWithTag("Tank");
        return tank.GetComponent<Rigidbody2D>().velocity.magnitude > 0.1f;
    }

    /***************************************************************\
     *                      Attributes private                     *
    \***************************************************************/

    // Tools
    private GameObject[] gameObjectArray;
    private bool prepPhaseDone = false;
    private bool combatPhaseDone = false;
    private bool analPhase1Done = false;
    private bool happeningPhaseDone = false;
    private bool takt = true;
    private Timer timer;

    // Components
    [SerializeField] private GameObject preparationPanel;
    [SerializeField] private GameObject combatPanel;
    [SerializeField] private GameObject happeningPanel;
    [SerializeField] private GameObject analysisPanel;
    [SerializeField] private Timer timerObject;
}
