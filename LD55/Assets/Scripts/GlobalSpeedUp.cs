using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GlobalSpeedUp : MonoBehaviour
{
    public bool SpeedUpActive;
    public float TimeChange;
    public float cooldownRemaining;
    public SummonController SummonController;
    public GlobalTimeController GlobalTimeController;
    public AudioSource Sound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (cooldownRemaining > 0)
        {

            cooldownRemaining -= Time.deltaTime;
            if (cooldownRemaining <= 0)
            {
                cooldownRemaining = -1;
                SpeedUpActive = true;
                Sound.Play();
            }
        }
        if (SpeedUpActive)
        {
            GlobalTimeController.globalSpeedUpActive = true;
            SummonController.AddVal(Time.deltaTime);
        }
        else { 
            GlobalTimeController.globalSpeedUpActive = false;
        }

    }

}
