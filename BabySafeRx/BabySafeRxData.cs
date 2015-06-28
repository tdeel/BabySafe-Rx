using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabySafeRx
{
  /// <summary>
  /// BabySafeRxData defines the class used to store and
  /// display OpenFda query results.
  /// </summary>
  public class BabySafeRxData
  {
    private string _splId;
    private string _riskLevel;
    private string _brandName;
    private string _genericName;
    private string _usage;
    private string _ingredients;
    private string _laborDeliveryUse;
    private string _nursingUse;
    private string _pregnancyUse;

    public string splId
    {
      get
      {
        return _splId;
      }
      set
      {
        _splId = value;
      }
    }

    public string riskLevel
    {
      get
      {
        return _riskLevel;
      }
      set
      {
        _riskLevel = value;
      }
    }

    public string brandName
    {
      get
      {
        return _brandName;
      }
      set
      {
        _brandName = value;
      }
    }

    public string genericName
    {
      get
      {
        return _genericName;
      }
      set
      {
        _genericName = value;
      }
    }

    public string usage
    {
      get
      {
        return _usage;
      }
      set
      {
        _usage = value;
      }
    }

    public string ingredients
    {
      get
      {
        return _ingredients;
      }
      set
      {
        _ingredients = value;
      }
    }

    public string laborDeliveryUse
    {
      get
      {
        return _laborDeliveryUse;
      }
      set
      {
        _laborDeliveryUse = value;
      }
    }

    public string nursingUse
    {
      get
      {
        return _nursingUse;
      }
      set
      {
        _nursingUse = value;
      }
    }

    public string pregnancyUse
    {
      get
      {
        return _pregnancyUse;
      }
      set
      {
        _pregnancyUse = value;
      }
    }
  }
}
