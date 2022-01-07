using System;

namespace MobilityScm.Modelo.Entidades
{
    [Serializable]
    public class SolicitudDeTrasladoDetalle
    {
        public int TRANSFER_REQUEST_ID { get; set; }

        public string MATERIAL_ID { get; set; }

        public string MATERIAL_NAME { get; set; }

        public int IS_MASTERPACK { get; set; }

        public string IS_MASTERPACK_DESCRIPTION { get; set; }

        public decimal QTY { get; set; }

        public string STATUS { get; set; }

        public string STATUS_DESCRIPTION { get; set; }

        public string WAREHOUSE_FROM { get; set; }

        public string WAREHOUSE_TO { get; set; }

        public DateTime? DELIVERY_DATE { get; set; }

        public string REQUEST_TYPE { get; set; }

        public string COMMENT { get; set; }

        public string STATUS_CODE { get; set; }
    }
}
