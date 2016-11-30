using System;

namespace App3
{
    class MasterPageItem
    {
        public MasterPageItem(string name, MasterPageItemKind kind, Type type)
        {
            Name = name;
            Kind = kind;
            Type = type;
        }

        public string Name { get; }

        public MasterPageItemKind Kind { get; }

        public Type Type { get; }
    }
}
