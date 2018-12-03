using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewUtility {

    public static bool IsVisibleUnit(GameObject unit, Transform from, float angle, float distance, LayerMask mask)
    {
        bool result = false;
        if (unit != null)
        {
            Eyesight unitEyesight = unit.GetComponent<Eyesight>();
            if (unitEyesight != null)
            {
                /*foreach (Transform visiblePoint in unitEyesight.VisiblePoints)
                {
                    if (IsVisibleObject(from, visiblePoint.position, unit.gameObject, angle, distance, mask))
                    {
                        result = true;
                        break;
                    }
                }*/
            }
        }
        return result;
    }

    public static bool IsVisibleObject(Transform from, Vector3 point, GameObject target, float angle, float distance, LayerMask mask)
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

    public static bool IsAvailablePoint(Transform from, Vector3 point, float angle, float distance)
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
            Debug.DrawRay(from.position, from.transform.position, Color.white);
        }
        else
        {
            Debug.DrawRay(from.position, from.transform.position, Color.red);
        }
        return result;
    }
}
