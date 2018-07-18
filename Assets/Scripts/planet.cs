using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planet : MonoBehaviour {

    public const float moveSpeed = 2.3f;
    public float oldD1 = 1;
    public float oldD2 = 1;
    private float d1, d2;

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
}
