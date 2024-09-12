using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{

    Vector2 speed;
    Vector2 position;
    bool isOnCD;
    [SerializeField] float cooldown;

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

    public void Dash(Vector2 dash)
    {
        if (!isOnCD)
        {
            StartCoroutine(DashCoroutine(dash));
            StartCoroutine(CoolDown());
        }
    }

    IEnumerator DashCoroutine(Vector2 dash)
    {
        avatar.SetInvincibility(true);
        Color original = avatar.GetComponent<SpriteRenderer>().color;
        avatar.GetComponent<SpriteRenderer>().color = Color.yellow;
        for (int i = 0; i < 10; i++)
        {
            position += dash * 1/10;
            transform.position = position;
            yield return new WaitForSeconds(1/100f);
        }
        yield return new WaitForSeconds(1);
        avatar.GetComponent<SpriteRenderer>().color = original;
        avatar.SetInvincibility(false);
    }
    IEnumerator CoolDown()
    {
        isOnCD = true;
        yield return new WaitForSeconds(cooldown);
        isOnCD = false;
    }
}
