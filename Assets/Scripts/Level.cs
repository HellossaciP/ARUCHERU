using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level
{
    public LevelDescription description;


    public void Initialize(LevelDescription description)
    {
        this.description = description;
    }

    public void Update()
    {
        foreach (EnemyDescription enemy in description.EnemyDescriptions)
        {
            Debug.Log("oo");
            Debug.Log(enemy.SpawnPosition);
            Debug.Log(enemy.SpawnDate);
        }
    }
}
