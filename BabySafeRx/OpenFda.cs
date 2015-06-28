using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using log4net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;

namespace BabySafeRx
{
  public class OpenFda : IOpenFda
  {
    // Inversion of control...
    private string OpenFdaSite;

    private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    
    public OpenFda(string OpenFdaSite)
    {
      this.OpenFdaSite = OpenFdaSite;
    }

    public List<BabySafeRxData> callAPI(string searchText)
    {
      // string returnJson = "";
      List<BabySafeRxData> babySafeList = new List<BabySafeRxData>();
      if (searchText.Length > 0)
      {
        string openFdaApiKey = "?api_key=ovNVdm7TO3IlzJr8ABOS6Zpdad70SNsBV3NW757e";
        string openFdaSearchDrugName = "&search=openfda.brand_name:{search}+openfda.generic_name:{search}";
        string openFdaLimit = "&limit=50";
        searchText = searchText.Replace(" ", "+");
        openFdaSearchDrugName = openFdaSearchDrugName.Replace("{search}", searchText);
        var fdaUrl = this.OpenFdaSite + openFdaApiKey + openFdaLimit + openFdaSearchDrugName;

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
              if (t["spl_product_data_elements"] != null)
              {
                bsrd.ingredients = t["spl_product_data_elements"][0].ToString().ToUpper();
                int endNdx = bsrd.ingredients.IndexOf(';');
                if (endNdx > 0)
                {
                  bsrd.ingredients = bsrd.ingredients.Substring(0, endNdx - 1);
                }
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
                bsrd.pregnancyUse = Regex.Replace(bsrd.pregnancyUse, "\\d.\\d .+?\\. ", "");
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
                bsrd.usage = bsrd.usage.Replace("INDICATIONS AND USAGE: ", "");
                bsrd.usage = bsrd.usage.Replace("1 INDICATIONS AND USAGE", "");

              }
              babySafeList.Add(bsrd);
            }

          }
        }
      }
      return babySafeList;
    }

  }
}