using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerAvatar;

public class EnemyAvatar : BaseAvatar
{

    public delegate void OnEnemyDeathEvent();
    public static event OnEnemyDeathEvent onEnemyDeathEvent;
    protected override void Die()
    {
        onEnemyDeathEvent?.Invoke();
        Destroy(gameObject);
    }

}
