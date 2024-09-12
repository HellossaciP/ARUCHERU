using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    Vector2 speed;
    Vector2 position;

    BaseAvatar avatar;

    // Start is called before the first frame update
    void Start()
    {
        avatar = GetComponent<BaseAvatar>();
    }

    // Update is called once per frame
    void Update()
    {
        position = transform.position;
        position += avatar.getMaxSpeed() * Time.deltaTime * speed;
        transform.position = position;
    }

    public void setSpeed(Vector2 newSpeed)
    {
        speed = newSpeed;
    }
}
