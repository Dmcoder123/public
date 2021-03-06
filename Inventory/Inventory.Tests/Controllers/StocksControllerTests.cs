﻿using System.Collections.Generic;
using System.Web.Mvc;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Renfield.Inventory.Controllers;
using Renfield.Inventory.Models;
using Renfield.Inventory.Services;

namespace Renfield.Inventory.Tests.Controllers
{
  [TestClass]
  public class StocksControllerTests
  {
    private Mock<Logic> logic;
    private StocksController sut;

    [TestInitialize]
    public void SetUp()
    {
      logic = new Mock<Logic>();
      sut = new StocksController(logic.Object);
    }

    [TestMethod]
    public void IndexReturnsViewWithNoModel()
    {
      var result = sut.Index() as ViewResult;

      result.Should().NotBeNull();
    }

    [TestMethod]
    public void GetStocksReturnsDataFromServiceAsJson()
    {
      var list = new List<StockModel>();
      logic
        .Setup(it => it.GetStocks())
        .Returns(list);

      var result = sut.GetStocks() as JsonResult;

      result.Data.As<List<StockModel>>().ShouldBeEquivalentTo(list);
    }
  }
}