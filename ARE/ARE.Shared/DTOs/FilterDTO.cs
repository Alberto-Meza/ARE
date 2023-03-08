using System;
using ARE.Shared.Enums;

namespace ARE.Shared.DTOs
{

    /// <summary>
    /// Campo = Propiedad ha validad
    /// Valor = Valor a validar
    /// Operator= {0 = Contenga, 1 = Igual, 2 = Diferente
    /// </summary>
	public class FilterDTO
	{
        public string Campo { get; set; } = null!;

        public string Valor { get; set; } = null!;

        public OperatorType Operator { get; set; }
    }
}

