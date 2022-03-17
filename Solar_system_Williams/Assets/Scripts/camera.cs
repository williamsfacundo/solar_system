using UnityEngine;

public class camera : MonoBehaviour
{
    public Vector3 cameraInitialPosition = new Vector3(-1000f, 0f, 0f);
    
    public GameObject solarSystem = null;

    private Vector3 cameraInitialRotation = new Vector3(0f, 90f, 0f);

    // Start is called before the first frame update
    void Start()
    {
        transform.position = cameraInitialPosition;
        transform.Rotate(cameraInitialRotation);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
}
