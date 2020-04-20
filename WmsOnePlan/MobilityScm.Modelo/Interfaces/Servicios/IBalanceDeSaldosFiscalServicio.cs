﻿using System.Collections.Generic;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Entidades;

namespace MobilityScm.Modelo.Interfaces.Servicios
{
    public interface  IBalanceDeSaldosFiscalServicio
    {
        IList<BalanceDeSaldosFiscal> ObtenerAcuerdosComerciales(BalanceDeSaldosFiscalArgumento acuerdoComercialArgumento);
    }
}
