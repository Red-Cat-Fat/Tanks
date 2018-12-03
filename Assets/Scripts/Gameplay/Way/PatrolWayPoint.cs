using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolWayPoint : MonoBehaviour {
    public int ID = -1;
    public void OnTriggerEnter(Collider other)
    {
        PatrolController patrolController = other.gameObject.GetComponent<PatrolController>();
        if (patrolController != null)
        {
            patrolController.ConnectToPatrolWayPoint(gameObject);
        }
    }
}
