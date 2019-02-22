﻿namespace ManagementAPI.Service.Common
{
    using System;
    using DataTransferObjects;
    using Swashbuckle.AspNetCore.Filters;

    public class RegisterPlayerResponseExample : IExamplesProvider
    {
        #region Methods

        public Object GetExamples()
        {
            return new RegisterPlayerResponse
                   {
                       PlayerId = Guid.Parse("BFC2FC37-86B3-4EAD-9CFA-6AF60803440F")
                   };
        }

        #endregion
    }
}