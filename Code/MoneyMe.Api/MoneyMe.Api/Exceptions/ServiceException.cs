﻿namespace MoneyMe.Api.Exceptions
{
    public class ServiceException : Exception
    {
        public ServiceException(string? message) : base(message) { }
    }
}
