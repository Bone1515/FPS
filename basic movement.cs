using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float speed = 5f; // character movement speed

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal"); // input horizontal direction 
        float moveZ = Input.GetAxis("Vertical"); // vertical input direction 

        Vector3 movement = new Vector3(moveX, 0f, moveZ) * speed * Time.deltaTime; // Calculate the movement vector
        transform.Translate(movement); // character movement
    }
}
