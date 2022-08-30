using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TankDisplay : MonoBehaviour
{

    public SO_Tanks tank;

    public Text spell1;
    public Text spell2;
    public Text spell3;
    public Text spell4;


    // Start is called before the first frame update
    void Start()
    {
        spell1.text = tank.spell1;
        spell2.text = tank.spell2;
        spell3.text = tank.spell3;
        spell4.text = tank.spell4;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
