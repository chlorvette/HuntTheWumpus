namespace HighScore_Tester
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
            this.buttonShootArrow = new System.Windows.Forms.Button();
            this.buttonCorrectAnswer = new System.Windows.Forms.Button();
            this.buttonWrongAnswer = new System.Windows.Forms.Button();
            this.buttonBats = new System.Windows.Forms.Button();
            this.buttonFallDown = new System.Windows.Forms.Button();
            this.buttonKillWompus = new System.Windows.Forms.Button();
            this.buttonMOVEROOM = new System.Windows.Forms.Button();
            this.buttonDieWompus = new System.Windows.Forms.Button();
            this.buttonItem = new System.Windows.Forms.Button();
            this.listBoxItems = new System.Windows.Forms.ListBox();
            this.buttonGetArrow = new System.Windows.Forms.Button();
            this.textBoxCoins = new System.Windows.Forms.TextBox();
            this.textBoxArrows = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxItems = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonShootArrow
            // 
            this.buttonShootArrow.Location = new System.Drawing.Point(40, 43);
            this.buttonShootArrow.Name = "buttonShootArrow";
            this.buttonShootArrow.Size = new System.Drawing.Size(183, 67);
            this.buttonShootArrow.TabIndex = 0;
            this.buttonShootArrow.Text = "shoot arrow";
            this.buttonShootArrow.UseVisualStyleBackColor = true;
            this.buttonShootArrow.Click += new System.EventHandler(this.buttonShootArrow_Click);
            // 
            // buttonCorrectAnswer
            // 
            this.buttonCorrectAnswer.Location = new System.Drawing.Point(40, 116);
            this.buttonCorrectAnswer.Name = "buttonCorrectAnswer";
            this.buttonCorrectAnswer.Size = new System.Drawing.Size(183, 67);
            this.buttonCorrectAnswer.TabIndex = 1;
            this.buttonCorrectAnswer.Text = "correct answer";
            this.buttonCorrectAnswer.UseVisualStyleBackColor = true;
            this.buttonCorrectAnswer.Click += new System.EventHandler(this.buttonCorrectAnswer_Click);
            // 
            // buttonWrongAnswer
            // 
            this.buttonWrongAnswer.Location = new System.Drawing.Point(40, 189);
            this.buttonWrongAnswer.Name = "buttonWrongAnswer";
            this.buttonWrongAnswer.Size = new System.Drawing.Size(183, 67);
            this.buttonWrongAnswer.TabIndex = 2;
            this.buttonWrongAnswer.Text = "wrong answer";
            this.buttonWrongAnswer.UseVisualStyleBackColor = true;
            this.buttonWrongAnswer.Click += new System.EventHandler(this.buttonWrongAnswer_Click);
            // 
            // buttonBats
            // 
            this.buttonBats.Location = new System.Drawing.Point(40, 262);
            this.buttonBats.Name = "buttonBats";
            this.buttonBats.Size = new System.Drawing.Size(183, 67);
            this.buttonBats.TabIndex = 3;
            this.buttonBats.Text = "encounter bats";
            this.buttonBats.UseVisualStyleBackColor = true;
            this.buttonBats.Click += new System.EventHandler(this.buttonBats_Click);
            // 
            // buttonFallDown
            // 
            this.buttonFallDown.Location = new System.Drawing.Point(40, 335);
            this.buttonFallDown.Name = "buttonFallDown";
            this.buttonFallDown.Size = new System.Drawing.Size(183, 67);
            this.buttonFallDown.TabIndex = 4;
            this.buttonFallDown.Text = "fall down";
            this.buttonFallDown.UseVisualStyleBackColor = true;
            this.buttonFallDown.Click += new System.EventHandler(this.buttonFallDown_Click);
            // 
            // buttonKillWompus
            // 
            this.buttonKillWompus.Location = new System.Drawing.Point(245, 262);
            this.buttonKillWompus.Name = "buttonKillWompus";
            this.buttonKillWompus.Size = new System.Drawing.Size(183, 67);
            this.buttonKillWompus.TabIndex = 8;
            this.buttonKillWompus.Text = "kill the wompus";
            this.buttonKillWompus.UseVisualStyleBackColor = true;
            this.buttonKillWompus.Click += new System.EventHandler(this.buttonKillWompus_Click);
            // 
            // buttonMOVEROOM
            // 
            this.buttonMOVEROOM.Location = new System.Drawing.Point(245, 189);
            this.buttonMOVEROOM.Name = "buttonMOVEROOM";
            this.buttonMOVEROOM.Size = new System.Drawing.Size(183, 67);
            this.buttonMOVEROOM.TabIndex = 7;
            this.buttonMOVEROOM.Text = "MOVE ROOM";
            this.buttonMOVEROOM.UseVisualStyleBackColor = true;
            // 
            // buttonDieWompus
            // 
            this.buttonDieWompus.Location = new System.Drawing.Point(245, 335);
            this.buttonDieWompus.Name = "buttonDieWompus";
            this.buttonDieWompus.Size = new System.Drawing.Size(183, 67);
            this.buttonDieWompus.TabIndex = 6;
            this.buttonDieWompus.Text = "killed by wompus";
            this.buttonDieWompus.UseVisualStyleBackColor = true;
            this.buttonDieWompus.Click += new System.EventHandler(this.buttonDieWompus_Click);
            // 
            // buttonItem
            // 
            this.buttonItem.Location = new System.Drawing.Point(245, 43);
            this.buttonItem.Name = "buttonItem";
            this.buttonItem.Size = new System.Drawing.Size(183, 67);
            this.buttonItem.TabIndex = 5;
            this.buttonItem.Text = "collect item";
            this.buttonItem.UseVisualStyleBackColor = true;
            this.buttonItem.Click += new System.EventHandler(this.buttonItem_Click);
            // 
            // listBoxItems
            // 
            this.listBoxItems.FormattingEnabled = true;
            this.listBoxItems.Location = new System.Drawing.Point(476, 82);
            this.listBoxItems.Name = "listBoxItems";
            this.listBoxItems.Size = new System.Drawing.Size(183, 212);
            this.listBoxItems.TabIndex = 10;
            // 
            // buttonGetArrow
            // 
            this.buttonGetArrow.Location = new System.Drawing.Point(245, 115);
            this.buttonGetArrow.Name = "buttonGetArrow";
            this.buttonGetArrow.Size = new System.Drawing.Size(183, 67);
            this.buttonGetArrow.TabIndex = 9;
            this.buttonGetArrow.Text = "get new arrow  5 coins";
            this.buttonGetArrow.UseVisualStyleBackColor = true;
            this.buttonGetArrow.Click += new System.EventHandler(this.buttonGetArrow_Click);
            // 
            // textBoxCoins
            // 
            this.textBoxCoins.Location = new System.Drawing.Point(515, 346);
            this.textBoxCoins.Name = "textBoxCoins";
            this.textBoxCoins.Size = new System.Drawing.Size(144, 20);
            this.textBoxCoins.TabIndex = 11;
            // 
            // textBoxArrows
            // 
            this.textBoxArrows.Location = new System.Drawing.Point(547, 372);
            this.textBoxArrows.Name = "textBoxArrows";
            this.textBoxArrows.Size = new System.Drawing.Size(112, 20);
            this.textBoxArrows.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(473, 349);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Coins:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(473, 375);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Arrow Count:";
            // 
            // textBoxItems
            // 
            this.textBoxItems.Location = new System.Drawing.Point(540, 44);
            this.textBoxItems.Name = "textBoxItems";
            this.textBoxItems.Size = new System.Drawing.Size(119, 20);
            this.textBoxItems.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(473, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Item Name:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 440);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxItems);
            this.Controls.Add(this.textBoxArrows);
            this.Controls.Add(this.textBoxCoins);
            this.Controls.Add(this.listBoxItems);
            this.Controls.Add(this.buttonGetArrow);
            this.Controls.Add(this.buttonKillWompus);
            this.Controls.Add(this.buttonMOVEROOM);
            this.Controls.Add(this.buttonDieWompus);
            this.Controls.Add(this.buttonItem);
            this.Controls.Add(this.buttonFallDown);
            this.Controls.Add(this.buttonBats);
            this.Controls.Add(this.buttonWrongAnswer);
            this.Controls.Add(this.buttonCorrectAnswer);
            this.Controls.Add(this.buttonShootArrow);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonShootArrow;
        private System.Windows.Forms.Button buttonCorrectAnswer;
        private System.Windows.Forms.Button buttonWrongAnswer;
        private System.Windows.Forms.Button buttonBats;
        private System.Windows.Forms.Button buttonFallDown;
        private System.Windows.Forms.Button buttonKillWompus;
        private System.Windows.Forms.Button buttonMOVEROOM;
        private System.Windows.Forms.Button buttonDieWompus;
        private System.Windows.Forms.Button buttonItem;
        private System.Windows.Forms.ListBox listBoxItems;
        private System.Windows.Forms.Button buttonGetArrow;
        private System.Windows.Forms.TextBox textBoxCoins;
        private System.Windows.Forms.TextBox textBoxArrows;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxItems;
        private System.Windows.Forms.Label label1;
    }
}

