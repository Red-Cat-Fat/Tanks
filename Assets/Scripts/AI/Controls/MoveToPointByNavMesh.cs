using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToPointByNavMesh : MonoBehaviour, IMove
{
    public float moveSpeed = 10f;
    private NavMeshAgent _navMeshAgent;
    // Use this for initialization
    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.speed = moveSpeed;
    }
    public void LookAt(GameObject target)
    {
        transform.LookAt(target.transform.position);
    }
    public void LookAt(Vector3 target)
    {
        transform.LookAt(target);
    }
    public void MoveTo(Vector3 moveStart, Vector3 moveEnd)
    {
        
        _navMeshAgent.SetDestination(moveEnd);
    }
    public void MoveTo(Vector3 moveStart, GameObject moveEnd)
    {
        MoveTo(moveStart, moveEnd.transform.position);
    }
    public void MoveTo(GameObject moveEnd)
    {
        MoveTo(gameObject.transform.position, moveEnd);
    }
    public void MoveTo(Vector3 moveEnd)
    {
        MoveTo(gameObject.transform.position, moveEnd);
    }
}
