using Godot;
using System;

public partial class Score : Control
{
	[Export]
	public Label score_label;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void SendScore(int event_score)
	{
		score_label.Text = event_score.ToString();
	}
}
