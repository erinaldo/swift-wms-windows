using System;
using MobilityScm.Modelo.Tipos;

namespace MobilityScm.Modelo.Entidades
{
    [Serializable]
    public class ManifiestoDetalle
    {
        public string MATERIAL_ID { get; set; }
        public string MATERIAL_NAME { get; set; }
        public decimal QTY { get; set; }
        public string CLIENT_CODE { get; set; }
        public string CLIENT_NAME { get; set; }
        public DateTime DOCUMENT_DATE { get; set; }
        public int WAVE_PICKING_ID { get; set; }
        public int MANIFEST_HEADER_ID { get; set; }

        public string MANIFEST_TYPE { get; set; }
        public decimal WEIGHT { get; set; }
        public string ADDRESS_CUSTOMER { get; set; }

        public string ERP_REFERENCE_DOC_NUM { get; set; }

        public int? PICKING_DEMAND_HEADER_ID { get; set; }
        public bool IS_SELECTED { get; set; }
        public string LAST_UPDATE_BY { get; set; }
        public DateTime LAST_UPDATE { get; set; }
        public string STATUS { get; set; }
        public int LINE_NUM { get; set; }
        public int MANIFEST_DETAIL_ID { get; set; }
        public string CODE_ROUTE { get; set; }

        public bool EsNuevo { get; set; }

        public DateTime COMPLETED_DATE { get; set; }

        public decimal TOTAL_VOLUME { get; set; }

        public int TYPE_DEMAND_CODE { get; set; }

        public string TYPE_DEMAND_NAME { get; set; }

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
        public string STATUS_CODE { get; set; }
    }
}
