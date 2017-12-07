/*
 * Erstellt mit SharpDevelop.
 * Benutzer: schulz
 * Datum: 26.09.2011
 * Zeit: 15:55
 * 
 */
using System;
using System.Drawing;

namespace TowDef
{
   /// <summary>
   /// Description of TowerFactory.
   /// </summary>
   public static class TowerFactory
   {      
      public static Tower GetNewTower(string Type)
      {
         Tower t = new Tower();
         
         if (Type == "B")
         {
            t.Type = Type;
            t.Name = "Base Tower";
            t.Damage = 10;
            t.Range = 60;
            t.Size = 15;
            t.Cost = 30;
            t.Blast.MaxFrequencyPerSecond = 2;
            t.Blast.SpeedPerFrame = 10;
            t.Blast.Size = 3;
            t.Blast.Type = BlastType.Normal;
            t.Blast.FreezeInSeconds = 0;
            t.Brush = Brushes.Black;
            t.EnemyFindStrategy = EnemyFindStrategy.First;
            
            // Upgrade
            t.UpgradeCost = 20;
            t.UpgradeCostFactor = 1.1;
            t.DamageIncrement = 4;
            t.RangeIncrement = 2;
            t.SizeIncrement = 1;
            t.Blast.MaxFrequencyPerSecondIncrement = 0.05;
            t.Blast.FreezeInSecondsIncrement = 0;            
            t.Blast.SpeedPerFrameIncrement = 0;
            
            return t;
         }
         
         if (Type == "R")
         {
            t.Type = Type;
            t.Name = "Range Tower";
            t.Damage = 40;
            t.Range = 150;
            t.Size = 25;
            t.Cost = 80;
            t.Blast.MaxFrequencyPerSecond = 0.5;
            t.Blast.SpeedPerFrame = 5;
            t.Blast.Size = 8;
            t.Blast.Type = BlastType.Normal;
            t.Blast.FreezeInSeconds = 0;
            t.Brush = Brushes.DarkGreen;
            t.EnemyFindStrategy = EnemyFindStrategy.Nearest;
            
            // Upgrade
            t.UpgradeCost = 40;
            t.UpgradeCostFactor = 1.1;
            t.DamageIncrement = 5;
            t.RangeIncrement = 3;
            t.SizeIncrement = 1;
            t.Blast.MaxFrequencyPerSecondIncrement = 0.05;
            t.Blast.FreezeInSecondsIncrement = 0;                        
            t.Blast.SpeedPerFrameIncrement = 0;
            
            return t;
         }         
         
         if (Type == "F")
         {
            t.Type = Type;
            t.Name = "Freeze Tower";
            t.Damage = 5;
            t.Range = 50;
            t.Size = 20;
            t.Cost = 180;
            t.Blast.MaxFrequencyPerSecond = 0.3;
            t.Blast.SpeedPerFrame = 8;
            t.Blast.Size = 5;
            t.Blast.Type = BlastType.Freeze;
            t.Blast.FreezeInSeconds = 2;
            t.Brush = Brushes.Blue;
            t.EnemyFindStrategy = EnemyFindStrategy.Strongest;
            
            // Upgrade
            t.UpgradeCost = 50;
            t.UpgradeCostFactor = 1.1;
            t.DamageIncrement = 2;
            t.RangeIncrement = 2;
            t.SizeIncrement = 1;
            t.Blast.MaxFrequencyPerSecondIncrement = 0.1;
            t.Blast.FreezeInSecondsIncrement = 0.1;            
            t.Blast.SpeedPerFrameIncrement = 0;
            
            return t;
         }    
         

         if (Type == "E")
         {
            // TODO!!!
            t.Type = Type;
            t.Name = "Splash Tower";
            t.Damage = 5;
            t.Range = 60;
            t.Size = 30;
            t.Cost = 150;
            t.Blast.MaxFrequencyPerSecond = 0.3;
            t.Blast.SpeedPerFrame = 8;
            t.Blast.Size = 5;
            t.Blast.Type = BlastType.Splash;
            t.Blast.FreezeInSeconds = 2;
            t.Brush = Brushes.Red;
            t.EnemyFindStrategy = EnemyFindStrategy.Strongest;
            
            // Upgrade
            t.UpgradeCost = 50;
            t.UpgradeCostFactor = 1.1;
            t.DamageIncrement = 2;
            t.RangeIncrement = 5;
            t.SizeIncrement = 1;
            t.Blast.MaxFrequencyPerSecondIncrement = 0.1;
            t.Blast.FreezeInSecondsIncrement = 0.1;            
            t.Blast.SpeedPerFrameIncrement = 0;
            
            return t;
         }
         

         if (Type == "T")
         {
            t.Type = Type;
            t.Name = "Teleport Tower";
            t.Damage = 3;
            t.Range = 70;
            t.Size = 25;
            t.Cost = 200;
            t.Blast.MaxFrequencyPerSecond = 0.4;
            t.Blast.SpeedPerFrame = 8;
            t.Blast.Size = 15;
            t.Blast.Type = BlastType.Teleport;
            t.Blast.TeleportRange = 200;
            t.Brush = Brushes.Chocolate;
            t.EnemyFindStrategy = EnemyFindStrategy.Strongest;
            
            
            // Upgrade
            t.UpgradeCost = 50;
            t.UpgradeCostFactor = 1.1;
            t.DamageIncrement = 2;
            t.RangeIncrement = 2;
            t.SizeIncrement = 1;
            t.Blast.MaxFrequencyPerSecondIncrement = 0.03;
            t.Blast.SpeedPerFrameIncrement = 0;
            t.Blast.TeleportRangeIncrement = 20;            
            
            return t;
         }         
         

         if (Type == "S")
         {
            t.Type = Type;
            t.Name = "Slow Tower";
            t.Damage = 5;
            t.Range = 60;
            t.Size = 25;
            t.Cost = 140;
            t.Blast.MaxFrequencyPerSecond = 0.5;
            t.Blast.SpeedPerFrame = 8;
            t.Blast.Size = 5;
            t.Blast.Type = BlastType.Slow;
            t.Blast.SlowInSeconds = 2;
            t.Blast.SlowSpeedPerFrame = 0.4;
            t.Brush = Brushes.DarkTurquoise;
            t.EnemyFindStrategy = EnemyFindStrategy.Nearest;
            
            // Upgrade
            t.UpgradeCost = 50;
            t.UpgradeCostFactor = 1.1;
            t.DamageIncrement = 2;
            t.RangeIncrement = 3;
            t.SizeIncrement = 1;
            t.Blast.MaxFrequencyPerSecondIncrement = 0.04;
            t.Blast.SpeedPerFrameIncrement = 0;
            t.Blast.SlowInSecondsIncrement = 0.1;
            t.Blast.SlowSpeedPerFrameIncrement = 0;
            
            return t;
         }
         
         return null;
      }
   }
}
