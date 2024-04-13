using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMovement : MonoBehaviour
{
    public float speed;
    public float speedSlowModCurrent;
    public float singleStepRotation;
    public float singleStepRotationBase;
    public Transform body;
    public Transform bodyVisual;
    public Vector3 Direction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Time.timeScale = 1f;
            speedSlowModCurrent = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Time.timeScale = 1f;
            speedSlowModCurrent = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Time.timeScale = 2f;
            speedSlowModCurrent = 1;
        }
        Vector3 newDirection = Vector3.RotateTowards(bodyVisual.forward, Direction, singleStepRotation, 0.0f);
        singleStepRotation = singleStepRotation * 0.9f;
        bodyVisual.rotation = Quaternion.LookRotation(newDirection);
        Debug.DrawRay(bodyVisual.position, newDirection, Color.red);
        var vertFlag = false;
        var gorizFlag = false;
        Vector3 _movement = Vector3.zero;
        if (Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow))
        {
            vertFlag = true;
            _movement += Vector3.forward * speed * speedSlowModCurrent * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow) && !Input.GetKey(KeyCode.UpArrow))
        {
            vertFlag = true;
            _movement += Vector3.back * speed * speedSlowModCurrent * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow))
        {
            gorizFlag = true;
            _movement += Vector3.left * speed * speedSlowModCurrent * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow))
        {
            gorizFlag = true;
            _movement += Vector3.right * speed * speedSlowModCurrent * Time.deltaTime;
        }
        if (!gorizFlag && !vertFlag) return;
        if (gorizFlag && vertFlag) _movement = _movement / 2;
        transform.position += _movement;
        Direction = _movement;
        singleStepRotation = singleStepRotationBase;
    }
}
