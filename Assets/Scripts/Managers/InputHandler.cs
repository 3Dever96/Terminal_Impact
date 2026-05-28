using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class InputHandler : MonoBehaviour
{
    // Input Properties that can be read by other scripts.
    public Vector2 Move { get { return move; } }
    public bool Attack {  get { return attack; } }
    public bool Dash { get { return dash; } }
    public bool Special { get { return special; } }
    public bool Pause {  get { return pause; } }

    // Singleton variable for this manager
    public static InputHandler instance;

    // Local reference to the player input
    private PlayerInput input;
    
    // Local variables for the input
    private Vector2 move;
    private bool attack;
    private bool dash;
    private bool special;
    private bool pause;

    private void Awake()
    {
        // Assign singleton
        instance = this;
    }

    private void OnEnable()
    {
        // Assign player input reference
        if (input == null)
        {
            input = GetComponent<PlayerInput>();
        }

        // Subscribe to the OnActionTriggered delegation
        input.onActionTriggered += OnAction;
    }

    private void OnDisable()
    {
        // Unsubscribe to the OnActionTriggered delegation
        input.onActionTriggered -= OnAction;
    }

    public void OnAction(InputAction.CallbackContext context)
    {
        // Set input variables based on the context's name and attributes
        switch (context.action.name)
        {
            case "Move":
                move = context.ReadValue<Vector2>();
                break;
            case "Attack":
                SetBoolValue(ref attack, context);
                break;
            case "Dash":
                SetBoolValue(ref dash, context);
                break;
            case "Special":
                SetBoolValue(ref special, context);
                break;
            case "Pause":
                SetBoolValue(ref pause, context);
                break;
        }
    }

    private void SetBoolValue(ref bool value, InputAction.CallbackContext context)
    {
        // If the context was performed, set the value to true
        if (context.performed)
        {
            value = true;
        }

        // If the context was canceled, set the value to false
        if (context.canceled)
        {
            value = false;
        }
    }
}
