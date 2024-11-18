using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MedleySwimming
{
    public class FirstInput : InputMethod
    {
        private bool waitingB = false;
        private void Start()
        {
            Init("A<=>B");
        }
        
        public override void CheckInput()
        {
            if (Input.GetKeyDown(KeyCode.A) && !waitingB)
            {
                waitingB = true;
                ClearInput();
            }
            if (Input.GetKeyDown(KeyCode.B) && waitingB)
            {
                waitingB = false;
                ClearInput();
            }
        }

        public override void DisplayUI()
        {
            inputUIText.text = inputUI;
        }
    }
}