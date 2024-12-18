using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    public static InputManager instance;

    Movement movement;
    ProjectileLauncher launcher;
    PlayerAvatar player;

    Vector2 speed;


    [SerializeField] float dashCost;
    [SerializeField] int dashDistance;
    [SerializeField] float dashWindow;

    float lastPressedRight;
    float lastPressedLeft;
    float lastPressedUp;
    float lastPressedDown;
    bool isRightPressed;
    bool isLeftPressed;
    bool isUpPressed;
    bool isDownPressed;
    bool wasRightPressed;
    bool wasLeftPressed;
    bool wasUpPressed;
    bool wasDownPressed;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        lastPressedRight = -999f;
        lastPressedLeft = -999f;
        lastPressedUp = -999f;
        lastPressedDown = -999f;
        isRightPressed = false;
        isLeftPressed = false;
        isUpPressed = false;
        isDownPressed = false;
        wasRightPressed = false;
        wasLeftPressed = false;
        wasUpPressed = false;
        wasDownPressed = false;

        movement = GetComponent<Movement>();
        launcher = GetComponent<ProjectileLauncher>();
        player = GetComponent<PlayerAvatar>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(SerialHandler.instance);
        float x = SerialHandler.instance.GetVector().x;
        float y = SerialHandler.instance.GetVector().y;

        Debug.Log(x);

        isRightPressed =  x > 0.9f;
        isLeftPressed = x < 0.1f;
        isUpPressed = y > 0.9f;
        isDownPressed = y < 0.1f;

        speed = (new Vector2(x-0.5f, y-0.5f)).normalized;
        movement.setSpeed(speed);
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -7.7f, -5.5f), Mathf.Clamp(transform.position.y, -4.5f, 4.5f));

        if (Input.GetButton("Fire1"))
        {
            launcher.Fire();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            launcher.SwitchWeapon();
        }

        if (isRightPressed && !wasRightPressed)
        {
            if (Time.time < lastPressedRight + dashWindow)
            {
                if (player.Cost(dashCost))
                {
                    movement.Dash(Vector2.right * dashDistance);
                }
            }
            lastPressedRight = Time.time;
        }

        if (isLeftPressed && !wasLeftPressed)
        {
            if (Time.time < lastPressedLeft + dashWindow)
            {
                if (player.Cost(dashCost))
                {
                    movement.Dash(Vector2.left * dashDistance);
                }
            }
            lastPressedLeft = Time.time;
        }

        if (isUpPressed && !wasUpPressed)
        {
            if (Time.time < lastPressedUp + dashWindow)
            {
                if (player.Cost(dashCost))
                {
                    movement.Dash(Vector2.up * dashDistance);
                }
            }
            lastPressedUp = Time.time;
        }

        if (isDownPressed && !wasDownPressed)
        {
            if (Time.time < lastPressedDown + dashWindow)
            {
                if (player.Cost(dashCost))
                {
                    movement.Dash(Vector2.down * dashDistance);
                }
            }
            lastPressedDown = Time.time;
        }

        wasRightPressed = isRightPressed;
        wasLeftPressed = isLeftPressed;
        wasUpPressed = isUpPressed;
        wasDownPressed = isDownPressed;
    }
}
