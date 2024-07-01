using Godot;
using System;

public partial class killzone : Area2D
{
    // get reference the timer node
    private Timer timer;

    public override void _Ready()
    {
        timer = GetNode<Timer>("Timer"); // Get the timer node.
        if(timer == null) // Check if the timer node is null.
        {
            GD.Print("Timer node not found!");
        }
    }

    public bool _on_body_entered(PhysicsBody2D body)
    {
        if (body is player)
        {
            GD.Print("Player died!");
            Engine.TimeScale = 0.5f; // Slow down the game.
            body.GetNode<CollisionShape2D>("CollisionShape2D").QueueFree(); // Disable the collision shape.
            timer.Start();
        }
        return true;
    }
    public void _on_timer_timeout()
    {
        Engine.TimeScale = 1.0f; // Reset the time scale.
        GetTree().ReloadCurrentScene();
    }
}
