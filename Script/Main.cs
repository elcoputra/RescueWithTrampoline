using Godot;
using System;

public class Main : Node2D
{
    [Export] 
    public PackedScene npc;
    public int score;
    public int minusNyawa;
    public int StatusmusicOn;
    public int menuAboutStatus = 0;
    public int speedMenuAbput = 100;
    int Menuopen = 0;
    

    Timer NpcTimer;
    Label LabelCoin;
    Label WaveLabel;
    Label MusicOnOfLabel;
    Panel PanelGameOver;
    Node2D AboutPanel;
    Tween AboutTween;

    AudioStreamPlayer2D MusicMenu;
    AudioStreamPlayer2D MusicPlay;
    AnimatedSprite animOnOffMusic;
    private Random rand = new Random();

    KinematicBody2D player;
    



    public override void _Ready()
    {
        MusicMenu = (AudioStreamPlayer2D) GetNode("MusicMenu");
        MusicPlay = (AudioStreamPlayer2D) GetNode("MusicPlay");
        MusicMenu.Play();
        animOnOffMusic = (AnimatedSprite) GetNode("Menu/MusicOnOf");
        StatusmusicOn = 1;
        MusicOnOfLabel = (Label) GetNode("Menu/MusicOnOf/MusicStatus");

        player = (KinematicBody2D) GetNode("Player");
        npc = (PackedScene)ResourceLoader.Load("res://Scene/NPCJatuh1.tscn");
        NpcTimer = (Timer) GetNode("NpcTimer");
        NpcTimer.Stop();
        WaveLabel = (Label) GetNode("GUI/WaveLabel");
        PanelGameOver = (Panel) GetNode("GameOver");
        PanelGameOver.Visible = false;

        AboutPanel = (Node2D) GetNode("Menu/About");
        AboutTween = (Tween) GetNode("Menu/About/Tween");


        player.Visible = false;    
    }

   public override void _Process(float delta)
   {
       wave();

       if(minusNyawa >= 3)
       {
           GameOver();
       }
   }

    private float RandRand(float min , float max)
    {
        return (float) (rand.NextDouble() * (max - min) + min);
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

    //    var direction = NpcSpawnLocation.Rotation + Mathf.Pi / 2;

       NpcInstance.Position = NpcSpawnLocation.Position;

       
    //    direction += RandRand(-Mathf.Pi / 4, Mathf.Pi / 15);
    //    NpcInstance.Rotation = direction;

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
       switch(score)
       {
           case 5:
           NpcTimer.WaitTime = 5.5f;
           WaveLabel.Text = "Wave 2 - Just Trying";
           break;

           case 20:
           NpcTimer.WaitTime = 5f;
           WaveLabel.Text = "Wave 3 - interested";
           break;

           case 30:
           NpcTimer.WaitTime = 4.80f;
           WaveLabel.Text = "Wave 4 - Amateur";
           break;

           case 40:
           NpcTimer.WaitTime = 4.50f;
           WaveLabel.Text = "Wave 5 - Keep Playing";
           break;

           case 50:
           NpcTimer.WaitTime = 4.00f;
           WaveLabel.Text = "Wave 6 - Litle Pro";
           break;

           case 70:
           NpcTimer.WaitTime = 3.00f;
           WaveLabel.Text = "Wave 7 - Semi Pro";
           break;

           case 80:
           NpcTimer.WaitTime = 3.50f;
           WaveLabel.Text = "Wave 8 - Very Interested";
           break;

           case 90:
           NpcTimer.WaitTime = 3.00f;
           WaveLabel.Text = "Wave 9 - Become A Pro";
           break;

           case 100:
           NpcTimer.WaitTime = 2.5f;
           WaveLabel.Text = "Wave 10 - Pro";
           break;
           
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

        MusicMenu.Stop();
        MusicPlay.Play();
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

        MusicPlay.Play();



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

   public void btn_about_down()
   {
       GD.Print(AboutPanel.GetPosition());

       Vector2 finalPosOpen = new Vector2();
       finalPosOpen.x = -1;
       finalPosOpen.y = 0;

       Vector2 finalPosClose = new Vector2();
       finalPosClose.x = -184;
       finalPosClose.y = 0;
    
       switch (Menuopen)
       {
           case 1:
            AboutTween.InterpolateProperty(AboutPanel,":position",
                                            AboutPanel.GetPosition(), finalPosClose, 1.0f, 
                                            Tween.TransitionType.Bounce, Tween.EaseType.Out, 0);
            AboutTween.Start();
            Menuopen = 0;
           break;

           case 0:
            AboutTween.InterpolateProperty(AboutPanel,":position",
                                            AboutPanel.GetPosition(), finalPosOpen, 1.0f, 
                                            Tween.TransitionType.Bounce, Tween.EaseType.Out, 0);
            AboutTween.Start();
            Menuopen = 1;
           break;
       }
   }

   public void GameOver()
   {      
       MusicPlay.Stop();
       Label LabelYourScore = (Label) GetNode("GameOver/YourScore/YourScoreValue");
       LabelYourScore.Text = score.ToString();
       player.Visible = false;
       NpcTimer.Stop();
       PanelGameOver.Visible = true;   

   }

   public void _on_GameOver_visibility_changed()
   {
       if(minusNyawa == 3)
       {
            AudioStreamPlayer2D MusicGameOver = (AudioStreamPlayer2D) GetNode("MusicGameOver");
            MusicGameOver.Play();
       }
       
   }

   public void _on_MsuciStatus_button_down()
   {
   
       switch (StatusmusicOn)
       {
           case 1:
            MusicMenu.Stop();
            animOnOffMusic.Play("Off");
            MusicOnOfLabel.SetText("Music Off");
            StatusmusicOn = 0;
            break;

            case 0:
            MusicMenu.Play();
            animOnOffMusic.Play("On");
            MusicOnOfLabel.SetText("Music On");
            StatusmusicOn = 1;
            break;
       }
       
   }
   
}
