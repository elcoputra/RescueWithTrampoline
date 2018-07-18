using Godot;
using System;

public class Main : Node2D
{
    // Member variables here, example:
    // private int a = 2;
    // private string b = "textvar";
    [Export] 
    public PackedScene npc;
    public int score;
    public int minusNyawa;
    Timer NpcTimer;
    Label LabelCoin;
    Label WaveLabel;

    Panel PanelGameOver;
    private Random rand = new Random();

    KinematicBody2D player;
    



    public override void _Ready()
    {
        // Called every time the node is added to the scene.
        // Initialization here
    
    player = (KinematicBody2D) GetNode("Player");
    npc = (PackedScene)ResourceLoader.Load("res://Scene/NPCJatuh1.tscn");
    NpcTimer = (Timer) GetNode("NpcTimer");
    NpcTimer.Stop();
    WaveLabel = (Label) GetNode("GUI/WaveLabel");
    PanelGameOver = (Panel) GetNode("GameOver");
    PanelGameOver.Visible = false;



    player.Visible = false;
    


        

        
        
    }

    private float RandRand(float min , float max)
    {
        return (float) (rand.NextDouble() * (max - min) + min);
    }

   public override void _Process(float delta)
   {

       wave();

       if(minusNyawa >= 3)
       {
           GameOver();
       }

      
       
   }

   public void _on_NpcTimer_timeout()
   {
       NpcTimer = (Timer) GetNode("NpcTimer");
       NpcTimer.Start();


       var NpcSpawnLocation = (PathFollow2D) GetNode("NpcSpawn/NpcSpawnLocation");
       NpcSpawnLocation.SetOffset(rand.Next());

    if(minusNyawa <= 3)
    {
        var NpcInstance = (RigidBody2D) npc.Instance();
        AddChild(NpcInstance);
    
      

       var direction = NpcSpawnLocation.Rotation + Mathf.Pi / 2;

       NpcInstance.Position = NpcSpawnLocation.Position;

       
       direction += RandRand(-Mathf.Pi / 4, Mathf.Pi / 15);
       NpcInstance.Rotation = direction;

    }
   }



   public void IncreseScore(Godot.Area2D area)
   {   
       score += 1;
       LabelCoin = (Label) GetNode("GUI/LabelCoin");
       LabelCoin.Text = score.ToString();
   }

   public void wave()
   {
       if(score == 10)
       {
           NpcTimer.WaitTime = 5.5f;
           WaveLabel.Text = "Wave 2 - Just Trying";
        //    GD.Print(NpcTimer.WaitTime);
           
       }

       if(score == 20)
       {
           NpcTimer.WaitTime = 5f;
           WaveLabel.Text = "Wave 3 - interested";
        //    GD.Print(NpcTimer.WaitTime);
           
       }
       if(score == 30)
       {
           NpcTimer.WaitTime = 4.80f;
           WaveLabel.Text = "Wave 4 - Newbe";
        //    GD.Print(NpcTimer.WaitTime);
           
       }
       if(score == 40)
       {
           NpcTimer.WaitTime = 4.75f;
           WaveLabel.Text = "Wave 5 - Amateur";
        //    GD.Print(NpcTimer.WaitTime);
           
       }
       if(score == 50)
       {
           NpcTimer.WaitTime = 4.50f;
           WaveLabel.Text = "Wave 6 Keep Playing";
        //    GD.Print(NpcTimer.WaitTime);
           
       }
       if(score == 80)
       {
           NpcTimer.WaitTime = 4.25f;
           WaveLabel.Text = "Wave 7 Litle Pro";
        //    GD.Print(NpcTimer.WaitTime);
           
       }
       if(score == 90)
       {
           NpcTimer.WaitTime = 4f;
           WaveLabel.Text = "Wave 8 Semi Pro";
        //    GD.Print(NpcTimer.WaitTime);
           
       }

       if(score == 100)
       {
           NpcTimer.WaitTime = 3.75f;
           WaveLabel.Text = "Wave 9 Very Interested";
        //    GD.Print(NpcTimer.WaitTime);
           
       }

       if(score == 115)
       {
           NpcTimer.WaitTime = 3.60f;
           WaveLabel.Text = "Wave 10 Become A Pro";
        //    GD.Print(NpcTimer.WaitTime);
           
       }

       if(score == 130)
       {
           NpcTimer.WaitTime = 3.5f;
           WaveLabel.Text = "Wave 11 Beautifull";
        //    GD.Print(NpcTimer.WaitTime);
           
       }

       if(score == 150)
       {
           NpcTimer.WaitTime = 3.25f;
           WaveLabel.Text = "Wave 12 Proffesional";
        //    GD.Print(NpcTimer.WaitTime);
           
       }

       if(score == 170)
       {
           NpcTimer.WaitTime = 3f;
           WaveLabel.Text = "Wave 13";
        //    GD.Print(NpcTimer.WaitTime);
           
       }

       if(score == 190)
       {
           NpcTimer.WaitTime = 2.75f;
           WaveLabel.Text = "Wave 14";
        //    GD.Print(NpcTimer.WaitTime);
           
       }

       if(score == 250)
       {
           NpcTimer.WaitTime = 2.5f;
           WaveLabel.Text = "Wave 15";
        //    GD.Print(NpcTimer.WaitTime);
           
       }

       if(score == 300)
       {
           NpcTimer.WaitTime = 2.25f;
           WaveLabel.Text = "Wave 16";
        //    GD.Print(NpcTimer.WaitTime);
           
       }
       if(score == 400)
       {
           NpcTimer.WaitTime = 2f;
           WaveLabel.Text = "Wave 17";
        //    GD.Print(NpcTimer.WaitTime);
           
       }

       if(score == 600)
       {
           NpcTimer.WaitTime = 1.75f;
           WaveLabel.Text = "Wave 18";
        //    GD.Print(NpcTimer.WaitTime);
           
       }
       if(score == 700)
       {
           NpcTimer.WaitTime = 1.75f;
           WaveLabel.Text = "Wave 18";
        //    GD.Print(NpcTimer.WaitTime);
           
       }

       if(score == 800)
       {
           NpcTimer.WaitTime = 1.50f;
           WaveLabel.Text = "Wave 19";
        //    GD.Print(NpcTimer.WaitTime);
           
       }

       if(score == 900)
       {
           NpcTimer.WaitTime = 1.25f;
           WaveLabel.Text = "Wave 20";
        //    GD.Print(NpcTimer.WaitTime);
           
       }
   }

   public void _on_LantaiLifeDetect_area_entered(Godot.Area2D lantaiDetectLife)
   {

       minusNyawa += 1;

       if(lantaiDetectLife.Name == "LifeDetect")
       {
        //    GD.Print("Nyawa Berkurang");

           if(minusNyawa == 1)
           {  
               var guiLope3 = (AnimatedSprite) GetNode("GUI/life/life3");
               guiLope3.Visible = false;
           }
           if(minusNyawa == 2)
           {  
               var guiLope2 = (AnimatedSprite) GetNode("GUI/life/life2");
               guiLope2.Visible = false;
           }
           if(minusNyawa == 3)
           {  
               var guiLope3 = (AnimatedSprite) GetNode("GUI/life/life1");
               guiLope3.Visible = false;
           }
           
           
       }
   }

   public void _on_btn_start_button_down()
   {
    //    GD.Print("start Pressed");

        minusNyawa = 0;
        NpcTimer.Start();
        player.Visible = true;

        var menuGui = (Node2D) GetNode("Menu");
        menuGui.Visible = false;

   }

   public void _on_btn_startGameOver_button_down()
   {
        score = 0;
        LabelCoin = (Label) GetNode("GUI/LabelCoin");
        LabelCoin.Text = score.ToString();
        

        minusNyawa = 0;
        var guiLope1 = (AnimatedSprite) GetNode("GUI/life/life1");
        guiLope1.Visible = true;
        var guiLope2 = (AnimatedSprite) GetNode("GUI/life/life2");
        guiLope2.Visible = true;
        var guiLope3 = (AnimatedSprite) GetNode("GUI/life/life3");
        guiLope3.Visible = true;



        PanelGameOver.Visible = false;
        NpcTimer.Start();
        player.Visible = true;
   }

   public void _on_btn_exit_button_down()
   {
       GetTree().Quit(); // default behavior
   }

   public void _on_btn_exitGameover_button_down()
   {
       GetTree().Quit(); // default behavior
   }



   public void GameOver()
   {   
       
       Label LabelYourScore = (Label) GetNode("GameOver/YourScore/YourScoreValue");
       LabelYourScore.Text = score.ToString();
       player.Visible = false;
       NpcTimer.Stop();
       PanelGameOver.Visible = true;
       
   }



   public void saveGame()
   {


   }

   public void loadGame()
   {

   }

   

   

   


   
}
