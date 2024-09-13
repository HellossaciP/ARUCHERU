using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleProjectile : Projectile
{

    [SerializeField] Projectile simpleProjectile;
    void Update()
    {
        UpdatePosition();
    }

    public override void Init(float idamage, Vector2 ispeed, Vector2 iposition, Quaternion irotation)
    {
        damage = idamage;
        speed = ispeed;
        position = iposition;
        transform.SetPositionAndRotation(iposition, irotation);
        transform.Rotate(new Vector3 (0, 0, 30));
        Projectile clone = ProjectileFactory.instance.GetProjectile(ProjectileType.SIMPLE);
        clone.transform.Rotate(new Vector3(0, 0, 60));
        clone.Init(damage, Quaternion.Euler(0, 0, -60) * ispeed, iposition, irotation);
        clone.transform.Rotate(new Vector3(0, 0, -30));
    }

    protected override void UpdatePosition()
    {
        position = transform.position;
        position += maxSpeed * Time.deltaTime * speed;
        transform.position = position;

        if (position.x > 10 || position.y > 10 || position.x < -10 || position.y < -10)
        {
            ProjectileFactory.instance.Release(this);
        }
    }
}
