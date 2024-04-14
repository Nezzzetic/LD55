using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalTimeController : MonoBehaviour
{

    public bool localSpeedUpActive;
    public bool globalSpeedUpActive;
    public float localSpeedMod;
    public float globalSpeedMod;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTime();
    }
    public void UpdateTime()
    {
        var _localSpeedMod=localSpeedUpActive? localSpeedMod : 1f;
        var _globalSpeedMod = globalSpeedUpActive ? globalSpeedMod : 1f;
        Time.timeScale = _localSpeedMod * _globalSpeedMod;
    }
}
