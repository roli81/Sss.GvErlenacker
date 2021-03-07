﻿using System.Collections.Generic;
using Sss.GvErlenacker.Models.PageModels;
using Sss.GvErlenacker.Models.Poco;
using Umbraco.Core.Models.PublishedContent;

namespace Sss.GvErlenacker.Services
{
    public interface ISearchService
    {
        SearchResultsModel PerformSearch(string query);

    }
}