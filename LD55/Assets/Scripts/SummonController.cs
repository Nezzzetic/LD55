using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SummonController : MonoBehaviour
{

    public float Value;
    public float ValueMax;
    public GameObject Rain;
    public Image progressBar;
    public GhostGenerator GhostGenerator;
    public BombRainController BombRainController;
    public GlobalSpeedUp GlobalSpeedUp;
    public GameObject WinScreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddVal(float val)
    {
        if (Value == ValueMax) return;
        Value += val;
        if (Value>=ValueMax)
        {
            GhostGenerator.ShostGenActive = false;
            Rain.SetActive(true);
            WinScreen.SetActive(true);
            GhostGenerator.Sound.enabled= false;
            BombRainController.Sound.enabled= false;
            GlobalSpeedUp.Sound.enabled= false;
            foreach (GameObject ghost in GhostGenerator.ghosts)
            {
                if (ghost != null)
                {
                    ghost.SetActive(false);
                }
            }
            foreach (GameObject bomb in BombRainController.bombs)
            {
                if (bomb != null)
                {
                    bomb.SetActive(false);
                }
            }
        }
        progressBar.fillAmount=Value/ValueMax;
    }
}
