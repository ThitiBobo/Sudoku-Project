using System;
using System.Collections.Generic;

namespace Sudoku_WinForm
{   
    /// <summary>
    ///  
    /// </summary>
    public class SudokuBuilder
    {
        #region Static Members
        /// <summary>
        /// représente la proportion de case à enlever pour le niveau easy
        /// </summary>
        public const double easy = 3.0 / 8.0;
        /// <summary>
        /// représente la proportion de case à enlever pour le niveau normal
        /// </summary>
        public const double normal = 4.0 / 8.0;
        /// <summary>
        /// représente la proportion de case à enlever pour le niveau expert
        /// </summary>
        public const double expert = 5.0 / 8.0;
        /// <summary>
        /// représente la proportion de case à enlever pour le niveau hard
        /// </summary>
        public const double hard = 6.0 / 8.0;
        /// <summary>
        /// instance de la classe Random
        /// </summary>
        public static Random rdom = new Random();
        #endregion

        #region Members
        /// <summary>
        /// n permet de calculer la taille de la grille de la façon suivante:
        /// size = n * n
        /// </summary>
        private int _n;
        /// <summary>
        /// représente la difficulté choisie de la grille
        /// </summary>
        private double _difficulty;
        /// <summary>
        /// représente la grille de sudoku 
        /// </summary>
        private int[,] _grid;
        /// <summary>
        /// représente la solution de la grille de sudoku
        /// </summary>
        private int[,] _solu;
        /// <summary>
        /// tableau représentant les indices des lignes de la grille de sudoku
        /// </summary>
        private int[] _rowIndex;
        /// <summary>
        /// tableau représentant les indices des colonnes de la grille de sudoku
        /// </summary>
        private int[] _colIndex;
        #endregion
        
        #region Constructors
        /// <summary>
        /// Initialise une instance de la classe SudokuBuilder avec une difficulté et une taille
        /// </summary>
        /// <param name="n">permet de définir la taille du sudoku</param>
        /// <param name="difficulty">la difficulté du sudoku</param>
        public SudokuBuilder(int n, double difficulty)
        {
            this._n = n;
            this._rowIndex = GenerateTab();
            this._colIndex = GenerateTab();
            this._difficulty = difficulty;
        }

        /// <summary>
        /// Initialise une instance de la classe SudokuBuilder avec une taille,
        /// le difficulté sera mise à easy par defaut
        /// </summary>
        /// <param name="n">permet de définir la taille du sudoku</param>
        public SudokuBuilder(int n) : this(n, easy)
        { }

        /// <summary>
        /// Initialise une instance de la classe SudokuBuilder, 
        /// le difficulté sera mise à easy par defaut et la taille à (9 x 9)
        /// </summary>
        public SudokuBuilder() : this(3, easy)
        { }
        #endregion

        #region Private Methods
        /// <summary>
        /// Permet d'obtenir un tableau de int de la taille du sudoku
        /// avec des valeurs comprises entre 0 et "taille - 1" rangées de façon
        /// croissantes
        /// </summary>
        /// <returns>retourne un tableau de type int</returns>
        private int[] GenerateTab()
        {
            int[] tab = new int[(_n * _n)];
            for (int i = 0; i < (_n * _n); i++)
                tab[i] = i;
            return tab;
        }
        #endregion

        #region CheckValue Methods
        /// <summary>
        /// Détermine si la valeur est manquante sur la ligne spécifiée
        /// </summary>
        /// <param name="value">valeur à tester</param>
        /// <param name="line">ligne du sudoku à tester</param>
        /// <returns>retorune true si elle est manquante sur la ligne, sinon false</returns>
        private bool MissingOnLine(int value, int line)
        {
            for (int col = 0; col < (_n * _n); col++)
                if (_grid[line, col] == value)
                    return false;
            return true;

        }

        /// <summary>
        /// Détermine si la valeur est manquante sur la colonne spécifiée
        /// </summary>
        /// <param name="value">valeur à tester</param>
        /// <param name="colonne">colonne du sudoku à tester</param>
        /// <returns>retorune true si elle est manquante sur la colonne, sinon false</returns>
        private bool MissingOnColumn(int value, int col)
        {
            for (int line = 0; line < (_n * _n); line++)
                if (_grid[line, col] == value)
                    return false;
            return true;

        }

        /// <summary>
        /// Détermine si la valeur est manquante dans le block en précisant la ligne et la colonne 
        /// de la valeur à tester
        /// </summary>
        /// <param name="value">valeur à tester</param>
        /// <param name="line">ligne du sudoku à tester</param>
        /// <param name="col">colonne du sudoku à tester</param>
        /// <returns>retorune true si elle est manquante dans le block, sinon false</returns>
        private bool MissingOnBlock(int value, int line, int col)
        {
            line = line - (line % _n);
            col = col - (col % _n);

            for (int i = line; i < (line + _n); i++)
                for (int j = col; j < (col + _n); j++)
                    if (_grid[i, j] == value)
                        return false;
            return true;
        }

        /// <summary>
        /// Détermine si la valeur est manquante sur la ligne, la colonne et le block
        /// en précisant la ligne et la colonne de la valeur à tester
        /// </summary>
        /// <param name="value">valeur à tester</param>
        /// <param name="line">ligne du sudoku à tester</param>
        /// <param name="col">colonne du sudoku à tester</param>
        /// <returns>retourne true si elle est manquante sur la ligne, colonne et block, sinon false</returns>
        private bool MissingValue(int value, int line, int col)
        {
            return (MissingOnLine(value, line)
                && MissingOnColumn(value, col)
                && MissingOnBlock(value, line, col)
                );
        }
        #endregion

        #region GenerateSudoku Methods
        /// <summary>
        /// Méthode récursive permetant de remplir seulement une grille de sudoku vierge à l'aide d'un algorhitme 
        /// de backtracking.
        /// </summary>
        /// <param name="position">postion de la case à remplir, pour commencer mettre la valeur à 0</param>
        /// <returns></returns>
        private bool IsValid(int position)
        {
            if (position == (_n * _n) * (_n * _n))
                return true;

            int i = position / (_n * _n);
            int j = position % (_n * _n);

            if (_grid[i, j] != 0)
                return IsValid(position + 1);

            for (int k = 1; k <= (_n * _n); k++)
            {
                if (MissingValue(k, i, j))
                {
                    _grid[i, j] = k;
                    if (IsValid(position + 1))
                        return true;
                }
            }
            _grid[i, j] = 0;
            return false;
        }

        /// <summary>
        /// Mélange un tableau d'entier en respectant des règles de mélange adapter à des sudoku
        /// Cette méthode permet de mélanger les tableau d'index de ligne ou de colonne du sudoku
        /// </summary>
        /// <param name="tab">tableau à mélanger</param>
        private void MixTab(int[] tab)
        {
            // la méthode de mélange va commancer par inntervertir les gros groupe entre eux
            // puis va mélanger les index au sein des groupes
            int var;
            int index1;
            int index2;
            
            // mélange des gros groupe entre eux;
            for (int i = 0; i < rdom.Next(50, 100); i++)
            {
                index1 = rdom.Next(_n);
                index2 = rdom.Next(_n);
                for (int j = 0; j < _n; j++)
                {
                    var = tab[index1 * _n + j];
                    tab[index1 * _n + j] = tab[index2 * _n + j];
                    tab[index2 * _n + j] = var;
                }

            }

            // mélange les n petits groupe entre eux;
            for (int i = 0; i < _n; i++)
            {
                // mélange les index entre eux au sein du même groupe
                for (int j = 0; j < rdom.Next(50, 100); j++)
                {
                    index1 = rdom.Next(_n);
                    index2 = rdom.Next(_n);
                    var = tab[index1 + i * _n];
                    tab[index1 + i * _n] = tab[index2 + i * _n];
                    tab[index2 + i * _n] = var;
                }
            }

        }

        /// <summary>
        /// Enlève un nombre de valeur dans la grille en fonction de la difficulté
        /// le nombre de valeur enlevé = n * coeff de difficulté
        /// </summary>
        /// <param name="difficulty">la difficulté du sudoku</param>
        public void RemoveValue(double difficulty)
        {
            // crée une collection d'index pour chaque case de la grille
            IList<Int32> cells = new List<Int32>();
            for (int i = 0; i < (_n * _n) * (_n * _n); i++)
                cells.Add(i);

            // va piocher au hasard un index dans la collection et va retirer la valeur de la grille
            // à l'index pioché, puis va retirer l'index de la collection.
            int nbCellToDelete = (int)(((_n * _n) * (_n * _n)) * difficulty);
            for (int i = 0; i < nbCellToDelete; i++)
            {
                int randomNumber = rdom.Next(0, cells.Count);
                int indexCell = cells[randomNumber];
                cells.RemoveAt(randomNumber);
                _grid[indexCell / (_n * _n), indexCell % (_n * _n)] = 0;
            }
        }

        /// <summary>
        /// Génére la grille de sudoku et la solution et mélange la grille
        /// </summary>
        private void GenerateGrid()
        {
            _grid = new int[(_n * _n), (_n * _n)];
            // remplie la grille vide, ce qui donne toujours la même grille
            if (!IsValid(0))
                throw new Exception("une erreur c'est produit lors de la génération du sudoku");
            // garde la soltion
            _solu = (int[,])_grid.Clone();
            // enlève des valeurs de la grille
            RemoveValue(_difficulty);

            // mélange seulement les tableaux d'index des colonnes et lignes de la grille au lieux de la grille elle même
            // ce qui permet à partir de la grille non mélangée et tableau d'index de retrouver les valeurs
            // vraiGrille[i,j] = grille[ indexLigne[i], indexColonne[j] ]
            MixTab(_rowIndex);
            MixTab(_colIndex);

        }
        #endregion

        /// <summary>
        /// Retourne l'instance de Sudoku créer, avec la grille mélangée et "vidée"
        /// </summary>
        /// <returns>retourne une instance de Sudoku</returns>
        public Sudoku GetSudoku()
        {
            // génére et mélange la grille
            GenerateGrid();
            // création de deux tableau de Case
            Case[,] grid = new Case[(_n * _n), (_n * _n)];
            Case[,] solu = new Case[(_n * _n), (_n * _n)];

            // initialise les deux tableaux de Case de telle sorte que les vrais valeurs 
            // soit remisent au bon index. 
            // tableauCase[i,j] = grille[ indexLigne[i], indexColonne[j] ]
            for (int i = 0; i < (_n * _n); i++)
            {
                for (int j = 0; j < (_n * _n); j++)
                {
                    if (_grid[_rowIndex[i], _colIndex[j]] == 0)
                        grid[i, j] = new Case((uint)_grid[_rowIndex[i], _colIndex[j]]);
                    else
                        grid[i, j] = new Case((uint)_grid[_rowIndex[i], _colIndex[j]],true);
                }
            }

            for (int i = 0; i < (_n * _n); i++)
            {
                for (int j = 0; j < (_n * _n); j++)
                {
                    solu[i, j] = new Case((uint)_solu[_rowIndex[i], _colIndex[j]], true);   
                }
            }
            // retourne une nouvlle instance de sudoku avec la grille et sa solution
            return new Sudoku(grid, solu, (uint)_n);
        }




    }
}