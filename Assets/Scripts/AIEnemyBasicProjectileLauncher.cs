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
            Projectile nprojectile = Instantiate(projectile, transform.position - transform.right, Quaternion.Euler(0, 0, -90));
            nprojectile.Init(damage, speed);
            yield return new WaitForSeconds(cooldown);
        }
    }
}
