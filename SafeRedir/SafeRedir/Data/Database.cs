﻿using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Renfield.SafeRedir.Data
{
  public class Database : DbContext, Repository
  {
    public DbSet<UrlInfo> UrlInformation { get; set; }

    public Database(string connectionName)
      : base(connectionName)
    {
    }

    public void AddUrlInfo(UrlInfo urlInfo)
    {
      UrlInformation.Add(urlInfo);
    }

    public UrlInfo GetUrlInfo(string id)
    {
      return UrlInformation.FirstOrDefault(it => it.Id == id);
    }

    public IEnumerable<UrlInfo> GetAll()
    {
      return UrlInformation;
    }
  }
}