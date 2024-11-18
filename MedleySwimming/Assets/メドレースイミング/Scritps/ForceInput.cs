using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MedleySwimming
{
    public class ForceInput : InputMethod
    {
        private bool xPressed = false;
        private bool yPressed = false;
        private bool zPressed = false;
        void Start()
        {
            Init("X + Y + Z");
        }
        public override void CheckInput()
        {
            if(Input.GetKeyDown(KeyCode.X))
            {
                xPressed = true;
            }
            if (Input.GetKeyUp(KeyCode.X))
            {
                xPressed = false;
            }
            if (Input.GetKeyDown(KeyCode.Y))
            {
                yPressed = true;
            }
            if (Input.GetKeyUp(KeyCode.Y))
            {
                yPressed = false;
            }
            if (Input.GetKeyDown(KeyCode.Z))
            {
                zPressed = true;
            }
            if (Input.GetKeyUp(KeyCode.Z))
            {
                zPressed = false;
            }
            if(xPressed && yPressed && zPressed)
            {
                ClearInput();
                xPressed = false;
                yPressed = false;
                zPressed = false;
            }
        }

        public override void DisplayUI()
        {
            inputUIText.text = inputUI;
        }
    }
}