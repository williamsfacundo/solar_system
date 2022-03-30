using UnityEngine;

public class movement : MonoBehaviour
{   
    private const float maxXPos = 1000000.0f;
    private const float initialXVelocity = 200.0f;

    private Vector3 initialPosition = new Vector3(0.0f, 0.0f, 0.0f);
    
    public Vector3 moveVelocity = new Vector3(0.0f, 0.0f, 0.0f);
    
    // Start is called before the first frame update
    private void Start()
    {
        moveVelocity.x = initialXVelocity;
        transform.position = initialPosition;        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (transform.position.x < maxXPos) {

            transform.position += moveVelocity * Time.deltaTime;
        }
        else {

            transform.position = initialPosition;
        }
    }
    public void StopContinueMovement()
    {
        if (moveVelocity.x != 0f)
        {
            moveVelocity.x = 0f;
        }
        else 
        {
            moveVelocity.x = initialXVelocity;
        }          
    }
}