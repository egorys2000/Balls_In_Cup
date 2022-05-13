using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubeController : MonoBehaviour
{
    private Vector2 PreviousPos;

    [SerializeField]
    private float RotateSensitivity = 1f;
    [SerializeField]
    private float MaxRotationSpeed = 1f;

    private Touch touch;

    private float Angle;

    void Update()
    {
        // Handle screen touches.
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began) 
            {
                PreviousPos = touch.position;
            }

            if (touch.phase == TouchPhase.Moved)
            {
                Vector2 touch_pos = touch.position;

                Angle = RotateSensitivity * (touch_pos - PreviousPos).x * Time.deltaTime;
                Angle = Mathf.Clamp(Angle, -MaxRotationSpeed, MaxRotationSpeed);
                
                PreviousPos = touch_pos;
                
                transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z + Angle);
            }
        }
    }
}
