using UnityEngine;

public class PlayerMovementService : IMovementService
{
    private readonly Rigidbody2D _rigidbody;
    private readonly float _moveSpeed;
    private readonly float _jumpForce;
    private readonly float _dashPower;

    public PlayerMovementService(Rigidbody2D rigidbody, float moveSpeed, float jumpForce, float dashPower)
    {
        _rigidbody = rigidbody;
        _moveSpeed = moveSpeed;
        _jumpForce = jumpForce;
        _dashPower = dashPower;
    }

    public void Move(Vector2 direction)
    {
        _rigidbody.velocity = new Vector2(direction.x * _moveSpeed, _rigidbody.velocity.y);
    }

    public void Jump(Vector2 jumpForce)
    {
        _rigidbody.velocity = new Vector2(0, 0);
        _rigidbody.AddForce(jumpForce * 10);
    }

    public void Dash(Vector2 direction)
    {
        _rigidbody.AddForce(direction * _dashPower, ForceMode2D.Impulse);
    }
}