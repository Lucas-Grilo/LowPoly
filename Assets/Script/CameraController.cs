using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
  public Transform playerTransform;
    public Vector3 offset;
    public float smoothSpeed = 0.250f;
    // Update is called once per frame
    void Update()
    {
        Vector3 desirePosition = playerTransform.position + offset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, desirePosition, smoothSpeed);
        transform.position = smoothPosition;
 
    }
}