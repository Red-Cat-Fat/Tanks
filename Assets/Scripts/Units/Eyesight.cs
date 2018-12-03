using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eyesight : MonoBehaviour {
    public GameObject CurrentEyes;
    public float VisibleAngle = 70.0f;
    public float VisibleDistance = 20.0f;
    public LayerMask visibleMask;

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        //Gizmos.DrawSphere(Points[i].transform.position, 3f);
        Vector3 vector3 = GetAngleView();
        
        Gizmos.DrawLine(CurrentEyes.transform.position, CurrentEyes.transform.position + vector3);
        vector3.x *= -1;
        Gizmos.DrawLine(CurrentEyes.transform.position, CurrentEyes.transform.position + vector3);
    }

    private Vector3 GetAngleView()
    {
        Vector3 vector3 = new Vector3(Mathf.Sin(VisibleAngle/2 * Mathf.Deg2Rad) * VisibleDistance, 0, Mathf.Cos(VisibleAngle/2 * Mathf.Deg2Rad) * VisibleDistance);
        return vector3;
    }

    public void Start()
    {
        if (CurrentEyes == null)
        {
            CurrentEyes = gameObject;
        }
    }

    public List<GameObject> GetVisibleUnits()
    {
        AIManager aiManager = GameManager.Instance.aiManager;
        List<GameObject> result = new List<GameObject>();
        foreach (GameObject unit in aiManager.units)
        {
            if (unit != null && unit != gameObject && unit.activeInHierarchy && IsVisibleUnit(unit))
            {
                Debug.DrawRay(unit.transform.position, gameObject.transform.position, Color.green);
                result.Add(unit);
            }
        }
        return result;
    }

    public bool IsVisibleUnit(GameObject unit)
    {
        bool result = IsVisibleUnit(unit, CurrentEyes.transform, VisibleAngle, VisibleDistance, visibleMask);
        return result;
    }

    public bool IsVisibleUnit(GameObject unit, Transform from, float angle, float distance, LayerMask mask)
    {
        bool result = false;
        if (unit != null)
        {
            if (IsVisibleObject(from, unit.transform.position, unit.gameObject, angle, distance, mask))
            {
                result = true;
            }
        }
        return result;
    }

    public bool IsVisibleObject(Transform from, Vector3 point, GameObject target, float angle, float distance, LayerMask mask)
    {
        bool result = false;
        if (IsAvailablePoint(from, point, angle, distance))
        {
            Vector3 direction = (point - from.position);
            Ray ray = new Ray(from.position, direction);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, distance, mask.value))
            {
                if (hit.collider.gameObject == target)
                {
                    result = true;
                }
            }
        }
        return result;
    }

    public bool IsAvailablePoint(Transform from, Vector3 point, float angle, float distance)
    {
        bool result = false;

        if (from != null && Vector3.Distance(from.position, point) <= distance)
        {
            Vector3 direction = (point - from.position);
            float dot = Vector3.Dot(from.forward, direction.normalized);
            if (dot < 1)
            {
                float angleRadians = Mathf.Acos(dot);
                float angleDeg = angleRadians * Mathf.Rad2Deg;
                result = (angleDeg <= angle);
            }
            else
            {
                result = true;
            }
        }
        if (result)
        {
            Debug.DrawRay(from.position, point, Color.white);
        }
        else
        {
            Debug.DrawRay(from.position, point, Color.red);
        }
        return result;
    }
}
