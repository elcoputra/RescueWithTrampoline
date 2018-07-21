using Godot;
using System;

public class Player : KinematicBody2D
{
    [Export] public int RunSpeed = 200;
    [Export] public int JumpSpeed = -400;
    [Export] public int Gravity = 1200;
    public float fillBar; 
    public Color FullAlpha;
    public Color ZeroAlpha;

    Vector2 velocity = new Vector2();
    AudioStreamPlayer JumpSound;
    AudioStreamPlayer2D CoinSound;
    ProgressBar stamina;
    Tween BarStaminaAlpha;

    bool jumping = false;
    public int scorePlayerNode = 0;



    AnimatedSprite animKiri , animKanan;


    public override void _Ready()
    {
        animKiri = (AnimatedSprite) GetNode("KiriAnimatedSprite");
        animKanan = (AnimatedSprite) GetNode("KananAnimatedSprite");
        JumpSound = (AudioStreamPlayer) GetNode("Jump");
        CoinSound = (AudioStreamPlayer2D) GetNode("Coin");
        stamina = (ProgressBar) GetNode("PlayerGui/Stamina");
        BarStaminaAlpha = (Tween) GetNode("PlayerGui/BarStaminaAlpha");
        

        FullAlpha = new Color(1.0f,1.0f,1.0f,1.0f);
        ZeroAlpha = new Color(1.0f,1.0f,1.0f,.0f);


        BarStaminaAlpha.InterpolateProperty(stamina, ":modulate", stamina.GetModulate(), ZeroAlpha, 2.0f, Tween.TransitionType.Quart, Tween.EaseType.Out);
        BarStaminaAlpha.Start();

        

    }

    public override void _Process(float delta)
    {
        fillBar += delta * 10;
        stamina.SetValue(fillBar);
    }


    public void getInput(float delta)
    {
        velocity.x = 0;
        bool right = Input.IsActionPressed("ui_right");
        bool left = Input.IsActionPressed("ui_left");
        bool jump = Input.IsActionPressed("ui_jump");
        bool boost = Input.IsActionPressed("Boost");

        if (jump && IsOnFloor())
        {

            jumping = true;
            velocity.y = JumpSpeed;
            JumpSound.Play();
            fillBar -= 15;
            BarStaminaAlpha.RemoveAll();
            BarStaminaAlpha.InterpolateProperty(stamina, ":modulate", stamina.GetModulate(), FullAlpha, 2.0f, Tween.TransitionType.Quart, Tween.EaseType.Out);
            BarStaminaAlpha.Start();
            
        }else
            {
                if(stamina.Value >= 50)
                {
                    BarStaminaAlpha.RemoveAll();
                    BarStaminaAlpha.InterpolateProperty(stamina, ":modulate", stamina.GetModulate(), ZeroAlpha, 4.0f, Tween.TransitionType.Quart, Tween.EaseType.Out);
                    BarStaminaAlpha.Start();
                }   
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
        
        if(boost && fillBar >= 1)
        {
            BarStaminaAlpha.RemoveAll();
            RunSpeed = 350;
            fillBar -= delta * 50;
            BarStaminaAlpha.InterpolateProperty(stamina, ":modulate", stamina.GetModulate(), FullAlpha, 2.0f, Tween.TransitionType.Quart, Tween.EaseType.Out);
            BarStaminaAlpha.Start();

            
            
        }else
            {   
                RunSpeed = 200;
                if(stamina.Value >= 50)
                {
                    BarStaminaAlpha.RemoveAll();
                    BarStaminaAlpha.InterpolateProperty(stamina, ":modulate", stamina.GetModulate(), ZeroAlpha, 4.0f, Tween.TransitionType.Quart, Tween.EaseType.Out);
                    BarStaminaAlpha.Start();
                }
                
                
            }
    }

    public override void _PhysicsProcess(float delta)
    {
        getInput(delta);
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
            CoinSound.Play();
        }
    }


}
