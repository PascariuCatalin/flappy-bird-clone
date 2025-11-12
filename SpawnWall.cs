using Godot;
using System;

public partial class SpawnWall : Node2D
{
	[Export]
	public PackedScene wall {  get; private set; }

	public StringName Object_parent_group { get; private set; } = "ObjectParent";

	private Node Object_parent;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Object_parent = GetTree().GetFirstNodeInGroup(Object_parent_group);

		if(Object_parent == null)
		{
			GD.PushWarning("No parrent found");
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

	}

    private void On_timer_timeout()
	{
		
		Spawn(GD.RandRange(-100, 100));
	}

    private void Spawn(float random_number)
	{
		Wall spawn_wall = wall.Instantiate<Wall>();

		Object_parent.AddChild(spawn_wall);

		spawn_wall.GlobalPosition = this.GlobalPosition + new Vector2(0, random_number);
		spawn_wall.GlobalRotation = this.GlobalRotation;
	}
}
