using UnityEngine;

public class camera : MonoBehaviour
{   
    [SerializeField] private GameObject[] planets;

    const float maxDistanceMultiplyer = 2.5f;

    private short index = 0;

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

    // Update is called once per frame
    private void FixedUpdate()
    {
        cameraSphereDistance = Vector3.Distance(transform.position, planets[index].transform.position);

        transform.LookAt(planets[index].transform.position);        

        if (Input.GetKey(KeyCode.A))
        {
            transform.RotateAround(planets[index].transform.position, rotationAxes, rotationValue * Time.deltaTime);
            CalculateCameraSunNormalDirection();
        }
        else if (Input.GetKey(KeyCode.D)) 
        {
            transform.RotateAround(planets[index].transform.position, rotationAxes, -(rotationValue * Time.deltaTime));
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
