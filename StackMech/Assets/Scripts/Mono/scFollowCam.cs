using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scFollowCam : MonoBehaviour
{
    [SerializeField]
    Transform _target;

    [SerializeField]
    float smoothSpeed = 2f;
    Vector3 _followOffset = new Vector3(0, 15, -25);

    void LateUpdate()
    {
        Vector3 _tempPos = _target.position + _followOffset;
        Vector3 smoothedPos = Vector3.Lerp(transform.position, _tempPos, smoothSpeed);
        transform.position = smoothedPos;

        transform.LookAt(_tempPos);
    }
}
