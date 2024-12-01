﻿using HotChocolate;
using System.ComponentModel.DataAnnotations;

namespace HireServices.Domain.Inputs
{
    public class AddressInput
    {
        [GraphQLNonNullType]
        public string Street { get; set; }

        [GraphQLNonNullType]
        public string City { get; set; }

        [GraphQLNonNullType]
        [Range(1, 6)]
        public string ZipCode { get; set; }

        [GraphQLNonNullType]
        public string State { get; set; }

        [GraphQLNonNullType]
        public string Country { get; set; }
    }
}
