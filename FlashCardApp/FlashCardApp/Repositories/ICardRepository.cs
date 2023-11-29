using FlashCardApp.Models;

namespace FlashCardApp.Repositories
{
    public interface ICardRepository
    {
        Task AddNewCardAsync(Card card);
        Task<List<Card>> GetAllCardsAsync();
        Task<Card?> GetByIdAsync(int id);
        Task SaveChangesAsync();
        bool IsCardWithThisName(string hungary, string german);
    }
}