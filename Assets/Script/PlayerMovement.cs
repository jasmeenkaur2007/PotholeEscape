using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float forwardSpeed = 8f;
    public float sideSpeed = 6f;

    void Update()
    {
        // Move forward automatically
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);

        // Move left and right
        float horizontal = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontal * sideSpeed * Time.deltaTime);
    }
}
