using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseWindow : MonoBehaviour
{
    public SceneControl SceneControl;
    public GhostGenerator GhostGenerator;
    public BombRainController BombRainController;
    public GlobalSpeedUp GlobalSpeedUp;
    public GlobalTimeController GlobalTimeController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneControl.RestartLevel();
        }
    }

    public void Lost()
    {
        gameObject.SetActive(true);
        GhostGenerator.ShostGenActive = false;
        GhostGenerator.Sound.enabled = false;
        BombRainController.Sound.enabled = false;
        GlobalSpeedUp.Sound.enabled = false;
        GlobalTimeController.Active= false;
        Time.timeScale = 0;
    }
}
