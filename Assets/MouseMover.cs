using UnityEngine;
using UnityEngine.InputSystem;

public class MouseMover : MonoBehaviour
{

    [SerializeField]
    [Tooltip("Move the player to the location of 'moveToLocation'.")]
    InputAction moveTo = new InputAction(type: InputActionType.Button);

    [SerializeField]
    [Tooltip("Determine the location to 'moveTo'.")]
    InputAction moveToLocation = new InputAction(type: InputActionType.Value, expectedControlType: nameof(Vector2));

    void OnValidate() {
        // Provide default bindings for the input actions.
        // Based on answer by DMGregory: https://gamedev.stackexchange.com/a/205345/18261
        if (moveTo.bindings.Count == 0)
            moveTo.AddBinding("<Mouse>/leftButton");
        if (moveToLocation.bindings.Count == 0)
            moveToLocation.AddBinding("<Mouse>/position");
    }

    void OnEnable() {
        moveTo.Enable();
        moveToLocation.Enable();
    }

    void OnDisable() {
        moveTo.Disable();
        moveToLocation.Disable();
    }

    void Update() {
        if (moveTo.WasPressedThisFrame()) {
            Vector2 mousePositionInScreenCoordinates = moveToLocation.ReadValue<Vector2>();
            Vector3 mousePositionInWorldCoordinates = Camera.main.ScreenToWorldPoint(mousePositionInScreenCoordinates);
            mousePositionInWorldCoordinates.z = transform.position.z;
            transform.position = mousePositionInWorldCoordinates;
        }
    }
}
