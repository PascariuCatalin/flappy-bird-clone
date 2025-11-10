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
		Spawn();
	}

	private void Spawn()
	{
		Wall spawn_wall = wall.Instantiate<Wall>();

		Object_parent.AddChild(spawn_wall);

		spawn_wall.GlobalPosition = this.GlobalPosition;
		spawn_wall.GlobalRotation = this.GlobalRotation;
	}
}
