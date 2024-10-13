using IBDA_automationTests.Framework.User;
using Microsoft.VisualStudio.TestPlatform.Common.Utilities;
using Newtonsoft.Json;
using NUnit.Framework;
using System.IO;

namespace IBDA_automationTests.Tests;


[TestFixture]
public class OneTimeSetup
{
    private Users users;
    protected User operatorIBDA;
    protected User kierownikLAB;
    protected User OpiekunIBDA;
    protected User PracownikBWG;
    protected User PracownikSAP;
    protected User PracownikCBIBDA;
    protected User koordynatorWydz;
    protected User tesKierownikDP;
    
    [OneTimeSetUp]
    public void GlobalSetup()
    {
        try
        {
            string config = File.ReadAllText("../../../config.json");
            users = JsonConvert.DeserializeObject<Users>(config);
        }
        catch (Exception e)
        {
            Assert.Fail($"Config init error : {e.Message}");
        }

        operatorIBDA = users.test_operatorIBDA;
        kierownikLAB = users.test_kierownikLAB;
        OpiekunIBDA = users.test_OpiekunIBDA;
        PracownikBWG = users.test_PracownikBWG;
        PracownikSAP = users.test_PracownikSAP;
        PracownikCBIBDA = users.test_PracownikCBIBDA;
        koordynatorWydz = users.test_koordynatorWydz;
        tesKierownikDP = users.test_KierownikDP;
        
    }
    
}