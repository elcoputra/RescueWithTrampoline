using Godot;
using System;

public class EnemySpawn : Node2D
{
    // Member variables here, example:
    // private int a = 2;
    // private string b = "textvar";

    [Signal]
    delegate void BarrelAddScoreToLabel();

    public PackedScene EnemyBarrel;

    private Random rand = new Random();
    public Timer TimerSpawnKanan;
    public float waitTimeSpawn;
    public int direction;
    public Position2D SpawnBarrelKanan;
    public Position2D SpawnBarrelKiri;

    public override void _Ready()
    {
        // Called every time the node is added to the scene.
        // Initialization here
        EnemyBarrel = (PackedScene) ResourceLoader.Load("res://Scene/Barrel.tscn");
        TimerSpawnKanan = (Timer) GetNode("SpawnBarrelKanan/TimerSpawnKanan");
        SpawnBarrelKanan = (Position2D) GetNode("SpawnBarrelKanan"); 
        SpawnBarrelKiri = (Position2D) GetNode("SpawnBarrelKiri"); 

        
    }

    public override void _Process(float delta)
    {
        
    }

    public float randrand(float min, float max)
    {
        return (float) (rand.NextDouble() * (max - min) + min);
    }

    public void onStartButtonPressed()
    {
        waitTimeSpawn = randrand(10,15);
        TimerSpawnKanan.SetWaitTime(waitTimeSpawn);
        TimerSpawnKanan.Start();

    }

    public void _on_TimerSpawnKanan_timeout()
    {
        direction = rand.Next()%2;
        GD.Print(direction);
        
        var EnemyBarrelInstance = (KinematicBody2D) EnemyBarrel.Instance();
        AddChild(EnemyBarrelInstance);
        EnemyBarrelInstance.Connect("ScoreBarrel", this, "ScoreBarrelConnect");
        switch(direction)
        {
            case 0:
            EnemyBarrelInstance.Position = SpawnBarrelKanan.Position;
            break;

            case 1:
            EnemyBarrelInstance.Position = SpawnBarrelKiri.Position;
            break;

        }
        waitTimeSpawn = randrand(10,20);
        TimerSpawnKanan.SetWaitTime(waitTimeSpawn);
        TimerSpawnKanan.Start();
    }
    public void ScoreBarrelConnect()
    {
        EmitSignal(nameof(BarrelAddScoreToLabel));
    }
}
