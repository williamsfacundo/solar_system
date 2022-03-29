using UnityEngine;

public class camera : MonoBehaviour
{    
    public GameObject sun = null;

    private float rotationValue = 100.0f;
    private float cameraMoveSpeedValue = 1000f;
    private float maxDistance = 10000f;
    private float minDistance = 1000f;
    private float cameraSphereDistance = 0f;    

    private Vector3 cameraInitialRotation = new Vector3(0f, 90f, 0f);
    private Vector3 cameraOffset = new Vector3(1200f, 0f, 0f);
    private Vector3 rotationAxes = new Vector3(0f, 1f, 0f);
    private Vector3 cameraSunNormalDirection;

    // Start is called before the first frame update
    void Start()
    {       
        Vector3 rotationValue = cameraInitialRotation - transform.rotation.eulerAngles;

        transform.position = sun.transform.position - cameraOffset;
        transform.LookAt(sun.transform.position);

        transform.Rotate(rotationValue);

        CalculateCameraSunNormalDirection();        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        cameraSphereDistance = Vector3.Distance(transform.position, sun.transform.position);


        if (Input.GetKey(KeyCode.A))
        {
            transform.RotateAround(sun.transform.position, rotationAxes, rotationValue * Time.deltaTime);
            transform.LookAt(sun.transform.position);
            CalculateCameraSunNormalDirection();
        }
        else if (Input.GetKey(KeyCode.D)) 
        {
            transform.RotateAround(sun.transform.position, rotationAxes, -(rotationValue * Time.deltaTime));
            transform.LookAt(sun.transform.position);
            CalculateCameraSunNormalDirection();
        }

        if (Input.GetKey(KeyCode.W) && cameraSphereDistance > minDistance)
        {
            transform.position -= cameraSunNormalDirection * cameraMoveSpeedValue * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.S) && cameraSphereDistance < maxDistance)
        {
            transform.position += cameraSunNormalDirection * cameraMoveSpeedValue * Time.deltaTime;
        }        
    }

    void CalculateCameraSunNormalDirection() 
    {
        cameraSunNormalDirection = Vector3.Normalize(transform.position - sun.transform.position);        
    }
}
