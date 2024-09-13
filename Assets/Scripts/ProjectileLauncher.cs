using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{

    [SerializeField] Projectile[] projectiles;
    [SerializeField] float[] cooldowns;
    [SerializeField] float[] costs;
    [SerializeField] float[] damages;
    [SerializeField] Vector2[] speeds;

    int weaponID;
    int maxWeaponID;
    bool isOnCD;

    ProjectileType type;

    PlayerAvatar player;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<PlayerAvatar>();
        isOnCD = false;
        maxWeaponID = 1;
        weaponID = 0;
        type = ProjectileType.SIMPLE;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fire()
    {
        if (!(isOnCD || player.IsBurnout()))
        {
            if (player.Cost(costs[weaponID]))
            {
                Projectile nprojectile = ProjectileFactory.instance.GetProjectile(type);
                nprojectile.Init(damages[weaponID], speeds[weaponID], transform.position + transform.right, Quaternion.Euler(0, 0, 90));
                StartCoroutine(CoolDown());
            }
        }
    }

    public void SwitchWeapon()
    {
        if (weaponID == 0)
        {
            weaponID = 1;
            type = ProjectileType.DOUBLE;
        }
        else if ( weaponID == maxWeaponID)
        {
            weaponID = 0;
            type = ProjectileType.SIMPLE;
        }
    }

    IEnumerator CoolDown()
    {
        isOnCD = true;
        yield return new WaitForSeconds(cooldowns[weaponID]);
        isOnCD = false;
    }

    public bool IsFiring()
    {
        return isOnCD;
    }
}
