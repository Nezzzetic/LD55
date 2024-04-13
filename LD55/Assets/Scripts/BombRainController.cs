using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombRainController : MonoBehaviour
{
    public float cooldown;
    public float cooldownRemaining;
    public Bomb BombPrefab;
    public bool ShostGenActive;
    public Vector2 GenerationX;
    public Vector2 GenerationY;
    public Transform DefaultTarget;
    public SummonController SummonController;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!ShostGenActive) return;
        SummonController.AddVal(Time.deltaTime);
        if (cooldownRemaining > 0)
        {
            cooldownRemaining -= Time.deltaTime;
            if (cooldownRemaining <= 0)
            {
                cooldownRemaining = cooldown;
                CreateBomb();
            }
        }
    }

    public void CreateBomb()
    {
        var rndx = Random.Range(GenerationX.x, GenerationX.y);
        var rndy = Random.Range(GenerationY.x, GenerationY.y);
        var bullet = Instantiate(BombPrefab, new Vector3(rndx, 3, rndy), Quaternion.identity);
        bullet.cooldownRemaining = bullet.Lifetime;
    }
}
