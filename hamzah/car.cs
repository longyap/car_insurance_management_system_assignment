    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance_customer_management_system
{
    class car
    {
        //nested class
        public class price_counting
        {
            public double price;
            public int options;
            public price_counting()
            {
                price = 0;
                options = 0;

            }
            public double PRICE
            {
                get { return price; }
                set { price = value; }
            }
            public int OPTION
            {
                get { return options; }
                set { options = value; }
            }

            public price_counting(int opt, double pr)
            {
                options = opt;
                price = pr;
            }

            public double gross_total(int options, double price)
            {
                double grosstotal = 0;
                switch (options)
                {
                    case 0:
                        grosstotal = Math.Round(price * (2.66 / 100), 2);
                        break;

                    case 1:
                        grosstotal = Math.Round(price * (2.75 / 100), 2);
                        break;
                    case 2:
                        grosstotal = Math.Round(price * (2.84 / 100), 2);
                        break;


                };
                return grosstotal;

            }
            public double sst(double gross_total)
            {
                double sst = Math.Round(gross_total * 6 / 100);
                return sst;
            }

            public double total_premium(double gross_total, double sst)
            {
                double totalpremium = gross_total + sst + 10;
                return totalpremium;
            }

        }
        
     
    }



}
