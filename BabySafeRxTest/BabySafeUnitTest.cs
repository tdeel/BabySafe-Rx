using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BabySafeRx;
using System.Collections.Generic;

namespace BabySafeRxTest
{
  [TestClass]
  public class BabySafeTest
  {
    [TestMethod]
    public void SearchAPI()
    {
      // Execute a test search and ensure results are returned.
      BabySafeRx.OpenFda openFda = new BabySafeRx.OpenFda("https://api.fda.gov/drug/label.json");  // Simple IoC example.

      string searchString = "Topamax";
      List<BabySafeRxData> babySafeData = openFda.callAPI(searchString);
      Assert.IsTrue(babySafeData.Count > 0);
    }
  }
}
