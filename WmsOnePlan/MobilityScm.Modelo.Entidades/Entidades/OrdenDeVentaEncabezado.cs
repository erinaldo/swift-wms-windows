using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace MobilityScm.Modelo.Entidades
{
    [Serializable]
    public class OrdenDeVentaEncabezado
    {
        public OrdenDeVentaEncabezado()
        {
            Detalles = new List<OrdenDeVentaDetalle>();
        }
        public string LOGIN { get; set; }
        public string SALES_ORDER_ID { get; set; }

        public string BASE_REF { get; set; }

        public string BASE_ENTRY { get; set; }

        public string TERMS { get; set; }

        public DateTime? POSTED_DATETIME { get; set; }

        public string CLIENT_ID { get; set; }

        public string CUSTOMER_NAME { get; set; }

        public string POS_TERMINAL { get; set; }

        public string GPS_URL { get; set; }

        public decimal? TOTAL_AMOUNT { get; set; }

        public int? STATUS { get; set; }

        public string POSTED_BY { get; set; }

        public string IMAGE_1 { get; set; }

        public string IMAGE_2 { get; set; }

        public string IMAGE_3 { get; set; }

        public int? DEVICE_BATTERY_FACTOR { get; set; }

        public DateTime? VOID_DATETIME { get; set; }

        public string VOID_REASON { get; set; }

        public string VOID_NOTES { get; set; }

        public int? VOIDED { get; set; }

        public DateTime? CLOSED_ROUTE_DATETIME { get; set; }

        public int? IS_ACTIVE_ROUTE { get; set; }

        public string GPS_EXPECTED { get; set; }

        public int? SALES_ORDER_ID_HH { get; set; }

        public string NAME_CUSTOMER { get; set; }

        public string ADRESS_CUSTOMER { get; set; }

        public string CONTACT_CUSTOMER { get; set; }

        public string CODE_ROUTE { get; set; }

        public string NAME_ROUTE { get; set; }

        public DateTime? DELIVERY_DATE { get; set; }

        public int? IS_PARENT { get; set; }

        public string IS_PARENT_DESCRIPTION { get; set; }

        public string REFERENCE_ID { get; set; }

        public string CODE_WAREHOUSE { get; set; }

        public string DESCRIPTION_WAREHOUSE { get; set; }

        public string DOC_SERIE { get; set; }

        public string DOC_NUM { get; set; }

        public string IS_VOID { get; set; }

        public string SALES_ORDER_TYPE { get; set; }

        public decimal DISCOUNT { get; set; }

        public int IS_DRAFT { get; set; }

        public string IS_DRAFT_DESCRIPTION { get; set; }

        public string ASSIGNED_BY { get; set; }

        public decimal TOTAL_CD { get; set; }

        public int IS_POSTED_ERP { get; set; }

        public string IS_POSTED_ERP_DESCRIPTION { get; set; }

        public decimal? CREDIT_AMOUNT { get; set; }

        public decimal? CASH_AMOUNT { get; set; }

        public List<OrdenDeVentaDetalle> Detalles { get; set; }

        public int EXTERNAL_SOURCE_ID { get; set; }

        public string COMMENT { get; set; }

        public string CodigoFuenteExterna { get; set; }

        public string SOURCE_NAME { get; set; }

        public int AdvertenciaFaltaInventario { get; set; }

        public int IS_FROM_SONDA { get; set; }
        public int IS_FROM_ERP { get; set; }
        public string CODE_SELLER { get; set; }

        public int Prioridad { get; set; }
        public int IS_COMPLETED { get; set; }

        public string DOC_ENTRY { get; set; }
        public bool IS_SELECTD { get; set; }
        public string CLIENT_OWNER { get; set; }
        public string MASTER_ID_SELLER { get; set; }
        public string SELLER_OWNER { get; set; }
        public string OWNER { get; set; }
        public string SOURCE_TYPE { get; set; }
        public string WAREHOUSE_FROM { get; set; }
        public string WAREHOUSE_TO { get; set; }

        public string ADDRESS_CUSTOMER { get; set; }

        public int STATE_CODE { get; set; }

        public int WAVE_PICKING_ID { get; set; }
        public int PICKING_DEMAND_HEADER_ID { get; set; }

        public int ID { get; set; }
        public int MIN_DAYS_EXPIRATION_DATE { get; set; }

        public decimal ORDER_VOLUME
        {
            get
            {
                if (this.Detalles == null) return 0;
                decimal volumen = 0;
                this.Detalles.ToList().ForEach(d => volumen += (d.MATERIAL_VOLUME * d.QTY));
                return volumen;

            }
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException(nameof(value));
                ORDER_VOLUME = value;
            }
        }
        public decimal ORDER_WEIGHT
        {
            get
            {
                if (this.Detalles == null) return 0;
                decimal peso = 0;
                this.Detalles.ToList().ForEach(d => peso += (d.MATERIAL_WEIGHT * d.QTY));
                return peso;
            }
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException(nameof(value));
                ORDER_VOLUME = value;
            }
        }

        public int TYPE_DEMAND_CODE { get; set; }
        public string TYPE_DEMAND_NAME { get; set; }

        public string LINE_DOC { get; set; }

        public int BOX_QTY { get; set; }

        public int TASK_PRIORITY { get; set; }

        public string PROJECT { get; set; }

        public string ASESOR { get; set; }

        public int CODIGO_ASESOR { get; set; }
    }
}
