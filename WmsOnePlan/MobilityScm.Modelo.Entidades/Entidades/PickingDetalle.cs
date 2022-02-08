using System;
using MobilityScm.Modelo.Tipos;

namespace MobilityScm.Modelo.Entidades
{
    [Serializable]
    public class PickingDetalle
    {
        public int PICKING_DETAIL { get; set; }

        public int PICKING_HEADER { get; set; }

        public string CODE_SKU { get; set; }

        public string DESCRIPTION_SKU { get; set; }

        public float DISPATCH { get; set; }

        public float SCANNED { get; set; }

        public float RESULT { get; set; }

        public string COMMENTS { get; set; }

        public DateTime LAST_UPDATE { get; set; }

        public string LAST_UPDATE_BY { get; set; }

        public float DIFFERENCE { get; set; }

        public float QUANTITY { get; set; }

        public string MATERIAL_ID { get; set; }

        public string MATERIAL_NAME { get; set; }

        public decimal QTY { get; set; }

        public string CLIENT_CODE { get; set; }

        public string CLIENT_NAME { get; set; }

        public DateTime COMPLETED_DATE { get; set; }

        public int WAVE_PICKING_ID { get; set; }

        public int? TRANSFER_REQUEST_ID { get; set; }

        public decimal? WEIGHT { get; set; }

        public string ADDRESS_CUSTOMER { get; set; }

        public int? PICKING_DEMAND_HEADER_ID { get; set; }

        public string ERP_REFERENCE_DOC_NUM { get; set; }

        public  bool IS_SELECTED { get; set; }

        public bool EsNuevo { get; set; } = true;

        public decimal TOTAL_VOLUME { get; set; }

        public int TYPE_DEMAND_CODE { get; set; }
        public string TYPE_DEMAND_NAME { get; set; }

        public decimal PRICE { get; set; }

        public decimal LINE_DISCOUNT { get; set; }

        public string LINE_DISCOUNT_TYPE { get; set; }

        public decimal HEADER_DISCOUNT { get; set; }

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
