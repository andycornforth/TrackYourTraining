using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingApi.Wrapper
{
    public interface IHttpMessenger
    {
        string Get(string relativeUrl);
        T GetObjectFromString<T>(string jsonString);
        T Post<T>(string relativeUrl, string message);
        T Post<T, TIn>(string relativeUrl, TIn postData);
    }
}
