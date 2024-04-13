using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpController : MonoBehaviour
{

    public bool SpeedUpActive;
    public SimpleMovement Movement;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if (!SpeedUpActive) return;
        if (Input.GetMouseButtonDown(0))
        {
            Movement.speedSlowModCurrent = 2;
        }
        if (Input.GetMouseButtonUp(0))
        {
            Movement.speedSlowModCurrent = 1;
        }

    }
    public void OnChange()
    {
        if (Input.GetMouseButton(0) && SpeedUpActive)
            Movement.speedSlowModCurrent = 2;
        else
            Movement.speedSlowModCurrent = 1;

    }
}
