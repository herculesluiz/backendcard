using System;
using System.Collections.Generic;
using System.Linq;
using BackEndCard.Models;

namespace BackEndCard.Repositories
{
   public interface ICardRepository
   {
       List<Card> Read(string email);
       List<Card> Create(Card card);
   }

    public class CardRepository : ICardRepository
    {
        private readonly DataContext _context;

        public CardRepository(DataContext data)
        {
            _context = data;
        }

        public List<Card> Create(Card card)
        {   
            string number;
            string[] array = new string[16];
            Random randNum = new Random();
            for (int i = 0; i < 16; i++)
                array[i] = randNum.Next(0,9).ToString();
                number = string.Join("",array);
    
            card.Number = number; 
            card.Id =Guid.NewGuid();
            _context.Cards.Add(card);
            _context.SaveChanges();
            return _context.Set<Card>().Where(c => c.Id == card.Id).ToList();
            
        }

        public List<Card> Read(string email)
        {   

             return _context.Set<Card>().Where(c => c.Email == email).ToList();
            
        }    

    }
}