using Godot;
using System;

public partial class Player : CharacterBody2D
{
    private const float jump_velocity = -350.0f;

    public int points = 0;

    [Export]
    public AudioStreamPlayer2D Point;

    [Export]
    public AudioStreamPlayer2D Fail;

    [Export]
    public AudioStreamPlayer2D Jump;

    [Signal]
    public delegate void SendScoreEventHandler(int event_score);

    [Signal]
    public delegate void RestartEventHandler();

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
            Jump.Play();
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

            Point.Play();
            
            EmitSignal(SignalName.SendScore, points);
        }
    }

    private void Over()
    {
        Fail.Play();

        EmitSignal(SignalName.Restart);
    }

}
