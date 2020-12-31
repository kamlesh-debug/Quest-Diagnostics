using System;
using System.Collections.Generic;
using System.Net.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;
using Moq;
using Quest.Functions;
using Quest.Models;
using Xunit;

namespace QuestDiagnostics.Test.Functions
{
    public class MathMultiplyStatusTests
    {
        [Fact]
        public void Test1()
        {

            var context = new DefaultHttpContext();
            var request = context.Request;
            var dir = new Dictionary<string, StringValues>();
            dir.TryAdd("multiplicand", "10");
            dir.TryAdd("multiplier", "10");
            request.Query = new QueryCollection(dir);
 
            var logger = Mock.Of<ILogger>();
            var mathMultiplyOperationModel=new MathMultiplyOperationModel();
            var response = MathStartMultiply.Run(request,out mathMultiplyOperationModel, logger);

            Assert.IsType<OkObjectResult>(response);
        }
    }
}