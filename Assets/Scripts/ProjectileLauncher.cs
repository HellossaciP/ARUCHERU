using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{

    [SerializeField] Projectile projectile;

    [SerializeField] float damage;
    [SerializeField] Vector2 speed;
    [SerializeField] float cooldown;
    [SerializeField] float cost;
    bool isOnCD;

    PlayerAvatar player;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<PlayerAvatar>();
        isOnCD = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fire()
    {
        if (!(isOnCD || player.IsBurnout()))
        {
            if (player.Cost(cost))
            {
                Projectile nprojectile = Instantiate(projectile, transform.position + transform.right, Quaternion.Euler(0, 0, 90));
                nprojectile.Init(damage, speed);
                StartCoroutine(CoolDown());
            }
        }
    }

    IEnumerator CoolDown()
    {
        isOnCD = true;
        yield return new WaitForSeconds(cooldown);
        isOnCD = false;
    }

    public bool IsFiring()
    {
        return isOnCD;
    }
}
