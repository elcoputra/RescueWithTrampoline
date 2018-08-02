using Godot;
using System;

public class BadanPenembak : Node2D
{
    // Member variables here, example:
    // private int a = 2;
    // private string b = "textvar";

    PackedScene Tangan;
    Position2D PosisiTangan;
    

    public override void _Ready()
    {
        // Called every time the node is added to the scene.
        // Initialization here

        Tangan = (PackedScene)ResourceLoader.Load("res://Prototype/MoveHand.tscn");
        PosisiTangan = (Position2D)GetNode("PosisiTangan");
        var TanganInstance = (KinematicBody2D)Tangan.Instance();
        GetParent().CallDeferred("add_child", TanganInstance);
        TanganInstance.Position = PosisiTangan.GlobalPosition;
        
    }

    public void _on_AreaBadanPenembak_area_entered(Area2D area)
    {
       if(area.Name == "PosPenembakKanan")
       {
           Sprite Badan = (Sprite)GetNode("Badan");
           Badan.FlipH = true;
       }
    }

//    public override void _Process(float delta)
//    {
//        // Called every frame. Delta is time since last frame.
//        // Update game logic here.
//        
//    }


}
