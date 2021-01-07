// Decompiled with JetBrains decompiler
// Type: CBNIntegration_NEW.Controllers.ValuesController
// Assembly: CBNIntegration_NEW, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6C724E3B-F2BD-4CEF-A0DE-A413F9617FBB
// Assembly location: C:\Users\Ayodele.Bamgboye\Downloads\CBN INTEGRATION\CBN INTEGRATION\CBNServiceIntegration\bin\CBNIntegration_NEW.dll

using System.Collections.Generic;
using System.Web.Http;

namespace CBNIntegration_NEW.Controllers
{
  public class ValuesController : ApiController
  {
    public IEnumerable<string> Get() => (IEnumerable<string>) new string[2]
    {
      "value1",
      "value2"
    };

    public string Get(int id) => "value";

    public void Post([FromBody] string value)
    {
    }

    public void Put(int id, [FromBody] string value)
    {
    }

    public void Delete(int id)
    {
    }
  }
}
