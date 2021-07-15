using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public GameObject target;
    private NavMeshAgent navMeshAgent;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        navMeshAgent.SetDestination(target.transform.position);
    }

    // Checks if enemy collided with player
    private void OnCollisionEnter(Collision collision) {
		if(collision.collider.tag == "Player") {
			Debug.Log("You got caught! Sadge");
            EndTextManager.looser = true;
			GameSceneManager.finished = true;
		}
	}
}
