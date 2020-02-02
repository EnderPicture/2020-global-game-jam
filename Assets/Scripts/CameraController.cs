using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;

    public float smoothness = 1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = target.position + offset;
        transform.DOMove(new Vector3(pos.x, offset.y, pos.z), smoothness);
    }
}
