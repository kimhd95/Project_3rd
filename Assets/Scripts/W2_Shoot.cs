using UnityEngine;

public class W2_Shoot : MonoBehaviour {

    public AudioClip sound; 

    void Start()
    {
        Destroy(this.gameObject, 1.0f);
    }
}
