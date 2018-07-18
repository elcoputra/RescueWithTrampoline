using Godot;
using System;

public class Player : KinematicBody2D
{
    [Export] public int RunSpeed = 200;
    [Export] public int JumpSpeed = -400;
    [Export] public int Gravity = 1200;

    Vector2 velocity = new Vector2();

    bool jumping = false;
    public int scorePlayerNode = 0;



    AnimatedSprite animKiri , animKanan;


    public override void _Ready()
    {
        animKiri = (AnimatedSprite) GetNode("KiriAnimatedSprite");
        animKanan = (AnimatedSprite) GetNode("KananAnimatedSprite");

    }

    // public override void _Process(float delta)
    // {

    // }


    public void getInput()
    {
        velocity.x = 0;
        bool right = Input.IsActionPressed("ui_right");
        bool left = Input.IsActionPressed("ui_left");
        bool jump = Input.IsActionPressed("ui_jump");

        if (jump && IsOnFloor())
        {
            jumping = true;
            velocity.y = JumpSpeed;
        }

        if (right)
        {
            if(IsOnFloor())
            {
                animKiri.Play("JalanKanan");
                animKanan.Play("JalanKanan");
            }else
                {
                    animKanan.Play("default");
                    animKiri.Play("default");
                }
            
            velocity.x += RunSpeed;

        }

        else if (left)
        {
            if(IsOnFloor())
            {
                animKanan.Play("JalanKiri");
                animKiri.Play("JalanKiri");
            }else
                {
                    animKanan.Play("default");
                    animKiri.Play("default");
                }
            
            velocity.x -= RunSpeed;
        }else 
            {
                animKanan.Play("default");
                animKiri.Play("default");
            }
    }

    public override void _PhysicsProcess(float delta)
    {
        getInput();
        velocity.y += Gravity * delta;
        if (jumping && IsOnFloor())
        {
            jumping = false;
        }
        velocity = MoveAndSlide(velocity, new Vector2(0, -1));
    }

    public void _on_PlayerArea_area_entered(Godot.Area2D area)
    {
        if(area.Name == "CoinArea")
        {
            scorePlayerNode += 1;
        }
    }


}
