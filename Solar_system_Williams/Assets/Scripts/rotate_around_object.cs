using UnityEngine;

public class rotate_around_object : MonoBehaviour
{
    public float rotationMultiplyer = 1f;

    public GameObject sun;  
    
    private float randomInitialRotation = 0f;
    private float rotationValue = 0.0f;
    
    private Vector3 rotationAxes = new Vector3(0.0f, 1.0f, 0.0f);
    
    // Start is called before the first frame update
    void Start()
    {
        randomInitialRotation = Random.Range(1.0f, 360.0f);
        rotationValue = 20.0f;

        transform.RotateAround(sun.transform.position, rotationAxes, randomInitialRotation);   
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(sun.transform.position, rotationAxes, rotationValue * Time.deltaTime);
    }
}
