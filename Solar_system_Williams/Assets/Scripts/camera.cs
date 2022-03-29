using UnityEngine;

public class camera : MonoBehaviour
{    
    [SerializeField] private GameObject[] planets;

    private short index = 0;

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

        transform.position = planets[index].transform.position - cameraOffset;
        transform.LookAt(planets[index].transform.position);

        transform.Rotate(rotationValue);

        CalculateCameraSunNormalDirection();        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        cameraSphereDistance = Vector3.Distance(transform.position, planets[index].transform.position);
        
        if (Input.GetKey(KeyCode.A))
        {
            transform.RotateAround(planets[index].transform.position, rotationAxes, rotationValue * Time.deltaTime);
            transform.LookAt(planets[index].transform.position);
            CalculateCameraSunNormalDirection();
        }
        else if (Input.GetKey(KeyCode.D)) 
        {
            transform.RotateAround(planets[index].transform.position, rotationAxes, -(rotationValue * Time.deltaTime));
            transform.LookAt(planets[index].transform.position);
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
        cameraSunNormalDirection = Vector3.Normalize(transform.position - planets[index].transform.position);        
    }
}
