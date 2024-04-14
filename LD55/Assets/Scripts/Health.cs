using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int Value;
    public SceneControl SceneControl;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<GhostController>() != null) {
            Destroy(other.gameObject);
            Value--;
            if (Value<=0) SceneControl.RestartLevel();
        }
    }
}