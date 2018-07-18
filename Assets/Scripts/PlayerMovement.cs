using UnityEngine;

public class PlayerMovement : MonoBehaviour {
     
    public static PlayerMovement instance;

    public GameObject bulletPrefab;
    public GameObject laserPrefab;
    public GameObject boosterEffect;
    public GameObject boosterSound;
    public GameObject reloadSound;

    public GameObject gameOver;

    public int speed = 8;
    public float shootDelay = 0.02f;
    public float shootDelay_2 = 1.0f;
    public float shootDelay_3 = 0.1f;
    public float shootDelay_4 = 0.04f;
    private float shootTimer = 1;
    private float shootTimer_2 = 1;
    private float shootTimer_3 = 1;
    private float shootTimer_4 = 1;

    public float MAX_SIZE = 0.7f;
    public int HP = 4;

    public float offset = 0.0f;
    Vector3 difference;
    private float xMove, yMove;
    private float rotation_z;
    
    private float _timer = 0.0f;
    private int shootingMode = 1;

    private float shootAngle = 0f;
    private float shootAngle_2 = 0f;

    private float superTimer = 11.0f;
    private float superDelay = 10.0f;

    void Awake()
    {
        if (!instance) //정적으로 자신을 체크합니다.
            instance = this;
    }
    void Start()
    {
        InvokeRepeating("turnOnBoosterSound", 0.5f, 27.0f);
    }

    void FixedUpdate()
    {
        transform.rotation = Quaternion.identity;
        xMove = Input.GetAxis("Horizontal") * speed * Time.deltaTime; //x축으로 이동할 양 
        yMove = Input.GetAxis("Vertical") * speed * Time.deltaTime; //y축으로 이동할양
        this.transform.Translate(new Vector3(xMove, yMove, 0));  //이동

        getKeyPressInput();
        ShootControl();

        difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();
        rotation_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg - 90.0f;
        transform.rotation = Quaternion.Euler(0f, 0f, rotation_z + offset);

        _timer += Time.deltaTime;
        scoreManager.instance.UpdateTime(_timer);

        Instantiate(boosterEffect, this.transform.position, transform.rotation);
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("Enemy"))
        {
            Destroy(other.gameObject);
            scoreManager.instance.DecreaseHP(1);
            recoverScale();
            if (--HP < 1)
                Destroy(this.gameObject);
        }
    }

    void ShootControl() // 발사를 관리하는 함수 입니다.
    {
        superTimer += Time.deltaTime;
        switch (shootingMode)
        {
            case 1:
                if (shootTimer > shootDelay && Input.GetMouseButton(0)) //쿨타임이 지났는지와, 공격키인 스페이스가 눌려있는지 검사합니다.
                {
                    Instantiate(bulletPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                    shootTimer = 0; //쿨타임을 다시 카운트 합니다.
                }
                shootTimer += Time.deltaTime; //쿨타임을 카운트 합니다.
                break;
            case 2:
                if (shootTimer_2 > shootDelay_2 && Input.GetMouseButton(0))
                {
                    Instantiate(laserPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                    shootTimer_2 = 0;
                }
                shootTimer_2 += Time.deltaTime;
                break;
            case 3:
                if (shootTimer_3 > shootDelay_3 && Input.GetMouseButton(0))
                {
                    Instantiate(bulletPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                    Instantiate(bulletPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, 8)));
                    Instantiate(bulletPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, -8)));
                    Instantiate(bulletPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, 16)));
                    Instantiate(bulletPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, -16)));
                    shootTimer_3 = 0;
                }
                shootTimer_3 += Time.deltaTime;
                break;
            case 4:
                if (shootTimer_4 > shootDelay_4 && Input.GetMouseButton(0))
                {
                    Instantiate(bulletPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, shootAngle)));
                    Instantiate(bulletPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, shootAngle - 90f)));
                    Instantiate(bulletPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, shootAngle + 90f)));
                    Instantiate(bulletPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, shootAngle - 180f)));
                    shootAngle = (shootAngle + 10f) % 360;
                    shootTimer_4 = 0;
                }
                shootTimer_4 += Time.deltaTime;
                break;
            

            case 11:
                if (shootTimer > shootDelay && Input.GetMouseButton(0))
                {
                    Instantiate(bulletPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                    Instantiate(bulletPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, 45)));
                    Instantiate(bulletPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, 90)));
                    Instantiate(bulletPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, 135)));
                    Instantiate(bulletPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, 180)));
                    Instantiate(bulletPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, -45)));
                    Instantiate(bulletPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, -90)));
                    Instantiate(bulletPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, -135)));
                    Instantiate(bulletPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, 15)));
                    Instantiate(bulletPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, 30)));
                    Instantiate(bulletPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, 60)));
                    Instantiate(bulletPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, 75)));
                    Instantiate(bulletPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, 105)));
                    Instantiate(bulletPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, 120)));
                    Instantiate(bulletPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, 150)));
                    Instantiate(bulletPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, 165)));
                    Instantiate(bulletPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, -15)));
                    Instantiate(bulletPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, -30)));
                    Instantiate(bulletPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, -60)));
                    Instantiate(bulletPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, -75)));
                    Instantiate(bulletPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, -105)));
                    Instantiate(bulletPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, -120)));
                    Instantiate(bulletPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, -150)));
                    Instantiate(bulletPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, -165)));
                    shootTimer = 0;
                }
                shootTimer += Time.deltaTime;
                break;
            case 12:
                if (shootTimer_2 > shootDelay && Input.GetMouseButton(0))
                {
                    Instantiate(laserPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, shootAngle_2)));
                    Instantiate(laserPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, shootAngle_2 - 180f)));
                    shootAngle_2 = (shootAngle_2 + 15f) % 360;
                    shootTimer_2 = 0;
                }
                shootTimer_2 += Time.deltaTime;
                break;
            
            default: break;
        }
        
    }
    public void getKeyPressInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            shootingMode = 1;
            Instantiate(reloadSound);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            shootingMode = 2;
            Instantiate(reloadSound);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            shootingMode = 3;
            Instantiate(reloadSound);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            shootingMode = 4;
            Instantiate(reloadSound);
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            if (superTimer > superDelay)
            {
                Instantiate(laserPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                Instantiate(laserPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, 45)));
                Instantiate(laserPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, 90)));
                Instantiate(laserPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, 135)));
                Instantiate(laserPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, 180)));
                Instantiate(laserPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, -45)));
                Instantiate(laserPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, -90)));
                Instantiate(laserPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, -135)));
                Instantiate(laserPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, 15)));
                Instantiate(laserPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, 30)));
                Instantiate(laserPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, 60)));
                Instantiate(laserPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, 75)));
                Instantiate(laserPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, 105)));
                Instantiate(laserPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, 120)));
                Instantiate(laserPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, 150)));
                Instantiate(laserPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, 165)));
                Instantiate(laserPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, -15)));
                Instantiate(laserPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, -30)));
                Instantiate(laserPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, -60)));
                Instantiate(laserPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, -75)));
                Instantiate(laserPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, -105)));
                Instantiate(laserPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, -120)));
                Instantiate(laserPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, -150)));
                Instantiate(laserPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, -165)));
                superTimer = 0;
            }
        }
        else if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            shootingMode = 11;
            Instantiate(reloadSound);
        }
        else if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            shootingMode = 12;
            Instantiate(reloadSound);
        }
    }

    public void getBigger(float incre)
    {
        if (this.transform.localScale.x < MAX_SIZE)
            this.transform.localScale += (new Vector3(incre, incre, 0));
    }
    public void recoverScale()
    {
        this.transform.localScale = new Vector3(0.15f, 0.15f, 0);
    }
    public void healHP(int num)
    {
        this.HP += num;
        try
        {
            scoreManager.instance.IncreaseHP(num);
        } catch(System.NullReferenceException)
        {
        }
    }
    void turnOnBoosterSound()
    {
        Instantiate(boosterSound);
    }
    public void OnDestroy()
    {
        gameOver.SetActive(true);
    }
}
