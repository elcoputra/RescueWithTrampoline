using Godot;
using System;

public class NPCJatuh1 : RigidBody2D
{
    AnimatedSprite animRigid;

    Timer TimerCoin;
    Timer TimerDestroyCoin;
    Timer TimerDestroyLantai;
    PackedScene CoinCollectable;

    public int status = 0;

    public override void _Ready()
    {

        CoinCollectable = (PackedScene)ResourceLoader.Load("res://Scene/CaoinCollectable.tscn");


        animRigid = (AnimatedSprite) GetNode("AnimatedSprite");
        TimerCoin = (Timer) GetNode("TimerCoin");
        TimerDestroyCoin = (Timer) GetNode("TimerDestroyCoin");
        TimerDestroyLantai = (Timer) GetNode("TimerDestroyLantai");

        
    }

//    public override void _Process(float delta)
//    {
       
//    }

   public void _on_Area2D_area_entered(Godot.Area2D area)
   {
       animRigid.Play("Idle");
    //    GD.Print(area.Name);

       if(area.Name == "Trampoline")
       {
           if(status == 0)
           {
               status = 1;
           }

           if(status == 1)
           {
               TimerCoin.Start();
               TimerDestroyCoin.Start();
           }
       }

       if(area.Name == "LantaiArea2D")
       {
           if (status == 0)
           {
               status = 2;
           }

           if(status == 2)
           {
               TimerDestroyLantai.Start();
           }
       }
       
   }
   public void _on_Area2D_area_exited(Godot.Object area)
   {
       animRigid.Play("default");
   }

   public void _on_TimerCoin_timeout()
   {
    //    GD.Print("Saatnya Spawn Koin");
       TimerCoin.Stop();

       RigidBody2D SpawnCoin = (RigidBody2D) CoinCollectable.Instance();
       GetParent().AddChild(SpawnCoin);

       Position2D CoinSpawn = (Position2D) GetNode("CoinSpawn");
       SpawnCoin.SetPosition(CoinSpawn.GetGlobalPosition());
   }

   public void _on_TimerDestroyCoin_timeout()
   {
       QueueFree();
   }


   public void _on_TimerDestroyLantai_timeout()
   {
       QueueFree();
   }

   public void _on_LifeDetect_area_entered(Godot.Area2D lifedetecd)
   {
    //    GD.Print(lifedetecd.Name);
       if(lifedetecd.Name == "Trampoline")
       {
           var VarLiveDetect = (Area2D) GetNode("LifeDetect");
           VarLiveDetect.CallDeferred("set_monitorable", false);
           VarLiveDetect.CallDeferred("set_monitoring", false);
           
       }
       
   }
 
}
