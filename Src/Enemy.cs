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
   /// Description of Enemy.
   /// </summary>
   public class Enemy
   {
      // Enemy
      private Point m_Position;         
      public Point Position {
         get { return m_Position; }
         set { m_Position = value; }
      }
      
      private List<Tower> m_LockedTowerList = new List<Tower>();
      
      private double m_SpeedPerFrame;         
      public double SpeedPerFrame {
         get { return m_SpeedPerFrame; }
         set { m_SpeedPerFrame = value; }
      }
            
      private int m_Size;
      public int Size {
         get { return m_Size; }
         set { m_Size = value; }
      }
      
      private bool m_IsSelected = false;               
      public bool IsSelected {
         get { return m_IsSelected; }
         set { m_IsSelected = value; }
      }

      private Point[] m_Path;         
      public Point[] Path {
         get { return m_Path; }
         set { m_Path = value; }
      }
      private double m_PathPosition = 0;                  
      public double PathPosition {
         get { return m_PathPosition; }
         set { m_PathPosition = value; }
      }
         
      private double m_CurrentLifePoints;   
      public double CurrentLifePoints {
         get { return m_CurrentLifePoints; }
         set { m_CurrentLifePoints = value; }
      }
      
      private double m_MaxLifePoints;
      public double MaxLifePoints {
         get { return m_MaxLifePoints; }
         set { m_MaxLifePoints = value; }
      }
      
      private int m_Money;      
      public int Money {
         get { return m_Money; }
         set { m_Money = value; }
      }
      
      private int m_Damage;         
      public int Damage {
         get { return m_Damage; }
         set { m_Damage = value; }
      }
      
      private string m_Type;         
      public string Type {
         get { return m_Type; }
         set { m_Type = value; }
      }
      
      private Brush m_Brush;         
      public Brush Brush {
         get { return m_Brush; }
         set { m_Brush = value; }
      }
      
      private Brush m_BrushLifePoints;         
      public Brush BrushLifePoint {
         get { return m_BrushLifePoints; }
         set { m_BrushLifePoints = value; }
      }      
      
      private Stopwatch m_FreezeTimer = new Stopwatch();
      private double m_FreezeInSeconds;
      
      private Stopwatch m_SlowTimer = new Stopwatch();
      private double m_SlowInSeconds;      
      private double m_SlowSpeedPerFrame;
      
      public Enemy()
      {
         
      }
      
      public void Reset()
      {
         m_Position = m_Path[0];
         m_PathPosition = 0;
         m_CurrentLifePoints = m_MaxLifePoints;
         m_FreezeTimer.Stop();
         m_FreezeTimer.Reset();
         m_SlowTimer.Stop();
         m_SlowTimer.Reset();         
         m_FreezeInSeconds = 0;
         m_SlowInSeconds = 0;
      }
      
      public void IsLockedByTower(Tower tower)
      {
         if (!m_LockedTowerList.Contains(tower))
            m_LockedTowerList.Add(tower);
      }
      
      public void IsUnlockedByTower(Tower tower)
      {
         if (m_LockedTowerList.Contains(tower))
            m_LockedTowerList.Remove(tower);
      }
      
      public void Freeze(double FreezeInSeconds)
      {
         // wenn bereits gefreezt -> nix machen
         if (m_FreezeTimer.IsRunning)
            return;
         
         m_FreezeInSeconds = FreezeInSeconds;
         m_FreezeTimer.Reset();
         m_FreezeTimer.Start();
      }
      
      public void Slow(double SlowInSeconds, double SlowSpeedPerFrame)
      {
         // wenn bereits gefreezt -> nix machen
         if (m_SlowTimer.IsRunning)
            return;
         
         m_SlowInSeconds = SlowInSeconds;
         m_SlowSpeedPerFrame = SlowSpeedPerFrame;
         m_SlowTimer.Reset();
         m_SlowTimer.Start();
      }      
      
      public void Update()
      {
         if (m_CurrentLifePoints <= 0)
         {
            return;
         }
         
         if (m_FreezeTimer.IsRunning)
         {
            // läuft die Freeze-Zeit noch?
            if (m_FreezeTimer.ElapsedMilliseconds / 1000.0 < m_FreezeInSeconds)
            {
               // ja --> keine Bewegung
               return;
            }
            else
            {
               // nein -> Timer abbrechen
               m_FreezeTimer.Stop();
               m_FreezeTimer.Reset();
            }
         }
         
         if (m_PathPosition < m_Path.Length)
            m_Position = m_Path[(int)m_PathPosition];
         

         if (m_SlowTimer.IsRunning)
         {            
            // läuft die Freeze-Zeit noch?
            if (m_SlowTimer.ElapsedMilliseconds / 1000.0 < m_SlowInSeconds)
            {
               // ja --> langsame Bewegung
               m_PathPosition += m_SlowSpeedPerFrame;
               return;
            }
            else
            {
               // nein -> Timer abbrechen
               m_SlowTimer.Stop();
               m_SlowTimer.Reset();
            }
         }
         else
         {
            m_PathPosition += m_SpeedPerFrame;
         }
         
      }
      
      public bool HasArrived()
      {
         return m_PathPosition + 1 >= m_Path.Length;
      }
      
      public void IsTeleported()
      {
         foreach(Tower t in m_LockedTowerList)
         {
            t.ResetBlast();
         }
      }
      
      public void Paint(Graphics g)
      {  
         // Lifepoints graphisch prozentual darstellen:
         float lifePointsPercent = (float)m_CurrentLifePoints / (float)m_MaxLifePoints;        
         
         g.FillEllipse(m_BrushLifePoints, 
                       m_Position.X - m_Size / 2,
                       m_Position.Y - m_Size / 2, 
                       m_Size, m_Size);

         g.FillEllipse(m_Brush,
                       m_Position.X - m_Size * lifePointsPercent / 2,
                       m_Position.Y - m_Size * lifePointsPercent / 2, 
                       m_Size * lifePointsPercent, m_Size * lifePointsPercent);         
         
         /*
         g.DrawString(m_Type,
                      new Font(FontFamily.GenericSansSerif, m_Size / 2.2f),
                      Brushes.White, 
                      m_Position.X - m_Size / 3,
                      m_Position.Y - m_Size / 3);
                      
         g.DrawString(m_CurrentLifePoints.ToString(), 
                      new Font(FontFamily.GenericSerif, m_Size / 3f),
                      Brushes.Orange, 
                      m_Position.X - m_Size / 2.7f,
                      m_Position.Y - m_Size / 4.0f);
         */
      }
   }
}
