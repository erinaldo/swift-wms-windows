
using System;

namespace MobilityScm.Modelo.Entidades
{
    public class TareaDetalle
    {
        public int SERIAL_NUMBER { get; set; }
        public string MATERIAL_ID { get; set; }
        public string MATERIAL_NAME { get; set; }
        public decimal QTY { get; set; }
        public decimal QTY_DOC { get; set; }
        public decimal QTY_DIFFERENCE { get; set; }
        public int QTY_SCANNED { get; set; }
        public int QTY_EXPECTED { get; set; }
        public int DIFFERENCE { get; set; }
        public string TASK_COMMENTS { get; set; }
        public decimal WAVE_PICKING_ID { get; set; }
        public string NUMERO_ORDEN_TARGET { get; set; }
        public string BARCODE_ID { get; set; }
        public string CODIGO_POLIZA_TARGET { get; set; }
        public string CODIGO_POLIZA_SOURCE { get; set; }
        public int USE_PICKING_LINE { get; set; }
        public int PHYSICAL_COUNT_DETAIL_ID { get; set; }
        public decimal PHYSICAL_COUNT_HEADER_ID { get; set; }
        public string WAREHOUSE_ID { get; set; }
        public string ZONE { get; set; }
        public string LOCATION { get; set; }
        public string CLIENT_CODE { get; set; }
        public string ASSIGNED_TO { get; set; }
        public string STATUS { get; set; }
        public string REGIMEN { get; set; }
        public string DISTRIBUTION_CENTER { get; set; }
        public string TASK_SUBTYPE { get; set; }

        public bool IS_SELECTED { get; set; }

        public int IN_PICKING_LINE { get; set; }
        public int CLASS_ID { get; set; }
        public string CLASS_NAME { get; set; }

        public decimal ASIGNADO { get; set; } 
        public int LICENSE_ID { get; set; }
        public string BATCH { get; set; }
        public DateTime? DATE_EXPIRATION { get; set; }
        public int FROM_MASTERPACK { get; set; }
    }
}
