using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Web.Services;
using log4net;

namespace BabySafeRx
{
  [System.Web.Script.Services.ScriptService]
  public partial class drug_search : System.Web.UI.Page
  {
    private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        if (Request["search"] != null)
        {
          string searchText = (string)Request["search"];
          inputSearch1.Text = searchText;
          runSearch(searchText);
        }
        else
        {
          Response.Redirect("Home.aspx");
        }
      }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
      runSearch(inputSearch1.Text);
    }

    private void runSearch(string searchText)
    {

      if (Session["babySafeData"] == null)
      {
        Response.Redirect("Home.asp"); // Session Timeout
      }
      //OpenFda openFda = new OpenFda("https://api.fda.gov/drug/label.json");  // Simple IoC example.
      
      // Perform the search on OpenFDA...
      List<BabySafeRxData> babySafeList = (List<BabySafeRxData>)Session["babySafeData"];
      // Session["babySafeData"] = babySafeList;

      // Build the table rows and display the results
      TableHeaderRow thr = new TableHeaderRow();

      // searchTable.Rows.Clear();
      foreach (BabySafeRxData bsrd in babySafeList)
      {
        
        TableRow tr = new TableRow();
        TableCell tc = new TableCell();
        Image im = new Image();
        switch (bsrd.riskLevel)
        {
          case "Low":
          im.ImageUrl = "~/img/Risk-1.png";
            break;
          case "Low*":
          im.ImageUrl = "~/img/Risk-2.png";
            break;
          case "Med":
          im.ImageUrl = "~/img/Risk-3.png";
            break;
          case "Med*":
          im.ImageUrl = "~/img/Risk-4.png";
            break;
          case "High":
          im.ImageUrl = "~/img/Risk-5.png";
            break;
          default:
          im.ImageUrl = "~/img/No-Data.png";
            break;
        }
        tc.Controls.Add(im);
        tr.Cells.Add(tc);
        HyperLink l = new HyperLink();
        l.NavigateUrl = "drug-details.aspx?splId=" + bsrd.splId;
        l.Text = bsrd.brandName;
        tc = new TableCell();
        tc.Controls.Add(l);
        // tc.Text = bsrd.brandName;
        tr.Cells.Add(tc);
        tc = new TableCell();
        tc.Text = bsrd.genericName;
        tr.Cells.Add(tc);
        tc = new TableCell();
        if (bsrd.usage.Length > 230)
        {
          tc.Text = bsrd.usage.Substring(0, 230);
        }
        else
        {
          tc.Text = bsrd.usage;
        }
        tr.Cells.Add(tc);
        searchTable.Rows.Add(tr);
        
      }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
    }

    protected void searchButton_Click(object sender, ImageClickEventArgs e)
    {
      if (inputSearch1.Text.Length > 0)
      {
        lblError.Visible = false;
        OpenFda openFda = new OpenFda("https://api.fda.gov/drug/label.json");  // Simple IoC example.

        // Perform the search on OpenFDA...
        List<BabySafeRxData> babySafeList = openFda.callAPI(inputSearch1.Text);
        if (babySafeList.Count == 0)
        {
          lblError.Text = inputSearch1.Text + " was not found";
          lblError.Visible = true;
        }
        else
        {
          Session["babySafeData"] = babySafeList;
          Response.Redirect("drug-search.aspx?search=" + inputSearch1.Text);
        }
      }
    }
  }
}