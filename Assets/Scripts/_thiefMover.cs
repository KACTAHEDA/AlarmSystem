using UnityEngine;

public class _thiefMover : MonoBehaviour
{
    [SerializeField] private float _speed = 2f;
    [SerializeField] CharacterController _controller;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        float maxDirectionLength = 1f;

        Vector3 direction = new Vector3(horizontal, 0f, vertical);
        direction = Vector3.ClampMagnitude(direction, maxDirectionLength);
        _controller.Move(direction * _speed * Time.deltaTime);
    }
}
