using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bomb : MonoBehaviour
{

    public float StartingSpeed;
    public float Lifetime;
    public float cooldownRemaining;
    public GameObject ExplosionPrefab;
    public Rigidbody BombRigidBody;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (cooldownRemaining > 0)
        {
            cooldownRemaining -= Time.deltaTime;
            if (cooldownRemaining <= 0)
            {
                Expload();
                Destroy(gameObject);
            }
        }
    }

    public void Expload()
    {
        var explosion = Instantiate(ExplosionPrefab, transform.position, Quaternion.identity);
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 3);
        foreach (var hitCollider in hitColliders)
        {
            Debug.Log(hitCollider.gameObject.name);
            if (hitCollider.GetComponent<GhostController>() != null)
                Destroy(hitCollider.gameObject);
        }
        Destroy(explosion, 1);
    }
}