using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterSteer : MonoBehaviour
{
    public Camera Camera;
    public GameObject trackingSpace;

    Vector3 prevForwardVector;
    float prevYawRelativeToCenter;
    float howMuchUserRotated;
    int directionUserRotated;
    float deltaYawRelativeToCenter;
    float distanceFromCenter;
    float howMuchToAccel;



    // Start is called before the first frame update
    void Start()
    {
        prevForwardVector = Camera.transform.forward;
        prevYawRelativeToCenter=angleBetweenVectors(Camera.transform.forward,trackingSpace.transform.position-Camera.transform.position);
    }
    // Update is called once per frame
    void Update()
    {
        howMuchUserRotated=angleBetweenVectors(prevForwardVector,Camera.transform.forward);
        directionUserRotated=(d(Camera.transform.position+prevForwardVector, Camera.transform.position, Camera.transform.position + Camera.transform.forward)<0)?-1:1;
        deltaYawRelativeToCenter=prevYawRelativeToCenter-angleBetweenVectors(Camera.transform.forward,trackingSpace.transform.position-Camera.transform.position);
        distanceFromCenter= (Camera.transform.position-trackingSpace.transform.position).magnitude;
        howMuchToAccel=((deltaYawRelativeToCenter<0)? - 0.13f: 0.3f) * howMuchUserRotated * directionUserRotated * Mathf.Clamp(distanceFromCenter/.1f/2,0,1);
        if (Mathf.Abs(howMuchToAccel)>0) {
            Debug.Log("I Enter");
        trackingSpace.transform.RotateAround(Camera.transform.position, new Vector3(0,1,0), howMuchToAccel);
        prevForwardVector = Camera.transform.forward;
        prevYawRelativeToCenter=angleBetweenVectors(Camera.transform.forward,trackingSpace.transform.position-Camera.transform.position);
        }
    }

    float d(Vector3 A,Vector3 B,Vector3 C) { return (A.x-B.x)*(C.z-B.z)-(A.z-B.z)*(C.x-B.x); }

    float angleBetweenVectors(Vector3 A, Vector3 B) { return Mathf.Acos(Vector3.Dot(Vector3.Normalize(A),Vector3.Normalize(B))); }
}
