﻿namespace Movies.Application.Helpers
{
    public class BusinessException : Exception
    {
        public BusinessException(int statusCode, object? value = null) =>
        (StatusCode, Value) = (statusCode, value);

        public int StatusCode { get; }

        public object? Value { get; }
    }
}
