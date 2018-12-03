using UnityEngine;

[ExecuteInEditMode]
public class PatrolWay : MonoBehaviour {
    public PatrolWayPoint[] Points;
    [SerializeField]
    private int _index = 0;

    public void Start()
    {
        _index = 0;
        Points = gameObject.GetComponentsInChildren<PatrolWayPoint>();
        for (int i = 0; i < Points.Length; i++)
        {
            Points[i].ID = i;
        }
    }

    public PatrolWayPoint GetCurrentPoint()
    {
        if (_index >= 0 && _index < Points.Length)
        {
            return Points[_index];
        }
        return null;
    }

    public PatrolWayPoint GetPointByIndex(int index)
    {
        if (index > 0 && index < Points.Length)
        {
            _index = index;
            return Points[index];
        }
        return null;
    }

    private PatrolWayPoint GetNextPoint()
    {
        _index++;
        if (_index >= Points.Length)
        {
            _index = 0;
        }
        return Points[_index];
    }

    public int GetIDCurrentPointTurget()
    {
        PatrolWayPoint currentPatrolWayPoint = GetCurrentPoint();
        if (currentPatrolWayPoint != null)
        {
            return Points[_index].ID;
        }
        return -1;
    }

    public PatrolWayPoint IsTrueWay(PatrolWayPoint patrolWayPoint)
    {
        PatrolWayPoint currentPatrolWayPoint = GetCurrentPoint();
        if (currentPatrolWayPoint != null)
        {
            if(patrolWayPoint == currentPatrolWayPoint)
            {
                return GetNextPoint();
            }
            else
            {
                return currentPatrolWayPoint;  
            }
        }
        return null;
    }

    void OnDrawGizmos()
    {
        for (int i = 0; i < Points.Length; i++)
        {
            Gizmos.color = (i==_index) ? Color.green : Color.blue;
            Gizmos.DrawSphere(Points[i].transform.position, 3f);
            if (i > 0)
            {
                Gizmos.DrawLine(Points[i].transform.position, Points[i - 1].transform.position);
            }
            else
            {
                Gizmos.DrawLine(Points[Points.Length - 1].transform.position, Points[0].transform.position);
            }
        }
    }
}
