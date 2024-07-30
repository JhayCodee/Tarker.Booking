using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Tarker.Booking.Application.DataBasse;

namespace Tarker.Booking.Application.DataBase.Customer.Queries.GetAllCustomer
{
    public class GetAllCustomerQuery : IGetAllCustomerQuery
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public GetAllCustomerQuery(IDataBaseService dataBaseService, IMapper mapper)
        {
            _mapper = mapper;
            _dataBaseService = dataBaseService;
        }

        public async Task<List<GetAllCustomerModel>> Execute()
        {
            var listEntity = await _dataBaseService.Customer.ToListAsync();
            return _mapper.Map<List<GetAllCustomerModel>>(listEntity);
        }
    }
}
