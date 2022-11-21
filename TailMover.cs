using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TailMover : MonoBehaviour
{
    public int length;
    public LineRenderer lineRenderer;
    public Vector3[] segmentPoses;

    private Vector3[] _segmentV;

    public Transform targetDirection;
    public float targetDistance;
    public float smoothSpeed;
    public float trailSpeed;

    public float wiggleSpeed;
    public float wiggleMagnitude;
    public Transform wiggleDirection;
    
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer.positionCount = length;
        segmentPoses = new Vector3[length];
        _segmentV = new Vector3[length];
    }

    // Update is called once per frame
    void Update()
    {
        wiggleDirection.localRotation = Quaternion.Euler(0, 0, Mathf.Sin(Time.time * wiggleSpeed) * wiggleMagnitude);
        
        segmentPoses[0] = targetDirection.position;

        for (int i = 1; i < segmentPoses.Length; i++)
        {
            segmentPoses[i] = Vector3.SmoothDamp(segmentPoses[i],
                segmentPoses[i - 1] + targetDirection.forward * targetDistance, ref _segmentV[i],
                smoothSpeed + i / trailSpeed);
        }
        
        lineRenderer.SetPositions(segmentPoses);
    }
}
