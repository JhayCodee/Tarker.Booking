using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarker.Booking.Application.DataBasse;

namespace Tarker.Booking.Application.DataBase.User.Queries.GetUserById
{
    public class GetUserByIdQuery : IGetUserByIdQuery
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public GetUserByIdQuery(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<GetUserByIdModel> Execute (int id)
        {
            var entity = await _dataBaseService.User.FirstOrDefaultAsync(x => x.UserId == id);
            return _mapper.Map<GetUserByIdModel>(entity); // devuelve null si no mapea
        }
    }
}
