﻿using System;
using Renfield.SafeRedir.Data;

namespace Renfield.SafeRedir.Services
{
  public class DbShorteningService : ShorteningService
  {
    public DbShorteningService(Repository repository, UniqueIdGenerator uniqueIdGenerator)
    {
      this.repository = repository;
      this.uniqueIdGenerator = uniqueIdGenerator;
    }

    public string CreateRedirect(string url, string safeUrl, int ttl)
    {
      var urlInfo = new UrlInfo
      {
        OriginalUrl = url,
        SafeUrl = safeUrl,
        ExpiresAt = SystemInfo.SystemClock().AddSeconds(ttl),
      };

      do
      {
        urlInfo.Id = uniqueIdGenerator.Generate();
        if (repository.GetUrlInfo(urlInfo.Id) != null)
          continue;

        try
        {
          repository.AddUrlInfo(urlInfo);
          repository.SaveChanges();
          return urlInfo.Id;
        }
        catch (Exception)
        {
          // get another unique id and try again
        }
      } while (true);
    }

    //

    private readonly Repository repository;
    private readonly UniqueIdGenerator uniqueIdGenerator;
  }
}