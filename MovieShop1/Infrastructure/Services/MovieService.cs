﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Models.Response;
using ApplicationCore.Models.Request;

namespace Infrastructure.Services
{
    public class MovieService
    {
        public List<MovieCardResponseModel> Get30HighestGrossing()
        {
            var movies = new List<MovieCardResponseModel>
            {
                new MovieCardResponseModel{Id = 1, Title = "Avengers: Infinity War"},
                new MovieCardResponseModel {Id = 2, Title = "Avatar"},
                new MovieCardResponseModel {Id = 3, Title = "Star Wars: The Force Awakens"},
                new MovieCardResponseModel {Id = 4, Title = "Titanic"},
                new MovieCardResponseModel {Id = 5, Title = "Inception"},
                new MovieCardResponseModel {Id = 6, Title = "Avengers: Age of Ultron"},
                new MovieCardResponseModel {Id = 7, Title = "Interstellar"},
                new MovieCardResponseModel {Id = 8, Title = "Fight Club"}

            };


            return movies;
        }

        public void CreateMovie(MovieCreateRequestModel model)
        {
            // take model and convert it to Movie Entity and send it to repository
            // if repository saves successfully return true/id:2
        }
    }
}
