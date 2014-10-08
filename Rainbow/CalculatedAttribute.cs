using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainbow.Web
{
    /// <summary>
    /// Skip the BusinessBase.HasConcurrency method. This is useful if you need a property serialized but want to skip it for concurrency validation. 
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, Inherited = true)]
    public class CalculatedAttribute : Attribute
    {
    }
}
