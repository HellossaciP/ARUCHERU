using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;


public enum ProjectileType
{
    SIMPLE,
    DOUBLE,
    ENEMY
}

public class ProjectileFactory : MonoBehaviour
{

    public static ProjectileFactory instance;

    [SerializeField] SimpleProjectile simpleProjectile;
    [SerializeField] DoubleProjectile doubleProjectile;
    [SerializeField] SimpleProjectile enemyProjectile;

    List<SimpleProjectile> simpleProjectiles;
    List<DoubleProjectile> doubleProjectiles;
    List<SimpleProjectile> enemyProjectiles;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        simpleProjectiles = new List<SimpleProjectile>();
        doubleProjectiles = new List<DoubleProjectile>();
        enemyProjectiles = new List<SimpleProjectile>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Projectile GetProjectile(ProjectileType type)
    {
        switch (type)
        {
            case ProjectileType.SIMPLE:
                foreach (SimpleProjectile s in simpleProjectiles)
                {
                    if (!s.gameObject.activeInHierarchy)
                    {
                        s.gameObject.SetActive(true);
                        return s;
                    }
                }
                SimpleProjectile ns = Instantiate(simpleProjectile);
                simpleProjectiles.Add(ns);
                return ns;

            case ProjectileType.DOUBLE:
                foreach (DoubleProjectile d in doubleProjectiles)
                {
                    if (!d.gameObject.activeInHierarchy)
                    {
                        d.gameObject.SetActive(true);
                        return d;
                    }
                }
                DoubleProjectile nd = Instantiate(doubleProjectile);
                doubleProjectiles.Add(nd);
                return nd;

            case ProjectileType.ENEMY:
                foreach (SimpleProjectile e in enemyProjectiles)
                {
                    if (!e.isActiveAndEnabled)
                    {
                        e.gameObject.SetActive(true);
                        return e;
                    }
                }
                SimpleProjectile ne = Instantiate(enemyProjectile);
                enemyProjectiles.Add(ne);
                return ne;

            default:
                return null;
        }
    }

    public void Release(Projectile projectile)
    {
        projectile.gameObject.SetActive(false);
    }
}
