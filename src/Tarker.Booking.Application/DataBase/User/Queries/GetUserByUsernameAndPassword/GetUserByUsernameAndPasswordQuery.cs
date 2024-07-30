using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarker.Booking.Application.DataBase.User.Queries.GetUserById;
using Tarker.Booking.Application.DataBasse;

namespace Tarker.Booking.Application.DataBase.User.Queries.GetUserByUsernameAndPassword
{
    public class GetUserByUsernameAndPasswordQuery : IGetUserByUsernameAndPasswordQuery
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public GetUserByUsernameAndPasswordQuery(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<GetUserByUsernameAndPasswordModel> Execute(string username, string password)
        {
            var entity = await _dataBaseService.User.FirstOrDefaultAsync(x => x.UserName == username && x.Password == password);
            return _mapper.Map<GetUserByUsernameAndPasswordModel>(entity); // devuelve null si no mapea
        }
    }
}
