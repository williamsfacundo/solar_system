using UnityEngine;

public class movement : MonoBehaviour
{   
    private const float maxXPos = 1000000.0f;
    private const float initialXVelocity = 200.0f;

    private Vector3 initialPosition = new Vector3(0.0f, 0.0f, 0.0f);
    
    public Vector3 moveVelocity = new Vector3(0.0f, 0.0f, 0.0f);
    
    // Start is called before the first frame update
    void Start()
    {
        moveVelocity.x = initialXVelocity;
        transform.position = initialPosition;        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.x < maxXPos) {

            transform.position += moveVelocity * Time.deltaTime;
        }
        else {

            transform.position = initialPosition;
        }
    }
}