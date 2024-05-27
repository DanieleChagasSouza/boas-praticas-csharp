using Alura.Adopet.Console.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Adopet.Console.Util;

public static class PetAPartiDoCSV
{
    public static Pet ConverteDoTexto(this string? linha)
    {
        //if (linha is null) throw new ArgumentNullException("Texto não pode ser nulo!");

        string[]? propriedades = linha?.Split(';') ?? throw new ArgumentNullException("Texto não pode ser nulo!");

        if (string.IsNullOrEmpty(linha)) throw new ArgumentException("Texto não pode ser vazio!");

        if (propriedades.Length != 3) throw new ArgumentException("Texto Invalido!");

        bool sucesso = Guid.TryParse(propriedades[0], out var petId);
        if (!sucesso) throw new ArgumentException("Guid invalido!");

        sucesso = int.TryParse(propriedades[2], out int tipoPet);
        if (!sucesso) throw new ArgumentException("Tipo de pet invlido!");

        //if (tipoPet != 0 || tipoPet != 1) throw new ArgumentException("Tipo de pet invalido!");
        int[] enums = Array.ConvertAll(Enum.GetValues<TipoPet>(), value => (int)value);
        if (!enums.Contains(tipoPet)) throw new ArgumentException("Tipo do pet inválido!");

        return new Pet(petId,
        propriedades[1],
       tipoPet == 0 ? TipoPet.Gato : TipoPet.Cachorro
        );
    }
}
