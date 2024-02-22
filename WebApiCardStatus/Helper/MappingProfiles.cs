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
            CreateMap<Users, UsersDto>();
            CreateMap<TransactionType, TransactionTypeDto>();
            CreateMap<Transactions, TransactionsDto>();
            CreateMap<TransactionsDto, Transactions>();
        }
    }
}
