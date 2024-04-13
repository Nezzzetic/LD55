using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GhostGenerator : MonoBehaviour
{
    public float cooldown;
    public float cooldownRemaining;
    public GameObject GhostPrefab;
    public bool ShootActive;
    public Vector2 GenerationX;
    public Vector2 GenerationY;
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
                cooldownRemaining = cooldown;
                CreateGhost();
            }
        }
    }

    public void CreateGhost()
    {
        var rndx = Random.Range(GenerationX.x, GenerationX.y);
        var rndy = Random.Range(GenerationY.x, GenerationY.y);
        var bullet = Instantiate(GhostPrefab, new Vector3(rndx,1,rndy), Quaternion.identity);
    }
}
