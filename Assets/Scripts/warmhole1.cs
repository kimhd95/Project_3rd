using UnityEngine;

public class warmhole1 : MonoBehaviour {
    
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("Player"))
            other.transform.position = new Vector3(14.0f, 28.0f, 0);
    }
}
