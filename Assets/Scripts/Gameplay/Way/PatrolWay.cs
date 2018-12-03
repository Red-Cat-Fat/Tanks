using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolWay : MonoBehaviour {
    public List<PatrolWayPoint> Points = new List<PatrolWayPoint>();
    [SerializeField]
    private int _index = 0;

    public void Start()
    {
        _index = 0;
        if (Points.Count == 0)
        {
            Debug.LogError("PointsWay is null");
        }
        for(int i = 0; i < Points.Count; i++)
        {
            Points[i].ID = i;
        }
    }

    public List<PatrolWayPoint> GetPoints()
    {
        return Points;
    }

    public PatrolWayPoint GetCurrentPoint()
    {
        if (_index >= 0 && _index < Points.Count)
        {
            return Points[_index];
        }
        return null;
    }

    public PatrolWayPoint GetPointByIndex(int index)
    {
        if (index > 0 && index < Points.Count)
        {
            _index = index;
            return Points[index];
        }
        return null;
    }

    private PatrolWayPoint GetNextPoint()
    {
        _index++;
        if (_index >= Points.Count)
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
        for (int i = 0; i < Points.Count; i++)
        {
            Gizmos.color = (i==_index) ? Color.green : Color.blue;
            Gizmos.DrawSphere(Points[i].transform.position, 3f);
            if (i > 0)
            {
                Gizmos.DrawLine(Points[i].transform.position, Points[i - 1].transform.position);
            }
            else
            {
                Gizmos.DrawLine(Points[Points.Count - 1].transform.position, Points[0].transform.position);
            }
        }
    }
}
