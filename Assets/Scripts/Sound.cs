using UnityEngine;

public class Sound : MonoBehaviour {

    public AudioClip sound;
    void Start()
    {
        Destroy(this.gameObject, 1.5f);
    }
}
