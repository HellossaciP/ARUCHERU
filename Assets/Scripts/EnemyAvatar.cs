using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAvatar : BaseAvatar
{
    protected override void Die()
    {
        Destroy(gameObject);
    }

}
