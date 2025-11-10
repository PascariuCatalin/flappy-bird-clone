using Godot;
using System;

public partial class Wall : Node2D
{
    private const float speed = -200.0f;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		GlobalPosition += new Vector2(speed, 0) * (float)delta;
	}

    private void OnArea2dAreaEntered(Area2D area)
	{
		this.QueueFree();
	}
}
