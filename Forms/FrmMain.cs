/*
 * Erstellt mit SharpDevelop.
 * Benutzer: schulz
 * Datum: 16.09.2011
 * Zeit: 13:47
 * 
 */
using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing;
using System.Diagnostics;
using System.Text;

using Helper;

namespace TowDef
{
   /// <summary>
   /// MainForm
   /// </summary>
   public partial class FrmMain : Form
   {
      // Game
      private Game m_Game;      
      
      public FrmMain()
      {
         InitializeComponent();
         StartGame();
      }      
      
      private void StartGame()
      {
         m_Game = new Game();
         m_Game.Start();
         m_Game.OnGameOver += new Game.GameOverEventHandler(this.GameOver);                  
      }

      private void GameOver()
      {
         tMain.Enabled = false;
         MsgBox.ShowInfo("Game Over Muchacho!");
      }
      
      private void UpdateControls()
      {
         // Allgemeine Informationen
         lStage.Text = "Wave: " + m_Game.Stage.ToString();
         lMoney.Text = "Money: " + m_Game.Money.ToString();
         lLifepoints.Text = "Lifepoints: " + m_Game.LifePoints.ToString();
         lEnemyCount.Text = "Enemy Count: " + m_Game.EnemyCurrentCount.ToString();
         lEnemiesLeft.Text = "Enemies Left: " + m_Game.EnemyLeftCount.ToString();
         lTowerCount.Text = "Towers: " + m_Game.TowerCount.ToString();
         
         
         // Towerneubau -> Build-Infos
         StringBuilder towerInfo = new StringBuilder();
         Tower tower = null;
         bool isUpgrade = false;
         
         if (m_Game.TowerToBuild != null)
         {
            tower = m_Game.TowerToBuild;
            isUpgrade = false;
         }
         // vorhandener Tower ausgewählt -> UpgradeInfos
         if (m_Game.TowerSelected != null)
         {
            tower = m_Game.TowerSelected;
            isUpgrade = true;            
         }


         if (tower != null)
         {                     
            towerInfo.AppendLine("NAME: " + tower.Name);
            towerInfo.AppendLine("LEVL: " + tower.Level.ToString());
            if (!isUpgrade)
               towerInfo.AppendLine("COST: " + tower.Cost.ToString());
            
            towerInfo.Append("DMGE: " + tower.Damage.ToString());
            if (isUpgrade)
               towerInfo.Append(" (+" + tower.DamageIncrement.ToString() + ")");
            towerInfo.AppendLine();
            
            towerInfo.Append("RNGE: " + tower.Range.ToString());
            if (isUpgrade)
               towerInfo.Append(" (+" + tower.RangeIncrement.ToString() + ")");
            towerInfo.AppendLine();
            
            towerInfo.Append("TYPE: " + tower.Blast.Type.ToString());
            
            if (tower.Blast.Type == BlastType.Freeze)
            {
               towerInfo.AppendLine();
               towerInfo.Append("FREZ: " + Math.Round(tower.Blast.FreezeInSeconds, 1).ToString());
               if (isUpgrade)
                  towerInfo.Append(" (+" + Math.Round(tower.Blast.FreezeInSecondsIncrement, 1).ToString() + ")");
            }
            if (tower.Blast.Type == BlastType.Slow)
            {
               towerInfo.AppendLine();
               towerInfo.Append("SLOW: " + Math.Round(tower.Blast.SlowInSeconds, 1).ToString());
               if (isUpgrade)
                  towerInfo.Append(" (+" + Math.Round(tower.Blast.SlowInSecondsIncrement, 1).ToString() + ")");
               towerInfo.AppendLine();
               towerInfo.Append("SLWSPD: " + Math.Round(tower.Blast.SlowSpeedPerFrame, 1).ToString());
               if (isUpgrade)
                  towerInfo.Append(" (+" + Math.Round(tower.Blast.SlowSpeedPerFrameIncrement, 1).ToString() + ")");               
            }
            if (tower.Blast.Type == BlastType.Teleport)
            {
               towerInfo.AppendLine();
               towerInfo.Append("TELE: " + tower.Blast.TeleportRange.ToString());
               if (isUpgrade)
                  towerInfo.Append(" (+" + tower.Blast.TeleportRangeIncrement.ToString() + ")");
            }          
            towerInfo.AppendLine();
            
            towerInfo.Append("SIZE: " + tower.Size.ToString());
            if (isUpgrade)
               towerInfo.Append(" (+" + tower.SizeIncrement.ToString() + ")");
            towerInfo.AppendLine();
            
            towerInfo.Append("SPED: " + tower.Blast.SpeedPerFrame.ToString());
            if (isUpgrade)
               towerInfo.Append(" (+" + tower.Blast.SpeedPerFrameIncrement.ToString() + ")");
            towerInfo.AppendLine();
            
            towerInfo.Append("FREQ: " + Math.Round(tower.Blast.MaxFrequencyPerSecond, 2).ToString());
            if (isUpgrade)
               towerInfo.Append(" (+" + Math.Round(tower.Blast.MaxFrequencyPerSecondIncrement, 2).ToString() + ")");
            towerInfo.AppendLine();
            
            
            if (isUpgrade)
               btnTowerSell.Text = "Sell (" + tower.SellValue.ToString() + ")";
            else
               btnTowerSell.Text = "Sell";
            
            if (isUpgrade)
               btnUpgradeTower.Text = "Upgrade (" + tower.UpgradeCost.ToString() + ")";
            else
               btnUpgradeTower.Text = "Upgrade";
            
            
            // EnemyFindStrategy anzeigen:
            if (tower.EnemyFindStrategy == EnemyFindStrategy.Farest)
               rbFindFarest.Checked = true;
            else if (tower.EnemyFindStrategy == EnemyFindStrategy.Nearest)
               rbFindNearest.Checked = true;
            else if (tower.EnemyFindStrategy == EnemyFindStrategy.Strongest)
               rbFindStrongest.Checked = true;
            else if (tower.EnemyFindStrategy == EnemyFindStrategy.Weakest)
               rbFindWeakest.Checked = true;
            else if (tower.EnemyFindStrategy == EnemyFindStrategy.First)
               rbFindFirst.Checked = true;
            else if (tower.EnemyFindStrategy == EnemyFindStrategy.Last)
               rbFindLast.Checked = true;
            else if (tower.EnemyFindStrategy == EnemyFindStrategy.Fastest)
               rbFindFastest.Checked = true;            
            else if (tower.EnemyFindStrategy == EnemyFindStrategy.Slowest)
               rbFindSlowest.Checked = true;               
         }
         else
         {
            btnTowerSell.Text = "Sell";
            btnUpgradeTower.Text = "Upgrade";
            rbFindFarest.Checked = false;
            rbFindNearest.Checked = false;
            rbFindStrongest.Checked = false;
            rbFindWeakest.Checked = false;
            rbFindFirst.Checked = false;
            rbFindLast.Checked = false;
            rbFindFastest.Checked = false;     
            rbFindSlowest.Checked = false;
         }

         
         lTowerInfo.Text = towerInfo.ToString();
         btnUpgradeTower.Enabled = m_Game.IsTowerUpgradePossible();
         btnTowerSell.Enabled = m_Game.IsTowerSellPossible();
      }
      
      void TMainTick(object sender, EventArgs e)
      {
	      GameUpdate();
	      UpdateControls();
      }
      
      private void GameUpdate()
      {
         m_Game.Update();
      	pbMain.Invalidate(); // ruft indirekt PbMainPaint() auf
      }

      void PbMainPaint(object sender, PaintEventArgs e)
      {         
         m_Game.Paint(e.Graphics);
      }         
      
      void PbMainMouseMove(object sender, MouseEventArgs e)
      {
         m_Game.MouseCursor.Position = e.Location;
      }
      
      void PbMainMouseEnter(object sender, EventArgs e)
      {
      	Cursor.Hide();
      }
      
      void PbMainMouseLeave(object sender, EventArgs e)
      {
         Cursor.Show();
         m_Game.MouseCursor.Hide();
      }
      
      void PbMainMouseClick(object sender, MouseEventArgs e)
      {
         m_Game.PerformClickAction(e.Location, e.Button);
      }
      
      void BtnTowerNormalClick(object sender, EventArgs e)
      {
         m_Game.PrepareBuildTower("B");
      }
      
      void BtnTowerRangeClick(object sender, EventArgs e)
      {
      	m_Game.PrepareBuildTower("R");
      }
      
      void BtnTowerFreezeClick(object sender, EventArgs e)
      {
      	m_Game.PrepareBuildTower("F");
      }
      
      void BtnTowerSlowClick(object sender, EventArgs e)
      {
      	m_Game.PrepareBuildTower("S");
      }
      
      void BtnTowerSplashClick(object sender, EventArgs e)
      {
      	m_Game.PrepareBuildTower("E");
      }      
      
      void BtnTowerTeleportClick(object sender, EventArgs e)
      {
      	m_Game.PrepareBuildTower("T");
      }      
      
      void BtnUpgradeTowerClick(object sender, EventArgs e)
      {
         m_Game.UpgradeSelectedTower();
      }     
      
      void BtnTowerSellClick(object sender, EventArgs e)
      {
         m_Game.SellSelectedTower();
         btnTowerSell.Text = "Sell";
      }      
      
      protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
      {
         if (keyData == Keys.E)
            BtnTowerSplashClick(null, null);
         if (keyData == Keys.S)
            BtnTowerSlowClick(null, null);
         if (keyData == Keys.F)
            BtnTowerFreezeClick(null, null);
         if (keyData == Keys.B)
            BtnTowerNormalClick(null, null);
         if (keyData == Keys.R)
            BtnTowerRangeClick(null, null);
         if (keyData == Keys.T)
            BtnTowerTeleportClick(null, null);           
         if (keyData == Keys.U)
            BtnUpgradeTowerClick(null, null);              
         
         if (keyData == Keys.F5)
         {
            ShowLevelEditor();
         }
         
         return true;
         
         //return base.ProcessCmdKey(ref msg, keyData);
      }      
      
      private void ShowLevelEditor()
      {
         tMain.Enabled = false;
         FrmLvlEdit f = new FrmLvlEdit(m_Game.Path.List);
         if (f.ShowDialog() == DialogResult.OK)
         {
            m_Game = new Game();
            m_Game.SetNewPath(f.Path);
            m_Game.Start();
            m_Game.OnGameOver += new Game.GameOverEventHandler(this.GameOver);         
                         
         }
         tMain.Enabled = true;           
      }
      
      void BtnLevelEditClick(object sender, EventArgs e)
      {
      	ShowLevelEditor();
      }
      
      void BtnQuitClick(object sender, EventArgs e)
      {
         this.Close();
      }
      
      void EnemyFindStrategyChanged(object sender, EventArgs e)
      {
         if (m_Game.TowerSelected == null)
            return;
         
         if (rbFindFarest.Checked)
            m_Game.TowerSelected.EnemyFindStrategy = EnemyFindStrategy.Farest;
         else if (rbFindNearest.Checked)
            m_Game.TowerSelected.EnemyFindStrategy = EnemyFindStrategy.Nearest;         
         else if (rbFindStrongest.Checked)
            m_Game.TowerSelected.EnemyFindStrategy = EnemyFindStrategy.Strongest;         
         else if (rbFindWeakest.Checked)
            m_Game.TowerSelected.EnemyFindStrategy = EnemyFindStrategy.Weakest;         
         else if (rbFindFirst.Checked)
            m_Game.TowerSelected.EnemyFindStrategy = EnemyFindStrategy.First;         
         else if (rbFindLast.Checked)
            m_Game.TowerSelected.EnemyFindStrategy = EnemyFindStrategy.Last;         
         else if (rbFindFastest.Checked)
            m_Game.TowerSelected.EnemyFindStrategy = EnemyFindStrategy.Fastest;                  
         else if (rbFindSlowest.Checked)
            m_Game.TowerSelected.EnemyFindStrategy = EnemyFindStrategy.Slowest;           
      }
      
      void BtnRestartClick(object sender, EventArgs e)
      {
      	StartGame();
      }
   }
}

