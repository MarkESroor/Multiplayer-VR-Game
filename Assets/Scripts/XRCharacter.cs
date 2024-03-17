using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class XRCharacter : MonoBehaviour
{
    public float speed = 5.0f;
    public float deadzone = 0.1f;

    public Transform head = null;
    public Transform mesh = null;
    public XRController controller = null;

    private Animator animator = null;
    private CharacterController character = null;

    private Vector3 currentDirection = Vector3.zero;


    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        character = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (controller.enableInputActions)
            CheckForMovement(controller.inputDevice);
    }

    private void CheckForMovement(InputDevice device)
    {
        if(device.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 joystickDirection))
        {
            Vector3 newDirection = CalculateDirection(joystickDirection);
            currentDirection = newDirection.magnitude > deadzone ? newDirection : Vector3.zero;

            MoveCharacter();

            OrientMesh();

            Animate();
        }
    }

    private Vector3 CalculateDirection(Vector2 joystickDirection)
    {
        Vector3 newDirection = new Vector3(joystickDirection.x, 0, joystickDirection.y);

        Vector3 headRotation = new Vector3(0, head.transform.eulerAngles.y, 0);

        return Quaternion.Euler(headRotation) * newDirection;
    }

    private void MoveCharacter()
    {
        Vector3 movement = currentDirection * speed;

        character.SimpleMove(movement);
    }

    private void OrientMesh()
    {
        if (currentDirection != Vector3.zero)
            mesh.transform.forward = currentDirection;
    }

    private void Animate()
    {
        float blend = currentDirection.magnitude;
        animator.SetFloat("Move", blend);
    }
}