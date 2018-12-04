using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToPointByNavMesh : MonoBehaviour, IMove
{
    public float moveSpeed = 10f;
    [SerializeField]
    private NavMeshAgent _navMeshAgent;
    // Use this for initialization
    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        if(_navMeshAgent == null)
        {
            Debug.LogError("In " + gameObject.name + " NavMeshAgent is null");
        }
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
    public void MoveTo(GameObject moveEnd)
    {
        _navMeshAgent.SetDestination(moveEnd.transform.position);
    }
    public void MoveTo(Vector3 moveEnd)
    {
        _navMeshAgent.SetDestination(moveEnd);
    }
}
