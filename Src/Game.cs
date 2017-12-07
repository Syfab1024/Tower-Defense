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
using System.Windows.Forms;


using Helper;

namespace TowDef
{
   /// <summary>
   /// Description of Game.
   /// </summary>
   public class Game
   {        
      private Path m_Path;            
      public Path Path {
         get { return m_Path; }
      }

      private Tower m_TowerSelected = null;         
      public Tower TowerSelected {
         get { return m_TowerSelected; }
      }
      private Tower m_TowerToBuild;         
      public Tower TowerToBuild {
         get { return m_TowerToBuild; }
      }
      private List<Tower> m_TowerList;
         
      public int TowerCount{
         get { return m_TowerList.Count; }
      }
      
      private int  m_Money;
      public int Money {
         get { return m_Money; }
      }
      private int m_LifePoints;
      public int LifePoints {
         get { return m_LifePoints; }
      }
      private int m_Stage = 1;         
      public int Stage {
         get { return m_Stage; }
      }
      
      private MouseCursor m_MouseCursor;        
      public MouseCursor MouseCursor {
         get { return m_MouseCursor; }
      }
      
      
      
      // Enemy
      private List<Enemy> m_EnemyList;
      private int m_EnemyCount;         
      private int m_EnemyCurrentCount;    
      
      
      public int EnemyCurrentCount {
         get { return m_EnemyCurrentCount; }
      }
      public int EnemyLeftCount {
         get { return m_EnemyCount - m_EnemyCurrentCount; }
      }      
      
      private double m_EnemyFrequencyPerSecond;
      private Stopwatch m_EnemyStopwatch = new Stopwatch();
      
      // zum Info nach außen geben, wenn Enemy zerstört wurde
      public delegate void GameOverEventHandler();
      /// <summary>
      /// Wird aufgerufen, wenn Enemy zerstört wurde
      /// </summary>
      public event GameOverEventHandler OnGameOver;
      
      
      public Game()
      {
         Init();
      }

      private void Init()
      {         
         m_Path = new Path(null);        
         m_Stage = 1;
         m_EnemyFrequencyPerSecond = 1;
         
         m_EnemyList = new List<Enemy>();
         m_TowerList = new List<Tower>();
         m_MouseCursor = new MouseCursor();
         m_TowerToBuild = null;
      }      
      
      public void SetNewPath(List<Point> path)
      {
         m_Path = new Path(path);
      }
      
      public void Start()
      {
         //m_Money = 200;
         m_Money = 99999999;
         m_LifePoints = 50;
         m_EnemyCount = 20;
         
         InitEnemies();
         AddEnemy();
      }

      private void InitEnemies()
      {          
         m_EnemyList.Clear();
      }      
      
      private void AddEnemy()
      {         
         if (m_Path.Length == 0)
            return;
         
         if (!m_EnemyStopwatch.IsRunning
             || (m_EnemyStopwatch.ElapsedMilliseconds > 1000 / m_EnemyFrequencyPerSecond
                 && m_EnemyCurrentCount < m_EnemyCount))
         {
            Enemy e = EnemyFactory.GetNewEnemy("1", m_Stage);
            e.Path = m_Path.EnemyPath;
            
            e.Reset();
            m_EnemyList.Add(e);
            m_EnemyStopwatch.Reset();
            m_EnemyStopwatch.Start();
            m_EnemyCurrentCount++;
         }            
      }
      
      public void Update()
      {
         GameLogic();
      }      

      private void GameLogic()
      {         
         AddEnemy();
      	UpdateEnemies();     
      	UpdateMouseCursor();
      	foreach(Tower t in m_TowerList)
      	{
      	   t.FindEnemyInRange(m_EnemyList);   	
      	}
      }      
      
      public void PrepareBuildTower(string TowerType)
      {
         // ggf. selektierten Tower zurücksetzen
         if (m_TowerSelected != null)
         {
            m_TowerSelected.Selected = false;
            m_TowerSelected = null;
         }         
         
         if (m_TowerToBuild == null
             || m_TowerToBuild.Type != TowerType)
            m_TowerToBuild = TowerFactory.GetNewTower(TowerType);  
         else
            m_TowerToBuild = null;
      }
      
      public void BuildTower(Point p)
      {                  
         // Tower wirklich bauen
         m_Money -= m_TowerToBuild.Cost;
         m_TowerToBuild.Position = p;
         m_TowerToBuild.OnEnemyDestroyed += new Tower.EnemyDestroyedEventHandler(this.EnemyDestroyed);         
         m_TowerList.Add(m_TowerToBuild);
         
         // nächsten Tower-Bau vorbereiten
         m_TowerToBuild = TowerFactory.GetNewTower(m_TowerToBuild.Type);         
      }      
      
      public void UpgradeSelectedTower()
      {
         if (!IsTowerUpgradePossible())
            return;
         
         m_Money -= m_TowerSelected.UpgradeCost;
         m_TowerSelected.Upgrade();         
      }
      
      public void SellSelectedTower()
      {         
         m_Money += m_TowerSelected.SellValue;
         m_TowerList.Remove(m_TowerSelected);
         m_TowerSelected = null;
      }
      
      public bool IsTowerUpgradePossible()
      {
         return m_TowerSelected != null
                && m_Money >= m_TowerSelected.UpgradeCost
                && !IsCursorColliding(m_TowerSelected.Position, m_TowerSelected.Size + m_TowerSelected.SizeIncrement);
      }

      public bool IsTowerSellPossible()
      {
         return m_TowerSelected != null;
      }      
      
      private void UpdateMouseCursor()
      {
         if (m_TowerToBuild == null)
         {
            m_MouseCursor.State = MouseCursorStates.Normal;
         }
         else
         {
            m_MouseCursor.TowerToBuild = m_TowerToBuild;
            if (!IsCursorColliding(m_MouseCursor.Position, m_TowerToBuild.Size)
                && m_Money >= m_TowerToBuild.Cost)
               m_MouseCursor.State = MouseCursorStates.TowerBuildYes;
            else
               m_MouseCursor.State = MouseCursorStates.TowerBuildNo;
         }
      }

      public void PerformClickAction(Point MouseLocation, MouseButtons Buttons)
      {
         if (Buttons == MouseButtons.Left)
         {
            // Tower bauen
            if (m_MouseCursor.State == MouseCursorStates.TowerBuildYes)
            {
               BuildTower(MouseLocation);
               return;
            }

            // Auswählen
            if (m_MouseCursor.State == MouseCursorStates.Normal)
            {
               SelectObject(MouseLocation);
               return;
            }
         }

         if (Buttons == MouseButtons.Right)
         {
            DeSelectObject();
         }
      }
      
      private void DeSelectObject()
      {
         if (m_TowerSelected != null)
         {
            m_TowerSelected.Selected = false;
            m_TowerSelected = null;
         }         
         if (m_TowerToBuild != null)
         {
            m_TowerToBuild = null;
         }
      }
      
      private void SelectObject(Point MouseLocation)
      {
         Tower t = SelectTower(MouseLocation);
         if (m_TowerSelected != null)
         {
            m_TowerSelected.Selected = false;
         }
         if (t != null)
         {
            t.Selected = true;
            m_TowerSelected = t;            
         }
         else
         {
            m_TowerSelected = null;
         }
      }
      
      private void UpdateEnemies()
      {    
         List<Enemy> enemiesToRemove = new List<Enemy>();
         
         foreach(Enemy e in m_EnemyList)
         {
            e.Update();
            if (e.HasArrived())
            {
               m_LifePoints -= e.Damage;
               if (m_LifePoints <= 0)
               {
                  if (OnGameOver != null)
                     OnGameOver();
               }
               enemiesToRemove.Add(e);
            }            
         }
         
         foreach(Enemy e in enemiesToRemove)
         {
            m_EnemyList.Remove(e);
         }
         
         CheckWaveFinished();
      }
            
      private void EnemyDestroyed(Enemy enemy)
      {
         m_EnemyList.Remove(enemy);
         m_Money += enemy.Money;
         CheckWaveFinished();
      }      
      
      private bool CheckWaveFinished()
      {
         // alle Feinde durch oder tot?
         if (m_EnemyList.Count == 0
             && m_EnemyCount == m_EnemyCurrentCount)
         {
            NextWave();
            return true;            
         }
         return false;
      }
      
      public void NextWave()
      {
         m_Stage++;
         m_EnemyFrequencyPerSecond += 0.2;
         m_EnemyCount += 3;
         m_EnemyCurrentCount = 0;
         InitEnemies();
      }
      
      public void Paint(Graphics g)
      {
         g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
         m_Path.Paint(g);
         
         foreach (Enemy e in m_EnemyList)
         {
            e.Paint(g);
         }
         
         foreach(Tower t in m_TowerList)
         {
            t.Paint(g);
         }
         m_MouseCursor.Paint(g);
      }
      
      public Tower SelectTower(Point Coordinate)
      {
         Rectangle rMouseCursor = new Rectangle(Coordinate.X - 1,
                                                Coordinate.Y - 1,
                                                1, 1);
         foreach(Tower t in m_TowerList)
         {
            if (t.Rectangle.IntersectsWith(rMouseCursor))
            {
               return t;
            }            
         }
         
         return null;
      }      
      
      public bool IsCursorColliding(Point Coordinate, int RectSize)
      {
         Rectangle rMouseCursor = new Rectangle(Coordinate.X - RectSize / 2,
                                                Coordinate.Y - RectSize / 2,
                                                RectSize, RectSize);
         bool isIntersecting = false;
         foreach(Rectangle r in m_Path.RectangleList)
         {
            if (r.IntersectsWith(rMouseCursor))
            {
               isIntersecting = true;
               break;
            }
         }
         foreach(Tower t in m_TowerList)
         {
            // falls ein Tower ausgewählt ist -> diesen von der Kollisionsprüfung
            // ausschließen (weil es jetzt um ein TowerUpgrade geht)
            if (t == m_TowerSelected)
               continue;
            
            if (t.Rectangle.IntersectsWith(rMouseCursor))
            {
               isIntersecting = true;
               break;
            }            
         }
         
         return isIntersecting;
      }
   }
}