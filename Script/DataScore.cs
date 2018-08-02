using Godot;
using System;

public class DataScore : Node2D
{
    // Member variables here, example:
    // private int a = 2;
    // private string b = "textvar";
    Label ScoreMeteor;
    public int NilaiMeteor = 0;
    Label ScoreBarrel;
    public int NilaiBarrel = 0;
    Node2D EnemySpawn;
    Node2D MainRoot;

    public override void _Ready()
    {
        // Called every time the node is added to the scene.
        // Initialization here
        ScoreBarrel = (Label) GetNode("/root/Main/GameOver/BarrelScore/ScoreBarrel");
        ScoreMeteor = (Label) GetNode("/root/Main/GameOver/MeteorScore/ScoreMeteor");

        EnemySpawn = (Node2D) GetNode("/root/Main/EnemySpawn");
        EnemySpawn.Connect("BarrelAddScoreToLabel", this, "ScoreBarrelConnect");

        MainRoot = (Node2D) GetNode("/root/Main");
        MainRoot.Connect("DataScoreMeteorData", this, "ScoreMeteorConnect");

        
        
    }

   public override void _Process(float delta)
   {
       // Called every frame. Delta is time since last frame.
       // Update game logic here.
       
   }

   public void ScoreBarrelConnect()
   {
    //    GD.Print("Signal Barrel Berhasil (DataScore.cs)");
       NilaiBarrel += 1;
       ScoreBarrel.Text = NilaiBarrel.ToString();
   }

       public void ScoreMeteorConnect()
    {
        // GD.Print("Connect Score Meteor Berhasil (main.cs)");
        NilaiMeteor += 1;
        ScoreMeteor.Text = NilaiMeteor.ToString();
    }
}
