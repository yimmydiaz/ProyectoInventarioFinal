using Inventario.GUI.Models.Parametros;
using LogicaNegocio.DTO.Parametros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventario.GUI.Mapeadores.Parametros
{
    public class MapeadorMarcaGUI : MapeadorBaseGUI<MarcaDTO, ModeloMarca>
    {
        public override ModeloMarca MapearTipo1Tipo2(MarcaDTO entrada)
    {
        return new ModeloMarca()
        {
            Id = entrada.Id,
            Nombre = entrada.Nombre
        };
    }

    public override IEnumerable<ModeloMarca> MapearTipo1Tipo2(IEnumerable<MarcaDTO> entrada)
    {
        foreach (var item in entrada)
        {
            yield return MapearTipo1Tipo2(item);
        }
    }

    public override MarcaDTO MapearTipo2Tipo1(ModeloMarca entrada)
    {
        return new MarcaDTO()
        {
            Id = entrada.Id,
            Nombre = entrada.Nombre
        };
    }

    public override IEnumerable<MarcaDTO> MapearTipo2Tipo1(IEnumerable<ModeloMarca> entrada)
    {
        foreach (var item in entrada)
        {
            yield return MapearTipo2Tipo1(item);
        }
    }
}
}