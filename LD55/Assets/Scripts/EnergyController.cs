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
        UseEnergy=new float[] { ShootValue, CallValue, SpeedUpValue };
    }
    void Update()
    {

        //if (weaponActive)
        //{
        //    var dif = -UseEnergy[currentWeapon] * Time.deltaTime;
        //    if (Value >= dif)
        //    {
        //        Value += dif;
        //    }
        //    else
        //    {
        //        Value = 0;
        //        weaponActive = false;
        //    }
        //}
        //else
        //{
        //    Value += RegenValue * Time.deltaTime;
        //    if (Value > MaxValue) Value = MaxValue;
        //}
    }
}
