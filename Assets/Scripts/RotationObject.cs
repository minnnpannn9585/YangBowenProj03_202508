using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationObject : MonoBehaviour
{
    public float rotationSpeed = 100f;
    private void Update()
    {
        // 旋转
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }
}
