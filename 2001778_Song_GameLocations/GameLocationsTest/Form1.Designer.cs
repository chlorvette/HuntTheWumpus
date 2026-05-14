namespace _2001778_Song_GameLocations
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.buttonSetLocations = new System.Windows.Forms.Button();
            this.buttonFallIntoPit = new System.Windows.Forms.Button();
            this.textBoxPlayerLocation = new System.Windows.Forms.TextBox();
            this.richTextBoxLocations = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.buttonSetPlayerStart = new System.Windows.Forms.Button();
            this.buttonMovePlayer = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxChosenLocation = new System.Windows.Forms.TextBox();
            this.buttonBats = new System.Windows.Forms.Button();
            this.textBoxStartingLocation = new System.Windows.Forms.TextBox();
            this.buttonBuySecret = new System.Windows.Forms.Button();
            this.buttonShootArrow = new System.Windows.Forms.Button();
            this.buttonGenerateRandomConnected = new System.Windows.Forms.Button();
            this.richTextBoxConnectedCaves = new System.Windows.Forms.RichTextBox();
            this.buttonWarning = new System.Windows.Forms.Button();
            this.richTextBoxWarnings = new System.Windows.Forms.RichTextBox();
            this.labelHit = new System.Windows.Forms.Label();
            this.textBoxWumpusLocation = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonWinTrivia = new System.Windows.Forms.Button();
            this.buttonOneTurn = new System.Windows.Forms.Button();
            this.labelWumpusCondition = new System.Windows.Forms.Label();
            this.textBoxWumpusCondition = new System.Windows.Forms.TextBox();
            this.richTextBoxSecret = new System.Windows.Forms.RichTextBox();
            this.buttonCheckHazards = new System.Windows.Forms.Button();
            this.textBoxPit1 = new System.Windows.Forms.TextBox();
            this.textBoxPit2 = new System.Windows.Forms.TextBox();
            this.textBoxBat1 = new System.Windows.Forms.TextBox();
            this.textBoxBat2 = new System.Windows.Forms.TextBox();
            this.textBoxWumpus = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.buttonManualSetLocations = new System.Windows.Forms.Button();
            this.textBoxTunnel1 = new System.Windows.Forms.TextBox();
            this.textBoxTunnel3 = new System.Windows.Forms.TextBox();
            this.textBoxTunnel2 = new System.Windows.Forms.TextBox();
            this.buttonManualSetConnected = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonSetLocations
            // 
            this.buttonSetLocations.Location = new System.Drawing.Point(14, 58);
            this.buttonSetLocations.Name = "buttonSetLocations";
            this.buttonSetLocations.Size = new System.Drawing.Size(75, 23);
            this.buttonSetLocations.TabIndex = 0;
            this.buttonSetLocations.Text = "set locations";
            this.buttonSetLocations.UseVisualStyleBackColor = true;
            this.buttonSetLocations.Click += new System.EventHandler(this.buttonSet_Click);
            // 
            // buttonFallIntoPit
            // 
            this.buttonFallIntoPit.Location = new System.Drawing.Point(1117, 274);
            this.buttonFallIntoPit.Name = "buttonFallIntoPit";
            this.buttonFallIntoPit.Size = new System.Drawing.Size(75, 23);
            this.buttonFallIntoPit.TabIndex = 1;
            this.buttonFallIntoPit.Text = "fall into pit";
            this.buttonFallIntoPit.UseVisualStyleBackColor = true;
            this.buttonFallIntoPit.Click += new System.EventHandler(this.buttonFallIntoPit_Click);
            // 
            // textBoxPlayerLocation
            // 
            this.textBoxPlayerLocation.Location = new System.Drawing.Point(448, 294);
            this.textBoxPlayerLocation.Name = "textBoxPlayerLocation";
            this.textBoxPlayerLocation.ReadOnly = true;
            this.textBoxPlayerLocation.Size = new System.Drawing.Size(100, 20);
            this.textBoxPlayerLocation.TabIndex = 2;
            // 
            // richTextBoxLocations
            // 
            this.richTextBoxLocations.Location = new System.Drawing.Point(12, 120);
            this.richTextBoxLocations.Name = "richTextBoxLocations";
            this.richTextBoxLocations.Size = new System.Drawing.Size(274, 90);
            this.richTextBoxLocations.TabIndex = 3;
            this.richTextBoxLocations.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(448, 275);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(220, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Current Player Location: check every second";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // buttonSetPlayerStart
            // 
            this.buttonSetPlayerStart.Location = new System.Drawing.Point(12, 29);
            this.buttonSetPlayerStart.Name = "buttonSetPlayerStart";
            this.buttonSetPlayerStart.Size = new System.Drawing.Size(186, 23);
            this.buttonSetPlayerStart.TabIndex = 5;
            this.buttonSetPlayerStart.Text = "set STARTING location of player";
            this.buttonSetPlayerStart.UseVisualStyleBackColor = true;
            this.buttonSetPlayerStart.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonMovePlayer
            // 
            this.buttonMovePlayer.Location = new System.Drawing.Point(705, 58);
            this.buttonMovePlayer.Name = "buttonMovePlayer";
            this.buttonMovePlayer.Size = new System.Drawing.Size(210, 50);
            this.buttonMovePlayer.TabIndex = 6;
            this.buttonMovePlayer.Text = "move player into that chyosen cave";
            this.buttonMovePlayer.UseVisualStyleBackColor = true;
            this.buttonMovePlayer.Click += new System.EventHandler(this.buttonMovePlayer_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(514, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "move player to a cave 1-25";
            // 
            // textBoxChosenLocation
            // 
            this.textBoxChosenLocation.Location = new System.Drawing.Point(517, 67);
            this.textBoxChosenLocation.Name = "textBoxChosenLocation";
            this.textBoxChosenLocation.Size = new System.Drawing.Size(100, 20);
            this.textBoxChosenLocation.TabIndex = 8;
            // 
            // buttonBats
            // 
            this.buttonBats.Location = new System.Drawing.Point(1098, 303);
            this.buttonBats.Name = "buttonBats";
            this.buttonBats.Size = new System.Drawing.Size(111, 23);
            this.buttonBats.TabIndex = 9;
            this.buttonBats.Text = "bats take you away";
            this.buttonBats.UseVisualStyleBackColor = true;
            this.buttonBats.Click += new System.EventHandler(this.buttonBats_Click);
            // 
            // textBoxStartingLocation
            // 
            this.textBoxStartingLocation.Location = new System.Drawing.Point(240, 32);
            this.textBoxStartingLocation.Name = "textBoxStartingLocation";
            this.textBoxStartingLocation.ReadOnly = true;
            this.textBoxStartingLocation.Size = new System.Drawing.Size(100, 20);
            this.textBoxStartingLocation.TabIndex = 10;
            this.textBoxStartingLocation.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxStartingLocation.TextChanged += new System.EventHandler(this.textBoxStartingLocation_TextChanged);
            // 
            // buttonBuySecret
            // 
            this.buttonBuySecret.Location = new System.Drawing.Point(1120, 445);
            this.buttonBuySecret.Name = "buttonBuySecret";
            this.buttonBuySecret.Size = new System.Drawing.Size(75, 23);
            this.buttonBuySecret.TabIndex = 11;
            this.buttonBuySecret.Text = "buy secret";
            this.buttonBuySecret.UseVisualStyleBackColor = true;
            this.buttonBuySecret.Click += new System.EventHandler(this.buttonBuySecret_Click);
            // 
            // buttonShootArrow
            // 
            this.buttonShootArrow.Location = new System.Drawing.Point(517, 85);
            this.buttonShootArrow.Name = "buttonShootArrow";
            this.buttonShootArrow.Size = new System.Drawing.Size(140, 23);
            this.buttonShootArrow.TabIndex = 12;
            this.buttonShootArrow.Text = "shoot an arrow into it";
            this.buttonShootArrow.UseVisualStyleBackColor = true;
            this.buttonShootArrow.Click += new System.EventHandler(this.buttonShootArrow_Click);
            // 
            // buttonGenerateRandomConnected
            // 
            this.buttonGenerateRandomConnected.Location = new System.Drawing.Point(319, 201);
            this.buttonGenerateRandomConnected.Name = "buttonGenerateRandomConnected";
            this.buttonGenerateRandomConnected.Size = new System.Drawing.Size(107, 40);
            this.buttonGenerateRandomConnected.TabIndex = 13;
            this.buttonGenerateRandomConnected.Text = "generate random connected caves ";
            this.buttonGenerateRandomConnected.UseVisualStyleBackColor = true;
            this.buttonGenerateRandomConnected.Click += new System.EventHandler(this.buttonGenerateRandomConnected_Click);
            // 
            // richTextBoxConnectedCaves
            // 
            this.richTextBoxConnectedCaves.Location = new System.Drawing.Point(336, 247);
            this.richTextBoxConnectedCaves.Name = "richTextBoxConnectedCaves";
            this.richTextBoxConnectedCaves.Size = new System.Drawing.Size(74, 121);
            this.richTextBoxConnectedCaves.TabIndex = 14;
            this.richTextBoxConnectedCaves.Text = "";
            this.richTextBoxConnectedCaves.TextChanged += new System.EventHandler(this.richTextBoxConnectedCaves_TextChanged);
            // 
            // buttonWarning
            // 
            this.buttonWarning.Location = new System.Drawing.Point(1098, 367);
            this.buttonWarning.Name = "buttonWarning";
            this.buttonWarning.Size = new System.Drawing.Size(112, 23);
            this.buttonWarning.TabIndex = 15;
            this.buttonWarning.Text = "BUY WARNING";
            this.buttonWarning.UseVisualStyleBackColor = true;
            this.buttonWarning.Click += new System.EventHandler(this.buttonWarning_Click);
            // 
            // richTextBoxWarnings
            // 
            this.richTextBoxWarnings.Location = new System.Drawing.Point(1043, 392);
            this.richTextBoxWarnings.Name = "richTextBoxWarnings";
            this.richTextBoxWarnings.Size = new System.Drawing.Size(226, 39);
            this.richTextBoxWarnings.TabIndex = 16;
            this.richTextBoxWarnings.Text = "";
            // 
            // labelHit
            // 
            this.labelHit.AutoSize = true;
            this.labelHit.Location = new System.Drawing.Point(568, 120);
            this.labelHit.Name = "labelHit";
            this.labelHit.Size = new System.Drawing.Size(34, 13);
            this.labelHit.TabIndex = 17;
            this.labelHit.Text = "is hit?";
            // 
            // textBoxWumpusLocation
            // 
            this.textBoxWumpusLocation.Location = new System.Drawing.Point(448, 347);
            this.textBoxWumpusLocation.Name = "textBoxWumpusLocation";
            this.textBoxWumpusLocation.ReadOnly = true;
            this.textBoxWumpusLocation.Size = new System.Drawing.Size(100, 20);
            this.textBoxWumpusLocation.TabIndex = 18;
            this.textBoxWumpusLocation.TextChanged += new System.EventHandler(this.textBoxWumpusLocation_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(448, 326);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "wumpus location";
            // 
            // buttonWinTrivia
            // 
            this.buttonWinTrivia.Location = new System.Drawing.Point(1098, 187);
            this.buttonWinTrivia.Name = "buttonWinTrivia";
            this.buttonWinTrivia.Size = new System.Drawing.Size(112, 23);
            this.buttonWinTrivia.TabIndex = 20;
            this.buttonWinTrivia.Text = "win trivia game ";
            this.buttonWinTrivia.UseVisualStyleBackColor = true;
            this.buttonWinTrivia.Click += new System.EventHandler(this.buttonWinTrivia_Click);
            // 
            // buttonOneTurn
            // 
            this.buttonOneTurn.Location = new System.Drawing.Point(319, 162);
            this.buttonOneTurn.Name = "buttonOneTurn";
            this.buttonOneTurn.Size = new System.Drawing.Size(75, 23);
            this.buttonOneTurn.TabIndex = 21;
            this.buttonOneTurn.Text = "One Turn";
            this.buttonOneTurn.UseVisualStyleBackColor = true;
            this.buttonOneTurn.Click += new System.EventHandler(this.buttonOneTurn_Click);
            // 
            // labelWumpusCondition
            // 
            this.labelWumpusCondition.AutoSize = true;
            this.labelWumpusCondition.Location = new System.Drawing.Point(702, 326);
            this.labelWumpusCondition.Name = "labelWumpusCondition";
            this.labelWumpusCondition.Size = new System.Drawing.Size(95, 13);
            this.labelWumpusCondition.TabIndex = 22;
            this.labelWumpusCondition.Text = "Wumpus is Awake";
            // 
            // textBoxWumpusCondition
            // 
            this.textBoxWumpusCondition.Location = new System.Drawing.Point(697, 344);
            this.textBoxWumpusCondition.Name = "textBoxWumpusCondition";
            this.textBoxWumpusCondition.ReadOnly = true;
            this.textBoxWumpusCondition.Size = new System.Drawing.Size(100, 20);
            this.textBoxWumpusCondition.TabIndex = 23;
            // 
            // richTextBoxSecret
            // 
            this.richTextBoxSecret.Location = new System.Drawing.Point(1043, 474);
            this.richTextBoxSecret.Name = "richTextBoxSecret";
            this.richTextBoxSecret.Size = new System.Drawing.Size(226, 39);
            this.richTextBoxSecret.TabIndex = 24;
            this.richTextBoxSecret.Text = "";
            // 
            // buttonCheckHazards
            // 
            this.buttonCheckHazards.Location = new System.Drawing.Point(687, 162);
            this.buttonCheckHazards.Name = "buttonCheckHazards";
            this.buttonCheckHazards.Size = new System.Drawing.Size(192, 87);
            this.buttonCheckHazards.TabIndex = 26;
            this.buttonCheckHazards.Text = "are u in a room with hazards";
            this.buttonCheckHazards.UseVisualStyleBackColor = true;
            this.buttonCheckHazards.Click += new System.EventHandler(this.buttonCheckHazards_Click);
            // 
            // textBoxPit1
            // 
            this.textBoxPit1.Location = new System.Drawing.Point(160, 294);
            this.textBoxPit1.Name = "textBoxPit1";
            this.textBoxPit1.Size = new System.Drawing.Size(100, 20);
            this.textBoxPit1.TabIndex = 26;
            // 
            // textBoxPit2
            // 
            this.textBoxPit2.Location = new System.Drawing.Point(160, 348);
            this.textBoxPit2.Name = "textBoxPit2";
            this.textBoxPit2.Size = new System.Drawing.Size(100, 20);
            this.textBoxPit2.TabIndex = 27;
            // 
            // textBoxBat1
            // 
            this.textBoxBat1.Location = new System.Drawing.Point(160, 392);
            this.textBoxBat1.Name = "textBoxBat1";
            this.textBoxBat1.Size = new System.Drawing.Size(100, 20);
            this.textBoxBat1.TabIndex = 28;
            // 
            // textBoxBat2
            // 
            this.textBoxBat2.Location = new System.Drawing.Point(160, 439);
            this.textBoxBat2.Name = "textBoxBat2";
            this.textBoxBat2.Size = new System.Drawing.Size(100, 20);
            this.textBoxBat2.TabIndex = 29;
            // 
            // textBoxWumpus
            // 
            this.textBoxWumpus.Location = new System.Drawing.Point(160, 486);
            this.textBoxWumpus.Name = "textBoxWumpus";
            this.textBoxWumpus.Size = new System.Drawing.Size(100, 20);
            this.textBoxWumpus.TabIndex = 30;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 294);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 31;
            this.label4.Text = "Pit 1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 350);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 13);
            this.label5.TabIndex = 32;
            this.label5.Text = "pit2";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(41, 455);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 13);
            this.label6.TabIndex = 34;
            this.label6.Text = "bat2";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(41, 399);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 13);
            this.label7.TabIndex = 33;
            this.label7.Text = "bat1";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(41, 493);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 13);
            this.label8.TabIndex = 35;
            this.label8.Text = "wumpus";
            // 
            // buttonManualSetLocations
            // 
            this.buttonManualSetLocations.Location = new System.Drawing.Point(66, 239);
            this.buttonManualSetLocations.Name = "buttonManualSetLocations";
            this.buttonManualSetLocations.Size = new System.Drawing.Size(132, 49);
            this.buttonManualSetLocations.TabIndex = 36;
            this.buttonManualSetLocations.Text = "MANUAL set locations";
            this.buttonManualSetLocations.UseVisualStyleBackColor = true;
            this.buttonManualSetLocations.Click += new System.EventHandler(this.buttonManualSetLocations_Click);
            // 
            // textBoxTunnel1
            // 
            this.textBoxTunnel1.Location = new System.Drawing.Point(517, 493);
            this.textBoxTunnel1.Name = "textBoxTunnel1";
            this.textBoxTunnel1.Size = new System.Drawing.Size(100, 20);
            this.textBoxTunnel1.TabIndex = 37;
            // 
            // textBoxTunnel3
            // 
            this.textBoxTunnel3.Location = new System.Drawing.Point(517, 576);
            this.textBoxTunnel3.Name = "textBoxTunnel3";
            this.textBoxTunnel3.Size = new System.Drawing.Size(100, 20);
            this.textBoxTunnel3.TabIndex = 39;
            // 
            // textBoxTunnel2
            // 
            this.textBoxTunnel2.Location = new System.Drawing.Point(517, 532);
            this.textBoxTunnel2.Name = "textBoxTunnel2";
            this.textBoxTunnel2.Size = new System.Drawing.Size(100, 20);
            this.textBoxTunnel2.TabIndex = 38;
            // 
            // buttonManualSetConnected
            // 
            this.buttonManualSetConnected.Location = new System.Drawing.Point(639, 517);
            this.buttonManualSetConnected.Name = "buttonManualSetConnected";
            this.buttonManualSetConnected.Size = new System.Drawing.Size(132, 49);
            this.buttonManualSetConnected.TabIndex = 43;
            this.buttonManualSetConnected.Text = "MANUAL set conneted tunnels";
            this.buttonManualSetConnected.UseVisualStyleBackColor = true;
            this.buttonManualSetConnected.Click += new System.EventHandler(this.buttonManualSetConnected_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(424, 583);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 13);
            this.label9.TabIndex = 42;
            this.label9.Text = "tunnel 3";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(424, 535);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(45, 13);
            this.label10.TabIndex = 41;
            this.label10.Text = "tunnel 2";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(420, 493);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(45, 13);
            this.label11.TabIndex = 40;
            this.label11.Text = "tunnel 1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1585, 652);
            this.Controls.Add(this.buttonManualSetConnected);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.textBoxTunnel3);
            this.Controls.Add(this.textBoxTunnel2);
            this.Controls.Add(this.textBoxTunnel1);
            this.Controls.Add(this.buttonManualSetLocations);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxWumpus);
            this.Controls.Add(this.textBoxBat2);
            this.Controls.Add(this.textBoxBat1);
            this.Controls.Add(this.textBoxPit2);
            this.Controls.Add(this.textBoxPit1);
            this.Controls.Add(this.buttonCheckHazards);
            this.Controls.Add(this.richTextBoxSecret);
            this.Controls.Add(this.textBoxWumpusCondition);
            this.Controls.Add(this.labelWumpusCondition);
            this.Controls.Add(this.buttonOneTurn);
            this.Controls.Add(this.buttonWinTrivia);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxWumpusLocation);
            this.Controls.Add(this.labelHit);
            this.Controls.Add(this.richTextBoxWarnings);
            this.Controls.Add(this.buttonWarning);
            this.Controls.Add(this.richTextBoxConnectedCaves);
            this.Controls.Add(this.buttonGenerateRandomConnected);
            this.Controls.Add(this.buttonShootArrow);
            this.Controls.Add(this.buttonBuySecret);
            this.Controls.Add(this.textBoxStartingLocation);
            this.Controls.Add(this.buttonBats);
            this.Controls.Add(this.textBoxChosenLocation);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonMovePlayer);
            this.Controls.Add(this.buttonSetPlayerStart);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBoxLocations);
            this.Controls.Add(this.textBoxPlayerLocation);
            this.Controls.Add(this.buttonFallIntoPit);
            this.Controls.Add(this.buttonSetLocations);
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Game Locations Test APp";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSetLocations;
        private System.Windows.Forms.Button buttonFallIntoPit;
        private System.Windows.Forms.TextBox textBoxPlayerLocation;
        private System.Windows.Forms.RichTextBox richTextBoxLocations;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button buttonSetPlayerStart;
        private System.Windows.Forms.Button buttonMovePlayer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxChosenLocation;
        private System.Windows.Forms.Button buttonBats;
        private System.Windows.Forms.TextBox textBoxStartingLocation;
        private System.Windows.Forms.Button buttonBuySecret;
        private System.Windows.Forms.Button buttonShootArrow;
        private System.Windows.Forms.Button buttonGenerateRandomConnected;
        private System.Windows.Forms.RichTextBox richTextBoxConnectedCaves;
        private System.Windows.Forms.Button buttonWarning;
        private System.Windows.Forms.RichTextBox richTextBoxWarnings;
        private System.Windows.Forms.Label labelHit;
        private System.Windows.Forms.TextBox textBoxWumpusLocation;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonWinTrivia;
        private System.Windows.Forms.Button buttonOneTurn;
        private System.Windows.Forms.Label labelWumpusCondition;
        private System.Windows.Forms.TextBox textBoxWumpusCondition;
        private System.Windows.Forms.RichTextBox richTextBoxSecret;
        private System.Windows.Forms.Button buttonCheckHazards;
        private System.Windows.Forms.TextBox textBoxPit1;
        private System.Windows.Forms.TextBox textBoxPit2;
        private System.Windows.Forms.TextBox textBoxBat1;
        private System.Windows.Forms.TextBox textBoxBat2;
        private System.Windows.Forms.TextBox textBoxWumpus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button buttonManualSetLocations;
        private System.Windows.Forms.TextBox textBoxTunnel1;
        private System.Windows.Forms.TextBox textBoxTunnel3;
        private System.Windows.Forms.TextBox textBoxTunnel2;
        private System.Windows.Forms.Button buttonManualSetConnected;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
    }
}

