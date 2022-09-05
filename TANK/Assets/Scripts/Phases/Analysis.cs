/*
 * Title : Analysis 
 * Authors : Titus Abele, Benjamin Mouchet, Guillaume Mouchet, Dorian Tan
 * Date : 05.09.2022
 */


using UnityEngine;
using UnityEngine.SceneManagement;

public class Analysis : MonoBehaviour
{

    private void OnEnable()
    {
        isOver = false;
        
        StartAnalyse();
    }

    /***************************************************************\
     *                      Methodes publiques                     *
    \***************************************************************/
    public bool IsOver()
    {
        return isOver;
    }

    public bool GameEnded()
    {
        return gameEnded;
    }

    /***************************************************************\
    *                      Methodes private                       *
    \***************************************************************/

    private void StartAnalyse()
    {
        CheckAlive();
        CheckVictory();
        CheckHappening();
        if (analysisTwo)
        {
            DefaultSettings();
            analysisTwo = false;
        }else
        {
            analysisTwo=true;
        }
        isOver = true;
    }

    private void DefaultSettings()
    {
        //Enlever les éléments de chaque TANKs (bouclier, buffs etc)
        
        Object[] shieldtab = FindObjectsOfType(typeof(Shield));
        foreach (Shield shield in shieldtab)
        {
            DestroyImmediate(shield.gameObject);
        }

    }

    private void CheckHappening()
    {
       //TODO
    }

    private void CheckAlive()
    {

        Object[] tankTab = FindObjectsOfType(typeof(TankController));
        Debug.Log("CheckAlive");
        foreach (TankController tank in tankTab)
        {
            if(tank.CompareTag("Tank"))
            {//Get Life
                if (tank.Gethealth()<0)
                {
                    Debug.Log("Player dead");
                    //if player is dead --> spectator Mode
                    tank.gameObject.SetActive(false);
                    

                }
            }
            
        }
    }

    private void CheckVictory()
    {
        //If all player of the same "team" are dead
        int i = 0;
        Object[] tankTab2 = FindObjectsOfType(typeof(TankController));
        Debug.Log("CheckVictory");
        foreach (TankController tank in tankTab2)
        {
            if (tank.CompareTag("Tank"))
            {//Get Life
                if (tank.Gethealth() > 0)
                {
                    i++;
                    winner = tank.gameObject;
                }
            }

        }
        Debug.Log("TTTTTTTTTTTTTTTTTTTTTTTT  " + i + " TTTTTTTTTTTTTTTTTTTTTTTTTTTTt");
        if(i<1) //i<2 for more than 1 players in game // i<1 for one player Game
        {
            endGamePanel.SetActive(true);
            Invoke("EndGame", 5f);
            analysisPanel.SetActive(false);
            gameEnded = true;
            winner.SetActive(false);
            
        }
        //Victory of the other team and end the Game
    }
    private void EndGame()
    {
        Debug.Log("ferme l'appli");
        Application.Quit();
    }

    /***************************************************************\
     *                      Attributes private                     *
    \***************************************************************/

    // Tools
    private bool analysisTwo = false;
    private bool gameEnded = false;
    private GameObject winner;
    [SerializeField] private Happening hp;
    [SerializeField] private GameObject endGamePanel;
    [SerializeField] private GameObject analysisPanel;
    private bool isOver = false;
}
