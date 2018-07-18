using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public GameObject go;
	void Start () {
        go = GameObject.Find("android");
	}
	
	void Update () {
        this.transform.position = go.transform.position - Vector3.forward;
	}
}
