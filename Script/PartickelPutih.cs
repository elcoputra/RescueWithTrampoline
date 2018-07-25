using Godot;
using System;
public class PartickelPutih : Particles2D
{
    // Member variables here, example:
    // private int a = 2;
    // private string b = "textvar";

    Timer destroy;

    public override void _Ready()
    {
        // Called every time the node is added to the scene.
        // Initialization here
        destroy = (Timer) GetNode("destroy");
        destroy.Start();
        
    }


    public void _on_destroy_timeout()
    {
        QueueFree();
    }

//    public override void _Process(float delta)
//    {
//        // Called every frame. Delta is time since last frame.
//        // Update game logic here.
//        
//    }

}

