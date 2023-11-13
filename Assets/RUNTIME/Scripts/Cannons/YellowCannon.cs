
using UnityEngine;


public class YellowCannon : Cannon
{
    private void Awake()
    {
        BulletCount = 2;
    }

    private void Update()
    {
        
        AllEnemies = GameObject.FindObjectsOfType<YellowEnemy>();
        
    }

    
}
