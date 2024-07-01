using Godot;
using System;

public partial class main_menu : Control
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public bool _on_button_pressed(){
		GetTree().ChangeSceneToFile("../Scenes/game.tscn");
		return true;
	}

		public bool _on_exit_button_pressed(){
		GetTree().Quit();
		return true;
	}
}
