using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class MovementController : MonoBehaviour
{
    public CharacterController Controller {  get; private set; }

    protected virtual void Start()
    {
        Controller = GetComponent<CharacterController>();
    }

    public void FaceDirection(Vector3 direction, float turnSpeed = 500f)
    {
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(direction), turnSpeed * Time.deltaTime);
    }

    public void ApplyMovement(Vector3 velocity)
    {
        Controller.Move(velocity * Time.deltaTime);
    }
}
