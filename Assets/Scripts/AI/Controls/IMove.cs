
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMove {
    void LookAt(GameObject target);
    void MoveTo(Vector3 moveStart, Vector3 moveEnd);
    void MoveTo(Vector3 moveStart, GameObject moveEnd);
    void MoveTo(GameObject moveEnd);
    void MoveTo(Vector3 moveEnd);
}
