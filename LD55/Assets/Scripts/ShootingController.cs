using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour
{
    public float cooldown;
    public float cooldownRemaining;
    public Bomb BulletPrefab;
    public Transform BulletHome;
    public bool ShootActive;
    public Camera camera;
    public EnergyController EnergyController;

    // Start is called before the first frame update
    void Start()
    {
        ActivateShoot(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (!ShootActive) return;
        
        if (Input.GetMouseButton(0) ) {
            EnergyController.weaponActive = true;
            if (cooldownRemaining > 0)
            {
                cooldownRemaining -= Time.deltaTime;
                if (cooldownRemaining <= 0)
                {
                    cooldownRemaining = cooldown;
                    shoot();
                }
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            cooldownRemaining = cooldown; 
            EnergyController.weaponActive = false; 
        }
        if (EnergyController.Value == 0)
        {
            cooldownRemaining = cooldown;
            ShootActive = false;
        }
    }

    void shoot()
    {
        int layerMask = 1 << 6;
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
        {
            var bullet = Instantiate(BulletPrefab, BulletHome.position + Vector3.up * 1.5f, Quaternion.identity);
            var directionToMouse = Vector3.Normalize(hit.point - BulletHome.position);
            bullet.BombRigidBody.AddForce(directionToMouse *15, ForceMode.VelocityChange);
            bullet.cooldownRemaining = bullet.Lifetime;
            // Do something with the object that was hit by the raycast.
        }

        
    }
    public void ActivateShoot(bool shoot)
    {
        ShootActive= shoot;
        if (ShootActive)
        {
            cooldownRemaining = cooldown;
        }
        else
        {
            cooldownRemaining = 0;
        }
    }
}
