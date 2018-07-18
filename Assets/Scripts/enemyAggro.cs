using UnityEngine;

public class enemyAggro : MonoBehaviour
{
    public const float moveSpeed = 4.0f;
    public GameObject DestroyedEffect;
    public GameObject DestroyedSound;
    public int HP = 5;

    Transform target;
    
    void Start()
    {
        try
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        } catch(System.NullReferenceException)
        {

        }
    }
    
    void Update()
    {
        
        if(target != null)
        {
            Vector2 dir = target.position - transform.position;
            transform.position += (target.position - transform.position).normalized * moveSpeed * Time.deltaTime;
        }
    }
    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("Bullet"))
        {
            --HP;
            if (HP < 1)
                Destroy(this.gameObject);
        }
    }
    private void OnDestroy()
    {
        Instantiate(DestroyedSound);
        Instantiate(DestroyedEffect, this.transform.position, Quaternion.identity);
        try
        {
            respawnEnemy.instance.DecreaseEnemyCount(1);
            PlayerMovement.instance.getBigger(0.001f);
            scoreManager.instance.AddScore(1);
        }
        catch (System.NullReferenceException)
        {

        }
    }
}

