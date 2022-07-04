using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class OrbitCamera : MonoBehaviour
{
    public Transform target;
    public float distance = 2.0f;
    public float xSpeed = 2.0f;
    public float ySpeed = 10.0f;

    public float panSpeed = 1000f;
    public float yMinLimit = -90f;
    public float yMaxLimit = 90f;
    public float distanceMin = 0f;
    public float distanceMax = 100f;
    public float smoothTime = 20f;
    private float rotationYAxis = 0.0f;
    private float rotationXAxis = 0.0f;
    private float velocityX = 0.0f;
    private float velocityY = 0.0f;
    private Vector3 vector3 = new Vector3();
    // Use this for initialization
    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        rotationYAxis = angles.y;
        rotationXAxis = angles.x;
        // Make the rigid body not change rotation
        if (GetComponent<Rigidbody>())
        {
            GetComponent<Rigidbody>().freezeRotation = true;
        }
    }
    void LateUpdate()
    {
        if ( target == null )
        {
            return;
        }

        if (Input.GetMouseButton(0))
        {
            velocityX += xSpeed * Input.GetAxis("Mouse X") * distance * 0.02f;
            // velocityY += ySpeed * Input.GetAxis("Mouse Y") * 0.02f;
            velocityY += ySpeed * Input.GetAxis("Mouse Y") * distance * 0.02f;
        }
        if (Input.GetMouseButton(1))
        {
            float speed = panSpeed * Time.deltaTime;
            target.transform.position += new Vector3(Input.GetAxis("Mouse X") * speed, 0, Input.GetAxis("Mouse Y") * speed);
        }
        rotationYAxis += velocityX;
        rotationXAxis -= velocityY;
        rotationXAxis = ClampAngle(rotationXAxis, yMinLimit, yMaxLimit);
        Quaternion fromRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0);
        Quaternion toRotation = Quaternion.Euler(rotationXAxis, rotationYAxis, 0);
        Quaternion rotation = toRotation;

        distance = Mathf.Clamp(distance - Input.GetAxis("Mouse ScrollWheel") * 5, distanceMin, distanceMax);
        RaycastHit hit;
        if (Physics.Linecast(target.position, transform.position, out hit))
        {
            distance -= hit.distance;
        }
        vector3.Set(0.0f, 0.0f, -distance);
        Vector3 position = rotation * vector3 + target.position;

        transform.rotation = rotation;
        transform.position = position;
        velocityX = Mathf.Lerp(velocityX, 0, Time.deltaTime * distance);
        velocityY = Mathf.Lerp(velocityY, 0, Time.deltaTime * distance);
        // velocityX = Mathf.Lerp(velocityX, 0, Time.deltaTime * smoothTime);
        // velocityY = Mathf.Lerp(velocityY, 0, Time.deltaTime * smoothTime);
        
    }
    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360F)
            angle += 360F;
        if (angle > 360F)
            angle -= 360F;
        return Mathf.Clamp(angle, min, max);
    }
 }