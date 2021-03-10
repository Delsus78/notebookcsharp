namespace Logic
{
    public interface IStockage
    {
        /// <summary>
        /// Creer une sauvegarde de notebook
        /// </summary>
        /// <returns>le notebook cree</returns>
        Notebook Create();

        /// <summary>
        /// actualise la sauvegarde du notebook
        /// </summary>
        void Update(Notebook n);

        /// <summary>
        /// charge la sauvegarde du notebook
        /// </summary>
        /// <returns>la sauvegarde en question</returns>
        Notebook Load();
    }
}
