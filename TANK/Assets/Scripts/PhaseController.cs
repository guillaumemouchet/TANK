using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PhaseController : MonoBehaviour
{
    private void Start()
    {
        if (PhotonNetwork.LocalPlayer.IsMasterClient)
        {
            timer = preparationPanel.GetComponentInChildren<Timer>();
            //tankController = tank.GetComponent<TankController>();
            prepPhaseDone = false;
            combatPhaseDone = false;
            analPhase1Done = false;
            happeningPhaseDone = false;
        }
    }

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(5);
        takt = true;
    }

    private void Update()
    {
        if (PhotonNetwork.LocalPlayer.IsMasterClient)
        {
            //Debug.Log(PhotonNetwork.LocalPlayer.NickName + " " + PhotonNetwork.LocalPlayer.IsMasterClient);
            if (!gotTankController)
            {
                if (PhotonNetwork.PlayerList.Length != 0)
                {
                    Dictionary<int, Player> playersDict = PhotonNetwork.CurrentRoom.Players;
                    foreach (KeyValuePair<int, Player> keyVal in playersDict)
                    {
                        if (keyVal.Value.IsLocal && keyVal.Value.TagObject != null)
                        {
                            var playerTank = keyVal.Value.TagObject;
                            tankController = ((GameObject)playerTank).GetComponent<TankController>();
                            gotTankController = true;
                        }
                    }
                }
            }
            else if (firstInit)
            {
                firstInit = false;
                InitiatePreparation();
            }

            if (takt)
            {
                Debug.Log("Entering takt");
                PhaseLogic();
                takt = false;
                StartCoroutine(waiter());
            }
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
            else
            {
                Debug.Log("Combat IS NOT over");
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
                happeningPhaseDone = false;
                InitiatePreparation();
            }
        }
    }

    private void InitiatePreparation()
    {
        // Lancer timer fait par panel de prép
        tankController.Enable();
        preparationPanel.SetActive(true);
        
        timer.ResetTimer();
    }

    private bool CombatOver()
    {
        // Tester si projectiles ont explosé
        gameObjectArray = GameObject.FindGameObjectsWithTag("Projectile");
        if (gameObjectArray.Length != 0)
        {
            Debug.Log("There still is a projectile");
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
        return tank.GetComponent<Rigidbody2D>().velocity.magnitude > 1f;
    }


    /***************************************************************\
     *                      Attributes private                     *
    \***************************************************************/

    // Tools
    private GameObject[] gameObjectArray;
    private bool prepPhaseDone ;
    private bool combatPhaseDone;
    private bool analPhase1Done;
    private bool happeningPhaseDone;
    private bool takt = true;
    private bool gotTankController = false;
    private bool firstInit = true;

    // Components
    private TankController tankController;
    [SerializeField] private GameObject preparationPanel;
    [SerializeField] private GameObject combatPanel;
    [SerializeField] private GameObject happeningPanel;
    [SerializeField] private GameObject analysisPanel;
    // [SerializeField] private Timer timer;
    private Timer timer;
    [SerializeField] private GameObject tank;
}
