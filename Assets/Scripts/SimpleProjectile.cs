using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleProjectile : Projectile
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePosition();
    }

    public override void Init(float idamage, Vector2 ispeed, Vector2 iposition, Quaternion irotation)
    {
        damage = idamage;
        speed = ispeed;
        position = iposition;
        transform.SetPositionAndRotation(position, irotation);
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
