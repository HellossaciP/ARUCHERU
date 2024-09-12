using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    Movement movement;
    ProjectileLauncher launcher;


    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent<Movement>();
        launcher = GetComponent<ProjectileLauncher>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.setSpeed((new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"))).normalized);
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -7.7f, -5.5f), Mathf.Clamp(transform.position.y, -4.5f, 4.5f));

        if (Input.GetKey(KeyCode.Space))
        {
            launcher.Fire();
        }
    }
}
