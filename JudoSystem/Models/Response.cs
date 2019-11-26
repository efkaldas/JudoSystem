using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JudoSystem.Models
{
    public class Response
    {
        public readonly static string SUCCESS = "success";
        public readonly static string ERROR = "error";

        public Object response { get; set; }
        public string status { get; set; }
        public int errorCode { get; set; }
        public string message { get; set; }

        public void success(Object obj)
        {
            response = obj;
            status = SUCCESS;
            message = SUCCESS;
        }

        public void success()
        {
            status = SUCCESS;
            message = SUCCESS;
        }

        public void success(List<Object> listObj)
        {
            response = listObj;
            status = SUCCESS;
            message = SUCCESS;
        }

        public void error(string msg, int errCode)
        {
            response = null;
            errorCode = errCode;
            message = msg;
            status = ERROR;
        }
        public void error(string msg)
        {
            response = null;
            errorCode = 0;
            message = msg;
            status = ERROR;
        }
        public void error()
        {
            response = null;
            errorCode = 0;
            message = null;
            status = ERROR;
        }
    }
}