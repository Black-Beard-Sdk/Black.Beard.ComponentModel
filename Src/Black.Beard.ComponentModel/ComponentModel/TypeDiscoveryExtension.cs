using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Bb.ComponentModel
{

    public static class TypeDiscoveryExtension
    {

        public static IEnumerable<Type> InFolder(this IEnumerable<Type> type, TypeDiscovery discovery)
        {

            var folders = new HashSet<string>(discovery.Paths);

            foreach (var item in type)
                if (item.InFolder(folders))
                    yield return item;

        }


        public static bool InFolder(this Type type, HashSet<string> folders)
        {
            var dir = new FileInfo(type.Assembly.Location).Directory;
            return folders.Contains(dir.FullName);
        }

    }

}



