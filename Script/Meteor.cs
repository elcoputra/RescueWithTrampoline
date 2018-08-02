using Godot;
using System;

public class Meteor : RigidBody2D
{
    // Member variables here, example:
    // private int a = 2;
    // private string b = "textvar";
    [Signal]
    delegate void ScoreMeteor();

    PackedScene Coin;
    AnimatedSprite ImagePecah;

    int NyawaMeteor = 2;
    int RanCoin;
    Random rand = new Random();

    public override void _Ready()
    {
        // Called every time the node is added to the scene.
        // Initialization here
        Coin = (PackedScene)ResourceLoader.Load("res://Scene/CaoinCollectable.tscn");
        ImagePecah = (AnimatedSprite) GetNode("MeteorImage");

    }

    public override void _PhysicsProcess(float delta)
    {
        RanCoin = rand.Next(0 , 5);
        // GD.Print(RanCoin, "Meteor.cs");
    }

    public void _on_AreaMeteor_area_entered(Area2D area)
    {
        if(area.Name == "AreaBullet")
        {
            NyawaMeteor -= 1;
            ImagePecah.Play("Pecah");

        }
        if(area.Name == "LantaiArea2D")
        {
            QueueFree();
        }
    }

   public override void _Process(float delta)
   {
       
       if(NyawaMeteor == 0)
       {
           var PackedAnimMeteorAncur = (PackedScene) ResourceLoader.Load("res://Art/Meteor/MeteorPecah/MeteorHancur.tscn");
           var AnimMeteorAncur = (AnimatedSprite) PackedAnimMeteorAncur.Instance();
           GetParent().AddChild(AnimMeteorAncur);
           

           if(RanCoin == 1)
           {
                var CoinInstance = (RigidBody2D) Coin.Instance();
                GetParent().AddChild(CoinInstance);
                CoinInstance.Position = this.GlobalPosition;
           }
           EmitSignal(nameof(ScoreMeteor));
           QueueFree();
       }       
   }
}
