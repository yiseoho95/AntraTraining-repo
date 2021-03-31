﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Models.Response;
using ApplicationCore.Models.Request;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IMovieService
    {
        List<MovieCardResponseModel> Get30HighestGrossing();
        void CreateMovie(MovieCreateRequestModel model);

    }
}
