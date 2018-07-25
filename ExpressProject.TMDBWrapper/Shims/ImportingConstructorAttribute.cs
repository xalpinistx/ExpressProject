using System;

namespace ExpressProject.TMDBWrapper.Shims
{
    [AttributeUsage(AttributeTargets.Constructor)]
    internal sealed class ImportingConstructorAttribute : Attribute
    { }
}
