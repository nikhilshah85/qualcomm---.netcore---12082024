namespace HttpClient_call_demo.Models
{
    public class CommentsData
    {
        //declare the properties as per incoming data
        public int postId { get; set; }
        public int Id { get; set; }
        public string name { get; set; }
        public string    email { get; set; }
        public string body { get; set; }

        //decalre a variable to catch the data

        List<CommentsData> data = new List<CommentsData>();


        //lets make a call

        public List<CommentsData> GetComments()
        {
            string url = "https://jsonplaceholder.typicode.com/comments";
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear(); //different calling env will have default data format
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            var call = client.GetAsync(url).Result; //this will return HttpStatusCode and referece to stream of incoming data
                                                    //data will come in chunk / small packets

            if(call.IsSuccessStatusCode) 
            {
                    //lets catch the data
                    var calldata = call.Content.ReadAsAsync<List<CommentsData>>();
                calldata.Wait();
                data = calldata.Result; //to our variable                   
             }
            else
            {
                throw new Exception("Cannot get the data from server, please contact admin");
            }         
            return data;
        }
    }
}
