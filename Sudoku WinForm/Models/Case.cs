
namespace Sudoku_WinForm
{
    /// <summary>
    /// La classe Case permet de représenter des instances qui modélisent des cases d'une grille de sudoku
    /// avec une valeur et la possibilitée d'être modifiée.
    /// </summary>
    public class Case
    {
        #region Attributs
        /// <summary>
        /// Valeur de la case comprise entre 1 - "longeur de la grille" ou 0 si la case est vide
        /// </summary>
        private uint _value;
        /// <summary>
        /// Attributs qui spécifie si la case peux être modifiée 
        /// </summary>
        private bool _locked;
        #endregion

        #region GetSet
        /// <summary>
        /// Obtient la valeur contenue dans la case ou la définie (si elle est modifiable)
        /// </summary>
        /// <exception cref="LockedValueException">renvoie une exception si la case n'est pas modifiable</exception>
        public uint Value {
            get { return _value; }
            set
            {
                if (_locked)
                    throw new LockedValueException("value is locked");
                _value = value;
            }
        }
        /// <summary>
        /// Obtient ou définie l'attribut locked de la case
        /// </summary>
        public bool Locked {
            get { return _locked; }
            private set { _locked = value; }
        }
        #endregion

        /// <summary>
        /// Initialise une nouvelle instance de la classe Case avec une valeur 
        /// et un attribut boolean pour spécifer si la valeur est modifiable
        /// </summary>
        /// <param name="value">valeur de la case</param>
        /// <param name="locked">true si la case est bloquée, sinon false</param>
        public Case(uint value, bool locked)
        {
            _value = value;
            _locked = locked;
        }

        /// <summary>
        /// Initialise une nouvelle instance de la classe Case avec une valeur 
        /// et la met modifiable par defaut.
        /// </summary>
        /// <param name="value">valeur de la case</param>
        public Case(uint value) : this(value, false)
        { }

        /// <summary>
        /// Initialise une nouvelle instance de la classe Case sans valeur et modifiable
        /// </summary>
        public Case() : this(0, false)
        { }

        /// <summary>
        /// Permet de savoir si la case est bloquée (non modifiable)
        /// </summary>
        /// <returns>renvoie true si elle est bloquée, sinon false</returns>
        public bool IsLocked()
        {
            return _locked;
        }

    }
}
