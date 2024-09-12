using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField] PlayerAvatar player;
    [SerializeField] EnemyAvatar enemy;

    [SerializeField] UIManager uIManager;

    int score;


    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        Instantiate(player, new Vector2(-7f, 0f), Quaternion.identity);
        PlayerAvatar.onDeathEvent += GameOver;
        EnemyAvatar.onEnemyDeathEvent += IncreaseScore;
        StartCoroutine(SpawnEnemies());
    }

    // Update is called once per frame
    void Update()
    {

    }

    void GameOver()
    {
        SceneManager.LoadScene("Menu");
    }

    void IncreaseScore()
    {
        score += 1;
        uIManager.SetScore(score);
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            Instantiate(enemy, new Vector2(9, (Random.value - 0.5f) * 8), Quaternion.identity);
            yield return new WaitForSeconds(3);
        }
    }
}
