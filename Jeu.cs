using System;
using System.Timers;
using Microsoft.VisualBasic;

public class Tim
{
   private static System.Timers.Timer aTimer;
   private bool fin;
   
   

   public Tim(int temps)
   {
        // Create a timer with a two second interval.
        aTimer = new System.Timers.Timer(temps);
      
    }

    public void lancetime(){
      // Hook up the Elapsed event for the timer. 
        aTimer.Elapsed += OnTimedEvent;
        aTimer.AutoReset = false;
        aTimer.Enabled = true;
    }
      void OnTimedEvent(Object source, ElapsedEventArgs e)
    {
        Console.WriteLine("le temps est écoulé, c'est votre dernier mot!");
        fin = true;          
        

    }
    public void stop()
    {
        aTimer.Stop();
        
    }
    public void start()
    {
        aTimer.Start();
    }

    public bool TFT()
    {
        return fin;
    }
    public void TFF(){
        fin = false;
    }
}