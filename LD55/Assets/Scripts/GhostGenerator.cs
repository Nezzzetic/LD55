using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GhostGenerator : MonoBehaviour
{
    public float cooldown;
    public float cooldownRemaining;
    public GameObject GhostPrefab;
    public bool ShostGenActive;
    public Vector2 GenerationX;
    public Vector2 GenerationY;
    public Transform DefaultTarget;
    public SummonController SummonController;
    public AudioSource Sound;
    bool soundActive;
    // Start is called before the first frame update
    void Start()
    {
        soundActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!ShostGenActive)  return;
        if (!soundActive) { 
            Sound.Play();
            soundActive = true;
        }
        SummonController.AddVal(Time.deltaTime);
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
        var rnd = Random.Range(0, 3);
        var rndx = GenerationX.x;
        var rndy = GenerationY.x;
        if (rnd==0)
        {
            rndy = Random.Range(GenerationY.x, GenerationY.y);
        }
        if (rnd == 1)
        {
            rndx = Random.Range(GenerationX.x, GenerationX.y);
        }
        if (rnd == 2)
        {
            rndx = GenerationX.y;
            rndy = Random.Range(GenerationY.x, GenerationY.y);
        }
        var bullet = Instantiate(GhostPrefab, new Vector3(rndx,1,rndy), Quaternion.identity);
        bullet.GetComponent<GhostController>().Target=DefaultTarget;
    }
}
