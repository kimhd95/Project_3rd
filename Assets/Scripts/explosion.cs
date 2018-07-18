using UnityEngine;

public class explosion : MonoBehaviour {
    
	void Start () {
        Destroy(this.gameObject, 1.5f);
	}
}
