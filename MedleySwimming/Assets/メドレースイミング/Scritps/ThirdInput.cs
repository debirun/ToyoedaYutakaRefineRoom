using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MedleySwimming
{
    public class ThirdInput : InputMethod
    {
        private enum KeyState
        {
            None,
            APressed,
            BPressed,
            //CPressed
        }
        private KeyState currentKeyState = KeyState.None;
        
        private void Start()
        {
            Init("A=>B=>C");
        }
        public override void CheckInput()
        {
            switch(currentKeyState)
            {
                case KeyState.None:
                    if(Input.GetKeyDown(KeyCode.A))
                    {
                        currentKeyState = KeyState.APressed;
                    }
                    break;
                case KeyState.APressed:
                    if(Input.GetKeyDown(KeyCode.B))
                    {
                        currentKeyState = KeyState.BPressed;
                    }
                    break;
                case KeyState.BPressed:
                    if(Input.GetKeyDown(KeyCode.C))
                    {
                        currentKeyState = KeyState.None;
                        ClearInput();
                    }
                    break;                    
            }
        }

        public override void DisplayUI()
        {
            inputUIText.text = inputUI;
        }
    }
}