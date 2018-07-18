using UnityEngine;

public class W1_hitSound : MonoBehaviour {

    public AudioClip sound;
    void Start()
    {
        Destroy(this.gameObject, 1.0f);
    }
}
