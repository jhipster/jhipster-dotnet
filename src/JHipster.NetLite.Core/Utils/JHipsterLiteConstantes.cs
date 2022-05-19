using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace JHipster.NetLite.Web.Utils;

public static class JHipsterLiteConstantes
{
    public static readonly string JHipsterLiteAssembly = typeof(JHipsterLiteConstantes).Assembly.GetName().Name;

    public static readonly Assembly WebAssembly = typeof(JHipsterLiteConstantes).Assembly;
}
