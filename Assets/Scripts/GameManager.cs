using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField] PlayerAvatar player;
    [SerializeField] EnemyAvatar enemy;
    PlayerAvatar myPlayer;

    bool win = false;
    bool loose = false;

    // Start is called before the first frame update
    void Start()
    {
        myPlayer = Instantiate(player, new Vector2(-7f, 0f), Quaternion.identity);
        PlayerAvatar.onDeathEvent += GameOver;
        StartCoroutine(SpawnEnemies());
    }

    // Update is called once per frame
    void Update()
    {
        if (myPlayer == null)
        {
            loose = true;
        }
    }

    void GameOver()
    {
        SceneManager.LoadScene("Menu");
    }

    IEnumerator SpawnEnemies()
    {
        while (!(win || loose))
        {
            Instantiate(enemy, new Vector2(9, (Random.value - 0.5f) * 8), Quaternion.identity);
            yield return new WaitForSeconds(3);
        }
    }
}
