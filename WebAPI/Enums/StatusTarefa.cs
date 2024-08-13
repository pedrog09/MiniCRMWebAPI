﻿using System.ComponentModel;

namespace WebAPI.Enums
{
    public enum StatusTarefa
    {
        [Description("A fazer")]
        AFazer = 1,
        [Description("Em Andamento")]
        EmAndamento = 2,
        [Description("Concluido")]
        Concluido = 3,
    }
}