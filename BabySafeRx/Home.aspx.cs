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
      int a = 0;
      string parameter = Request["__EVENTARGUMENT"]; // parameter
      if (parameter != null)
      {
        if (parameter.Length > 0)
        {
          Response.Redirect("drug-search.aspx?search=" + parameter);
        }
      }
    }
  }
}