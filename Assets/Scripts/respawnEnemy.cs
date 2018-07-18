using UnityEngine;

public class respawnEnemy : MonoBehaviour {

    public static respawnEnemy instance;
    public bool enableSpawn;
    public GameObject Enemy1, Enemy2, Enemy3;
    float AppearX, AppearY;
    float AppearX2, AppearY2;
    float AppearX3, AppearY3;
    public int enemyCount = 0;
    public int MAX_Count = 500;


    void Awake()
    {
        if (!instance) //정적으로 자신을 체크합니다.
            instance = this;
    }

    public void DecreaseEnemyCount(int num)
    {
        enemyCount -= num;
    }

    void Respawn1()
    {
        if (enemyCount < MAX_Count)
        {
            AppearX = Random.Range(10.0f, 50.0f);
            AppearY = Random.Range(-10.0f, 20.0f);
            Instantiate(Enemy1, new Vector3(AppearX, AppearY, 0f), Quaternion.identity);
            Instantiate(Enemy1, new Vector3(AppearX + 1, AppearY, 0f), Quaternion.identity);
            Instantiate(Enemy1, new Vector3(AppearX, AppearY + 1, 0f), Quaternion.identity);
            Instantiate(Enemy1, new Vector3(AppearX + 1, AppearY + 1, 0f), Quaternion.identity);
            Instantiate(Enemy1, new Vector3(AppearX - 1, AppearY, 0f), Quaternion.identity);
            Instantiate(Enemy1, new Vector3(AppearX, AppearY - 1, 0f), Quaternion.identity);
            Instantiate(Enemy1, new Vector3(AppearX - 1, AppearY - 1, 0f), Quaternion.identity);
            Instantiate(Enemy1, new Vector3(AppearX + 1, AppearY - 1, 0f), Quaternion.identity);
            Instantiate(Enemy1, new Vector3(AppearX - 1, AppearY + 1, 0f), Quaternion.identity);
            enemyCount += 9;
        }
    }
    void Respawn2()
    {
        if (enemyCount < MAX_Count)
        {
            AppearX2 = Random.Range(10.0f, 50.0f);
            AppearY2 = Random.Range(-10.0f, 20.0f);
            Instantiate(Enemy2, new Vector3(AppearX2, AppearY2, 0f), Quaternion.identity);
            enemyCount += 10;
        }
    }
    void Respawn3()
    {
        if (enemyCount < MAX_Count)
        {
            AppearX3 = Random.Range(10.0f, 50.0f);
            AppearY3 = Random.Range(-10.0f, 20.0f);
            Instantiate(Enemy3, new Vector3(AppearX3, AppearY3, 0f), Quaternion.identity);
            Instantiate(Enemy3, new Vector3(AppearX3+2, AppearY3, 0f), Quaternion.identity);
            Instantiate(Enemy3, new Vector3(AppearX3 + 1, AppearY3+1, 0f), Quaternion.identity);
            enemyCount += 3;
        }
    }
	// Use this for initialization
	void Start () {
        InvokeRepeating("Respawn1", 3, 2.0f);
        InvokeRepeating("Respawn2", 10, 10.0f);
        InvokeRepeating("Respawn3", 5, 2.0f);
	}
}
