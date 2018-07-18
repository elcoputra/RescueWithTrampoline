using Godot;
using System;

public class CaoinCollectable : RigidBody2D
{
    // Member variables here, example:
    // private int a = 2;
    // private string b = "textvar";

    public override void _Ready()
    {
        // Called every time the node is added to the scene.
        // Initialization here
        
    }


    public void _on_CoinArea_area_entered(Godot.Area2D area)
    {
        // GD.Print("Coin ", area.Name);
        if(area.Name == "PlayerArea")
        {
            QueueFree();
            // GD.Print("QueueFree");
        }
        
    }

//    public override void _Process(float delta)
//    {
//        // Called every frame. Delta is time since last frame.
//        // Update game logic here.
//        
//    }
}
