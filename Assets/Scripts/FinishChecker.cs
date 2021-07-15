using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishChecker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    // Checks if players triggers/enters finishlight
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player") {
            Debug.Log("Level finished! widepeepoHappy");
            EndTextManager.winner = true;
            GameSceneManager.finished = true;
        }
    }
}
