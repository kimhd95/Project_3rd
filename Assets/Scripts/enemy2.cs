using UnityEngine;

public class enemy2 : MonoBehaviour {

    public const float moveSpeed = 1.0f;
    public float oldD1 = 1;
    public float oldD2 = 1;
    private float d1, d2;
    public GameObject createEnemy;
    public GameObject createEnemy2;
    public GameObject DestroyedEffect;
    public GameObject DestroyedSound;
    public int HP = 30;
    Transform target;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {

        if (target != null)
        {
            Vector2 dir = target.position - transform.position;
            transform.position += (target.position - transform.position).normalized * moveSpeed * Time.deltaTime;
        }
        //moveControl();
    }
    void moveControl()
    {
        float distanceX = moveSpeed * Time.deltaTime;
        float distanceY = moveSpeed * Time.deltaTime;
        int turn = Random.Range(1, 80);

        if (turn == 1)
        {
            d1 = Random.Range((float)-0.99, (float)1.001);
            d2 = Random.Range((float)-0.99, (float)1.001);
            this.gameObject.transform.Translate(d1 * distanceX, d2 * distanceY, 0);
            oldD1 = d1;
            oldD2 = d2;
        }
        else
        {
            this.gameObject.transform.Translate(oldD1 * distanceX, oldD2 * distanceY, 0);
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("Bullet"))
        {
            --HP;
            if (HP < 1)
                Destroy(this.gameObject);
        }
    }
    void OnDestroy()
    {
        Instantiate(DestroyedSound);
        Instantiate(DestroyedEffect, this.transform.position, Quaternion.identity);

        Instantiate(createEnemy2, this.transform.position, Quaternion.identity);
        Instantiate(createEnemy2, this.transform.position + new Vector3(1, 0, 0), Quaternion.identity);
        Instantiate(createEnemy2, this.transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        Instantiate(createEnemy, this.transform.position + new Vector3(1, 1, 0), Quaternion.identity);
        Instantiate(createEnemy, this.transform.position + new Vector3(-1, 0, 0), Quaternion.identity);
        Instantiate(createEnemy, this.transform.position + new Vector3(0, -1, 0), Quaternion.identity);
        Instantiate(createEnemy, this.transform.position + new Vector3(-1, -1, 0), Quaternion.identity);
        Instantiate(createEnemy, this.transform.position + new Vector3(1, -1, 0), Quaternion.identity);
        Instantiate(createEnemy, this.transform.position + new Vector3(-1, 1, 0), Quaternion.identity);

        try
        {
            respawnEnemy.instance.DecreaseEnemyCount(1);
            PlayerMovement.instance.getBigger(0.001f);
            scoreManager.instance.AddScore(10);
        } catch(System.NullReferenceException)
        {

        }
    }
}
