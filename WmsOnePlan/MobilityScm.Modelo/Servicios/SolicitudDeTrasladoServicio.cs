using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Entidades;
using MobilityScm.Modelo.Interfaces.Servicios;
using MobilityScm.Modelo.Tipos;
using MobilityScm.Utilerias;
using MobilityScm.Vertical.Entidades;
using Telerik.OpenAccess.Data.Common;

namespace MobilityScm.Modelo.Servicios
{
    public class SolicitudDeTrasladoServicio : ISolicitudDeTrasladoServicio
    {
        #region Base de datos
        public IBaseDeDatosServicio BaseDeDatosServicio { get; set; }

        public SolicitudDeTrasladoServicio(IBaseDeDatosServicio baseDeDatosServicio)
        {
            BaseDeDatosServicio = baseDeDatosServicio;
        }
        #endregion

        public SolicitudDeTrasladoEncabezado ObtenerSolicitudDeTrasladoEncabezado(SolicitudDeTrasladoArgumento solicitudDeTrasladoArgumento)
        {
            DbParameter[] parameters =
            {
                new OAParameter
                {
                    ParameterName = "@TRANSFER_REQUEST_ID",
                    Value = solicitudDeTrasladoArgumento.SolicitudDeTrasladoEncabezado.TRANSFER_REQUEST_ID
                }
            };
            var encabezado = BaseDeDatosServicio.ExecuteQuery<SolicitudDeTrasladoEncabezado>(
                BaseDeDatosServicio.Esquema + ".OP_WMS_SP_GET_TRANSFER_REQUEST_HEADER", CommandType.StoredProcedure,
                false, parameters);
            return encabezado.Count == 0 ? null : encabezado[0];
        }
        public Operacion AgregarSolicitudDeTrasladoEncabezado(SolicitudDeTrasladoArgumento solicitudDeTrasladoArgumento)
        {
            DbParameter[] parameters =
            {
                new OAParameter
                {
                    ParameterName = "@REQUEST_TYPE",
                    Value = solicitudDeTrasladoArgumento.SolicitudDeTrasladoEncabezado.REQUEST_TYPE
                }, new OAParameter
                {
                    ParameterName = "@WAREHOUSE_FROM",
                    Value = solicitudDeTrasladoArgumento.SolicitudDeTrasladoEncabezado.WAREHOUSE_FROM
                }, new OAParameter
                {
                    ParameterName = "@WAREHOUSE_TO",
                    Value = solicitudDeTrasladoArgumento.SolicitudDeTrasladoEncabezado.WAREHOUSE_TO
                }, new OAParameter
                {
                    ParameterName = "@DELIVERY_DATE",
                    Value = solicitudDeTrasladoArgumento.SolicitudDeTrasladoEncabezado.DELIVERY_DATE
                }, new OAParameter
                {
                    ParameterName = "@COMMENT",
                    Value = solicitudDeTrasladoArgumento.SolicitudDeTrasladoEncabezado.COMMENT
                }, new OAParameter
                {
                    ParameterName = "@STATUS",
                    Value = solicitudDeTrasladoArgumento.SolicitudDeTrasladoEncabezado.STATUS
                }, new OAParameter
                {
                    ParameterName = "@CREATED_BY",
                    Value = solicitudDeTrasladoArgumento.SolicitudDeTrasladoEncabezado.CREATED_BY
                }, new OAParameter
                {
                    ParameterName = "@OWNER",
                    Value = solicitudDeTrasladoArgumento.SolicitudDeTrasladoEncabezado.OWNER
                }, new OAParameter
                {
                    ParameterName = "@IS_FROM_ERP",
                    Value = solicitudDeTrasladoArgumento.SolicitudDeTrasladoEncabezado.IS_FROM_ERP
                }
            };
            var operacion = BaseDeDatosServicio.ExecuteQuery<Operacion>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_ADD_TRANSFER_REQUEST_HEADER", CommandType.StoredProcedure, false, parameters)[0];
            if (operacion.Resultado != ResultadoOperacionTipo.Error) BaseDeDatosServicio.Commit();
            else BaseDeDatosServicio.Rollback();
            return operacion;
        }

        public Operacion ActualizarSolicitudDeTrasladoEncabezado(SolicitudDeTrasladoArgumento solicitudDeTrasladoArgumento)
        {
            DbParameter[] parameters =
            {
                new OAParameter
                {
                    ParameterName = "@TRANSFER_REQUEST_ID",
                    Value = solicitudDeTrasladoArgumento.SolicitudDeTrasladoEncabezado.TRANSFER_REQUEST_ID
                },new OAParameter
                {
                    ParameterName = "@REQUEST_TYPE",
                    Value = solicitudDeTrasladoArgumento.SolicitudDeTrasladoEncabezado.REQUEST_TYPE
                }, new OAParameter
                {
                    ParameterName = "@WAREHOUSE_FROM",
                    Value = solicitudDeTrasladoArgumento.SolicitudDeTrasladoEncabezado.WAREHOUSE_FROM
                }, new OAParameter
                {
                    ParameterName = "@WAREHOUSE_TO",
                    Value = solicitudDeTrasladoArgumento.SolicitudDeTrasladoEncabezado.WAREHOUSE_TO
                }, new OAParameter
                {
                    ParameterName = "@DELIVERY_DATE",
                    Value = solicitudDeTrasladoArgumento.SolicitudDeTrasladoEncabezado.DELIVERY_DATE
                }, new OAParameter
                {
                    ParameterName = "@COMMENT",
                    Value = solicitudDeTrasladoArgumento.SolicitudDeTrasladoEncabezado.COMMENT
                }, new OAParameter
                {
                    ParameterName = "@STATUS",
                    Value = solicitudDeTrasladoArgumento.SolicitudDeTrasladoEncabezado.STATUS
                }, new OAParameter
                {
                    ParameterName = "@LAST_UPDATE_BY",
                    Value = solicitudDeTrasladoArgumento.SolicitudDeTrasladoEncabezado.LAST_UPDATE_BY
                }, new OAParameter
                {
                    ParameterName = "@OWNER",
                    Value = solicitudDeTrasladoArgumento.SolicitudDeTrasladoEncabezado.OWNER
                }
            };
            var operacion = BaseDeDatosServicio.ExecuteQuery<Operacion>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_UPDATE_TRANSFER_REQUEST_HEADER", CommandType.StoredProcedure, false, parameters)[0];
            if (operacion.Resultado != ResultadoOperacionTipo.Error) BaseDeDatosServicio.Commit();
            else BaseDeDatosServicio.Rollback();
            return operacion;
        }
        public Operacion EliminarSolicitudDeTrasladoEncabezado(SolicitudDeTrasladoArgumento solicitudDeTrasladoArgumento)
        {
            DbParameter[] parameters =
            {
                new OAParameter
                {
                    ParameterName = "@TRANSFER_REQUEST_ID",
                    Value = solicitudDeTrasladoArgumento.SolicitudDeTrasladoEncabezado.TRANSFER_REQUEST_ID
                }
            };
            var operacion = BaseDeDatosServicio.ExecuteQuery<Operacion>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_DELETE_TRANSFER_REQUEST_HEADER", CommandType.StoredProcedure, false, parameters)[0];
            if (operacion.Resultado != ResultadoOperacionTipo.Error) BaseDeDatosServicio.Commit();
            else BaseDeDatosServicio.Rollback();
            return operacion;
        }
        public IList<SolicitudDeTrasladoDetalle> ObtenerSolicitudDeTrasladoDetalle(SolicitudDeTrasladoArgumento solicitudDeTrasladoArgumento)
        {
            DbParameter[] parameters =
            {
                new OAParameter
                {
                    ParameterName = "@TRANSFER_REQUEST_ID",
                    Value = solicitudDeTrasladoArgumento.SolicitudDeTrasladoEncabezado.TRANSFER_REQUEST_ID
                }
            };
            return BaseDeDatosServicio.ExecuteQuery<SolicitudDeTrasladoDetalle>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_GET_TRANSFER_REQUEST_DETAIL", CommandType.StoredProcedure, false, parameters).ToList();
        }

        public Operacion AgregarSolicitudDeTrasladoDetalle(SolicitudDeTrasladoArgumento solicitudDeTrasladoArgumento)
        {
            var operacion = AgregarDetalles(solicitudDeTrasladoArgumento);
            if (operacion.Resultado != ResultadoOperacionTipo.Error)
            {
                BaseDeDatosServicio.Commit();
                return operacion;
            }
            BaseDeDatosServicio.Rollback();
            return operacion;
        }

        private Operacion AgregarDetalles(SolicitudDeTrasladoArgumento solicitudDeTrasladoArgumento)
        {
            var operacion = new Operacion();
            foreach (var detalle in solicitudDeTrasladoArgumento.SolicitudDeTrasladoDetalles)
            {
                DbParameter[] parameters =
                {
                    new OAParameter
                    {
                        ParameterName = "@TRANSFER_REQUEST_ID",
                        Value = detalle.TRANSFER_REQUEST_ID
                    },new OAParameter
                    {
                        ParameterName = "@MATERIAL_ID",
                        Value = detalle.MATERIAL_ID
                    },new OAParameter
                    {
                        ParameterName = "@MATERIAL_NAME",
                        Value = detalle.MATERIAL_NAME
                    },new OAParameter
                    {
                        ParameterName = "@IS_MASTERPACK",
                        Value = detalle.IS_MASTERPACK
                    },new OAParameter
                    {
                        ParameterName = "@QTY",
                        Value = detalle.QTY
                    },new OAParameter
                    {
                        ParameterName = "@STATUS",
                        Value = detalle.STATUS
                    }, new OAParameter
                    {
                        ParameterName = "@STATUS_CODE",
                        Value = detalle.STATUS_CODE
                    }
                };
                operacion = BaseDeDatosServicio.ExecuteQuery<Operacion>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_ADD_TRANSFER_REQUEST_DETAIL", CommandType.StoredProcedure, false, parameters)[0];
                if (operacion.Resultado != ResultadoOperacionTipo.Error) continue;
                operacion.Mensaje = $"Error. No se pudo insertar detalle de la solicitud {detalle.TRANSFER_REQUEST_ID}: {operacion.Mensaje}";
                return operacion;
            }
            return operacion;
        }

        public Operacion ActualizarSolicitudDeTrasladoDetalle(SolicitudDeTrasladoArgumento solicitudDeTrasladoArgumento)
        {
            var operacion = ActualizarDetalles(solicitudDeTrasladoArgumento);
            if (operacion.Resultado != ResultadoOperacionTipo.Error)
            {
                BaseDeDatosServicio.Commit();
                return operacion;
            }
            BaseDeDatosServicio.Rollback();
            return operacion;
        }

        private Operacion ActualizarDetalles(SolicitudDeTrasladoArgumento solicitudDeTrasladoArgumento)
        {
            var operacion = new Operacion();
            foreach (var detalle in solicitudDeTrasladoArgumento.SolicitudDeTrasladoDetalles)
            {
                DbParameter[] parameters =
                {
                    new OAParameter
                    {
                        ParameterName = "@TRANSFER_REQUEST_ID",
                        Value = detalle.TRANSFER_REQUEST_ID
                    },new OAParameter
                    {
                        ParameterName = "@MATERIAL_ID",
                        Value = detalle.MATERIAL_ID
                    },new OAParameter
                    {
                        ParameterName = "@MATERIAL_NAME",
                        Value = detalle.MATERIAL_NAME
                    },new OAParameter
                    {
                        ParameterName = "@IS_MASTERPACK",
                        Value = detalle.IS_MASTERPACK
                    },new OAParameter
                    {
                        ParameterName = "@QTY",
                        Value = detalle.QTY
                    },new OAParameter
                    {
                        ParameterName = "@STATUS",
                        Value = detalle.STATUS
                    }
                };
                operacion = BaseDeDatosServicio.ExecuteQuery<Operacion>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_UPDATE_TRASNFER_REQUEST_DETAIL", CommandType.StoredProcedure, false, parameters)[0];
                if (operacion.Resultado != ResultadoOperacionTipo.Error) continue;
                operacion.Mensaje = $"Error. No se pudo actualizar el detalle de la solicitud {detalle.TRANSFER_REQUEST_ID}: {operacion.Mensaje}.";
                return operacion;
            }
            return operacion;
        }

        public Operacion EliminarSolicitudDeTrasladoDetalle(SolicitudDeTrasladoArgumento solicitudDeTrasladoArgumento)
        {
            DbParameter[] parameters =
            {
                new OAParameter
                {
                    ParameterName = "@TRANSFER_REQUEST_ID",
                    Value = solicitudDeTrasladoArgumento.SolicitudDeTrasladoDetalle.TRANSFER_REQUEST_ID
                },new OAParameter
                {
                    ParameterName = "@MATERIAL_ID",
                    Value = solicitudDeTrasladoArgumento.SolicitudDeTrasladoDetalle.MATERIAL_ID
                }
            };
            var operacion = BaseDeDatosServicio.ExecuteQuery<Operacion>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_DELETE_TRANSFER_REQUEST_DETAIL", CommandType.StoredProcedure, false, parameters)[0];
            if (operacion.Resultado != ResultadoOperacionTipo.Error) BaseDeDatosServicio.Commit();
            else BaseDeDatosServicio.Rollback();
            return operacion;
        }

        public IList<OrdenDeVentaEncabezado> ObtenerSolicitudesDeTransferenciaPorFecha(OrdenDeVentaArgumento ordenDeVentaArgumento)
        {
            DbParameter[] parameters =
            {
                new OAParameter
                {
                    ParameterName = "@WAREHOUSE_ID",
                    Value = ordenDeVentaArgumento.CodigoBodega
                },new OAParameter
                {
                    ParameterName = "@START_DATETIME",
                    Value = ordenDeVentaArgumento.FechaInicio
                },new OAParameter
                {
                    ParameterName = "@END_DATETIME",
                    Value = ordenDeVentaArgumento.FechaFin
                }
            };
            return BaseDeDatosServicio.ExecuteQuery<OrdenDeVentaEncabezado>(
                BaseDeDatosServicio.Esquema + ".OP_WMS_SP_GET_TRANSFER_REQUEST_HEADER_BY_DATE", CommandType.StoredProcedure,
                true, parameters).ToList();
        }

        public IList<OrdenDeVentaDetalle> ObtenerDetalleDeSolicitudesDeTransferencia(OrdenDeVentaArgumento ordenDeVentaArgumento)
        {
            DbParameter[] parameters =
            {
                new OAParameter
                {
                    ParameterName = "@XML",
                    Value = ordenDeVentaArgumento.XmlDocumentos
                }

            };
            return BaseDeDatosServicio.ExecuteQuery<OrdenDeVentaDetalle>(
                BaseDeDatosServicio.Esquema + ".OP_WMS_SP_GET_TRANSFER_REQUEST_DETAIL_FOR_DEMAND_PICKING", CommandType.StoredProcedure,
                false, parameters).ToList();
        }

        public IList<OrdenDeVentaEncabezado> ObtenerSolicitudesDeTransferenciaDeErpPorFecha(OrdenDeVentaArgumento ordenDeVentaArgumento)
        {
            DbParameter[] parameters =
            {
                new OAParameter
                {
                    ParameterName = "@WAREHOUSE_ID",
                    Value = ordenDeVentaArgumento.CodigoBodega
                },new OAParameter
                {
                    ParameterName = "@START_DATETIME",
                    Value = ordenDeVentaArgumento.FechaInicio
                },new OAParameter
                {
                    ParameterName = "@END_DATETIME",
                    Value = ordenDeVentaArgumento.FechaFin
                }
            };
            return BaseDeDatosServicio.ExecuteQuery<OrdenDeVentaEncabezado>(
                BaseDeDatosServicio.Esquema + ".OP_WMS_SP_GET_ERP_TRANSFER_REQUEST_HEADER_BY_DATE", CommandType.StoredProcedure,
                true, parameters).ToList();
        }

        public IList<OrdenDeVentaDetalle> ObtenerDetalleDeSolicitudesDeTransferenciaErp(OrdenDeVentaArgumento ordenDeVentaArgumento)
        {
            DbParameter[] parameters =
            {
                new OAParameter
                {
                    ParameterName = "@XML",
                    Value = ordenDeVentaArgumento.XmlDocumentos
                }

            };
            return BaseDeDatosServicio.ExecuteQuery<OrdenDeVentaDetalle>(
                BaseDeDatosServicio.Esquema + ".OP_WMS_SP_GET_ERP_TRANSFER_REQUEST_DETAIL_FOR_DEMAND_PICKING", CommandType.StoredProcedure,
                true, parameters).ToList();
        }

        public IList<SolicitudDeTrasladoEncabezado> ObtenerSolicitudesDeTrasladoPorBodegaEstadoYFecha(ReporteDeSolicitudDeTrasladoArgumento reporteDeSolicitudDeTrasladoArgumento)
        {
            DbParameter[] parameters =
            {
                new OAParameter
                {
                    ParameterName = "@START_DATETIME",
                    Value = reporteDeSolicitudDeTrasladoArgumento.FechaInicial
                },new OAParameter
                {
                    ParameterName = "@END_DATETIME",
                    Value = reporteDeSolicitudDeTrasladoArgumento.FechaFinal
                },new OAParameter
                {
                    ParameterName = "@STATUS",
                    Value = reporteDeSolicitudDeTrasladoArgumento.Estado
                },new OAParameter
                {
                    ParameterName = "@WAREHOUSES",
                    Value = reporteDeSolicitudDeTrasladoArgumento.Bodegas
                }
            };
            return BaseDeDatosServicio.ExecuteQuery<SolicitudDeTrasladoEncabezado>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_GET_TRANSFER_REQUEST_BY_WAREHOUSE_AND_DATETIME", CommandType.StoredProcedure, false, parameters).ToList();

        }

        public IList<TrazabilidadDeSolicitudDeTraslado> ObtenerTrazabilidadDeSolicitudDeTraslado(ReporteDeSolicitudDeTrasladoArgumento reporteDeSolicitudDeTrasladoArgumento)
        {
            DbParameter[] parameters =
            {
                new OAParameter
                {
                    ParameterName = "@TRANSFER_REQUEST_ID",
                    Value = reporteDeSolicitudDeTrasladoArgumento.SolicitudDeTrasladoEncabezado.TRANSFER_REQUEST_ID
                }
            };
            return BaseDeDatosServicio.ExecuteQuery<TrazabilidadDeSolicitudDeTraslado>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_GET_TRANSFER_REQUEST_TRACEABILITY", CommandType.StoredProcedure, false, parameters).ToList();

        }

        public Operacion CerrarSolicitudesDeTraslado(ReporteDeSolicitudDeTrasladoArgumento reporteDeSolicitudDeTrasladoArgumento)
        {
            DbParameter[] parameters =
            {
                new OAParameter
                {
                    ParameterName = "@TRANSFER_REQUEST_ID",
                    Value = reporteDeSolicitudDeTrasladoArgumento.IdsSolicitudesDeTraslado
                },new OAParameter
                {
                    ParameterName = "@MATERIAL_ID",
                    Value = reporteDeSolicitudDeTrasladoArgumento.MaterialesSolicitudDeTraslado
                }
            };
            var operacion = BaseDeDatosServicio.ExecuteQuery<Operacion>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_CLOSE_TRANSFER_REQUEST", CommandType.StoredProcedure, false, parameters)[0];
            if (operacion.Resultado != ResultadoOperacionTipo.Error) BaseDeDatosServicio.Commit();
            else BaseDeDatosServicio.Rollback();
            return operacion;
        }
    }
}
