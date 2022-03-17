using UnityEngine;

public class camera : MonoBehaviour
{
    private Vector3 cameraInitialPosition;
    private Vector3 cameraInitialRotation;

    public GameObject solarSystem;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(100.0f, 100.0f, 100.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
