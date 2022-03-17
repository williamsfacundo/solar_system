using UnityEngine;

public class camera : MonoBehaviour
{    
    public GameObject sun = null;

    private float rotationValue = 40.0f;
        
    private Vector3 cameraInitialRotation = new Vector3(0f, 90f, 0f);
    private Vector3 cameraOffset = new Vector3(1200f, 0f, 0f);
    private Vector3 rotationAxes = new Vector3(0f, 1f, 0f);

    // Start is called before the first frame update
    void Start()
    {
        Vector3 rotationValue = cameraInitialRotation - transform.rotation.eulerAngles;

        if (sun != null) 
        { 
            transform.position = sun.transform.position - cameraOffset; 
        }

        transform.Rotate(rotationValue);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CalculateCameraSunNormalDirection();
        if (sun != null) 
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                transform.RotateAround(sun.transform.position, rotationAxes, -(rotationValue * Time.deltaTime));
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                transform.RotateAround(sun.transform.position, rotationAxes, rotationValue * Time.deltaTime);
            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {

            }
        }        
    }

    Vector3 CalculateCameraSunNormalDirection() 
    {        
        Vector3 normalizedDirection = Vector3.Normalize(transform.position - sun.transform.position);

        return normalizedDirection;
    }
}
