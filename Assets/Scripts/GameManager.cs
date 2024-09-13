using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    [SerializeField] PlayerAvatar player;
    [SerializeField] EnemyAvatar enemy;

    [SerializeField] UIManager uIManager;

    int score;

    [SerializeField] TextAsset level;

    LevelDescription data;
    Level currentLevel;

    float initialTimer;


    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        Instantiate(player, new Vector2(-7f, 0f), Quaternion.identity);
        PlayerAvatar.onDeathEvent += GameOver;
        EnemyAvatar.onEnemyDeathEvent += IncreaseScore;

        data = XmlHelpers.DeserializeFromXML<LevelDescription>(level);
        currentLevel = new Level();
        currentLevel.Initialize(data);

        initialTimer = Time.time;

        foreach (EnemyDescription enemyDescription in currentLevel.description.EnemyDescriptions)
        {
            StartCoroutine(WaitAndSpawn(enemyDescription.SpawnDate, enemyDescription.SpawnPosition));
        }
    }

    // Update is called once per frame
    void Update()
    {
        currentLevel.Update();
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

    IEnumerator WaitAndSpawn(float date, Vector2 position)
    {
        while (Time.time - initialTimer < date)
        {
            yield return new WaitForSeconds(0.1f);
        }
        Instantiate(enemy, position, Quaternion.identity);
    }
}
