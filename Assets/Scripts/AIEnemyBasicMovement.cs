using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIEnemyBasicMovment : MonoBehaviour
{

    Movement movement;

    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent<Movement>();

    }

    // Update is called once per frame
    void Update()
    {
        movement.setSpeed((new Vector2(-1, 0)).normalized);
        if (transform.position.x < -10)
        {
            Destroy(gameObject);
        }

    }
}
