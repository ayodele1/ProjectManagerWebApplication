
using NUnit.Framework;
using System;
using System.Transactions;

namespace ProjectManager.IntegrationTests
{
    public class RollBackAttribute : Attribute, ITestAction
    {
        private TransactionScope transaction;
        public void AfterTest(NUnit.Framework.Interfaces.ITest test)
        {
            transaction.Dispose();
        }

        public void BeforeTest(NUnit.Framework.Interfaces.ITest test)
        {
            transaction = new TransactionScope();
        }

        public ActionTargets Targets
        {
            get { return ActionTargets.Test; }
        }
    }
}
