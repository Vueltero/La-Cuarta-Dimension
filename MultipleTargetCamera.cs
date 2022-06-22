using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleTargetCamera : MonoBehaviour
{
    public List<Transform> targets;

    public Vector3 offset;

    public static MultipleTargetCamera instance;


    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void LateUpdate()
    {
        if (targets.Count == 0)
            return;

        if (MainScript.instance.pausarCamara == false)
        {
            Vector3 centerPoint = GetCenterPoint();

            Vector3 newPosition = centerPoint + offset;

            Camera.main.transform.position = newPosition;
        }
        else
            return;
    }

    Vector3 GetCenterPoint()
    {
        if (targets.Count == 1)
        {
            return targets[0].position;
        }

        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for (int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }

        return bounds.center;
    }
}
