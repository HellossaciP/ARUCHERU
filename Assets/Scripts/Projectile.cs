using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{

    [SerializeField] protected int maxSpeed;

    protected float damage;
    protected Vector2 speed;
    protected Vector2 position;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePosition();
    }

    public virtual void Init(float idamage, Vector2 ispeed)
    {

    }

    protected virtual void UpdatePosition()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<BaseAvatar>().TakeDamage(damage);
        Debug.Log(damage);
        Destroy(gameObject);
    }
}