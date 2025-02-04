using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateScript : MonoBehaviour
{
    private float x;
    private float y;
    public float sensitivity = -1.5f;
    private Vector3 rotate;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        y = Input.GetAxis("Mouse X");
        x = Input.GetAxis("Mouse Y");
        rotate = new Vector3(x * (-sensitivity)/4, y * sensitivity, 0);
        transform.eulerAngles = transform.eulerAngles - rotate;
    }
}
