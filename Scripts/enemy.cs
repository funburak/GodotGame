using Godot;
using System;

public partial class enemy : Node2D
{
	private const float Speed = 60.0f;
    private int direction = 1;
    private RayCast2D rayCastRight;
    private RayCast2D rayCastLeft;
    private AnimatedSprite2D animatedSprite;
    private AnimatedSprite2D player;

    public override void _Ready()
    {
        rayCastRight = GetNode<RayCast2D>("RayCastRight");
        rayCastLeft = GetNode<RayCast2D>("RayCastLeft");
        animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
        //player = GetNode<AnimatedSprite2D>("../player/AnimatedSprite2D");

    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
	{
        if (rayCastRight.IsColliding())
        {
            direction = -1;
            //animatedSprite.FlipH = false;
        }
        if(rayCastLeft.IsColliding())
        {
            direction = 1;
            //animatedSprite.FlipH = true;
        }

        //if (rayCastRight.GetCollider().Equals(player))
        //{
        //    animatedSprite.Play("attack");
        //}
        //if(rayCastLeft.GetCollider().Equals(player))
        //{
        //    animatedSprite.Play("attack");
        //}


		//Position += new Vector2(direction * Speed * (float)delta, 0);
    }
}
