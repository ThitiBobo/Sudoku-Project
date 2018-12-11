using System.Drawing;
using System.Windows.Forms;

namespace Sudoku_WinForm
{
    partial class FSudoku
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FSudoku));
            this.sudokuGridView = new System.Windows.Forms.DataGridView();
            this.mainPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.menuPanel = new System.Windows.Forms.Panel();
            this.parameterGroupBox = new System.Windows.Forms.GroupBox();
            this.difficultyComboBox = new System.Windows.Forms.ComboBox();
            this.generateButton = new System.Windows.Forms.Button();
            this.sizeComboBox = new System.Windows.Forms.ComboBox();
            this.sizeLabel = new System.Windows.Forms.Label();
            this.difficultyLabel = new System.Windows.Forms.Label();
            this.solutionButton = new System.Windows.Forms.Button();
            this.correctButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.sudokuGridView)).BeginInit();
            this.mainPanel.SuspendLayout();
            this.menuPanel.SuspendLayout();
            this.parameterGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // sudokuGridView
            // 
            this.sudokuGridView.AllowUserToAddRows = false;
            this.sudokuGridView.AllowUserToResizeColumns = false;
            this.sudokuGridView.AllowUserToResizeRows = false;
            this.sudokuGridView.ColumnHeadersVisible = false;
            this.sudokuGridView.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sudokuGridView.GridColor = System.Drawing.Color.DarkBlue;
            this.sudokuGridView.Location = new System.Drawing.Point(3, 3);
            this.sudokuGridView.Name = "sudokuGridView";
            this.sudokuGridView.RowHeadersVisible = false;
            this.sudokuGridView.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.sudokuGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.sudokuGridView.Size = new System.Drawing.Size(200, 200);
            this.sudokuGridView.TabIndex = 0;
            this.sudokuGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.CellValueChanged);
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.sudokuGridView);
            this.mainPanel.Controls.Add(this.menuPanel);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(800, 450);
            this.mainPanel.TabIndex = 1;
            // 
            // menuPanel
            // 
            this.menuPanel.Controls.Add(this.parameterGroupBox);
            this.menuPanel.Controls.Add(this.solutionButton);
            this.menuPanel.Controls.Add(this.correctButton);
            this.menuPanel.Location = new System.Drawing.Point(209, 3);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.Size = new System.Drawing.Size(223, 140);
            this.menuPanel.TabIndex = 8;
            // 
            // parameterGroupBox
            // 
            this.parameterGroupBox.Controls.Add(this.difficultyComboBox);
            this.parameterGroupBox.Controls.Add(this.generateButton);
            this.parameterGroupBox.Controls.Add(this.sizeComboBox);
            this.parameterGroupBox.Controls.Add(this.sizeLabel);
            this.parameterGroupBox.Controls.Add(this.difficultyLabel);
            this.parameterGroupBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.parameterGroupBox.Location = new System.Drawing.Point(3, 3);
            this.parameterGroupBox.Name = "parameterGroupBox";
            this.parameterGroupBox.Size = new System.Drawing.Size(215, 101);
            this.parameterGroupBox.TabIndex = 5;
            this.parameterGroupBox.TabStop = false;
            this.parameterGroupBox.Text = "Paramètres";
            // 
            // difficultyComboBox
            // 
            this.difficultyComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.difficultyComboBox.FormattingEnabled = true;
            this.difficultyComboBox.Items.AddRange(new object[] {
            "easy",
            "normal",
            "expert",
            "hard"});
            this.difficultyComboBox.Location = new System.Drawing.Point(64, 46);
            this.difficultyComboBox.Name = "difficultyComboBox";
            this.difficultyComboBox.Size = new System.Drawing.Size(121, 21);
            this.difficultyComboBox.TabIndex = 8;
            this.difficultyComboBox.SelectedIndexChanged += new System.EventHandler(this.ChangeDifficulty);
            // 
            // generateButton
            // 
            this.generateButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.generateButton.Location = new System.Drawing.Point(3, 75);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(209, 23);
            this.generateButton.TabIndex = 9;
            this.generateButton.Text = "Générer";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.GenerateGrid);
            // 
            // sizeComboBox
            // 
            this.sizeComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sizeComboBox.FormattingEnabled = true;
            this.sizeComboBox.Items.AddRange(new object[] {
            "4 x 4",
            "9 x 9",
            "16 x 16"});
            this.sizeComboBox.Location = new System.Drawing.Point(64, 19);
            this.sizeComboBox.Name = "sizeComboBox";
            this.sizeComboBox.Size = new System.Drawing.Size(121, 21);
            this.sizeComboBox.TabIndex = 7;
            this.sizeComboBox.SelectedIndexChanged += new System.EventHandler(this.ChangeGridSize);
            // 
            // sizeLabel
            // 
            this.sizeLabel.AutoSize = true;
            this.sizeLabel.Location = new System.Drawing.Point(26, 22);
            this.sizeLabel.Name = "sizeLabel";
            this.sizeLabel.Size = new System.Drawing.Size(32, 13);
            this.sizeLabel.TabIndex = 6;
            this.sizeLabel.Text = "Taille";
            this.sizeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // difficultyLabel
            // 
            this.difficultyLabel.AutoSize = true;
            this.difficultyLabel.Location = new System.Drawing.Point(10, 49);
            this.difficultyLabel.Name = "difficultyLabel";
            this.difficultyLabel.Size = new System.Drawing.Size(48, 13);
            this.difficultyLabel.TabIndex = 6;
            this.difficultyLabel.Text = "Difficulté";
            this.difficultyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // solutionButton
            // 
            this.solutionButton.Location = new System.Drawing.Point(124, 107);
            this.solutionButton.Name = "solutionButton";
            this.solutionButton.Size = new System.Drawing.Size(75, 23);
            this.solutionButton.TabIndex = 7;
            this.solutionButton.Text = "Solution";
            this.solutionButton.UseVisualStyleBackColor = true;
            this.solutionButton.Click += new System.EventHandler(this.ShowSolution);
            // 
            // correctButton
            // 
            this.correctButton.Location = new System.Drawing.Point(26, 107);
            this.correctButton.Name = "correctButton";
            this.correctButton.Size = new System.Drawing.Size(75, 23);
            this.correctButton.TabIndex = 6;
            this.correctButton.Text = "Corriger";
            this.correctButton.UseVisualStyleBackColor = true;
            this.correctButton.Click += new System.EventHandler(this.CorrectGrid);
            // 
            // FSudoku
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Menu;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mainPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FSudoku";
            this.Text = "Jeu du Sudoku";
            ((System.ComponentModel.ISupportInitialize)(this.sudokuGridView)).EndInit();
            this.mainPanel.ResumeLayout(false);
            this.menuPanel.ResumeLayout(false);
            this.parameterGroupBox.ResumeLayout(false);
            this.parameterGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView sudokuGridView;
        private FlowLayoutPanel mainPanel;
        private GroupBox parameterGroupBox;
        private Label difficultyLabel;
        private Button generateButton;
        private Label sizeLabel;
        private ComboBox sizeComboBox;
        private ComboBox difficultyComboBox;
        private Button correctButton;
        private Button solutionButton;
        private Panel menuPanel;
    }
}

