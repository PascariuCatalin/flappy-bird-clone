using Godot;
using System;

public partial class Pause : Control
{
	private bool is_open = false;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Close();
		Resume();

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if(Input.IsActionJustPressed("quit"))
		{
			if(is_open && GetTree().Paused == true)
			{
				Close();
				Resume();
			}
			else
			{
                Open();
				Pause_();
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

	private void Pause_()
	{
		GetTree().Paused = true;
	}

	private void Resume_button()
	{
		Close();
		Resume();
	}

	private void Restart_button()
	{
		Resume();
		GetTree().ReloadCurrentScene();
	}

	private void Quit_button()
	{
		GetTree().Quit();
	}
}
