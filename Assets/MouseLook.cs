using UnityEngine; //using Engine; -> using UnityEngine;
//Errors : 17
namespace Debugging.Player
{
    [AddComponentMenu("RPG/Player/Mouse Look")] //AddComponent -> AddComponentMenu
    public class MouseLook : MonoBehaviour //Mouselook -> MouseLook //Monobehaviour -> MonoBehaviour
    {
        public enum RotationalAxis
        {
            MouseX,
            MouseY
        } //curly boi
        [Header("Rotation Variables")]
        public RotationalAxis axis = RotationalAxis.MouseX;
        [Range(0,200)]
        public float sensitivity = 100;
        public float minY = -60, maxY = 60;
        private float _rotY;

        void Start()
        {
            if(GetComponent<Rigidbody>()) //Get<Rigidbody>() -> GetComponent<Rigidbody>()
            {
                GetComponent<Rigidbody>().freezeRotation = true; //freeze -> freezeRotation
            }
            Cursor.lockState = CursorLockMode.Locked; //= not ==
            Cursor.visible = false; //semicolon
            if(GetComponent<Camera>()) //extra )
            {
                axis = RotationalAxis.MouseY; //Capital Y
            }
        }
        void Update() //Capital U
        {
            if(axis == RotationalAxis.MouseX)
            {
                transform.Rotate(0,Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime,0); //transform.rotate -> transform.Rotate
            }
            else
            {
                _rotY += Input.GetAxis("Mouse Y")  * sensitivity * Time.deltaTime; //"MouseY" -> "Mouse Y"
                _rotY = Mathf.Clamp(_rotY,minY,maxY); //rotY -> _rotY
                transform.localEulerAngles = new Vector3(-_rotY,0.0f); //transform.localEuler -> transform.localEulerAngles //also float typecast
            }
        }
    }   
}
