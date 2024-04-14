using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpController : MonoBehaviour
{

    public bool SpeedUpActive;
    public SimpleMovement Movement;
    public EnergyController EnergyController;
    public GlobalTimeController GlobalTimeController;
    public GameObject Trail;
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
            Trail.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetMouseButton(0))
        {
            GlobalTimeController.localSpeedUpActive = false;
            Movement.speedSlowModCurrent = 1;
            Trail.SetActive(false);
        }
        if (EnergyController.Value==0)
        {
            Movement.speedSlowModCurrent = 1;
            SpeedUpActive = false;
            Trail.SetActive(false);
            GlobalTimeController.localSpeedUpActive = false;
        }

    }
    public void OnChange()
    {
        if (Input.GetMouseButton(0) && SpeedUpActive)
        {
            GlobalTimeController.localSpeedUpActive = true;

            Trail.SetActive(true);
            Movement.speedSlowModCurrent = 5;
        }
        else
        {
            GlobalTimeController.localSpeedUpActive = false;
            Trail.SetActive(false);
            Movement.speedSlowModCurrent = 1;
        }            

    }
}
