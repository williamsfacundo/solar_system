using UnityEngine;

public class local_rotation : MonoBehaviour
{
    public float rotationMultiplyer = 1.5f;

    private float rotationValue = 0.0f;
    private float localRotation = 0.0f;
    
    private Vector3 rotationAxes = new Vector3(0.0f, 1.0f, 0.0f);

    private bool rotate;

    // Start is called before the first frame update
    void Start()
    {
        rotationValue = 10.0f;
        localRotation = rotationValue * rotationMultiplyer;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (rotate) 
        {
            transform.Rotate(rotationAxes * localRotation * Time.deltaTime);
        }                
    }

    public void ChangeRotateBool() 
    {
        rotate = !rotate;
    }
}
