using UnityEngine;

public class bullet : MonoBehaviour {

    public float moveSpeed = 30.0f;
    public GameObject shotPrefab;
    private Vector3 shootDirection;
    private float moveX, moveY;
    public GameObject shootSound;
    public GameObject hitSound;
    

    void Start () {
        Instantiate(shootSound);
        Destroy(this.gameObject, 0.8f);
        shootDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        shootDirection.z = 0.0f;
        shootDirection.Normalize();
    }
	
	void Update () {
        moveX = moveSpeed * Time.deltaTime * shootDirection.x;
        moveY = moveSpeed * Time.deltaTime * shootDirection.y;
        transform.Translate(moveX, moveY, 0);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Instantiate(shotPrefab, this.transform.position, Quaternion.identity);
        Instantiate(hitSound);
        Destroy(this.gameObject);
    }
}
