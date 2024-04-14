using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalTimeController : MonoBehaviour
{

    public bool localSpeedUpActive;
    public bool globalSpeedUpActive;
    public float localSpeedMod;
    public float globalSpeedMod;
    public bool Active;
    // Start is called before the first frame update
    void Start()
    {
        Active=true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!Active) { return; }
        UpdateTime();
    }
    public void UpdateTime()
    {
        var _localSpeedMod=localSpeedUpActive? localSpeedMod : 1f;
        var _globalSpeedMod = globalSpeedUpActive ? globalSpeedMod : 1f;
        Time.timeScale = _localSpeedMod * _globalSpeedMod;
    }
}
