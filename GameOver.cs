using Godot;
using System;

public partial class GameOver : Control
{
	private bool is_open = false;

	private bool is_dead = false;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
        Close();
        Resume();
		is_dead = false;
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if(Input.IsActionJustPressed("quit"))
		{
			if(is_open && GetTree().Paused == true && is_dead == false)
			{
				Close();
				Resume();
			}
			else
			{
				Open();
				Pause();
			}
		}
	}

	private void Open()
	{
		Visible = true;
		is_open = true;
	}

	private void Close()
	{
		Visible = false;
		is_open = false;
	}

	private void Resume()
	{
		GetTree().Paused = false;
	}

	private void Pause()
	{
		GetTree().Paused = true;
	}

	private void Restart()
	{
		is_dead = true;
		Visible = true;
		GetTree().Paused = true;
	}

	private void Resume_button()
	{
		if(is_dead == false)
		{
			Close();
			Resume();
		}
	}

	private void Restart_button()
	{
		is_dead = false;
		GetTree().Paused = false;
		GetTree().ReloadCurrentScene();
	}

	private void Quit_button()
	{
		GetTree().Quit();
	}
}
