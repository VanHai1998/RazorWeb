namespace ASP_RAZORWEB.Helper
{
    public class PagingModels
    {
        public int currentpage { set; get; }
        public int countpages { set; get; }
        public Func<int?, string> generateUrl { set; get; }
    }
}