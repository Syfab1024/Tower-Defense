/*
 * Erstellt mit SharpDevelop.
 * Benutzer: schulz
 * Datum: 16.09.2011
 * Zeit: 13:47
 * 
 */
namespace TowDef
{
   partial class FrmMain
   {
      /// <summary>
      /// Designer variable used to keep track of non-visual components.
      /// </summary>
      private System.ComponentModel.IContainer components = null;
      
      /// <summary>
      /// Disposes resources used by the form.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing)
      {
         if (disposing) {
            if (components != null) {
               components.Dispose();
            }
         }
         base.Dispose(disposing);
      }
      
      /// <summary>
      /// This method is required for Windows Forms designer support.
      /// Do not change the method contents inside the source code editor. The Forms designer might
      /// not be able to load this method if it was changed manually.
      /// </summary>
      private void InitializeComponent()
      {
      	this.components = new System.ComponentModel.Container();
      	this.pbMain = new System.Windows.Forms.PictureBox();
      	this.tMain = new System.Windows.Forms.Timer(this.components);
      	this.gbTower = new System.Windows.Forms.GroupBox();
      	this.btnTowerTeleport = new System.Windows.Forms.Button();
      	this.btnTowerSplash = new System.Windows.Forms.Button();
      	this.btnTowerSlow = new System.Windows.Forms.Button();
      	this.btnTowerFreeze = new System.Windows.Forms.Button();
      	this.btnTowerRange = new System.Windows.Forms.Button();
      	this.btnTowerBase = new System.Windows.Forms.Button();
      	this.gbInfo = new System.Windows.Forms.GroupBox();
      	this.lTowerCount = new System.Windows.Forms.Label();
      	this.lEnemiesLeft = new System.Windows.Forms.Label();
      	this.lEnemyCount = new System.Windows.Forms.Label();
      	this.lLifepoints = new System.Windows.Forms.Label();
      	this.lMoney = new System.Windows.Forms.Label();
      	this.lStage = new System.Windows.Forms.Label();
      	this.menuStrip1 = new System.Windows.Forms.MenuStrip();
      	this.dateiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      	this.btnRestart = new System.Windows.Forms.ToolStripMenuItem();
      	this.btnLevelEdit = new System.Windows.Forms.ToolStripMenuItem();
      	this.btnQuit = new System.Windows.Forms.ToolStripMenuItem();
      	this.statusStrip1 = new System.Windows.Forms.StatusStrip();
      	this.gbTowerInfo = new System.Windows.Forms.GroupBox();
      	this.rbFindSlowest = new System.Windows.Forms.RadioButton();
      	this.rbFindFastest = new System.Windows.Forms.RadioButton();
      	this.rbFindLast = new System.Windows.Forms.RadioButton();
      	this.rbFindFirst = new System.Windows.Forms.RadioButton();
      	this.rbFindStrongest = new System.Windows.Forms.RadioButton();
      	this.rbFindWeakest = new System.Windows.Forms.RadioButton();
      	this.rbFindFarest = new System.Windows.Forms.RadioButton();
      	this.rbFindNearest = new System.Windows.Forms.RadioButton();
      	this.btnTowerSell = new System.Windows.Forms.Button();
      	this.btnUpgradeTower = new System.Windows.Forms.Button();
      	this.lTowerInfo = new System.Windows.Forms.Label();
      	((System.ComponentModel.ISupportInitialize)(this.pbMain)).BeginInit();
      	this.gbTower.SuspendLayout();
      	this.gbInfo.SuspendLayout();
      	this.menuStrip1.SuspendLayout();
      	this.gbTowerInfo.SuspendLayout();
      	this.SuspendLayout();
      	// 
      	// pbMain
      	// 
      	this.pbMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      	this.pbMain.Location = new System.Drawing.Point(167, 73);
      	this.pbMain.Name = "pbMain";
      	this.pbMain.Size = new System.Drawing.Size(800, 540);
      	this.pbMain.TabIndex = 0;
      	this.pbMain.TabStop = false;
      	this.pbMain.MouseLeave += new System.EventHandler(this.PbMainMouseLeave);
      	this.pbMain.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PbMainMouseMove);
      	this.pbMain.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PbMainMouseClick);
      	this.pbMain.Paint += new System.Windows.Forms.PaintEventHandler(this.PbMainPaint);
      	this.pbMain.MouseEnter += new System.EventHandler(this.PbMainMouseEnter);
      	// 
      	// tMain
      	// 
      	this.tMain.Enabled = true;
      	this.tMain.Interval = 40;
      	this.tMain.Tick += new System.EventHandler(this.TMainTick);
      	// 
      	// gbTower
      	// 
      	this.gbTower.Controls.Add(this.btnTowerTeleport);
      	this.gbTower.Controls.Add(this.btnTowerSplash);
      	this.gbTower.Controls.Add(this.btnTowerSlow);
      	this.gbTower.Controls.Add(this.btnTowerFreeze);
      	this.gbTower.Controls.Add(this.btnTowerRange);
      	this.gbTower.Controls.Add(this.btnTowerBase);
      	this.gbTower.Location = new System.Drawing.Point(12, 68);
      	this.gbTower.Name = "gbTower";
      	this.gbTower.Size = new System.Drawing.Size(149, 200);
      	this.gbTower.TabIndex = 1;
      	this.gbTower.TabStop = false;
      	this.gbTower.Text = "Tower";
      	// 
      	// btnTowerTeleport
      	// 
      	this.btnTowerTeleport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
      	      	      	| System.Windows.Forms.AnchorStyles.Right)));
      	this.btnTowerTeleport.Location = new System.Drawing.Point(6, 164);
      	this.btnTowerTeleport.Name = "btnTowerTeleport";
      	this.btnTowerTeleport.Size = new System.Drawing.Size(137, 23);
      	this.btnTowerTeleport.TabIndex = 7;
      	this.btnTowerTeleport.Text = "Teleport (T)";
      	this.btnTowerTeleport.UseVisualStyleBackColor = true;
      	this.btnTowerTeleport.Click += new System.EventHandler(this.BtnTowerTeleportClick);
      	// 
      	// btnTowerSplash
      	// 
      	this.btnTowerSplash.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
      	      	      	| System.Windows.Forms.AnchorStyles.Right)));
      	this.btnTowerSplash.Location = new System.Drawing.Point(6, 135);
      	this.btnTowerSplash.Name = "btnTowerSplash";
      	this.btnTowerSplash.Size = new System.Drawing.Size(137, 23);
      	this.btnTowerSplash.TabIndex = 5;
      	this.btnTowerSplash.Text = "Splash (E)";
      	this.btnTowerSplash.UseVisualStyleBackColor = true;
      	this.btnTowerSplash.Click += new System.EventHandler(this.BtnTowerSplashClick);
      	// 
      	// btnTowerSlow
      	// 
      	this.btnTowerSlow.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
      	      	      	| System.Windows.Forms.AnchorStyles.Right)));
      	this.btnTowerSlow.Location = new System.Drawing.Point(6, 106);
      	this.btnTowerSlow.Name = "btnTowerSlow";
      	this.btnTowerSlow.Size = new System.Drawing.Size(137, 23);
      	this.btnTowerSlow.TabIndex = 4;
      	this.btnTowerSlow.Text = "Slow (S)";
      	this.btnTowerSlow.UseVisualStyleBackColor = true;
      	this.btnTowerSlow.Click += new System.EventHandler(this.BtnTowerSlowClick);
      	// 
      	// btnTowerFreeze
      	// 
      	this.btnTowerFreeze.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
      	      	      	| System.Windows.Forms.AnchorStyles.Right)));
      	this.btnTowerFreeze.Location = new System.Drawing.Point(6, 77);
      	this.btnTowerFreeze.Name = "btnTowerFreeze";
      	this.btnTowerFreeze.Size = new System.Drawing.Size(137, 23);
      	this.btnTowerFreeze.TabIndex = 3;
      	this.btnTowerFreeze.Text = "Freeze (F)";
      	this.btnTowerFreeze.UseVisualStyleBackColor = true;
      	this.btnTowerFreeze.Click += new System.EventHandler(this.BtnTowerFreezeClick);
      	// 
      	// btnTowerRange
      	// 
      	this.btnTowerRange.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
      	      	      	| System.Windows.Forms.AnchorStyles.Right)));
      	this.btnTowerRange.Location = new System.Drawing.Point(6, 48);
      	this.btnTowerRange.Name = "btnTowerRange";
      	this.btnTowerRange.Size = new System.Drawing.Size(137, 23);
      	this.btnTowerRange.TabIndex = 1;
      	this.btnTowerRange.Text = "Range (R)";
      	this.btnTowerRange.UseVisualStyleBackColor = true;
      	this.btnTowerRange.Click += new System.EventHandler(this.BtnTowerRangeClick);
      	// 
      	// btnTowerBase
      	// 
      	this.btnTowerBase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
      	      	      	| System.Windows.Forms.AnchorStyles.Right)));
      	this.btnTowerBase.Location = new System.Drawing.Point(6, 19);
      	this.btnTowerBase.Name = "btnTowerBase";
      	this.btnTowerBase.Size = new System.Drawing.Size(137, 23);
      	this.btnTowerBase.TabIndex = 0;
      	this.btnTowerBase.Text = "Base (B)";
      	this.btnTowerBase.UseVisualStyleBackColor = true;
      	this.btnTowerBase.Click += new System.EventHandler(this.BtnTowerNormalClick);
      	// 
      	// gbInfo
      	// 
      	this.gbInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
      	      	      	| System.Windows.Forms.AnchorStyles.Right)));
      	this.gbInfo.Controls.Add(this.lTowerCount);
      	this.gbInfo.Controls.Add(this.lEnemiesLeft);
      	this.gbInfo.Controls.Add(this.lEnemyCount);
      	this.gbInfo.Controls.Add(this.lLifepoints);
      	this.gbInfo.Controls.Add(this.lMoney);
      	this.gbInfo.Controls.Add(this.lStage);
      	this.gbInfo.Location = new System.Drawing.Point(12, 27);
      	this.gbInfo.Name = "gbInfo";
      	this.gbInfo.Size = new System.Drawing.Size(955, 40);
      	this.gbInfo.TabIndex = 2;
      	this.gbInfo.TabStop = false;
      	this.gbInfo.Text = "Information";
      	// 
      	// lTowerCount
      	// 
      	this.lTowerCount.Location = new System.Drawing.Point(558, 16);
      	this.lTowerCount.Name = "lTowerCount";
      	this.lTowerCount.Size = new System.Drawing.Size(109, 17);
      	this.lTowerCount.TabIndex = 6;
      	this.lTowerCount.Text = "Towers: 8888";
      	// 
      	// lEnemiesLeft
      	// 
      	this.lEnemiesLeft.Location = new System.Drawing.Point(443, 16);
      	this.lEnemiesLeft.Name = "lEnemiesLeft";
      	this.lEnemiesLeft.Size = new System.Drawing.Size(109, 17);
      	this.lEnemiesLeft.TabIndex = 5;
      	this.lEnemiesLeft.Text = "Enemies Left: 8888";
      	// 
      	// lEnemyCount
      	// 
      	this.lEnemyCount.Location = new System.Drawing.Point(328, 16);
      	this.lEnemyCount.Name = "lEnemyCount";
      	this.lEnemyCount.Size = new System.Drawing.Size(109, 17);
      	this.lEnemyCount.TabIndex = 4;
      	this.lEnemyCount.Text = "Enemy Count: 8888";
      	// 
      	// lLifepoints
      	// 
      	this.lLifepoints.Location = new System.Drawing.Point(215, 16);
      	this.lLifepoints.Name = "lLifepoints";
      	this.lLifepoints.Size = new System.Drawing.Size(91, 17);
      	this.lLifepoints.TabIndex = 3;
      	this.lLifepoints.Text = "Lifepoints: 8888";
      	// 
      	// lMoney
      	// 
      	this.lMoney.Location = new System.Drawing.Point(95, 16);
      	this.lMoney.Name = "lMoney";
      	this.lMoney.Size = new System.Drawing.Size(114, 17);
      	this.lMoney.TabIndex = 2;
      	this.lMoney.Text = "Money: 888888";
      	// 
      	// lStage
      	// 
      	this.lStage.Location = new System.Drawing.Point(19, 16);
      	this.lStage.Name = "lStage";
      	this.lStage.Size = new System.Drawing.Size(58, 17);
      	this.lStage.TabIndex = 1;
      	this.lStage.Text = "Wave: 88";
      	// 
      	// menuStrip1
      	// 
      	this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
      	      	      	this.dateiToolStripMenuItem});
      	this.menuStrip1.Location = new System.Drawing.Point(0, 0);
      	this.menuStrip1.Name = "menuStrip1";
      	this.menuStrip1.Size = new System.Drawing.Size(981, 24);
      	this.menuStrip1.TabIndex = 3;
      	this.menuStrip1.Text = "menuStrip1";
      	// 
      	// dateiToolStripMenuItem
      	// 
      	this.dateiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
      	      	      	this.btnRestart,
      	      	      	this.btnLevelEdit,
      	      	      	this.btnQuit});
      	this.dateiToolStripMenuItem.Name = "dateiToolStripMenuItem";
      	this.dateiToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
      	this.dateiToolStripMenuItem.Text = "Spiel";
      	// 
      	// btnRestart
      	// 
      	this.btnRestart.Name = "btnRestart";
      	this.btnRestart.Size = new System.Drawing.Size(161, 22);
      	this.btnRestart.Text = "Neu starten";
      	this.btnRestart.Click += new System.EventHandler(this.BtnRestartClick);
      	// 
      	// btnLevelEdit
      	// 
      	this.btnLevelEdit.Name = "btnLevelEdit";
      	this.btnLevelEdit.Size = new System.Drawing.Size(161, 22);
      	this.btnLevelEdit.Text = "Leveleditor (F5)";
      	this.btnLevelEdit.Click += new System.EventHandler(this.BtnLevelEditClick);
      	// 
      	// btnQuit
      	// 
      	this.btnQuit.Name = "btnQuit";
      	this.btnQuit.Size = new System.Drawing.Size(161, 22);
      	this.btnQuit.Text = "Beenden";
      	this.btnQuit.Click += new System.EventHandler(this.BtnQuitClick);
      	// 
      	// statusStrip1
      	// 
      	this.statusStrip1.Location = new System.Drawing.Point(0, 623);
      	this.statusStrip1.Name = "statusStrip1";
      	this.statusStrip1.Size = new System.Drawing.Size(981, 22);
      	this.statusStrip1.TabIndex = 4;
      	this.statusStrip1.Text = "statusStrip1";
      	// 
      	// gbTowerInfo
      	// 
      	this.gbTowerInfo.Controls.Add(this.rbFindSlowest);
      	this.gbTowerInfo.Controls.Add(this.rbFindFastest);
      	this.gbTowerInfo.Controls.Add(this.rbFindLast);
      	this.gbTowerInfo.Controls.Add(this.rbFindFirst);
      	this.gbTowerInfo.Controls.Add(this.rbFindStrongest);
      	this.gbTowerInfo.Controls.Add(this.rbFindWeakest);
      	this.gbTowerInfo.Controls.Add(this.rbFindFarest);
      	this.gbTowerInfo.Controls.Add(this.rbFindNearest);
      	this.gbTowerInfo.Controls.Add(this.btnTowerSell);
      	this.gbTowerInfo.Controls.Add(this.btnUpgradeTower);
      	this.gbTowerInfo.Controls.Add(this.lTowerInfo);
      	this.gbTowerInfo.Location = new System.Drawing.Point(12, 274);
      	this.gbTowerInfo.Name = "gbTowerInfo";
      	this.gbTowerInfo.Size = new System.Drawing.Size(149, 339);
      	this.gbTowerInfo.TabIndex = 5;
      	this.gbTowerInfo.TabStop = false;
      	this.gbTowerInfo.Text = "Tower-Info";
      	// 
      	// rbFindSlowest
      	// 
      	this.rbFindSlowest.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      	this.rbFindSlowest.Location = new System.Drawing.Point(78, 245);
      	this.rbFindSlowest.Name = "rbFindSlowest";
      	this.rbFindSlowest.Size = new System.Drawing.Size(65, 24);
      	this.rbFindSlowest.TabIndex = 16;
      	this.rbFindSlowest.TabStop = true;
      	this.rbFindSlowest.Text = "Slowest";
      	this.rbFindSlowest.UseVisualStyleBackColor = true;
      	this.rbFindSlowest.CheckedChanged += new System.EventHandler(this.EnemyFindStrategyChanged);
      	// 
      	// rbFindFastest
      	// 
      	this.rbFindFastest.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      	this.rbFindFastest.Location = new System.Drawing.Point(9, 245);
      	this.rbFindFastest.Name = "rbFindFastest";
      	this.rbFindFastest.Size = new System.Drawing.Size(65, 24);
      	this.rbFindFastest.TabIndex = 15;
      	this.rbFindFastest.TabStop = true;
      	this.rbFindFastest.Text = "Fastest";
      	this.rbFindFastest.UseVisualStyleBackColor = true;
      	this.rbFindFastest.CheckedChanged += new System.EventHandler(this.EnemyFindStrategyChanged);
      	// 
      	// rbFindLast
      	// 
      	this.rbFindLast.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      	this.rbFindLast.Location = new System.Drawing.Point(78, 225);
      	this.rbFindLast.Name = "rbFindLast";
      	this.rbFindLast.Size = new System.Drawing.Size(65, 24);
      	this.rbFindLast.TabIndex = 14;
      	this.rbFindLast.TabStop = true;
      	this.rbFindLast.Text = "Last";
      	this.rbFindLast.UseVisualStyleBackColor = true;
      	this.rbFindLast.CheckedChanged += new System.EventHandler(this.EnemyFindStrategyChanged);
      	// 
      	// rbFindFirst
      	// 
      	this.rbFindFirst.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      	this.rbFindFirst.Location = new System.Drawing.Point(9, 225);
      	this.rbFindFirst.Name = "rbFindFirst";
      	this.rbFindFirst.Size = new System.Drawing.Size(65, 24);
      	this.rbFindFirst.TabIndex = 13;
      	this.rbFindFirst.TabStop = true;
      	this.rbFindFirst.Text = "First";
      	this.rbFindFirst.UseVisualStyleBackColor = true;
      	this.rbFindFirst.CheckedChanged += new System.EventHandler(this.EnemyFindStrategyChanged);
      	// 
      	// rbFindStrongest
      	// 
      	this.rbFindStrongest.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      	this.rbFindStrongest.Location = new System.Drawing.Point(9, 205);
      	this.rbFindStrongest.Name = "rbFindStrongest";
      	this.rbFindStrongest.Size = new System.Drawing.Size(70, 24);
      	this.rbFindStrongest.TabIndex = 12;
      	this.rbFindStrongest.TabStop = true;
      	this.rbFindStrongest.Text = "Strongest";
      	this.rbFindStrongest.UseVisualStyleBackColor = true;
      	this.rbFindStrongest.CheckedChanged += new System.EventHandler(this.EnemyFindStrategyChanged);
      	// 
      	// rbFindWeakest
      	// 
      	this.rbFindWeakest.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      	this.rbFindWeakest.Location = new System.Drawing.Point(78, 205);
      	this.rbFindWeakest.Name = "rbFindWeakest";
      	this.rbFindWeakest.Size = new System.Drawing.Size(65, 24);
      	this.rbFindWeakest.TabIndex = 11;
      	this.rbFindWeakest.TabStop = true;
      	this.rbFindWeakest.Text = "Weakest";
      	this.rbFindWeakest.UseVisualStyleBackColor = true;
      	this.rbFindWeakest.CheckedChanged += new System.EventHandler(this.EnemyFindStrategyChanged);
      	// 
      	// rbFindFarest
      	// 
      	this.rbFindFarest.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      	this.rbFindFarest.Location = new System.Drawing.Point(78, 185);
      	this.rbFindFarest.Name = "rbFindFarest";
      	this.rbFindFarest.Size = new System.Drawing.Size(65, 24);
      	this.rbFindFarest.TabIndex = 10;
      	this.rbFindFarest.TabStop = true;
      	this.rbFindFarest.Text = "Farest";
      	this.rbFindFarest.UseVisualStyleBackColor = true;
      	this.rbFindFarest.CheckedChanged += new System.EventHandler(this.EnemyFindStrategyChanged);
      	// 
      	// rbFindNearest
      	// 
      	this.rbFindNearest.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      	this.rbFindNearest.Location = new System.Drawing.Point(9, 185);
      	this.rbFindNearest.Name = "rbFindNearest";
      	this.rbFindNearest.Size = new System.Drawing.Size(65, 24);
      	this.rbFindNearest.TabIndex = 9;
      	this.rbFindNearest.TabStop = true;
      	this.rbFindNearest.Text = "Nearest";
      	this.rbFindNearest.UseVisualStyleBackColor = true;
      	this.rbFindNearest.CheckedChanged += new System.EventHandler(this.EnemyFindStrategyChanged);
      	// 
      	// btnTowerSell
      	// 
      	this.btnTowerSell.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
      	      	      	| System.Windows.Forms.AnchorStyles.Right)));
      	this.btnTowerSell.Enabled = false;
      	this.btnTowerSell.Location = new System.Drawing.Point(6, 281);
      	this.btnTowerSell.Name = "btnTowerSell";
      	this.btnTowerSell.Size = new System.Drawing.Size(134, 23);
      	this.btnTowerSell.TabIndex = 8;
      	this.btnTowerSell.Text = "Sell";
      	this.btnTowerSell.UseVisualStyleBackColor = true;
      	this.btnTowerSell.Click += new System.EventHandler(this.BtnTowerSellClick);
      	// 
      	// btnUpgradeTower
      	// 
      	this.btnUpgradeTower.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
      	      	      	| System.Windows.Forms.AnchorStyles.Right)));
      	this.btnUpgradeTower.Enabled = false;
      	this.btnUpgradeTower.Location = new System.Drawing.Point(6, 310);
      	this.btnUpgradeTower.Name = "btnUpgradeTower";
      	this.btnUpgradeTower.Size = new System.Drawing.Size(134, 23);
      	this.btnUpgradeTower.TabIndex = 7;
      	this.btnUpgradeTower.Text = "&Upgrade";
      	this.btnUpgradeTower.UseVisualStyleBackColor = true;
      	this.btnUpgradeTower.Click += new System.EventHandler(this.BtnUpgradeTowerClick);
      	// 
      	// lTowerInfo
      	// 
      	this.lTowerInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
      	      	      	| System.Windows.Forms.AnchorStyles.Right)));
      	this.lTowerInfo.Location = new System.Drawing.Point(6, 33);
      	this.lTowerInfo.Name = "lTowerInfo";
      	this.lTowerInfo.Size = new System.Drawing.Size(134, 149);
      	this.lTowerInfo.TabIndex = 0;
      	// 
      	// FrmMain
      	// 
      	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      	this.ClientSize = new System.Drawing.Size(981, 645);
      	this.Controls.Add(this.gbTowerInfo);
      	this.Controls.Add(this.statusStrip1);
      	this.Controls.Add(this.gbInfo);
      	this.Controls.Add(this.gbTower);
      	this.Controls.Add(this.pbMain);
      	this.Controls.Add(this.menuStrip1);
      	this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      	this.MainMenuStrip = this.menuStrip1;
      	this.MaximizeBox = false;
      	this.Name = "FrmMain";
      	this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      	this.Text = "TowDef";
      	((System.ComponentModel.ISupportInitialize)(this.pbMain)).EndInit();
      	this.gbTower.ResumeLayout(false);
      	this.gbInfo.ResumeLayout(false);
      	this.menuStrip1.ResumeLayout(false);
      	this.menuStrip1.PerformLayout();
      	this.gbTowerInfo.ResumeLayout(false);
      	this.ResumeLayout(false);
      	this.PerformLayout();
      }
      private System.Windows.Forms.ToolStripMenuItem btnRestart;
      private System.Windows.Forms.RadioButton rbFindSlowest;
      private System.Windows.Forms.RadioButton rbFindFastest;
      private System.Windows.Forms.RadioButton rbFindLast;
      private System.Windows.Forms.RadioButton rbFindFirst;
      private System.Windows.Forms.RadioButton rbFindStrongest;
      private System.Windows.Forms.RadioButton rbFindWeakest;
      private System.Windows.Forms.RadioButton rbFindFarest;
      private System.Windows.Forms.RadioButton rbFindNearest;
      private System.Windows.Forms.Label lTowerInfo;
      private System.Windows.Forms.GroupBox gbTowerInfo;
      private System.Windows.Forms.ToolStripMenuItem btnQuit;
      private System.Windows.Forms.ToolStripMenuItem dateiToolStripMenuItem;
      private System.Windows.Forms.StatusStrip statusStrip1;
      private System.Windows.Forms.MenuStrip menuStrip1;
      private System.Windows.Forms.ToolStripMenuItem btnLevelEdit;
      private System.Windows.Forms.Label lTowerCount;
      private System.Windows.Forms.Button btnTowerSell;
      private System.Windows.Forms.Button btnTowerTeleport;
      private System.Windows.Forms.GroupBox gbInfo;
      private System.Windows.Forms.Button btnTowerSlow;
      private System.Windows.Forms.Button btnTowerSplash;
      private System.Windows.Forms.Button btnTowerFreeze;
      private System.Windows.Forms.Button btnUpgradeTower;
      private System.Windows.Forms.Label lEnemiesLeft;
      private System.Windows.Forms.Label lEnemyCount;
      private System.Windows.Forms.Button btnTowerRange;
      private System.Windows.Forms.Button btnTowerBase;
      private System.Windows.Forms.GroupBox gbTower;
      private System.Windows.Forms.Label lLifepoints;
      private System.Windows.Forms.Label lMoney;
      private System.Windows.Forms.Label lStage;
      private System.Windows.Forms.Timer tMain;
      private System.Windows.Forms.PictureBox pbMain;
   }
}
