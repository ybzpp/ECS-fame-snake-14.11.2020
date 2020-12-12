using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateCamera : MonoBehaviour
{
    public GameObject Cube;
    public float Speed;
    private Camera Camera;

    private void Start()
    {
        Camera = Camera.main;
    }
    void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            Debug.Log($"Mouse Y: {Input.GetAxis("Mouse Y")}");
            Debug.Log($"Mouse X: {Input.GetAxis("Mouse X")}");

            var x = Input.GetAxis("Mouse X") * Speed * Time.deltaTime;
            var y = Input.GetAxis("Mouse Y") * Speed * Time.deltaTime;

            
        }
        var mousePos = Input.mousePosition;
        var point = Camera.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, Camera.nearClipPlane));
        Cube.transform.rotation = Quaternion.LookRotation(point, Vector3.up);

    }
}
