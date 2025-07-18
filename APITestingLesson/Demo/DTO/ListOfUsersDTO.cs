using System;
using System.Collections.Generic;

namespace UsersList
{
    public partial class ListOfUsersDTO
    {
        public long Page { get; set; }
        public long PerPage { get; set; }
        public long Total { get; set; }
        public long TotalPages { get; set; }
        public List<Data> Data { get; set; }
        public Support Support { get; set; }
    }

    public partial class Data
    {
        public long id { get; set; }
        public string email { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public Uri avatar { get; set; }
    }

    public partial class Support
    {
        public Uri Url { get; set; }
        public string Text { get; set; }
    }
}
