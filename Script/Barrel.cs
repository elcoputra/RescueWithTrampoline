using Godot;
using System;

public class Barrel : KinematicBody2D
{
    // Member variables here, example:
    // private int a = 2;
    // private string b = "textvar";

    float force = 150;
    int direction = 0;
    AnimatedSprite animBarrel;

    public override void _Ready()
    {
        // Called every time the node is added to the scene.
        // Initialization here
        animBarrel = (AnimatedSprite) GetNode("animBarrel");
        
    }

//    public override void _Process(float delta)
//    {
//        // Called every frame. Delta is time since last frame.
//        // Update game logic here.
//        
//    }


    public override void _PhysicsProcess(float delta)
    {
        Vector2 GerakKiri = new Vector2();
        GerakKiri.y += force;
        

        switch(direction)
        {
            case 1:
            GerakKiri.x += force;
            animBarrel.FlipH = true;
            break;

            case 0:
            GerakKiri.x -= force;
            animBarrel.FlipH = false;
            break;
        }

        MoveAndSlide(GerakKiri);

        

    }

    public void _on_AreaBarrel_area_entered(Godot.Area2D area)
    {
        if(area.Name == "AreaSpawnKiri")
        {
            direction = 1;
        }

        if(area.Name == "QuefreeKanan" || area.Name == "QuefreeKiri")
        {
            QueueFree();
        }
    }
}
