using Godot;
using System;

public partial class player : CharacterBody2D
{
	public const float Speed = 200.0f;
	public const float JumpVelocity = -300.0f;
	private int jumpCount = 0;
	private AnimatedSprite2D animatedSprite;

    // Get the gravity from the project settings to be synced with RigidBody nodes.
    public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

    public override void _Ready()
    {
        animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
    }


    public override void _PhysicsProcess(double delta) // physics process is better for physics calculations
    {
		Vector2 velocity = Velocity;

		// Add the gravity.
		if (!IsOnFloor())
		{
			velocity.Y += gravity * (float)delta;
			if (Input.IsActionJustPressed("jump") && velocity.Y > 0 && jumpCount < 2) // Double Jump
            {
				velocity.Y = JumpVelocity;
				jumpCount++;
            }
        }

		// Handle Jump.
		if (Input.IsActionJustPressed("jump") && IsOnFloor())
		{
			velocity.Y = JumpVelocity;
            jumpCount = 1;
        }

        // Flip the sprite based on the input direction.
        float direction = Input.GetAxis("move_left", "move_right");
		if(direction > 0.0f)
		{
			animatedSprite.FlipH = false;
            animatedSprite.Play("MoveRight");
        }
        else if(direction < 0.0f)
        {
            animatedSprite.FlipH = false;
            animatedSprite.Play("MoveLeft");
        }

        // Play animations based on the input direction.
        if (IsOnFloor())
        {
            if(direction == 0.0f)
            {
                animatedSprite.Play("Idle");
            }
        }

        // Get the input direction and handle the movement/deceleration.
        if (direction != 0.0f)
		{
			velocity.X = direction * Speed;
        }
        else
        {
            velocity.X = Mathf.MoveToward(velocity.X, 0, Speed);
        }

        // Get the input direction and handle the movement/deceleration.
        // As good practice, you should replace UI actions with custom gameplay actions.
        //Vector2 direction = Input.GetVector("move_left", "move_right", "ui_up", "ui_down");
        //if (direction != Vector2.Zero)
        //{
        //	velocity.X = direction.X * Speed;
        //}
        //else
        //{
        //	velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
        //}

        Velocity = velocity;
		MoveAndSlide();
	}
}
