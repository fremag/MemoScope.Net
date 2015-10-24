using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace WinFwk
{
    public static class WinFwkHelper
    {
        public static List<Type> GetGenericInterfaceArguments(object obj, Type genericInterface)
        {
            List<Type> types = new List<Type>();

            if (obj == null)
            {
                return types;
            }

            Type type = obj.GetType();
            var interfaces = type.GetInterfaces();
            foreach (var interfType in interfaces)
            {
                if (interfType.IsGenericType &&
                    interfType.GetGenericTypeDefinition().IsAssignableFrom(genericInterface))
                {
                    var genArgs = interfType.GetGenericArguments();
                    foreach (var genArg in genArgs)
                    {
                        types.Add(genArg);
                    }
                }
            }
            return types;
        }

        private static readonly List<Assembly> assemblies = new List<Assembly>();
        public static List<Type> GetDerivedTypes(Type baseType)
        {
            var types = new List<Type>();
            if (assemblies.Count == 0)
            {
                var execAssembly = Assembly.GetEntryAssembly();
                assemblies.Add(execAssembly);
                string path = Path.GetDirectoryName(execAssembly.Location);
                foreach (string dll in Directory.GetFiles(path, "*.dll"))
                    assemblies.Add(Assembly.LoadFile(dll));
            }
            
            foreach (var assembly in assemblies)
            {
                var allTypes = assembly.GetTypes();
                foreach (var type in allTypes)
                {
                    bool b1 = type.IsAssignableFrom(baseType);
                    if (b1 && type != baseType)
                    {
                        types.Add(type);
                    }

                    bool b2 = baseType.IsGenericTypeDefinition && type.BaseType != null && type.BaseType.IsGenericType ;
                    if (b2)
                    {
                        Type genTypeDef = type.BaseType.GetGenericTypeDefinition();
                        if (genTypeDef == baseType)
                        {
                            types.Add(type);
                        }
                    }
                }
            }
            return types;
        }
    }
}
