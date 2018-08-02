using Godot;
using System;

public class MoveHand : KinematicBody2D
{
    // Member variables here, example:
    // private int a = 2;
    // private string b = "textvar";
    PackedScene Bullet;
    Position2D PosisiRespawn;
    AnimatedSprite Percikan;
    Timer TimerBulletKanan;
    Timer TimerBulletKiri;
    bool Flip = false;

    public override void _Ready()
    {
        // Called every time the node is added to the scene.
        // Initialization here
        Bullet = (PackedScene)ResourceLoader.Load("res://Prototype/Bullet.tscn");
        PosisiRespawn = (Position2D)GetNode("PosisiRespawn");
        Percikan = (AnimatedSprite)GetNode("Tangan/Percikan");
        TimerBulletKanan = (Timer) GetNode("TimerBulletKanan");
        TimerBulletKiri = (Timer) GetNode("TimerBulletKiri");
        TimerBulletKanan.IsStopped();
        TimerBulletKiri.IsStopped();

        
    }

    public override void _PhysicsProcess(float delta)
    {
        LookAt(GetGlobalMousePosition());
        input();
    }

    public void input()
    {   

        if(Flip == false)
        {
            if(Input.IsActionPressed("left_mouse") && TimerBulletKiri.IsStopped())
            {
                var BulletInstance = (KinematicBody2D) Bullet.Instance();
                GetParent().AddChild(BulletInstance);

                BulletInstance.Position = PosisiRespawn.GlobalPosition;
                BulletInstance.Rotation = PosisiRespawn.GlobalRotation;
                Percikan.Play("Percik");
                TimerBulletKiri.Start();
            }

                else
                {
                    Percikan.Play("Default");
                }

        }

        if(Flip == true)
        {
            var Tangan = (Sprite)GetNode("Tangan");
            Tangan.FlipV = true;
            if(Input.IsActionPressed("right_mouse") && TimerBulletKanan.IsStopped())
            {
                var BulletInstance = (KinematicBody2D) Bullet.Instance();
                GetParent().AddChild(BulletInstance);

                BulletInstance.Position = PosisiRespawn.GlobalPosition;
                BulletInstance.Rotation = PosisiRespawn.GlobalRotation;
                Percikan.Play("Percik");
                TimerBulletKanan.Start();
            }
                else
                {
                    Percikan.Play("Default");
                }

        }
        
        
    }

    public void _on_areaFlip_y_area_entered(Area2D area)
    {
        if(area.Name == "PosPenembakKanan")
        {
            Flip = true;
        }
    }

    public void _on_TimerBulletKanan_timeout()
    {
        TimerBulletKanan.IsStopped();
    }
    public void _on_TimerBulletKiri_timeout()
    {
        TimerBulletKanan.IsStopped();
    }
}
