using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallSphere : MonoBehaviour
{
    public Transform NewTarget;
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
        if (other.GetComponent<GhostController>()!=null) other.GetComponent<GhostController>().Target= NewTarget;
    }
}
