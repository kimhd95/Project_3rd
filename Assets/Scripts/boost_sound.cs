using UnityEngine;

public class boost_sound : MonoBehaviour {

    public AudioClip sound;
    void Start()
    {
        Destroy(this.gameObject, 27.0f);
    }
}
