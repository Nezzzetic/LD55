using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyController : MonoBehaviour
{
    public float Value;
    public float MaxValue;
    public float SpeedUpValue;
    public float ShootValue;
    public float CallValue;
    public float RegenValue;
    public int currentWeapon;
    public bool weaponActive;
    private float[] UseEnergy;
    void Start()
    {
        
    }
    void Update()
    {

        if (weaponActive)
        {
            Value += UseEnergy[currentWeapon] * Time.deltaTime;
            if (Value < 0) Value = 0;
        }
        else
        {
            Value += RegenValue * Time.deltaTime;
            if (Value > MaxValue) Value = MaxValue;
        }
    }
}
