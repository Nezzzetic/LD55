using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageNearController : MonoBehaviour
{
    public float cooldown;
    public float cooldownRemaining;
    public GameObject DamageCollider;
    public bool DamageNearActive;
    public EnergyController EnergyController;
    public Camera camera;
    public Transform bodyVisual;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!DamageNearActive) return;
        if (Input.GetMouseButtonDown(0))
        {
            DamageCollider.SetActive(true);
            EnergyController.weaponActive = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            DamageCollider.SetActive(false);
            EnergyController.weaponActive = false;
        }
        if (Input.GetMouseButton(0))
        {
            int layerMask = 1 << 6;
            RaycastHit hit;
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
            {
                var directionToMouse = new Vector3(hit.point.x,0, hit.point.z) - new Vector3(transform.position.x, 0, transform.position.z);
                transform.rotation = Quaternion.LookRotation(directionToMouse);
            }
        }

        if (EnergyController.Value == 0)
        {
            DamageCollider.SetActive(false);
            DamageNearActive = false;
            EnergyController.weaponActive = false;
        }
    }
}
