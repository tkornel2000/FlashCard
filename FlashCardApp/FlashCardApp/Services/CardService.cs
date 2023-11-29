using AutoMapper;
using FlashCardApp.Dtos;
using FlashCardApp.Models;
using FlashCardApp.Repositories;

namespace FlashCardApp.Services
{
    public class CardService : ICardService
    {
        private readonly IMapper _mapper;
        private readonly ICardRepository _cardRepository;

        public CardService(IMapper mapper, ICardRepository cardRepository)
        {
            _mapper = mapper;
            _cardRepository = cardRepository;
        }
        public async Task AddCardAsync(CardDto cardDto)
        {
            var card = _mapper.Map<Card>(cardDto);
            await _cardRepository.AddNewCardAsync(card);
        }

        public async Task<List<Card>> GetAllCardsRandomAsync()
        {
            return (await _cardRepository.GetAllCardsAsync())
                .OrderBy(x => Random.Shared.Next()).ToList();
        }

        public async Task<bool> ModifyCardResultAsync(int id, bool isCorrect)
        {
            var currentCard = await _cardRepository.GetByIdAsync(id);
            if (currentCard is null)
            {
                return false;
            }

            if (isCorrect) 
            {
                currentCard.Correct += 1;
            }
            else
            {
                currentCard.Incorrect += 1;
            }
            await _cardRepository.SaveChangesAsync();
            return true;
        }

        public bool CanIAdd(CardDto cardDto)
        {
            return !_cardRepository.IsCardWithThisName(cardDto.Hungary, cardDto.German);
        }
    }
}
