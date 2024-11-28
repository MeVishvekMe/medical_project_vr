using UnityEngine;

public class LookAtPlayer : MonoBehaviour {
    
    void Update() {
        transform.LookAt(Camera.main.transform.position);
    }
}
