using System.Collections.Generic;
using WebApi.Models;

namespace WebApi.Repositories
{
    public class LibraryCardRepository : ILibraryCardRepository
    {
        /// <summary>
        ///     2.1.3 - Статичный список, отвечающий за хранение сущности LibraryCard
        /// </summary>
        private static List<LibraryCard> LibraryCards { get; } = new();

        private static int LastId { get; set; } = 0;

        public void Add(LibraryCard card)
        {
            LibraryCards.Add(card);
        }
    }
}
