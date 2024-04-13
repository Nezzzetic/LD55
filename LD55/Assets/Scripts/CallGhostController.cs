using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallGhostController : MonoBehaviour
{
    public float cooldown;
    public float cooldownRemaining;
    public GameObject CallSphere;
    public bool CallActive;
    public EnergyController EnergyController;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (!CallActive) return;
        if (Input.GetMouseButtonDown(0))
        {
            CallSphere.SetActive(true);
            EnergyController.weaponActive = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            CallSphere.SetActive(false);
            EnergyController.weaponActive = false;
        }
        if (EnergyController.Value == 0)
        {
            CallSphere.SetActive(false);
            CallActive = false;
            EnergyController.weaponActive = false;
        }

    }

    public void OnChange()
    {
        if (Input.GetMouseButton(0) && CallActive)
        { CallSphere.SetActive(true); }
         else
            CallSphere.SetActive(false);
        
    }
}
