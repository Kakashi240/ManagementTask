﻿using ManagementTask.Domain.ModelsDTO.TokenDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ManagementTask.Business.TokenService
{
    public interface ITokenService
    {
        Task<TokenResponse> GetToken(Credentials credentials);
    }
}
