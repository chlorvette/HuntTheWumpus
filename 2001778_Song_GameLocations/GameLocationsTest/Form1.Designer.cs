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
            this.buttonFallIntoPit.Location = new System.Drawing.Point(613, 390);
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
            this.richTextBoxLocations.Size = new System.Drawing.Size(274, 248);
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
            this.buttonMovePlayer.Location = new System.Drawing.Point(517, 93);
            this.buttonMovePlayer.Name = "buttonMovePlayer";
            this.buttonMovePlayer.Size = new System.Drawing.Size(75, 23);
            this.buttonMovePlayer.TabIndex = 6;
            this.buttonMovePlayer.Text = "move player";
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
            this.buttonBats.Location = new System.Drawing.Point(613, 345);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
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
    }
}

