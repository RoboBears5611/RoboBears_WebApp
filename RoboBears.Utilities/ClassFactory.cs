﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DontPanic.Helpers;

namespace RoboBears.Utilities
{
    public static class ClassFactory
    {
        private static readonly ProxyFactory Factory = new ProxyFactory();

        public static T CreateClass<T>()
            where T : class
        {
            return Factory.Proxy<T>();
        }

        // ReSharper disable once InconsistentNaming
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Justification = "Can't infer types here")]
        public static void OverrideProxy<I, T>(T impl)
            where I : class
            where T : I
        {
            Factory.AddProxyOverride<I>(impl);
        }
    }
}
