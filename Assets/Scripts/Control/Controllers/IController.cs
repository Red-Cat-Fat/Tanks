using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IController {
    bool CanFire { get; }
    void Move();
    void StartFire();
    void StopFire();
}
