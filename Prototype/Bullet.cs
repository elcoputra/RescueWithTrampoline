using Godot;
using System;

public class Bullet : KinematicBody2D
{
    // Member variables here, example:
    // private int a = 2;
    // private string b = "textvar";
    Vector2 velocity;
    public int kecepatan = 2000;

    PackedScene HitSound;
    AudioStreamPlayer HitSoundInstance;

    public override void _Ready()
    {
        // Called every time the node is added to the scene.
        // Initialization here
        
    }

//    public override void _Process(float delta)
//    {
//        // Called every frame. Delta is time since last frame.
//        // Update game logic here.
//        
//    }

    public override void _PhysicsProcess(float delta)
    {
        velocity = new Vector2(kecepatan, 0).Rotated(Rotation);
        MoveAndCollide(velocity * delta);
        
    }
    
    public void _on_AreaBullet_area_entered(Area2D area)
    {
        if(area.Name == "AreaBarrel" || area.Name == "AreaMeteor")
        {
            HitSound = (PackedScene) ResourceLoader.Load("res://Music/NodeDanScript/HitSound.tscn");
            HitSoundInstance = (AudioStreamPlayer) HitSound.Instance();
            GetParent().AddChild(HitSoundInstance);
            HitSoundInstance.Play();

        }
        if(area.Name == "AreaBarrel" || area.Name == "AreaMeteor" || area.Name == "AreaBullet" || area.Name == "LantaiArea2D")
        {
            QueueFree();
        }
    }
}
