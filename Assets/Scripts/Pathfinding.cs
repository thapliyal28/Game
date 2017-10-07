using UnityEngine;
using System.Collections;

public class Pathfinding : MonoBehaviour {
    private const float minDistance = 1.5f;
    public Transform target;
    
    // Use this for initialization


    // Update is called once per frame
    void LateUpdate() {
        Debug.Log("Hello");
        if ((transform.position - target.transform.position).sqrMagnitude <= minDistance * minDistance)
        {
            
            Time.timeScale = 0;
            Debug.Log("Game over");

        }

    }
}
