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
            Rain.SetActive(true);
        }
        progressBar.fillAmount=Value/ValueMax;
    }
}
