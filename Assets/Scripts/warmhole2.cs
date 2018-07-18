using UnityEngine;

public class warmhole2 : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("Player"))
            other.transform.position = new Vector3(9.0f, -24.0f, 0);
    }
}
