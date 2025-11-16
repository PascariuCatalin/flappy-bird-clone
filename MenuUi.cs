using Godot;
using System;

public partial class MenuUi : PanelContainer
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void Play_button()
	{
		GD.Print("play");
		GetTree().ChangeSceneToFile("res://main_scene.tscn");
	}

	private void Quit_button()
	{
		GetTree().Quit();
	}
}
