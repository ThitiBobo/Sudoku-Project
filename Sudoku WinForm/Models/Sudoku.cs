using System;
using System.Text;

namespace Sudoku_WinForm
{
    /// <summary>
    /// La classe Sudoku représente des instances de grille de sudoku, 
    /// composée de deux tableaux de Case de taille [size x size], 
    /// un tableau pour modéliser la grille partiellement remplie qui sera à compléter
    /// et un tableau pour la grille résolue.
    /// </summary>
    /// 
    /// <remarks>
    /// la taille de la grille est spécifiée par un paramètre "n" de tel sorte que:
    /// - la taille = [ n*n , n*n ]
    /// - le nombre de cases au total = n^4
    /// exemple: n = 3 donne une grille 9x9 (classic)
    ///          n = 4 donne une grille de 16x16
    /// </remarks>
    public class Sudoku
    {
        #region Members
        /// <summary>
        /// n permet de calculer la taille de la grille de la façons suivante:
        /// size = n * n
        /// </summary>
        private uint _n;
        /// <summary>
        /// représente la taille de la grille
        /// </summary>
        private uint _size;
        /// <summary>
        /// représente la grille partiellement remplie
        /// </summary>
        private Case[,] _sudokuGrid;
        /// <summary>
        /// représente la solution de la grille partiellement remplie
        /// </summary>
        private Case[,] _sudokuSol;
        #endregion

        #region GetSet
        /// <summary>
        /// Obtient la taille de la grille
        /// </summary>
        public int Size
        {
            get { return (int)_size; }
        }
        #endregion

        /// <summary>
        /// Initialise une nouvelle instance de la classe Sudoku
        /// </summary>
        /// <param name="sudokuGrid">tableau de Case représentant la grille partiellement remplie</param>
        /// <param name="sudokuSol">tableau de Case représentant la solution de la grille</param>
        /// <param name="n">le type de grille, n = 3 donne une grille de (9 x 9)</param>
        public Sudoku(Case[,] sudokuGrid, Case[,] sudokuSol, uint n)
        {
            _sudokuGrid = sudokuGrid;
            _sudokuSol = sudokuSol;
            _n = n;
            _size = (n * n);
        }

        /// <summary>
        /// Obtient la grille de sudoku sous forme de chaine de caractères (seulement la grille partiellement remplie)
        /// </summary>
        /// <returns>retourne la grille sous forme de chaine de caractères</returns>
        public override String ToString()
        {
            StringBuilder str = new StringBuilder();
            for (int line = 0; line < _size; line++)
            {
                for (int col = 0; col < _size; col++)
                {
                    str.Append(" " + _sudokuGrid[line, col].Value);
                    if (col % _n == _n - 1)
                        str.Append("  ");

                }
                if (line % _n == _n - 1)
                    str.Append(Environment.NewLine);
                str.Append(Environment.NewLine);
            }

            return str.ToString();
        }

        /// <summary>
        /// Permet de modifier la valeur de la case aux coordonées données
        /// </summary>
        /// <param name="value">nouvelle valeur de la case</param>
        /// <param name="rows">ligne de la case</param>
        /// <param name="cols">colonne de la case</param>
        /// <exception cref="LockedValueException">retourne une exception si la case n'est pas modifiable</exception>
        public void SetValue(int value, int rows, int cols)
        {
            _sudokuGrid[rows, cols].Value = (uint)value;
        }

        /// <summary>
        /// Obtient la valeur de la case aux coordonnées données
        /// </summary>
        /// <param name="rows">ligne de la case</param>
        /// <param name="cols">colonne de la case</param>
        /// <returns>retourne la valeur de la case</returns>
        public int GetValue(int rows, int cols)
        {
            return (int)_sudokuGrid[rows, cols].Value;
        }

        /// <summary>
        /// Obtient la valeur correcte de la grille aux coordonnées données 
        /// </summary>
        /// <param name="rows">ligne de la case</param>
        /// <param name="cols">colonne de la case</param>
        /// <returns>retourne la valeur correcte de la case</returns>
        public int GetCorrectValue(int rows, int cols)
        {
            return (int)_sudokuSol[rows, cols].Value;
        }

        /// <summary>
        /// Permet de savoir si la case est bloquée (non modifiable) aux coordonnées données  
        /// </summary>
        /// <param name="rows">ligne de la case</param>
        /// <param name="cols">colonne de la case</param>
        /// <returns>retourne true si la case est bloquée, sinon false</returns>
        public bool IsLocked(int rows, int cols)
        {
            return _sudokuGrid[rows, cols].IsLocked();
        }
    }
}
