//TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

int threshold = Convert.ToInt32(Console.ReadLine().Trim());

List<string> result = Result.getUsernames(threshold);

//textWriter.WriteLine(String.Join("\n", result));

//textWriter.Flush();
//textWriter.Close();


class Result
{

    /*
     * Complete the 'getUsernames' function below.
     *
     * The function is expected to return a STRING_ARRAY.
     * The function accepts INTEGER threshold as parameter.
     * API URL: https://jsonmock.hackerrank.com/api/article_users?page=<pageNumber>
     */
    class  Response
    {
        public IEnumerable<User>? data { get; set; }
        public int total_pages { get; set; }
    }

    public class User
    {
        public int submission_count { get; set; }
        public string? username { get; set; }
    }

    public static  List<string> getUsernames(int threshold)
    {
        using var httpClient = new HttpClient();
        var page = 0;
        List<string> usernames = new();
        bool hasPages;
        do
        {
            page++;
            var apiUrl = $"https://jsonmock.hackerrank.com/api/article_users?page={page}";
            var jsonString =   httpClient.GetAsync(apiUrl);
            var responseJSON = Task.Run(async () => await jsonString.Result.Content.ReadFromJsonAsync<Response>()) ;
           var response  = responseJSON.Result;
            if (response != null)
            {
                var pageUsernames = response.data.Where(x => x.submission_count > threshold).Select(x => x.username);
                hasPages = page < response.total_pages;
                usernames.AddRange(pageUsernames);
            }
            else
            {
                hasPages = false;
            }
           
        } while (hasPages);
       
        return usernames.ToList();
    }

}
