using Godot;
using System;

public class Trampoline : Area2D
{
    // Member variables here, example:
    // private int a = 2;
    // private string b = "textvar";

    AnimatedSprite anim;

    public override void _Ready()
    {
        // Called every time the node is added to the scene.
        // Initialization here

        anim = (AnimatedSprite) GetNode("AnimatedSprite");
        
    }


    public void _on_Trampoline_body_entered(object body)
    {
        anim.Play("Bouncing");
        
       
    }

    public void _on_Trampoline_body_exited(object body)
    {
        anim.Play("default");
        
    }

//    public override void _Process(float delta)
//    {
//        // Called every frame. Delta is time since last frame.
//        // Update game logic here.
//        
//    }
}
