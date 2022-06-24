using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputLookAtCamera : MonoBehaviour
{
    Vector3 rotation;

    void Update()
    {
        LookAt(Camera.main.transform);
    }

    void LookAt(Transform target)
    {
        transform.LookAt(target.position);
    }
}
