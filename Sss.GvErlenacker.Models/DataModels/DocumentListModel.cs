using System;
using System.Collections.Generic;
using Sss.GvErlenacker.Models.Poco;

namespace Sss.GvErlenacker.Models.DataModels
{
    public class DocumentListModel
    {
        public DateTime ReleaseDate { get; set; }
        public List<Document> Documents { get; set; }

        public DocumentListModel()
        {
            Documents = new List<Document>();
        }
    }
}
