using AutoMapper;
using WebApiCardStatus.Dto;
using WebApiCardStatus.Models;

namespace WebApiCardStatus.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<CreditCard, CreditCardDto>();
            CreateMap<CreditCardDto, CreditCard>();
            CreateMap<Users, UsersDto>();
            CreateMap<UsersDto, Users>();
            CreateMap<TransactionType, TransactionTypeDto>();
            CreateMap<TransactionTypeDto, TransactionType>();
            CreateMap<Transactions, TransactionsDto>();
            CreateMap<TransactionsDto, Transactions>();
        }
    }
}
