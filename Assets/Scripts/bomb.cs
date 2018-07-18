using UnityEngine;

public class bomb : MonoBehaviour {
    
	void Start () {
        Destroy(this.gameObject, 3.0f);
    }
}
