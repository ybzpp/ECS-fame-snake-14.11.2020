using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerafollowtest : MonoBehaviour
{

    public Transform CameraTransform;
    public Transform Target;
    public float Speed = 1f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CameraTransform.position = Vector3.Lerp(CameraTransform.position, new Vector3(Target.position.x, CameraTransform.position.y, Target.position.z), Speed * Time.deltaTime);
    }
}
