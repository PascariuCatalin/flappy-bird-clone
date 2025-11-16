using Godot;
using System;

public partial class GameOver : Control
{
	private bool is_dead = false;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
        Visible = false;
        GetTree().Paused = false;
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
        if (Input.IsActionJustPressed("quit") && is_dead == true)
		{
			Restart_button();
		}

    }

	private void Restart()
	{
		is_dead = true;
		Visible = true;
		GetTree().Paused = true;
	}

	private void Restart_button()
	{
		is_dead = false;
		Visible = false;
		GetTree().Paused = false;
		GetTree().ReloadCurrentScene();
	}

	private void Quit_button()
	{
		GetTree().Quit();
	}
}
