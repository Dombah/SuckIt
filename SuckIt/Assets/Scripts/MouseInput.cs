using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInput : MonoBehaviour
{
    #region Variables
    [SerializeField] Canvas background = null;
    [SerializeField] VacuumMovement vacuumMovement = null;
    
    Vector3 clickedPos; // position of the mouse click
    private bool firstClick = false;
    // Values for either X = 0 or Y = 0
    //private float movementFactorRaw = 0f;
    private float movementFactorClamped = 0f;
    #endregion

    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            Vector3 mousePos = Input.mousePosition;
            if(!firstClick) 
            {
                clickedPos = mousePos; // Sets the 1st clicked position to be the first mouse position detected
                firstClick = true;

            }
            else // Compare all the possibble situations 
            {             
                if(mousePos == clickedPos) { return; } // If the mousePos is equal to the clickedPos return(don't do anything because there is no need to move the player) 

                //************ Horizontal line = const ************//
                if (mousePos.x == clickedPos.x && mousePos.y > clickedPos.y)
                {
                    print("X = 0, Y is greater");
                    //movementFactorRaw = mousePos.y - clickedPos.y;
                    movementFactorClamped = vacuumMovement.ProcessMovementFactor(mousePos.y, clickedPos.y);//Mathf.Clamp(movementFactorRaw, Mathf.Epsilon, .3f);
                    vacuumMovement.Move(movementFactorClamped, Vector3.forward);

                }
                else if (mousePos.x == clickedPos.x && mousePos.y < clickedPos.y)
                {
                    print("X = 0, Y is lesser");
                    //movementFactorRaw = clickedPos.y - mousePos.y;
                    //movementFactorClamped = Mathf.Clamp(movementFactorRaw, Mathf.Epsilon, .3f);
                    movementFactorClamped = vacuumMovement.ProcessMovementFactor(clickedPos.y, mousePos.y);
                    vacuumMovement.Move(movementFactorClamped, -Vector3.forward);
                }
                //************ Vertical line = const ************//
                else if (mousePos.x > clickedPos.x && mousePos.y == clickedPos.y)
                {
                    print("Y = 0, X is greater");
                    // movementFactorRaw = mousePos.x - clickedPos.x;
                    // movementFactorClamped = Mathf.Clamp(movementFactorRaw, Mathf.Epsilon, .3f);
                    movementFactorClamped = vacuumMovement.ProcessMovementFactor(mousePos.x, clickedPos.x);
                    vacuumMovement.Move(movementFactorClamped, Vector3.right);
                }
                else if (mousePos.x < clickedPos.x && mousePos.y == clickedPos.y)
                {
                    print("Y = 0, X is lesser");
                    // movementFactorRaw = clickedPos.x - mousePos.x;
                    // movementFactorClamped = Mathf.Clamp(movementFactorRaw, Mathf.Epsilon, .3f);
                    movementFactorClamped = vacuumMovement.ProcessMovementFactor(clickedPos.x, mousePos.x);
                    vacuumMovement.Move(movementFactorClamped, Vector3.left);
                }
                //************ 1.KV , 2.KV , 3.KV , 4.KV ************//
                else
                {
                    Vector3 position = new Vector3(mousePos.x - clickedPos.x, 0f, mousePos.y - clickedPos.y);
                    vacuumMovement.Move(vacuumMovement.vacuumSpeed, position);
                }
               
            }  
        }
        else
        {
            firstClick = false;
            clickedPos = Vector3.zero;
        }
    }
    
}
