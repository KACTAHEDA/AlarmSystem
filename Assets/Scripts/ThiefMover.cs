using UnityEngine;

public class ThiefMover : MonoBehaviour
{
    [SerializeField] private float _speed = 2f;
    [SerializeField] private CharacterController _controller;

    private string _horizontalInput = "Horizontal";
    private string _verticalInput = "Vertical";

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        float horizontal = Input.GetAxis(_horizontalInput);
        float vertical = Input.GetAxis(_verticalInput);
        float maxDirectionLength = 1f;

        Vector3 direction = new Vector3(horizontal, 0f, vertical);
        direction = Vector3.ClampMagnitude(direction, maxDirectionLength);
        _controller.Move(direction * _speed * Time.deltaTime);
    }
}
