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
   /// Description of Tower.
   /// </summary>
   public class Tower
   {
      private string m_Type;         
      public string Type {
         get { return m_Type; }
         set { m_Type = value; }
      }
      
      private EnemyFindStrategy m_EnemyFindStrategy;         
      public EnemyFindStrategy EnemyFindStrategy {
         get { return m_EnemyFindStrategy; }
         set { m_EnemyFindStrategy = value; }
      }
         
      private string m_Name;         
      public string Name {
         get { return m_Name; }
         set { m_Name = value; }
      }
      
      private Point m_Position = new Point();         
      public Point Position {
         get { return m_Position; }
         set 
         {
            m_Position = value;
            m_Rectangle = GetRectangle();
         }
      }
      private int m_Size;         
      public int Size {
         get { return m_Size; }
         set 
         { 
            m_Size = value; 
            m_Font = new Font(FontFamily.GenericSansSerif, (int)Math.Round(m_Size / 2.5, 0));
         }
      }
      
      private int m_Range;               
      public int Range {
         get { return m_Range; }
         set { m_Range = value; }
      }
      
      private double m_Damage;         
      public int Damage {
         get { return (int)m_Damage; }
         set { m_Damage = value; }
      }      
      
      private Rectangle m_Rectangle;         
      public Rectangle Rectangle {
         get { return m_Rectangle; }
      }

      private int m_CostUntilNow;
      
      private int m_Cost;         
      public int Cost {
         get { return m_Cost; }
         set { 
            m_Cost = value;
            m_CostUntilNow = m_Cost;
         }
      }
      
      private Font m_Font = new Font(FontFamily.GenericSansSerif, 7);
      
      private Blast m_Blast;   
      public Blast Blast {
         get { return m_Blast; }
         set { m_Blast = value; }
      }
      private Enemy m_CurrentEnemy;
      
      private Brush m_Brush;
      public Brush Brush {
         get { return m_Brush; }
         set { m_Brush = value; }
      }
      
      private bool m_Selected = false;         
      public bool Selected {
         get { return m_Selected; }
         set { m_Selected = value; }
      }
      
      // Upgrade
      private double m_UpgradeCost;         
      public int UpgradeCost {
         get { return (int)m_UpgradeCost; }
         set { m_UpgradeCost = value; }
      }
      
      private double m_UpgradeCostFactor;         
      public double UpgradeCostFactor {
         get { return m_UpgradeCostFactor; }
         set { m_UpgradeCostFactor = value; }
      }      
      
      private int m_Level;         
      public int Level {
         get { return m_Level; }
         set { m_Level = value; }
      }     
      
      private double m_DamageIncrement;         
      public int DamageIncrement {
         get { return (int)m_DamageIncrement; }
         set { m_DamageIncrement = value; }
      }
      private int m_RangeIncrement;         
      public int RangeIncrement {
         get { return m_RangeIncrement; }
         set { m_RangeIncrement = value; }
      }
      private int m_SizeIncrement;   
      public int SizeIncrement {
         get { return m_SizeIncrement; }
         set { m_SizeIncrement = value; }
      }
      
      public int SellValue {
         get { return  (int)Math.Round((m_CostUntilNow) * 0.8, 0); }
      }
            
      
      
      // zum Info nach außen geben, wenn Enemy zerstört wurde
      public delegate void EnemyDestroyedEventHandler(Enemy enemy);
      /// <summary>
      /// Wird aufgerufen, wenn Enemy zerstört wurde
      /// </summary>
      public event EnemyDestroyedEventHandler OnEnemyDestroyed;          
      
      public Tower()
      {
         m_Blast = new Blast();   
         m_Position = Position;
         m_Level = 1;
      }
      
      public void Upgrade()
      {
         m_Level++;
         m_CostUntilNow += UpgradeCost;
         
         m_UpgradeCost *= m_UpgradeCostFactor;
         m_Damage += m_DamageIncrement;
         m_Range += m_RangeIncrement;
         Size += m_SizeIncrement;
         m_Rectangle = GetRectangle();
         m_Blast.Upgrade();
      }
      
      private Rectangle GetRectangle()
      {
         return new Rectangle(m_Position.X - m_Size / 2,
                             m_Position.Y - m_Size / 2, 
                             m_Size, m_Size);
      }
      
      public void Paint(Graphics g)
      {
         if (m_Position.IsEmpty)
            return;
         
         if (m_Selected)
         {
            // Tower-Range:
            g.FillEllipse(new SolidBrush(Color.FromArgb(30, 0, 0, 0)),
                       m_Position.X - m_Range,
                       m_Position.Y - m_Range,
                       m_Range * 2, m_Range * 2);
            
            // Tower-Umrandung:
            g.FillRectangle(Brushes.Yellow, 
                            m_Rectangle.X - 2, m_Rectangle.Y - 2,
                            m_Rectangle.Width + 4, m_Rectangle.Height + 4);
         }
         
         g.FillRectangle(m_Brush, m_Rectangle);
         
         g.DrawString(m_Type, m_Font, Brushes.White, 
                      m_Position.X - m_Size / 4,
                      m_Position.Y - m_Size / 4);
         
         m_Blast.Paint(g);
      }        
      
      private double GetDistanceBetweenPoints(Point p1, Point p2)
      {
         if (p1.IsEmpty || p2.IsEmpty)
            return 999999;
         
         // Entfernung über Pythagoras:  distance := sqrt(a^2 + b^2)
         int diffX = p1.X - p2.X;
         int diffY = p1.Y - p2.Y;
         
         double distance = MathHelper.Sqrt(diffX * diffX + diffY * diffY);
         
         return distance;
      }
      
      public void FindEnemyInRange(List<Enemy> EnemyList)
      {         
         // Blast noch unterwegs zum Feind?
         if (!m_Blast.Position.IsEmpty)
         {
            UpdateBlast();
            return;
         }
            
         
         // ggf. neuen/nächsten Enemy finden
         // --> Feind an vorderster Position (max(pathPosition)) finden
         if (m_CurrentEnemy != null)
            m_CurrentEnemy.IsUnlockedByTower(this);
         
         m_CurrentEnemy = null;         
         double valueToCompare;
         if (m_EnemyFindStrategy == EnemyFindStrategy.First
             || m_EnemyFindStrategy == EnemyFindStrategy.Strongest
             || m_EnemyFindStrategy == EnemyFindStrategy.Farest
             || m_EnemyFindStrategy == EnemyFindStrategy.Fastest)
         {         
            valueToCompare = 0;
         }
         else
         {
            valueToCompare = double.MaxValue;
         }
         foreach(Enemy e in EnemyList)
         {
            // ist Enemy im Range?
            if (GetDistanceBetweenPoints(m_Position, e.Position) <= m_Range)
            {
               double currentValue = 0;
               
               /// <summary>
               /// First/Last -> Enemy mit höchster bzw. niedrigster PathPosition
               /// </summary>
               if (m_EnemyFindStrategy == EnemyFindStrategy.First
                   || m_EnemyFindStrategy == EnemyFindStrategy.Last)
                  currentValue = e.PathPosition;
               
               /// <summary>
               /// Strongest/Weakest -> Enemy mit höchsten bzw. niedrigsten LifePoints
               /// </summary>               
               else if (m_EnemyFindStrategy == EnemyFindStrategy.Strongest
                        || m_EnemyFindStrategy == EnemyFindStrategy.Weakest)
                  currentValue = e.CurrentLifePoints;
               
               /// <summary>
               /// Farest/Nearest -> Enemy mit höchster bzw. niedrigster Entfernung zum Tower
               /// </summary>               
               else if (m_EnemyFindStrategy == EnemyFindStrategy.Farest
                        || m_EnemyFindStrategy == EnemyFindStrategy.Nearest)
                  currentValue = GetDistanceBetweenPoints(m_Position, e.Position);
               
               /// <summary>
               /// Fastest/Slowest -> Enemy mit höchster bzw. niedrigster Geschwindigkeit
               /// </summary>                         
               else if (m_EnemyFindStrategy == EnemyFindStrategy.Fastest
                        || m_EnemyFindStrategy == EnemyFindStrategy.Slowest)
                  currentValue = e.SpeedPerFrame;
               
               // ermittelte Werte auswerten
               if (m_EnemyFindStrategy == EnemyFindStrategy.First
                   || m_EnemyFindStrategy == EnemyFindStrategy.Strongest
                   || m_EnemyFindStrategy == EnemyFindStrategy.Farest
                   || m_EnemyFindStrategy == EnemyFindStrategy.Fastest)
               {
                  if (currentValue > valueToCompare)
                  {
                     m_CurrentEnemy = e;
                     m_CurrentEnemy.IsLockedByTower(this);
                     valueToCompare = currentValue;
                  }                  
               }
               else
               {
                  if (currentValue < valueToCompare)
                  {
                     m_CurrentEnemy = e;
                     m_CurrentEnemy.IsLockedByTower(this);
                     valueToCompare = currentValue;
                  }                      
               }
            }
         }
         
         UpdateBlast();
      }      
      
      public void ResetBlast()
      {
         m_Blast.Position = new Point();
      }
      
      private void UpdateBlast()
      {
         // ist überhaupt ein Enemy gelockt?
         if (m_CurrentEnemy == null)
         {
            if (!m_Blast.Position.IsEmpty)
               ResetBlast();
            
            return;
         }
         
         // bereit für neuen/nächsten Blast?
         if (m_Blast.Position.IsEmpty
             && m_Blast.Timer.ElapsedMilliseconds < 1000 / m_Blast.MaxFrequencyPerSecond
             && m_Blast.Timer.IsRunning)
         {
            return;
         }         
         
         // neuen Blast abfeuern
         if (m_Blast.Position.IsEmpty)
         {
            m_Blast.Position = m_Position;
            m_Blast.Timer.Reset();
            m_Blast.Timer.Start();
         }
         
         // neue Position des Blasts berechnen
         int x = m_CurrentEnemy.Position.X - m_Blast.Position.X;
         int y = m_CurrentEnemy.Position.Y - m_Blast.Position.Y;
         
         if (Math.Abs(x) < m_Blast.SpeedPerFrame)
            x = 0;
         if (Math.Abs(y) < m_Blast.SpeedPerFrame)
            y = 0;
         
         int xSign = Math.Sign(x);
         int ySign = Math.Sign(y);
         m_Blast.Position = new Point(m_Blast.Position.X + xSign * m_Blast.SpeedPerFrame,
                                      m_Blast.Position.Y + ySign * m_Blast.SpeedPerFrame);
         
         // hat Blast sein Ziel erreicht?
         if (xSign == 0 && ySign == 0)
         {
            OnEnemyHit();
         }
      }      
      
      private void OnEnemyHit()
      {
         // Spezial-Schüsse auswerten
         if (m_Blast.Type == BlastType.Freeze)
            m_CurrentEnemy.Freeze(m_Blast.FreezeInSeconds);

         if (m_Blast.Type == BlastType.Slow)
            m_CurrentEnemy.Slow(m_Blast.SlowInSeconds, m_Blast.SlowSpeedPerFrame);            

         if (m_Blast.Type == BlastType.Teleport)
         {
            if (m_CurrentEnemy.PathPosition - m_Blast.TeleportRange < 0)
               m_CurrentEnemy.PathPosition = 0;
            else
               m_CurrentEnemy.PathPosition -= m_Blast.TeleportRange;
            
            m_CurrentEnemy.IsTeleported();
         }

         ResetBlast();
         m_CurrentEnemy.CurrentLifePoints -= m_Damage;
         
         // Enemy tot?
         if (m_CurrentEnemy.CurrentLifePoints <= 0)
         {
            if (OnEnemyDestroyed != null)
               OnEnemyDestroyed(m_CurrentEnemy);
         }

         if (m_CurrentEnemy != null)
            m_CurrentEnemy.IsUnlockedByTower(this);
         m_CurrentEnemy = null;      
      }
   }
}
