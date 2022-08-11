using UnityEngine;
// 10 errors
public class CharCon : MonoBehaviour //Charcon -> CharCon
{
    public float speed; //Speed -> speed

    public Vector3 movement; //Vector2 -> Vector3

    public float mouseSpeed;

    public float gravity = 9.8f; //floatify

    public float jumpHeight = 6;

    CharacterController charCon;
    void Start() //Capital S
    {
        charCon = GetComponent<CharacterController>();
    }

    void Update() //Close bracket
    {
        movement.x = 0;
        movement.z = 0;
        transform.Rotate(Vector3.up * Input.GetAxisRaw("Mouse X") * mouseSpeed);


        movement += transform.forward * Input.GetAxisRaw("Vertical") * speed;
        movement += transform.right * Input.GetAxisRaw("Horizontal") * speed; //extra equals

        if (charCon.isGrounded) //"if == (charCon.isGrounded)" -> "if (charCon.isGrounded)"
        {
            movement.y = -1;
            if (Input.GetButtonDown("Jump"))
            {
                movement.y = jumpHeight;
            }
        }
        else
        {
            movement.y -= gravity * Time.deltaTime; //+= adds gravity -> -=
        }

        charCon.Move(movement * Time.deltaTime); //semicolon
    } //closing curly boi for Update()
}
