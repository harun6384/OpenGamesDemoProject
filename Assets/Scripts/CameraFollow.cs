using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject character;
    public Vector3 distance;
    [SerializeField] private float followSpeed;
  
    private void LateUpdate()
    {
        this.transform.position = Vector3.Lerp(this.transform.position, character.transform.position + distance, followSpeed);
    }
}
