using System;
using MobilityScm.Modelo.Tipos;

namespace MobilityScm.Modelo.Entidades
{
    [Serializable]
    public class ManifiestoCarga
    {
        public string MATERIAL_ID { get; set; }
        public string MATERIAL_NAME { get; set; }
        public int QTY { get; set; }
        public string CLIENT_CODE { get; set; }
        public string CLIENT_NAME { get; set; }
        public DateTime DOCUMENT_DATE { get; set; }
        public int WAVE_PICKING_ID { get; set; }
        public string DISTRIBUTION_CENTER { get; set; }
        public int? DRIVER { get; set; }
        public string VEHICLE { get; set; }
        public string HEADER_STATUS { get; set; }
        public int MANIFEST_HEADER_ID { get; set; }
        public string CODE_ROUTE { get; set; }

        public int? TRANSFER_REQUEST_ID { get; set; }

        public decimal WEIGHT { get; set; }

        public string ADDRESS_CUSTOMER { get; set; }

        public string ERP_REFERENCE_DOC_NUM { get; set; }

        public string SHOWN_DOCUMENT { get; set; }

        public decimal PRICE { get; set; }

        public decimal LINE_DISCOUNT { get; set; }

        public string LINE_DISCOUNT_TYPE { get; set; }

        public decimal HEADER_DISCOUNT { get; set; }

        public decimal LINE_TOTAL
        {
            get
            {
                decimal lineTotal;

                var priceBefDiscount = PRICE * QTY;
                if (LINE_DISCOUNT_TYPE == Enums.GetStringValue(TipoDescuento.Porcentual))
                {
                    lineTotal = priceBefDiscount - priceBefDiscount * (LINE_DISCOUNT / 100);
                }
                else
                {
                    lineTotal = priceBefDiscount - LINE_DISCOUNT;
                }
                return lineTotal;
            }
        }

        public decimal FINAL_PRICE
        {
            get
            {
                decimal finalPrice, priceAfterLineDiscount;

                var priceBefDiscount = PRICE * QTY;
                if (LINE_DISCOUNT_TYPE == Enums.GetStringValue(TipoDescuento.Porcentual))
                {
                    priceAfterLineDiscount = priceBefDiscount - priceBefDiscount * (LINE_DISCOUNT / 100);
                    finalPrice = priceAfterLineDiscount - priceAfterLineDiscount * (HEADER_DISCOUNT / 100);
                }
                else
                {
                    priceAfterLineDiscount = priceBefDiscount - LINE_DISCOUNT;
                    finalPrice = priceAfterLineDiscount - priceAfterLineDiscount * (HEADER_DISCOUNT / 100);

                }
                return finalPrice;
            }
        }

        public decimal DOCUMENT_TOTAL { get; set; }

        public string Olas { get; set; }

        public string PILOT_NAME { get; set; }
        public string WAREHOUSE_FROM { get; set; }
        public string WAREHOUSE_TO { get; set; }

        public string STATUS_CODE { get; set; }
    }
}
