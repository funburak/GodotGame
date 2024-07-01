using Godot;
using System;

public partial class game_manager : Node
{
    private int score;
    private Label scoreLabel;

    public override void _Ready()
    {
        scoreLabel = GetNode<Label>("ScoreLabel");
    }

    public void addPoint()
    {
        score += 1;
        scoreLabel.Text = "You collected " + score + " coins!";
    }
}
