using Godot;
using System;

public partial class Player : CharacterBody2D
{
    private const float jump_velocity = -400.0f;

    public int points = 0;

    public override void _Ready()
    {

    }

    public override void _Process(double delta)
    {
        Vector2 velocity = Velocity;

        velocity += GetGravity() * (float)delta;

        if (Input.IsActionJustPressed("jump"))
        {
            velocity.Y = jump_velocity;
        }

        Velocity = velocity;
        MoveAndSlide();
    }

    private void OnArea2dAreaEntered(Area2D area)
    {
        if(area.CollisionLayer == 1)
        {
            Over();
        } 
        else if(area.CollisionLayer == 2)
        {
            points++;
        }
    }

    private void Over()
    {

    }

}
