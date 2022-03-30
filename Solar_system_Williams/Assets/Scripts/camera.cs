using UnityEngine;

public class camera : MonoBehaviour
{   
    [SerializeField] private GameObject[] planets;

    enum MovementStatus { RotateRight, RotateLeft, MoveFront, MoveBack, None};

    MovementStatus movementStatus = MovementStatus.None;
    MovementStatus rotationStatus = MovementStatus.None;

    const float maxDistanceMultiplyer = 2.5f;

    private short index = 0;

    private bool noneMovement = true;
    private bool noneRotation = true;

    private float rotationValue = 100.0f;
    private float cameraMoveSpeedValue = 1000f;
    private float maxDistance;
    private float minDistance;
    private float cameraSphereDistance = 0f;    

    private Vector3 cameraInitialRotation = new Vector3(0f, 90f, 0f);   
    private Vector3 rotationAxes = new Vector3(0f, 1f, 0f);
    private Vector3 cameraSunNormalDirection;

    // Start is called before the first frame update
    private void Start()
    {       
        Vector3 rotationValue = cameraInitialRotation - transform.rotation.eulerAngles;

        transform.position = planets[index].transform.position - GetCameraOffset();
        transform.LookAt(planets[index].transform.position);

        transform.Rotate(rotationValue);

        maxDistance = Mathf.Abs(GetCameraOffset().z) * maxDistanceMultiplyer;
        minDistance = Mathf.Abs(GetCameraOffset().z);

        CalculateCameraSunNormalDirection();        
    }

    private void Update()
    {      
        if (Input.GetKey(KeyCode.A))
        {
            rotationStatus = MovementStatus.RotateLeft;            
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rotationStatus = MovementStatus.RotateRight;           
        }
        else 
        {
            rotationStatus = MovementStatus.None;          
        }

        if (Input.GetKey(KeyCode.W) && cameraSphereDistance > minDistance)
        {
            movementStatus = MovementStatus.MoveFront;
        }
        else if (Input.GetKey(KeyCode.S) && cameraSphereDistance < maxDistance)
        {
            movementStatus = MovementStatus.MoveBack;            
        }
        else 
        {
            movementStatus = MovementStatus.None;
        }
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        cameraSphereDistance = Vector3.Distance(transform.position, planets[index].transform.position);

        transform.LookAt(planets[index].transform.position);

        switch (rotationStatus) 
        {
            case MovementStatus.RotateRight:

                transform.RotateAround(planets[index].transform.position, rotationAxes, -(rotationValue * Time.deltaTime));
                CalculateCameraSunNormalDirection();
                break;
            case MovementStatus.RotateLeft:

                transform.RotateAround(planets[index].transform.position, rotationAxes, rotationValue * Time.deltaTime);
                CalculateCameraSunNormalDirection();
                break;
            default:
                break;
        }

        switch (movementStatus) 
        {                
            case MovementStatus.MoveFront:

                transform.position -= cameraSunNormalDirection * cameraMoveSpeedValue * Time.deltaTime;
                break;
            case MovementStatus.MoveBack:

                transform.position += cameraSunNormalDirection * cameraMoveSpeedValue * Time.deltaTime;
                break;
            default:
                break;
        }
    }

    private Vector3 GetCameraOffset() 
    {
        float scale = planets[index].transform.localScale.x * 2.4f;

        return new Vector3(0f, 0f, -scale);
    }

    private void CalculateCameraSunNormalDirection() 
    {
        cameraSunNormalDirection = Vector3.Normalize(transform.position - planets[index].transform.position);        
    }

    public void NextIndexRight() 
    {
        index += 1;

        if (index > planets.Length - 1) 
        {
            index = 0;
        }

        transform.position = planets[index].transform.position - GetCameraOffset();
        maxDistance = Mathf.Abs(GetCameraOffset().z) * maxDistanceMultiplyer;
        minDistance = Mathf.Abs(GetCameraOffset().z);
    }

    public void NextIndexLeft() 
    {
        index -= 1;

        if (index < 0)
        {
            index = (short)(planets.Length - 1);
        }

        transform.position = planets[index].transform.position - GetCameraOffset();
        maxDistance = Mathf.Abs(GetCameraOffset().z) * maxDistanceMultiplyer;
        minDistance = Mathf.Abs(GetCameraOffset().z);
    }
}
