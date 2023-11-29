using FlashCardApp.Dtos;
using FlashCardApp.Models;

namespace FlashCardApp.Services
{
    public interface ICardService
    {
        Task AddCardAsync(CardDto cardDto);
        Task<List<Card>> GetAllCardsRandomAsync();
        Task<bool> ModifyCardResultAsync(int id, bool isCorrect);
        bool CanIAdd(CardDto cardDto);
    }
}