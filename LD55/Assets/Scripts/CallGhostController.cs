using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallGhostController : MonoBehaviour
{
    public float cooldown;
    public float cooldownRemaining;
    public GameObject CallSphere;
    public float SphereDefaultSize;
    public float SphereCurrentSize;
    public float SphereMaxSize;
    public float SphereGrowSpeed;
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
        if (Input.GetMouseButton(0))
        {
            _updateSphere();
        }
        if (Input.GetMouseButtonDown(0))
        {
            CallSphere.SetActive(true);
            EnergyController.weaponActive = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            CallSphere.SetActive(false);
            SphereCurrentSize = SphereDefaultSize;
            CallSphere.transform.localScale = new Vector3(SphereCurrentSize, SphereCurrentSize, SphereCurrentSize);
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
        {
            CallSphere.SetActive(true); 
        }
         else
        {
            CallSphere.SetActive(false);
            SphereCurrentSize = SphereDefaultSize;
            CallSphere.transform.localScale = new Vector3(SphereCurrentSize, SphereCurrentSize, SphereCurrentSize);
        }
    }

    private void _updateSphere()
    {
        SphereCurrentSize += SphereGrowSpeed * Time.deltaTime;
        if (SphereCurrentSize > SphereMaxSize) { SphereCurrentSize = SphereMaxSize; }
        CallSphere.transform.localScale = new Vector3(SphereCurrentSize, SphereCurrentSize, SphereCurrentSize);
    }
}
