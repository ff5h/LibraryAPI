﻿using Library.Models.DTO.Models.Clients;
using MediatR;

namespace LibraryAPI.Queries.Clients
{
    public class GetClientsQuery : IRequest<IEnumerable<ClientDTO>> //То что, я запрашиваю
    {

    }
}
