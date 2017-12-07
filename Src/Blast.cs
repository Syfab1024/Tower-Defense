/*
 * Erstellt mit SharpDevelop.
 * Benutzer: schulz
 * Datum: 23.09.2011
 * Zeit: 13:33
 * 
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Diagnostics;

namespace TowDef
{
   /// <summary>
   /// Description of Blast.
   /// </summary>
   public class Blast
   {     
      private Point m_Position = new Point();         
      public Point Position {
         get { return m_Position; }
         set { m_Position = value; }
      }
      private int m_Size;         
      public int Size {
         get { return m_Size; }
         set { m_Size = value; }
      }
      
      private int m_SpeedPerFrame;
      public int SpeedPerFrame {
         get { return m_SpeedPerFrame; }
         set { m_SpeedPerFrame = value; }
      }
      
      private double m_MaxFrequencyPerSecond;
      public double MaxFrequencyPerSecond {
         get { return m_MaxFrequencyPerSecond; }
         set { m_MaxFrequencyPerSecond = value; }
      }
           
      private Stopwatch m_Timer = new Stopwatch();         
      public Stopwatch Timer {
         get { return m_Timer; }
         set { m_Timer = value; }
      }
      
      private BlastType m_Type;
      public BlastType Type {
         get { return m_Type; }
         set { m_Type = value; }
      }
      
      private double m_FreezeInSeconds;
      public double FreezeInSeconds {
         get { return m_FreezeInSeconds; }
         set { m_FreezeInSeconds = value; }
      }      
      
      private double m_SlowInSeconds;
      public double SlowInSeconds {
         get { return m_SlowInSeconds; }
         set { m_SlowInSeconds = value; }
      }   
      
      private double m_SlowSpeedPerFrame;      
      public double SlowSpeedPerFrame {
         get { return m_SlowSpeedPerFrame; }
         set { m_SlowSpeedPerFrame = value; }
      }

      private int m_TeleportRange;      
      public int TeleportRange {
         get { return m_TeleportRange; }
         set { m_TeleportRange = value; }
      }     
      
      
      
      // Upgrade
      private int m_Level;         
      public int Level {
         get { return m_Level; }
         set { m_Level = value; }
      }      
      
      private double m_MaxFrequencyPerSecondIncrement;
      public double MaxFrequencyPerSecondIncrement {
         get { return m_MaxFrequencyPerSecondIncrement; }
         set { m_MaxFrequencyPerSecondIncrement = value; }
      }
      private int m_SpeedPerFrameIncrement;      
      public int SpeedPerFrameIncrement {
         get { return m_SpeedPerFrameIncrement; }
         set { m_SpeedPerFrameIncrement = value; }
      }
      
      private double m_FreezeInSecondsIncrement;
      public double FreezeInSecondsIncrement {
         get { return m_FreezeInSecondsIncrement; }
         set { m_FreezeInSecondsIncrement = value; }
      }
         
      private double m_SlowInSecondsIncrement;
      public double SlowInSecondsIncrement {
         get { return m_SlowInSecondsIncrement; }
         set { m_SlowInSecondsIncrement = value; }
      }   
      
      private double m_SlowSpeedPerFrameIncrement;      
      public double SlowSpeedPerFrameIncrement {
         get { return m_SlowSpeedPerFrameIncrement; }
         set { m_SlowSpeedPerFrameIncrement = value; }
      }               
      
      private int m_TeleportRangeIncrement;      
      public int TeleportRangeIncrement {
         get { return m_TeleportRangeIncrement; }
         set { m_TeleportRangeIncrement = value; }
      }
      
      
      
      public Blast()
      {
      }
      
      public void Upgrade()
      {
         m_Level++;
         m_MaxFrequencyPerSecond += m_MaxFrequencyPerSecondIncrement;
         m_SpeedPerFrame += m_SpeedPerFrameIncrement;
         m_FreezeInSeconds += m_FreezeInSecondsIncrement;
         m_SlowInSeconds += m_SlowInSecondsIncrement;
         m_SlowSpeedPerFrame += m_SlowSpeedPerFrameIncrement;
         m_TeleportRange += m_TeleportRangeIncrement;
      }
      
      public void Paint(Graphics g)
      {
         if (m_Position.IsEmpty)
            return;
         
         if (m_Type == BlastType.Normal)
         {
            g.FillEllipse(Brushes.Green, 
                          m_Position.X - m_Size / 2, 
                          m_Position.Y - m_Size / 2,
                          m_Size, m_Size);
            return;
         }
         
         if (m_Type == BlastType.Freeze)
         {
            g.FillEllipse(Brushes.Blue, 
                          m_Position.X - m_Size / 2, 
                          m_Position.Y - m_Size / 2,
                          m_Size, m_Size);
            return;
         }  
         
         if (m_Type == BlastType.Slow)
         {
            g.FillEllipse(Brushes.MediumAquamarine, 
                          m_Position.X - m_Size / 2, 
                          m_Position.Y - m_Size / 2,
                          m_Size, m_Size);
            return;
         }   
         
         if (m_Type == BlastType.Teleport)
         {
            g.FillEllipse(Brushes.Gold, 
                          m_Position.X - m_Size / 2, 
                          m_Position.Y - m_Size / 2,
                          m_Size, m_Size);
            return;
         }             

      }      
   }
}
