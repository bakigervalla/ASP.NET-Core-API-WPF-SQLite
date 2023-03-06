using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Solid.UI.API
{
    public interface IResponse
    {
        HttpStatusCode StatusCode { get; }

        string Content { get; }

        byte[] RawContent { get; }
    }
}
