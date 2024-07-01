using Godot;
using System;

public partial class coin : Area2D
{
    private game_manager gameManager;

    public override void _Ready()
    {
        gameManager = GetNode<game_manager>("../../GameManager");
    }

    public bool _on_body_entered(PhysicsBody2D body)
	{
        if (body is player)
		{
            gameManager.addPoint();
            QueueFree();
        }
        return true;
    }

	

}
