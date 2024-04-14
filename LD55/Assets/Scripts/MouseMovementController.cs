using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovementController : MonoBehaviour
{
    public Camera camera;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0)) {
            int layerMask = 1 << 6;
            RaycastHit hit;
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
            {
                var step = speed * Time.deltaTime; // calculate distance to move
                transform.position = Vector3.MoveTowards(transform.position, hit.point, step);
            }
        }
    }
}
