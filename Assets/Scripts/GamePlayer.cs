using System;
using UnityEngine;

public static class GamePlayer
{
    public const float MOVE_FORCE = 0.5f;
    public const float JUMP_THRESHOLD = 0.75f;

    public static void ApplyForce(Rigidbody rigidbody, UserInput input)
    {
        if (input.up)
        {
            rigidbody.AddForce(
                Camera.main.transform.forward * MOVE_FORCE,
                ForceMode.Impulse);
        }

        if (input.down)
        {
            rigidbody.AddForce(
                -Camera.main.transform.forward * MOVE_FORCE,
                ForceMode.Impulse);
        }

        if (input.right)
        {
            rigidbody.AddForce(
                Camera.main.transform.right * MOVE_FORCE,
                ForceMode.Impulse);
        }

        if (input.left)
        {
            rigidbody.AddForce(
                -Camera.main.transform.right * MOVE_FORCE,
                ForceMode.Impulse);
        }

        if (input.jump && rigidbody.position.y <= JUMP_THRESHOLD)
        {
            rigidbody.AddForce(
                Camera.main.transform.up * MOVE_FORCE,
                ForceMode.Impulse);
        }
    }
}