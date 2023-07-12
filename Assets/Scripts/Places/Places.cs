using System;

namespace Manager.Places
{
    [Flags]
    public enum Places
    {
        none = 0,
        Fazenda = 1,
        Residências = 1 << 1,
        Floresta = 1 << 2,
        Industrial = 1 << 3,
        Comercial = 1 << 4,
        Acadêmico = 1 << 5,
        Prefeitura = 1 << 6,
    }
}
