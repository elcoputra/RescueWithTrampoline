using Godot;
using System;

public class CaoinCollectable : RigidBody2D
{
 
    Timer coinHilang;

    public override void _Ready()
    {
    
        coinHilang = (Timer) GetNode("TimerCoin");
        coinHilang.Start();
        
    }

    public void _on_CoinArea_area_entered(Godot.Area2D area)
    {
        // GD.Print("Coin ", area.Name);
        if(area.Name == "PlayerArea")
        {
            QueueFree();
        }
        
    }

    public void _on_TimerCoin_timeout()
    {
        QueueFree();
            // GD.Print("QueueFree");
    }
//    public override void _Process(float delta)
//    {
//        // Called every frame. Delta is time since last frame.
//        // Update game logic here.
//        
//    }
}
