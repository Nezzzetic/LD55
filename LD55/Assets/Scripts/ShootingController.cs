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

    // Start is called before the first frame update
    void Start()
    {
        ActivateShoot(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (!ShootActive) return;
        if (cooldownRemaining>0)
        {
            cooldownRemaining -= Time.deltaTime;
            if (cooldownRemaining <= 0) {
                cooldownRemaining = cooldown;
                shoot();
            }
        }
    }

    void shoot()
    {
        
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            Transform objectHit = hit.transform;
            var bullet = Instantiate(BulletPrefab, hit.point + Vector3.up * 1.5f, Quaternion.identity);
            bullet.BombRigidBody.AddForce(Vector3.down, ForceMode.VelocityChange);
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
            cooldownRemaining= 0;
        }
    }
}
