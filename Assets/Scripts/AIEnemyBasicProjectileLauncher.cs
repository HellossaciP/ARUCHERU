using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIEnemyBasicProjectileLauncher : MonoBehaviour
{

    [SerializeField] Projectile projectile;

    [SerializeField] float damage;
    [SerializeField] Vector2 speed;
    [SerializeField] float cooldown;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FireAtWill());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator FireAtWill()
    {
        while(true)
        {
            Projectile nprojectile = ProjectileFactory.instance.GetProjectile(ProjectileType.ENEMY);
            nprojectile.Init(damage, speed, transform.position - transform.right, Quaternion.Euler(0, 0, -90));
            yield return new WaitForSeconds(cooldown);
        }
    }
}
