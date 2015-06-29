using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BabySafeRx
{
  public partial class drug_details : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      // In order to display the drug details, must have a single selection
      BabySafeRxData bsrd = new BabySafeRxData();
      if (Session["babySafeData"] != null)
      {
        List<BabySafeRxData> babySafeDataList = (List<BabySafeRxData>)Session["babySafeData"];
        if (Request["splId"] != null)
        {
          string splId = Convert.ToString(Request["splId"]);
          foreach (BabySafeRxData bsd in babySafeDataList)
          {
            if (bsd.splId.Equals(splId))
            {
              // Match
              brandName.InnerText = bsd.brandName;
              genericName.InnerText = bsd.genericName;
              switch (bsd.riskLevel)
              {
                case "Low":
                  riskImage.Src = "img/Risk-1.png";
                  riskText.InnerText = "Human studies show low risk for fetal harm.";
                  noHumanStudiesText.InnerText = "";
                  break;
                case "Low*":
                  riskImage.Src = "img/Risk-2.png";
                  riskText.InnerText = "Human studies show low* risk for fetal harm.";
                  noHumanStudiesText.InnerText = "* no human studies";
                  break;
                case "Med":
                  riskImage.Src = "img/Risk-3.png";
                  riskText.InnerText = "Human studies show medium risk for fetal harm. Consult a doctor for guidance before taking this drug while pregnant.";
                  noHumanStudiesText.InnerText = "";
                  break;
                case "Med*":
                  riskImage.Src = "img/Risk-4.png";
                  riskText.InnerText = "Human studies show medium* risk for fetal harm. Consult a doctor for guidance before taking this drug while pregnant.";
                  noHumanStudiesText.InnerText = "* no human studies";
                  break;
                case "High":
                  riskImage.Src = "img/Risk-5.png";
                  riskText.InnerText = "Human studies show high risk for fetal harm. Consult a doctor for guidance before taking this drug while pregnant.";
                  noHumanStudiesText.InnerText = "";
                  break;
                default:
                  riskImage.Src = "img/No-Data.png";
                  break;
              }
              pregnancyUse.InnerText = bsd.pregnancyUse;
              laborDelivery.InnerText = bsd.laborDeliveryUse;
              nursingUse.InnerText = bsd.nursingUse;
              usageText.InnerText = bsd.usage;
              ingredientsText.InnerText = bsd.ingredients;
            }
          }
        }
      }
      else
      {
        Response.Redirect("Home.aspx");
      }
    }
  }
}