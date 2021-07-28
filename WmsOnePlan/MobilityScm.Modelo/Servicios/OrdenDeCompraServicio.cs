using MobilityScm.Modelo.Interfaces.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Entidades;
using MobilityScm.Utilerias;
using System.Data.Common;
using System.Data;
using Telerik.OpenAccess.Data.Common;
using System.Xml.Serialization;
using MobilityScm.Vertical.Entidades;
using System.IO;
using System.Xml;
using MobilityScm.Modelo.Tipos;

namespace MobilityScm.Modelo.Servicios
{
    public class OrdenDeCompraServicio : IOrdenDeCompraServicio
    {
        public IBaseDeDatosServicio BaseDeDatosServicio { get; set; }

        public OrdenDeCompraServicio(IBaseDeDatosServicio baseDeDatosServicio)
        {
            BaseDeDatosServicio = baseDeDatosServicio;
        }

        public IList<OrdenDeCompraDetalle> ObtenerDetalleRecepcionOrdenDeCompra(TareaArgumento tareaArgumento)
        {
            DbParameter[] parameters =
                               {
                    new OAParameter
                    {
                        ParameterName = "@SERIAL_NUMBER",
                        Value = tareaArgumento.Tarea.SERIAL_NUMBER
                    }
                };
            return BaseDeDatosServicio.ExecuteQuery<OrdenDeCompraDetalle>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_GET_RECEPTION_ERP_DOCUMENT_DETAIL", CommandType.StoredProcedure, false, parameters).ToList();
        }

        public Operacion GuardarConfirmacionRecepcionErp(IList<OrdenDeCompraDetalle> detalle, IList<SerieRecepcionDetalle> detalleSeries, string login, int taskId)
        {

            var serializer = new XmlSerializer(typeof(List<OrdenDeCompraDetalle>));
            var stringWriter = new StringWriter();
            var xmlWriter = new XmlTextWriter(stringWriter) { Formatting = Formatting.Indented };
            serializer.Serialize(xmlWriter, detalle);
            
            var serializerSeries = new XmlSerializer(typeof(List<SerieRecepcionDetalle>));
            var stringWriterSeries = new StringWriter();
            var xmlWriterSeries = new XmlTextWriter(stringWriterSeries) { Formatting = Formatting.Indented };
            serializerSeries.Serialize(xmlWriterSeries, detalleSeries);

            DbParameter[] parameters =
            {
                new OAParameter
                {
                    ParameterName = "@XML",
                    Value =  stringWriter.ToString()
                },new OAParameter
                {
                    ParameterName = "@XML_SERIES",
                    Value =  stringWriterSeries.ToString()
                }
                ,new OAParameter
                {
                    ParameterName = "@LOGIN",
                    Value = login
                },new OAParameter
                {
                    ParameterName = "@TASK_ID",
                    Value = taskId
                }
            };
            var operacion = BaseDeDatosServicio.ExecuteQuery<Operacion>($"{BaseDeDatosServicio.Esquema}.OP_WMS_SP_CONFIRMED_RECEPTION_ERP_BY_XML", CommandType.StoredProcedure, false, parameters)[0];
            if (operacion.Resultado != ResultadoOperacionTipo.Error) BaseDeDatosServicio.Commit();
            else BaseDeDatosServicio.Rollback();
            return operacion;
        }

        public Operacion ObtenerUltimoCorrelativoAsignado()
        {
            return BaseDeDatosServicio.ExecuteQuery<Operacion>($"{BaseDeDatosServicio.Esquema}.OP_WMS_SP_GET_LAST_ASSIGNED_SERIAL_CORRELATIVE", CommandType.StoredProcedure, false, null)[0];
        }

        public IList<SerieRecepcionDetalle> ObtenerDetalleRecepcionSerieDetalle(TareaArgumento tareaArgumento)
        {
            DbParameter[] parameters =
                               {
                    new OAParameter
                    {
                        ParameterName = "@SERIAL_NUMBER",
                        Value = tareaArgumento.Tarea.SERIAL_NUMBER
                    }
                };
            return BaseDeDatosServicio.ExecuteQuery<SerieRecepcionDetalle>(BaseDeDatosServicio.Esquema + ".OP_WMS_SP_GET_RECEPTION_ERP_DOCUMENT_SERIES", CommandType.StoredProcedure, false, parameters).ToList();
        }

        public Operacion ValidarSiTodosLosDocumentosHanSidoEnviadosAErp(int taskId)
        {
            DbParameter[] parameters =
            {
                new OAParameter
                {
                    ParameterName = "@TASK_ID",
                    Value = taskId
                }
            };
            return BaseDeDatosServicio.ExecuteQuery<Operacion>($"{BaseDeDatosServicio.Esquema}.OP_WMS_SP_VALIDATE_IF_ALL_DOCUMENTS_HAS_BEEN_SEND_TO_ERP", CommandType.StoredProcedure, false, parameters)[0];
        }

        public Operacion DesbloquearInventarioParaTareasEnviadasAErpFallidas(TareaArgumento tareaArgumento)
        {
            DbParameter[] parameters =
            {
                new OAParameter
                {
                    ParameterName = "@TASK_ID",
                    Value =  tareaArgumento.taskId
                },new OAParameter
                {
                    ParameterName = "@REFERENCE",
                    Value =  tareaArgumento.reference != null ? tareaArgumento.reference : " "
                },new OAParameter
                {
                    ParameterName = "@REASON",
                    Value =  tareaArgumento.reason
                },new OAParameter
                {
                    ParameterName = "@LOGIN",
                    Value =  tareaArgumento.Login
                }
            };
            return BaseDeDatosServicio.ExecuteQuery<Operacion>($"{BaseDeDatosServicio.Esquema}.OP_WMS_SP_UNLOCK_INVENTORY_BY_TASKS_SEND_TO_ERP_FAILED", CommandType.StoredProcedure, parameters)[0];
        }

        public Operacion DesbloquearTransaccionOperacionManual(TareaArgumento tareaArgumento)
        {
            DbParameter[] parameters =
            {
                new OAParameter
                {
                    ParameterName = "@TASK_ID",
                    Value =  tareaArgumento.taskId
                },new OAParameter
                {
                    ParameterName = "@REFERENCE",
                    Value =  tareaArgumento.reference != null ? tareaArgumento.reference : " "
                },new OAParameter
                {
                    ParameterName = "@REASON",
                    Value =  tareaArgumento.reason
                },new OAParameter
                {
                    ParameterName = "@LOGIN",
                    Value =  tareaArgumento.Login
                }
            };
            return BaseDeDatosServicio.ExecuteQuery<Operacion>($"{BaseDeDatosServicio.Esquema}.OP_WMS_SP_UNLOCK_TRANSACTION", CommandType.StoredProcedure, parameters)[0];
        }

        public Operacion CrearTareaRectificacionMP(TareaArgumento tareaArgumento)
        {
            DbParameter[] parameters =
            {
                new OAParameter
                {
                    ParameterName = "@TASK_ID",
                    Value =  tareaArgumento.taskId
                },new OAParameter
                {
                    ParameterName = "@WAVE_PICKING_ID",
                    Value =  tareaArgumento.WAVE_PICKING_ID
                },new OAParameter
                {
                    ParameterName = "@LOGIN",
                    Value =  tareaArgumento.Login
                }
            };
            return BaseDeDatosServicio.ExecuteQuery<Operacion>($"{BaseDeDatosServicio.Esquema}.OP_WMS_SP_CREATE_MP_RECTIFICATION_TASK", CommandType.StoredProcedure, parameters)[0];
        }

        public Operacion AutorizarControlDeCalidad(TareaArgumento tareaArgumento)
        {
            DbParameter[] parameters =
            {
                new OAParameter
                {
                    ParameterName = "@TASK_ID",
                    Value =  tareaArgumento.taskId
                },new OAParameter
                {
                    ParameterName = "@LOGIN",
                    Value =  tareaArgumento.Login
                }
            };
            return BaseDeDatosServicio.ExecuteQuery<Operacion>($"{BaseDeDatosServicio.Esquema}.OP_WMS_SP_CHANGE_QA_STATUS_TO_DEFAUL_BY_TASK", CommandType.StoredProcedure, parameters)[0];
        }

    }
}
