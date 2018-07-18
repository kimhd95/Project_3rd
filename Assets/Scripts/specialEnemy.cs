using UnityEngine;

public class specialEnemy : MonoBehaviour {

    public const float moveSpeed = 11.0f;
    public float oldD1 = 1;
    public float oldD2 = 1;
    private float d1, d2;
    public GameObject DestroyedEffect;
    public GameObject DestroyedSound;
    public int HP = 15;


    void Update()
    {
        moveControl();
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
            if (--HP < 1)
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
            scoreManager.instance.AddScore(20);
            PlayerMovement.instance.recoverScale();
            PlayerMovement.instance.healHP(1);
        }
        catch (System.NullReferenceException)
        {

        }
    }
}
