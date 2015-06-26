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
      if (Request["search"] != null)
      {
        string searchText = (string)Request["search"];
        txtSearch.Text = searchText;
        runSearch(searchText);
      }
    }

    [WebMethod(EnableSession = true)]
    public List<BabySafeRxData> CallAPI(string searchText)
    {
      // string returnJson = "";
      List<BabySafeRxData> babySafeList = new List<BabySafeRxData>();
      if (searchText.Length > 0)
      {
        // string openFdaDrugSite = "https://api.fda.gov/drug/event.json";
        string openFdaLabelSite = "https://api.fda.gov/drug/label.json";
        string openFdaApiKey = "?api_key=ovNVdm7TO3IlzJr8ABOS6Zpdad70SNsBV3NW757e";
        string openFdaSearchDrugName = "&search=openfda.brand_name:{search}+openfda.generic_name:{search}";
        string openFdaLimit = "&limit=50";
        searchText = searchText.Replace(" ", "+");
        openFdaSearchDrugName = openFdaSearchDrugName.Replace("{search}", searchText);
        var fdaUrl = openFdaLabelSite + openFdaApiKey + openFdaLimit + openFdaSearchDrugName;

        WebRequest wrGetUrl;
        wrGetUrl = WebRequest.Create(fdaUrl);

        Stream objStream = null;

        try
        {
          objStream = wrGetUrl.GetResponse().GetResponseStream();
        }
        catch (Exception ex)
        {
          log.Info(ex.Message);
        }
        if (objStream != null)
        {
          StreamReader objReader = new StreamReader(objStream);

          string sLine = "";
          int i = 0;

          System.Text.StringBuilder result = new System.Text.StringBuilder();
          while (sLine != null)
          {
            i++;
            sLine = objReader.ReadLine();
            if (sLine != null)
            {
              result.Append(sLine);
            }
          }

          // Parse the JSON result
          if (result.Length > 0)
          {
            JsonTextReader jtr = new JsonTextReader(new StringReader(result.ToString()));
            // var js = new JsonSerializer();
            JObject x = JObject.Parse(result.ToString());
            // JToken rslt = x["results"];
            IList<JToken> results = x["results"].Children().ToList();
            foreach (JToken t in results)
            {
              BabySafeRxData bsrd = new BabySafeRxData();
              bsrd.brandName = "";
              bsrd.genericName = "";
              bsrd.ingredients = "";
              bsrd.laborDeliveryUse = "";
              bsrd.nursingUse = "";
              bsrd.pregnancyUse = "";
              bsrd.riskLevel = "";
              bsrd.usage = "";
              // bsrd.alternativeDrugs = new List<AlternativeDrugs>();
              string id = t["openfda"]["spl_id"][0].ToString();
              bsrd.splId = id;
              if (t["openfda"]["brand_name"] != null)
              {
                bsrd.brandName = t["openfda"]["brand_name"][0].ToString();
              }
              if (t["openfda"]["generic_name"] != null)
              {
                bsrd.genericName = t["openfda"]["generic_name"][0].ToString();
              }
              if (t["description"] != null)
              {
                bsrd.ingredients = t["description"][0].ToString();
              }
              if (t["labor_and_delivery"] != null)
              {
                bsrd.laborDeliveryUse = t["labor_and_delivery"][0].ToString();
              }
              if (t["nursing_mothers"] != null)
              {
                bsrd.nursingUse = t["nursing_mothers"][0].ToString();
              }
              if (t["pregnancy"] != null)
              {
                bsrd.pregnancyUse = t["pregnancy"][0].ToString();
              }
              bsrd.riskLevel = "Unknown";
              if (t["teratogenic_effects"] != null)
              {
                string teratogenic_effects = t["teratogenic_effects"][0].ToString();
                if (teratogenic_effects.Contains("Pregnancy Category A"))
                {
                  bsrd.riskLevel = "Low";
                }
                else if (teratogenic_effects.Contains("Pregnancy Category B"))
                {
                  bsrd.riskLevel = "Low*";
                }
                else if (teratogenic_effects.Contains("Pregnancy Category C"))
                {
                  bsrd.riskLevel = "Med";
                }
                else if (teratogenic_effects.Contains("Pregnancy Category D"))
                {
                  bsrd.riskLevel = "Med*";
                }
                else if (teratogenic_effects.Contains("Pregnancy Category X"))
                {
                  bsrd.riskLevel = "High*";
                }
              }
              if (t["indications_and_usage"] != null)
              {
                bsrd.usage = t["indications_and_usage"][0].ToString();
              }
              babySafeList.Add(bsrd);
            }

            // returnJson = JsonConvert.SerializeObject(babySafeList);
            HttpContext.Current.Session["babySafeData"] = babySafeList;
          }
        }
      }
      return babySafeList;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
      runSearch(txtSearch.Text);
    }

    private void runSearch(string searchText)
    {
      List<BabySafeRxData> babySafeList = CallAPI(searchText);

      TableHeaderRow thr = new TableHeaderRow();

      // searchTable.Rows.Clear();
      foreach (BabySafeRxData bsrd in babySafeList)
      {
        
        TableRow tr = new TableRow();
        TableCell tc = new TableCell();
        Image im = new Image();
        if (bsrd.riskLevel.Equals("Low"))
        {
          im.ImageUrl = "~/img/Risk-1.png";
        }
        else if (bsrd.riskLevel.Equals("Low*"))
        {
          im.ImageUrl = "~/img/Risk-2.png";
        }
        else if (bsrd.riskLevel.Equals("Med"))
        {
          im.ImageUrl = "~/img/Risk-3.png";
        }
        else if (bsrd.riskLevel.Equals("Med*"))
        {
          im.ImageUrl = "~/img/Risk-4.png";
        }
        else if (bsrd.riskLevel.Equals("High"))
        {
          im.ImageUrl = "~/img/Risk-5.png";
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
  }

  public class BabySafeRxData
  {
    public string splId;
    public string riskLevel;
    public string brandName;
    public string genericName;
    public string usage;
    public string ingredients;
    public string laborDeliveryUse;
    public string nursingUse;
    public string pregnancyUse;
  }
}