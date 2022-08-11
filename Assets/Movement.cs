using UnityEngine;
namespace Debugging.Player
{
    [AddComponentMenu("RPG/Player/Movement")] //"ComponentMenu" to "AddComponentMenu"
    [RequireComponent(typeof(CharacterController))] //added typeof
    public class Movement : MonoBehaviour  //capital M also suppoed to inheret monobehaviour
    {
        [Header("Speed Vars")]
        public float moveSpeed;
        public float walkSpeed, runSpeed, crouchSpeed, jumpSpeed;
        private float _gravity = 20.0f; //make a float
        private Vector3 _moveDir;

        private CharacterController _charC; //declare _charC
        private void Start()
        {
            _charC = GetComponent<CharacterController>(); //Get component for _charC
        }
        private void Update() //Capital U
        {
            Move();
        }
        private void Move()
        {
            if (_charC.isGrounded)
            {
                if (Input.GetButton("Sprint")) //extra bracket
                {
                    moveSpeed = runSpeed;
                }
                else if (Input.GetButton("Crouch"))
                {
                    moveSpeed = crouchSpeed;
                }
                else
                {
                    moveSpeed = walkSpeed;
                }
                _moveDir = transform.TransformDirection(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * moveSpeed); //Horisontal -> Horizontal
                if (Input.GetButton("Jump"))
                {
                    _moveDir.y = jumpSpeed; //semicolon
                }
            }
            _moveDir.y -= _gravity * Time.deltaTime;
            _charC.Move(_moveDir * Time.deltaTime);
        }
         //extra curly boi
    }
}
