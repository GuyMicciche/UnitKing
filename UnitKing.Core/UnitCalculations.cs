using System;
using System.Collections.Generic;
using System.Text;

namespace UnitKing.Core
{
    public class Calculation
    {
        public static int Weight { get; set; }
        public static int Actual { get; set; }
        public static int Target { get; set; }
        public static int Carbohydrates { get; set; }
        public static bool IsPouunds { get; set; }

        public static void InitCalculation(int weight, bool isPounds = true)
        {
            Weight = weight;
            IsPouunds = isPounds;
        }

        public static void InitCalculation(int weight, int actual, int target, int carbohydrates, bool isPounds = true)
        {
            Weight = weight;
            Actual = actual;
            Target = target;
            Carbohydrates = carbohydrates;
            IsPouunds = isPounds;
        }

        public static int TotalDailyInsulinRequirement
        {
            get
            {
			    double units = 0;

                if (IsPouunds)
                {
                    units = Weight / 4;
			    }
			    else
                {
                    units = Weight * .55;
			    }

			    return (int)Math.Round(units);
            }
		}

		public static int CarbohydrateCoverageRatio
        {
            get
            {
			    double ccr = 500 / TotalDailyInsulinRequirement;

                return (int)Math.Round(ccr);
            }
		}

		public static int CorrectionFactor
        {
            get
            {
                double cf = 1800 / TotalDailyInsulinRequirement;

			    return (int)Math.Round(cf);
            }
		}

		public static int CorrectionDose
        {
            get
            {
                double cd = (Actual - Target) / CorrectionFactor;

			    return (int)Math.Round(cd);
            }
		}

		public static int MealtimeDose
        {
            get
            {
                double md = Carbohydrates / CarbohydrateCoverageRatio;

			    return (int)Math.Round(md);
            }
		}

		public static int TotalMealtimeDose
        {
            get
            {
                int tmd = CorrectionDose + MealtimeDose;

			    return tmd;
            }
		}
    }
}
