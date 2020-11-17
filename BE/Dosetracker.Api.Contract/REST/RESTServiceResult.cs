using System;
using System.Collections.Generic;

namespace Cloud.HL7.Api.Contract
{
    public class RESTServiceResult
    {
        public static RESTServiceResult<T> Ok<T>(T data)
        {
            var sc = new RESTServiceResult<T>();
            sc.TypeVal = ServiceResultType.SUCCESS;
            sc.Data = data;
            return sc;
        }
        public static RESTServiceResult<Exception> Ex(Exception data)
        {
            var sc = new RESTServiceResult<Exception>();
            sc.TypeVal = ServiceResultType.FAIL;
            sc.Exception = data;
            sc.Message = data.Message;
            return sc;
        }
        public static RESTServiceResult<T> OkData<T>(T data)
        {
            var sc = new RESTServiceResult<T>();
            sc.TypeVal = ServiceResultType.SUCCESS_WITH_DATA;
            sc.Data = data;
            return sc;
        }
        public static RESTServiceResult<T> Fail<T>(T data)
        {
            var sc = new RESTServiceResult<T>();
            sc.TypeVal = ServiceResultType.FAIL;
            sc.Data = data;
            return sc;
        }
    }
    public class RESTServiceResult<T>
    {
        public RESTServiceResult()
        {
            ExtraData = new Dictionary<string, object>();

        }
        public RESTServiceResult(T data, string message, ServiceResultType type) : this()
        {
            TypeVal = type;
            Message = message;
            Data = data;
        }
        public string Type => TypeVal.ToString();
        public ServiceResultType TypeVal { get; set; }

        public string Message { get; set; }
        public Exception Exception { get; set; }

        public T Data { get; set; }

        public Dictionary<string, object> ExtraData { get; private set; }

        public bool HasError => ((int)TypeVal) < 10;



        
        
    }
    public enum ServiceResultType
    {
        FAIL = 0,
        NOT_AUTHENTICATED,
        NOT_AUTHORIZED,
        NOT_VALID,

        SUCCESS = 10,
        SUCCESS_WITH_DATA,

    }
}
