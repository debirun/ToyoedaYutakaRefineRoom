using MedleySwimming;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MedleySwimming
{
    public class SecondInput : InputMethod
    {
        private bool xPressed = false;
        private bool yPressed = false;
        private void Start()
        {
            Init("X + Y");
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
            if (xPressed && yPressed)
            {
                ClearInput();
                xPressed = false;
                yPressed = false;
            }
        }

        public override void DisplayUI()
        {
            inputUIText.text = inputUI;
        }
    }
}