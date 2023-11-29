using FlashCardApp.Data;
using FlashCardApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FlashCardApp.Repositories
{
    public class CardRepository : ICardRepository
    {
        private readonly ApplicationDbContext _context;

        public CardRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddNewCardAsync(Card card)
        {
            _context.Cards.Add(card);
            await _context.SaveChangesAsync();
        }

        public Task<List<Card>> GetAllCardsAsync()
        {
            return _context.Cards.ToListAsync();
        }

        public Task<Card?> GetByIdAsync(int id)
        {
            return _context.Cards.FirstOrDefaultAsync(x => x.Id == id);
        }

        public bool IsCardWithThisName(string hungary, string german)
        {
            return _context.Cards.Any(x => x.German == german) ||
                _context.Cards.Any(x => x.Hungary == hungary);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
