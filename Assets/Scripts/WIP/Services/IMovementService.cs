using UnityEngine;

public interface IMovementService
{
    void Move(Vector2 direction);
    void Jump(Vector2 jumpForce);
    void Dash(Vector2 direction);
}