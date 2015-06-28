using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BabySafeRx
{
  public partial class Home : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void searchButton_Click(object sender, ImageClickEventArgs e)
    {
      if (inputSearch.Text.Length > 0)
      {
        lblError.Visible = false;
        OpenFda openFda = new OpenFda("https://api.fda.gov/drug/label.json");  // Simple IoC example.

        // Perform the search on OpenFDA...
        List<BabySafeRxData> babySafeList = openFda.callAPI(inputSearch.Text);
        if (babySafeList.Count == 0)
        {
          lblError.Text = inputSearch.Text + " was not found";
          lblError.Visible = true;
        }
        else
        {
          Session["babySafeData"] = babySafeList;
          Response.Redirect("drug-search.aspx?search=" + inputSearch.Text);
        }
      }
    }
  }
}