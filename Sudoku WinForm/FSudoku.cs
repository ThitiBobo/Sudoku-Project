using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku_WinForm
{
    public partial class FSudoku : Form
    {
        #region Static Members
        /// <summary>
        /// largeur graphique des cases
        /// </summary>
        private const int cColWidth = 45;
        /// <summary>
        /// hauteru graphique des cases
        /// </summary>
        private const int cRowHeigth = 45;
        #endregion

        #region Members
        /// <summary>
        /// caractérise la taille du Sudoku
        /// </summary>
        private int _n;
        /// <summary>
        /// taille du Sudoku
        /// </summary>
        private int _gridsize;
        /// <summary>
        /// difficulté du sudoku
        /// </summary>
        private double _difficulty;
        /// <summary>
        /// instance de la classe Sudoku
        /// </summary>
        private Sudoku _sk;
        #endregion

        #region GetSet
        /// <summary>
        /// Obtient ou définit l'attribut n du sudoku
        /// </summary>
        private int N
        {
            get { return _n; }
            set
            {
                _n = value;
                _gridsize = value * value;
            }
        }

        /// <summary>
        /// Obtient la taille du sudoku
        /// </summary>
        private int GridSize
        {
            get { return _gridsize; }
        }

        /// <summary>
        /// Obtient la difficulté du sudoku
        /// </summary>
        public double Difficulty {
            get { return _difficulty; }
            private set { _difficulty = value; }
        }
        #endregion

        /// <summary>
        /// Permet d'initialiser une nouvelle fenetre FSudoku
        /// </summary>
        public FSudoku()
        {
            N = 3;
            Difficulty = SudokuBuilder.normal;
            InitializeComponent();
            InitializeSudokuGridView();
            // règle les comboBox sur les valeurs par défaut
            this.difficultyComboBox.SelectedIndex = 1;
            this.sizeComboBox.SelectedIndex = 1;
        }

        /// <summary>
        /// Initialise le DataGridView représentant le sudoku
        /// </summary>
        public void InitializeSudokuGridView()
        {

            this.sudokuGridView.Size = new System.Drawing.Size(cColWidth * GridSize + 3, cRowHeigth * GridSize + 3);
            // ajoute les (size * size) cellules au DataGridView
            for (int i = 0; i < GridSize; i++)
            {
                DataGridViewTextBoxColumn TxCol = new DataGridViewTextBoxColumn();
                TxCol.MaxInputLength = 2;   // only one digit allowed in a cell
                this.sudokuGridView.Columns.Add(TxCol);
                this.sudokuGridView.Columns[i].Name = "Col " + (i + 1).ToString();
                this.sudokuGridView.Columns[i].Width = cColWidth;
                this.sudokuGridView.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                DataGridViewRow row = new DataGridViewRow();
                row.Height = cRowHeigth;
                this.sudokuGridView.Rows.Add(row);
            }
            // marque n * n zone dans le DataGridView
            for (int i = 0; i < GridSize; i++)
            {
                this.sudokuGridView.Columns[i].DividerWidth = 0;
                this.sudokuGridView.Rows[i].DividerHeight = 0;
            }
            for (int i = 0; i < N - 1; i++)
            {
                this.sudokuGridView.Columns[(i * N) + (N - 1)].DividerWidth = 2;
                this.sudokuGridView.Rows[(i * N) + (N - 1)].DividerHeight = 2;
            }            
        }

        /// <summary>
        /// Méthode attachée au boutton Générer, qui remplie le DataGridView sudokuGridView avec les
        /// valeurs d'une instance Sudoku
        /// </summary>
        private void GenerateGrid(object sender, EventArgs e)
        {
            // création d'une nouvlle grille
            SudokuBuilder skBuilder = new SudokuBuilder(N,Difficulty);
            _sk = skBuilder.GetSudoku();

            // remplie le DataGridView avec les valeurs
            for (int i = 0; i < GridSize; i++)
            {
                for (int j = 0; j < GridSize; j++)
                {
                    if (_sk.GetValue(i, j) != 0)
                    {
                        this.sudokuGridView[i, j].Value = _sk.GetValue(i, j);
                        this.sudokuGridView.Rows[j].Cells[i].Style.BackColor = Color.LightSteelBlue;
                        this.sudokuGridView.Rows[j].Cells[i].ReadOnly = true;
                    }
                    else
                    {
                        this.sudokuGridView[i, j].Value = "";
                        this.sudokuGridView.Rows[j].Cells[i].Style.BackColor = Color.White;
                        this.sudokuGridView.Rows[j].Cells[i].ReadOnly = false;
                        
                    }
                    
                }
            }
        }
        
        /// <summary>
        /// Méthode attachée à la comboBox difficulté, permet de changer la difficulté pour la prochaine grille
        /// à générer
        /// </summary>
        private void ChangeDifficulty(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            double difficulty;
            switch ((string)comboBox.SelectedItem)
            {
                case "easy": difficulty = SudokuBuilder.easy; break;
                case "normal": difficulty = SudokuBuilder.normal; break;
                case "expert": difficulty = SudokuBuilder.expert; break;
                case "hard": difficulty = SudokuBuilder.hard; break;
                default: difficulty = SudokuBuilder.normal; break;
            }
            Difficulty = difficulty;
        }

        /// <summary>
        /// Méthode attaché à la comboBox size, permet permet de changer la taille pour la prochaine grille
        /// à générer
        /// </summary>
        private void ChangeGridSize(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            int n;
            switch ((string)comboBox.SelectedItem)
            {
                case "4 x 4": n = 2; break;
                case "9 x 9": n = 3; break;
                case "16 x 16": n = 4; break;
                default: n = 3; break;
            }
            N = n;
            InitializeSudokuGridView();
        }

        /// <summary>
        /// Méthode attaché au clic du boutton corriger, corrige les valeur déja saisie dans la grille
        /// </summary>
        private void CorrectGrid(object sender, EventArgs e)
        {
            if (_sk == null)
                return;
            if (_sk.Size != _gridsize)
                return;

            for (int i = 0; i < GridSize; i++)
            {
                for (int j = 0; j < GridSize; j++)
                {
                    if (!_sk.IsLocked(i,j))
                    {
                        if (_sk.GetValue(i, j) == _sk.GetCorrectValue(i, j))
                        {
                            this.sudokuGridView.Rows[j].Cells[i].Style.BackColor = Color.LightGreen;
                        }
                        else
                        {
                            if (_sk.GetValue(i, j) != 0)
                                this.sudokuGridView.Rows[j].Cells[i].Style.BackColor = Color.OrangeRed;
                        }
                    }

                }
            }
        }

        /// <summary>
        /// Méthode attaché au clic du boutton Solution, affiche la solution de la grille
        /// </summary>
        private void ShowSolution(object sender, EventArgs e)
        {
            if (_sk == null)
                return;
            if (_sk.Size != _gridsize)
                return;

            for (int i = 0; i < GridSize; i++)
            {
                for (int j = 0; j < GridSize; j++)
                {
                    this.sudokuGridView[i, j].Value = _sk.GetCorrectValue(i, j);
                    this.sudokuGridView.Rows[j].Cells[i].Style.BackColor = Color.LightSteelBlue;
                    this.sudokuGridView.Rows[j].Cells[i].ReadOnly = true;
                }
            }
        }

        /// <summary>
        /// Méthode quise déclenche lorsqu'une valeur de la grille est modifiée, permet de "liée" 
        /// la valeur de la grille avec celle du sudoku
        /// si la valeur mise dans la grille n'est pas compris netre 1 et size, elle est éffacés
        /// </summary>
        private void CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView grid = (DataGridView)sender;

            if (_sk == null)
                return;
            if (_sk.Size != _gridsize)
                return;

            if (grid[e.ColumnIndex, e.RowIndex].Value.ToString() == "")
                return;

            string value = grid[e.ColumnIndex, e.RowIndex].Value.ToString();
            int number = 0;

            try
            {
                number = int.Parse(value);
                if (number > 0 && number <= _gridsize)
                {
                    if (!_sk.IsLocked(e.ColumnIndex, e.RowIndex))
                        _sk.SetValue(number, e.ColumnIndex, e.RowIndex);
                }
                else
                {
                    grid[e.ColumnIndex, e.RowIndex].Value = "";
                }
            }
            catch (Exception)
            {
                grid[e.ColumnIndex, e.RowIndex].Value = "";
            }  
        }
    }
}

