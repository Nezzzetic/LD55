using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : MonoBehaviour
{
    public Transform Target;
    public float speed;
    public GameObject DeathFX;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.LookRotation(Target.position - transform.position);
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    public void Death()
    {
        var bullet = Instantiate(DeathFX, transform.position, Quaternion.identity);
        Destroy(bullet,2);
        Destroy(gameObject);
    }
}
