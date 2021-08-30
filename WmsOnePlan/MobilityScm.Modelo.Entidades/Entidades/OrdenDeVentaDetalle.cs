using System;

namespace MobilityScm.Modelo.Entidades
{
    [Serializable]
    public class OrdenDeVentaDetalle
    {
        public int ID { get; set; }
        public int HEADER_ID { get; set; }

        public string SALES_ORDER_ID { get; set; }

        public string BASE_REF { get; set; }

        public string BASE_ENTRY { get; set; }

        public string SKU { get; set; }

        public string DESCRIPTION_SKU { get; set; }

        public int LINE_SEQ { get; set; }

        public decimal QTY { get; set; }
        public decimal QTY_ORIGINAL { get; set; }
        public decimal QTY_PENDING { get; set; }
        public decimal PRICE { get; set; }
        public decimal TOTAL_WEIGHT { get; set; }
        public decimal LINE_WEIGHT
        {
            get
            {
                if (MATERIAL_WEIGHT == 0) return 0;
                return MATERIAL_WEIGHT * QTY; ;
            }
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException(nameof(value));
                LINE_WEIGHT = value;
            }
        }

        public decimal DISCOUNT { get; set; }

        public decimal TOTAL_LINE { get; set; }

        public DateTime? POSTED_DATETIME { get; set; }

        public string SERIE { get; set; }

        public string SERIE_2 { get; set; }

        public int REQUERIES_SERIE { get; set; }

        public int MIN_DAYS_EXPIRATION_DATE { get; set; }

        public string COMBO_REFERENCE { get; set; }

        public int PARENT_SEQ { get; set; }

        public int IS_ACTIVE_ROUTE { get; set; }

        public string CODE_PACK_UNIT { get; set; }

        public int EXTERNAL_SOURCE_ID { get; set; }

        public string SOURCE_NAME { get; set; }

        public int IS_BONUS { get; set; }

        public string ALTERNATE_BARCODE { get; set; }

        public string BARCODE_ID { get; set; }

        public int AdvertenciaFaltaInventario { get; set; }

        public int ERP_OBJECT_TYPE { get; set; }

        public DateTime fechaModificacion { get; set; }

        public string CODE_WAREHOUSE_SOURCE { get; set; }

        public bool IS_SELECTD { get; set; }

        public decimal AVAILABLE_QTY { get; set; }

        public int IS_MASTER_PACK { get; set; }

        public string MASTER_ID_MATERIAL { get; set; }
        public string MATERIAL_OWNER { get; set; }
        public string SOURCE_TYPE { get; set; }
        public string SOURCE { get; set; }

        // ReSharper disable once InconsistentNaming
        public string TONE { get; set; }

        // ReSharper disable once InconsistentNaming
        public string CALIBER { get; set; }

        public string DISCOUNT_TYPE { get; set; }
        public decimal MATERIAL_WEIGHT { get; set; }
        public decimal MATERIAL_VOLUME { get; set; }

        public int USE_PICKING_LINE { get; set; }

        public string MEASUREMENT_UNIT { get; set; }

        public string unitMsr { get; set; }

        public string STATUS_CODE { get; set; }

        public string STATUS_CODE_ORIGIN { get; set; }

        public string STATUS_CODE_CONSOLIDATED { get; set; }
    }
}