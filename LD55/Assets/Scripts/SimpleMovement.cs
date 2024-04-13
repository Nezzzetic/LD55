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
    public SpeedUpController SpeedUpController;
    public CallGhostController CallGhostController;
    public ShootingController ShootingController;
    public int weaponIndex;

    // Start is called before the first frame update
    void Start()
    {
        weaponIndex = 0;
        ShootingController.ShootActive = true;
        CallGhostController.CallActive = false;
        SpeedUpController.SpeedUpActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        var a123 = new bool[] { false, false, false };

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (weaponIndex==2) weaponIndex= 0; else weaponIndex++;
            for (var i=0; i<a123.Length; i++)
            {
                if (i == weaponIndex) a123[i] = true; else a123[i] = false;
            }
            if (a123[0])
            {
                ShootingController.ShootActive = true;
                CallGhostController.CallActive = false;
                SpeedUpController.SpeedUpActive = false;
                
            }
            if (a123[1])
            {
                ShootingController.ShootActive = false;
                CallGhostController.CallActive = true;
                SpeedUpController.SpeedUpActive = false;
            }
            if (a123[2])
            {
                ShootingController.ShootActive = false;
                CallGhostController.CallActive = false;
                SpeedUpController.SpeedUpActive = true;
            }
            CallGhostController.OnChange();
            SpeedUpController.OnChange();
        }
        //if (Input.GetKeyDown(KeyCode.Alpha1) || a123[0])
        //{
        //    ShootingController.ShootActive = true;
        //    CallGhostController.CallActive= false;
        //    SpeedUpController.SpeedUpActive = false;
        //}
        //if (Input.GetKeyDown(KeyCode.Alpha2) || a123[1])
        //{
        //    ShootingController.ShootActive = false;
        //    CallGhostController.CallActive = true;
        //    SpeedUpController.SpeedUpActive = false;
        //}
        //if (Input.GetKeyDown(KeyCode.Alpha3) || a123[2])
        //{
        //    ShootingController.ShootActive = false;
        //    CallGhostController.CallActive = false;
        //    SpeedUpController.SpeedUpActive = true;
        //}
        Vector3 newDirection = Vector3.RotateTowards(bodyVisual.forward, Direction, singleStepRotation, 0.0f);
        singleStepRotation = singleStepRotation * 0.9f;
        bodyVisual.rotation = Quaternion.LookRotation(newDirection);
        Debug.DrawRay(bodyVisual.position, newDirection, Color.red);
        var vertFlag = false;
        var gorizFlag = false;
        Vector3 _movement = Vector3.zero;

        bool up= Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W);
        bool down= Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S);
        bool left = Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A);
        bool right = Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D);
        if (up && !down)
        {
            vertFlag = true;
            _movement += Vector3.forward * speed * speedSlowModCurrent * Time.deltaTime;
        }
        if (down && !up)
        {
            vertFlag = true;
            _movement += Vector3.back * speed * speedSlowModCurrent * Time.deltaTime;
        }
        if (left && !right)
        {
            gorizFlag = true;
            _movement += Vector3.left * speed * speedSlowModCurrent * Time.deltaTime;
        }
        if (right && !left)
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
