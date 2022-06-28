using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject go = new GameObject("GameManager");
                go.AddComponent<GameManager>();
            }

            return _instance;
        }
    }

    void Awake()
    {
        _instance = this;
        gameTime = 0;
        spawnCD = 2;
}
    public int score = 0;
    public GameObject enemyBoat;
    public float spawnCD=2;
    public float currentCD=0;
    public int maxhp = 3;
    public int currenthp = 3;
    public float gameTime=0;
    private void Update()
    {
        gameTime += Time.deltaTime;
        if (gameTime % 30 == 0)
        {
            spawnCD -= 0.2f;
        }
        currentCD -= Time.deltaTime;
        if (currentCD <= 0)
        {
            currentCD = spawnCD;
            GameObject boat = Instantiate(enemyBoat);
            float rand = Random.Range(0, 2);
            if (rand ==1)
            {
                boat.transform.position = new Vector2(-7,Random.Range(-2,-5));
                boat.GetComponent<Rigidbody2D>().velocity = new Vector2(2.5f,0);
            }
            else
            {
                boat.transform.position = new Vector2(9, Random.Range(-2, -5));
                boat.GetComponent<Rigidbody2D>().velocity = new Vector2(-2.5f, 0);
            }
            
        }

        if (currenthp <= 0)
        {
            SceneMan.sm.help.SetActive(true);
            Time.timeScale = 0;
        }
    }

}
