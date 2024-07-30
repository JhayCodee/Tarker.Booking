using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Tarker.Booking.Application.DataBasse;

namespace Tarker.Booking.Application.DataBase.Customer.Queries.GetCustomerByDocumentNumber
{
    public class GetCustomerByDocumentNumberQuery : IGetCustomerByDocumentNumberQuery
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public GetCustomerByDocumentNumberQuery(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<GetCustomerByDocumentNumberModel> Execute(string doumentNumber)
        {
            var entity = _dataBaseService.Customer.FirstOrDefaultAsync(x => x.DocumentNumber == doumentNumber);
            return _mapper.Map<GetCustomerByDocumentNumberModel>(entity);   
        }
    }
}
