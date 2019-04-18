using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sitecore.FakeDb;

namespace Bupa.Sitecore9Starterkit.MainSite.Tests
{
    [TestClass]
    public class HeaderTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            using (var db = new Db("master"))
            {
                var homeItem = new DbItem("Home") { { "Title", "Welcome" } };
                db.Add(homeItem);

                var item = db.GetItem("/sitecore/content/home");
                Assert.AreEqual(item["Title"], "Welcome");
            }
        }
    }
}
