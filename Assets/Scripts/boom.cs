using UnityEngine;

public class boom : MonoBehaviour {
    
	void Start () {
        Destroy(this.gameObject, 1.3f);
	}
}
