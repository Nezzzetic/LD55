using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpController : MonoBehaviour
{

    public bool SpeedUpActive;
    public SimpleMovement Movement;
    public EnergyController EnergyController;
    public GlobalTimeController GlobalTimeController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {

        if (!SpeedUpActive) return;
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            EnergyController.weaponActive = true;
            GlobalTimeController.localSpeedUpActive = true;
            Movement.speedSlowModCurrent = 5;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetMouseButton(0))
        {
            GlobalTimeController.localSpeedUpActive = false;
            Movement.speedSlowModCurrent = 1;
        }
        if (EnergyController.Value==0)
        {
            Movement.speedSlowModCurrent = 1;
            SpeedUpActive = false;
            GlobalTimeController.localSpeedUpActive = false;
        }

    }
    public void OnChange()
    {
        if (Input.GetMouseButton(0) && SpeedUpActive)
        {
            GlobalTimeController.localSpeedUpActive = true;

            Movement.speedSlowModCurrent = 5;
        }
        else
        {
            GlobalTimeController.localSpeedUpActive = false;
            Movement.speedSlowModCurrent = 1;
        }            

    }
}
