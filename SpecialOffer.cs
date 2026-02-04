
//========================================================== 
// Student Number : S10268600D
// Student Name : Kristine Keok Jia Xuan
// Partner Name : Miridhu D/O Ellapparaja
//==========================================================

using System;

namespace S10268600D_PRG2Assignment
{
    class SpecialOffer
    {
        private string offerCode;

        private string offerDesc;

        private double discount;

        public string OfferCode
        {
            get { return offerCode; }
            set { offerCode = value; }
        }

        public string OfferDesc
        {
            get { return offerDesc; } 
            set { offerDesc = value; }
        }

        public double Discount
        {
            get { return discount; }
            set { discount = value; }
        }

        public SpecialOffer() { }

        public SpecialOffer(string offerCode, string offerDesc, double discount)
        {
            OfferCode = offerCode;
            OfferDesc = offerDesc;
            Discount = discount;
        }

        public override string ToString()
        {
            if (discount <= 0)
                return "Offer " + offerCode + ": " + offerDesc + " (Discount: -)";

            else
                return "Offer " + offerCode + ": " + offerDesc +
                       " (Discount: " + discount.ToString("F0") + "%)";
        }
    }
}