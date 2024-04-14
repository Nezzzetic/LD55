using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallGhostController : MonoBehaviour
{
    public float cooldown;
    public float cooldownRemaining;
    public GameObject CallSphere;
    public ParticleSystem CallSpherePart;
    public ParticleSystem.ShapeModule ParticleSystemShapeType;
    public ParticleSystem.MainModule ParticleSystemMainModule;
    public float SphereDefaultSize;
    public float SphereCurrentSize;
    public float SphereMaxSize;
    public float SphereGrowSpeed;
    public bool CallActive;
    public EnergyController EnergyController;

    // Start is called before the first frame update
    void Start()
    {
        ParticleSystemShapeType = CallSpherePart.shape;
        ParticleSystemMainModule = CallSpherePart.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (!CallActive) return;
        if (Input.GetKey(KeyCode.Space))
        {
            _updateSphere();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CallSphere.SetActive(true);
            EnergyController.weaponActive = true;
        }
        if (Input.GetKeyUp(KeyCode.Space) || Input.GetKey(KeyCode.LeftShift) || Input.GetMouseButton(0))
        {
            CallSphere.SetActive(false);
            //SphereCurrentSize = SphereDefaultSize;
            //CallSphere.transform.localScale = new Vector3(SphereCurrentSize, SphereCurrentSize, SphereCurrentSize);
            //ParticleSystemShapeType.radius = 3 + SphereCurrentSize - 5;
            //ParticleSystemMainModule.startSpeed = -2 * SphereCurrentSize / 6;
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
        if (Input.GetKey(KeyCode.Space) && CallActive)
        {
            CallSphere.SetActive(true); 
        }
         else
        {
            CallSphere.SetActive(false);
            //SphereCurrentSize = SphereDefaultSize;
            //CallSphere.transform.localScale = new Vector3(SphereCurrentSize, SphereCurrentSize, SphereCurrentSize);
            //ParticleSystemShapeType.radius = 3 + SphereCurrentSize - 5;
            //ParticleSystemMainModule.startSpeed = -2 * SphereCurrentSize / 5;
        }
    }

    private void _updateSphere()
    {
        //SphereCurrentSize += SphereGrowSpeed * Time.deltaTime;
        //if (SphereCurrentSize > SphereMaxSize) { SphereCurrentSize = SphereMaxSize; }
        //CallSphere.transform.localScale = new Vector3(SphereCurrentSize, SphereCurrentSize, SphereCurrentSize);
        //ParticleSystemShapeType.radius = 3 + SphereCurrentSize - 5;
        //ParticleSystemMainModule.startSpeed = -2 * SphereCurrentSize / 5;
    }
}
